using System.Collections;
using UnityEngine;

public class EnemySpawner : ObjectPool<Enemy>
{
    [SerializeField] private float _upperBound = 3f;
    [SerializeField] private float _lowerBound = -3f;
    [SerializeField] private float _delay = 3f;
    [SerializeField] private BulletSpawner _bulletSpawner;
    [SerializeField] private Enemy _enemy;

    private Coroutine _coroutine;

    public void DeactivateGeneration()
    {
        StopGenerate();
        Reset();
    }

    public void ActivateGeneration()
    {
        StopGenerate();
        _coroutine = StartCoroutine(Generate());
    }

    private void StopGenerate()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private void SetUpEnemy()
    {
        float spawnPointY = Random.Range(_upperBound, _lowerBound);
        Vector3 spawnPosition = new(transform.position.x, spawnPointY, transform.position.z);

        Enemy enemy = GetObject(_enemy);

        enemy.transform.position = spawnPosition;
        enemy.gameObject.SetActive(true);

        enemy.GetComponent<EnemyShooting>().Initialize(_bulletSpawner);
    }

    private IEnumerator Generate()
    {
        WaitForSeconds wait = new(_delay);

        while(enabled)
        {
            yield return wait;

            SetUpEnemy();
        }
    }
}
