using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private BulletSpawner _bulletSpawner;

    public void Activate() => _enemySpawner.ActivateGeneration();

    public void Deactivate()
    {
        _enemySpawner.DeactivateGeneration();
        _bulletSpawner.Deactivate();
    }
}
