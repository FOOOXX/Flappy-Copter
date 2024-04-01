using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private Transform _container;

    private List<T> _pool;

    private void Awake() => _pool = new();

    protected void Reset()
    {
        foreach (var pool in _pool)
        {
            pool.gameObject.SetActive(false);
        }
    }

    protected T GetObject(T spawnPrefab)
    {
        var result = _pool.FirstOrDefault(item => item.gameObject.activeSelf == false);

        if(result == null)
        {
            result = Instantiate(spawnPrefab, _container);
            _pool.Add(result);
        }

        result.gameObject.SetActive(false);

        return result;
    }
}
