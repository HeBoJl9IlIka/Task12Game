using UnityEngine;
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;
using UnityEngine.Events;

public class AdSettings : MonoBehaviour, IRewardedVideoAdListener
{
    private const string AppKey = "9788513d4db24cdf22fbdc2cc5e871fa38f74b803cb8a280";

    public UnityAction<double> VideoFinished;
    public UnityEvent VideoLoaded;

    private void Start()
    {
        int adType = Appodeal.REWARDED_VIDEO;
        Appodeal.initialize(AppKey, adType, true);

        Appodeal.setRewardedVideoCallbacks(this);
    }

    public void ShowRewardedVideo()
    {
        if (Appodeal.canShow(Appodeal.REWARDED_VIDEO, "MyPlacement") && Appodeal.isPrecache(Appodeal.REWARDED_VIDEO) == false)
            Appodeal.show(Appodeal.REWARDED_VIDEO, "MyPlacement");
    }

    public void onRewardedVideoClicked()
    {
    }

    public void onRewardedVideoClosed(bool finished)
    {
    }

    public void onRewardedVideoExpired()
    {
    }

    public void onRewardedVideoFailedToLoad()
    {
    }

    public void onRewardedVideoFinished(double amount, string name)
    {
        VideoFinished?.Invoke(amount);
    }

    public void onRewardedVideoLoaded(bool precache)
    {
        VideoLoaded?.Invoke();
    }

    public void onRewardedVideoShowFailed()
    {
    }

    public void onRewardedVideoShown()
    {
    }
}
