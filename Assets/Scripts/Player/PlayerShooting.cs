using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private BulletSpawner _bulletSpawner;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _prefabWaiting;

    private Coroutine _coroutine;
    private readonly float _delay = 3f;

    private void OnEnable()
    {
        StopShoot();
        _coroutine = StartCoroutine(Shoot());
    }

    private void OnDisable()
    {
        StopShoot();
    }

    private void StopShoot()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            ResetState();
        }
    }

    private void ResetState() => _prefabWaiting.gameObject.SetActive(false);

    private IEnumerator Shoot()
    {
        WaitUntil waitUntil = new(() => Input.GetMouseButtonDown(1));
        WaitForSeconds wait = new(_delay);

        while (enabled)
        {
            yield return waitUntil;

            _bulletSpawner.Shoot(_spawnPoint, Vector2.right, false);

            _prefabWaiting.gameObject.SetActive(true);

            yield return wait;

            _prefabWaiting.gameObject.SetActive(false);
        }
    }
}
