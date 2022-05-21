using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnItems : MonoBehaviour
{
    [SerializeField] private Transform _spawner;
    [SerializeField] private Transform _pool;

    private List<Transform> _points;
    private Transform[] _items;

    private void Start()
    {
        AddItemsInPool();
        AddPointsInSpawner();

        foreach (var item in _items)
        {
            if (_points.Count > 0)
            {
                int currentPoint = Random.Range(0, _points.Count);
                item.transform.position = _points[currentPoint].transform.position;

                _points.RemoveAt(currentPoint);
            }
        }
    }

    private void AddItemsInPool()
    {
        _items = new Transform[_pool.childCount];
        for (int i = 0; i < _pool.childCount; i++)
        {
            _items[i] = _pool.GetChild(i);
        }
    }

    private void AddPointsInSpawner()
    {
        _points = new List<Transform>();
        for (int i = 0; i < _spawner.childCount; i++)
        {
            _points.Add(_spawner.GetChild(i));
        }
    }
}
