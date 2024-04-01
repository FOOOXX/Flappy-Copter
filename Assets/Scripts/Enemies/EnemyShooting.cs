using System.Collections;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] private float _delay = 1.5f;
    [SerializeField] private Transform _spawnPoint;

    private BulletSpawner _bulletSpawner;
    private Coroutine _coroutine;

    private void OnEnable()
    {
        if(_coroutine != null)
            StopCoroutine( _coroutine );

        _coroutine = StartCoroutine(Shoot());
    }

    private void OnDisable()
    {
        if( _coroutine != null )
            StopCoroutine( _coroutine );
    }

    public void Initialize(BulletSpawner bulletSpawner) => _bulletSpawner = bulletSpawner;

    private IEnumerator Shoot()
    {
        WaitForSeconds wait = new(_delay);

        while (enabled)
        {
            yield return wait;

            _bulletSpawner.Shoot(_spawnPoint, Vector2.left, true);
        }
    }
}
