using System;
using UnityEngine;

[RequireComponent(typeof(PlayerCollisionHandler))]
[RequireComponent(typeof(PlayerMover))]
public class Player : MonoBehaviour
{
    public event Action GameOver;

    private PlayerCollisionHandler _collisionHandler;
    private PlayerMover _playerMover;

    private void Awake()
    {
        _collisionHandler = GetComponent<PlayerCollisionHandler>();
        _playerMover = GetComponent<PlayerMover>();
    }

    private void OnEnable() => _collisionHandler.CollisionDetected += HandleCollision;
    private void OnDisable() => _collisionHandler.CollisionDetected -= HandleCollision;
    public void Reset() => _playerMover.Reset();

    private void Die()
    {
        GameOver?.Invoke();
        gameObject.SetActive(false);
    }

    private void HandleCollision(IInteractable interactable)
    {
        switch(interactable)
        {
            case Enemy: Die(); 
                break;
            case Ground: Die();
                break;
            case Bullet: Die(); 
                break;
        }
    }
}
