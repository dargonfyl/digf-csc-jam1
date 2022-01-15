using UnityEngine;

public class TestMovement : MonoBehaviour
{
    private float _userHorizontalInput;

    private const float MovementScale = 0.02f;

    private Transform _playerTransform;

    private float _userRotationInput;
    private Vector3 _userRotation;

    // Start is called before the first frame update
    void Start()
    {
        _playerTransform = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        _userHorizontalInput = Input.GetAxis("Vertical");
        _userRotationInput = Input.GetAxis("Horizontal");

        _userRotation = _playerTransform.rotation.eulerAngles;
        _userRotation += new Vector3(0, _userRotationInput, 0);

        _playerTransform.rotation = Quaternion.Euler(_userRotation);
        _playerTransform.position += transform.forward * _userHorizontalInput * MovementScale;
    }
}
