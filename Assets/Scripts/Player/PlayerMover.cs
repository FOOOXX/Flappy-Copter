using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _tapForce;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _minRotationZ;
    [SerializeField] private float _maxRotationZ;

    private Rigidbody2D _rigidbody;
    private Vector3 _startPosition;
    private Quaternion _minRotation;
    private Quaternion _maxRotation;

    private void Start()
    {
        _startPosition = transform.position;

        _rigidbody = GetComponent<Rigidbody2D>();
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.velocity = new Vector2(_speed, _tapForce);
            transform.rotation = _maxRotation;
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }

    public void Reset()
    {
        gameObject.SetActive(true);
        transform.SetPositionAndRotation(_startPosition, Quaternion.identity);
        _rigidbody.velocity = Vector2.zero;
    }
}