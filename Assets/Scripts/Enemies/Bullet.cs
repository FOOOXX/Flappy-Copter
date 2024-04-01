using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour, IInteractable
{
    private Rigidbody2D _rigidbody;
    private Vector2 _direction;

    public bool IsEnemyBullet { get; private set; }

    private void Awake() => _rigidbody = GetComponent<Rigidbody2D> ();
    private void Update() => Move();
    private void OnTriggerEnter2D(Collider2D collision) => gameObject.SetActive (false);
    public void Initialize(bool isEnemyBullet) => IsEnemyBullet = isEnemyBullet;
    public void SetDirection(Vector2 direction) => _direction = direction;
    private void Move() => _rigidbody.AddForce(_direction, ForceMode2D.Impulse);
}