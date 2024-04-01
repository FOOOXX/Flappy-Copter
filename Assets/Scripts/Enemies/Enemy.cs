using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour, IInteractable
{
    private Rigidbody2D _rigidbody;
    private Animator _animator;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

        SetValue(0, true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Bullet bullet) && bullet.IsEnemyBullet == false)
        {
            SetValue(3, false);
        }

        if(collision.TryGetComponent(out Ground bound))
        {
            gameObject.SetActive(false);

            SetValue(0, true);
        }
    }

    private void SetValue(int gravityValue, bool isEnabled)
    {
        _rigidbody.gravityScale = gravityValue;
        _animator.enabled = isEnabled;
    }
}
