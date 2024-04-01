using UnityEngine;

public class BulletSpawner : ObjectPool<Bullet>
{
    [SerializeField] private Bullet _bullet;

    public void Deactivate() => Reset();

    public void Shoot(Transform spawnPoint, Vector2 direction, bool isEnemyBullet)
    {
        Bullet bullet = GetObject(_bullet);

        bullet.Initialize(isEnemyBullet);
        bullet.SetDirection(direction);
        bullet.transform.position = spawnPoint.position;
        bullet.gameObject.SetActive(true);
    }
}
