using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    private const float _tiltScale = 0.5f;
    private const float _forwardScale = 0.25f;
    private Vector3 _eulerRotate;

    //private float _forwardInput;
    //private float _rotationInput;
    //private Vector3 _userRot;

    private Rigidbody _rigidbody;
    private Transform _transform;

    // Start is called before the first frame update
    void Start()
    {
        _transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        _transform.position += _forwardScale * _transform.forward * Time.deltaTime * Input.GetAxis("Vertical");

       _transform.Rotate(_tiltScale*Input.GetAxis("Vertical"), 0, -_tiltScale*Input.GetAxis("Horizontal"));

        // NEW
        //_eulerRotate = _transform.rotation.eulerAngles;
        //_eulerRotate += new Vector3(0, Input.GetAxis("Horizontal"), 0);
        //_transform.rotation = Quaternion.Euler(_eulerRotate);

        //_transform.Rotate(_tiltScale * Input.GetAxis("TiltVertical"), 0, -_tiltScale * Input.GetAxis("TiltHorizontal"));

        // avoid go below the terrrain
        float currAltitude = Terrain.activeTerrain.SampleHeight(_transform.position);
        if (currAltitude > _transform.position.y)
        {
            _transform.position = new Vector3(_transform.position.x,
                currAltitude,
                _transform.position.z);
        }
        //_transform.position += new Vector3(
        //    _transform.forward.x * Input.GetAxis("Vertical") * _forwardScale,
        //    _transform.forward.y * Input.GetAxis("TiltVertical") * _forwardScale,
        //    _transform.forward.z * Input.GetAxis("Vertical") * _forwardScale);
    }
}
