using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    private bool _locked = false;

    private const float _tiltScale = 0.5f;
    private const float _forwardScale = 50f;

    private Rigidbody _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!_locked)
        {
            // forward
            transform.position += _forwardScale * transform.forward * Time.deltaTime;
            // tilting
            transform.Rotate(_tiltScale*Input.GetAxis("Vertical"), 0, -_tiltScale*Input.GetAxis("Horizontal"));
        }
    }

    public void Lock()
    {
        _locked = true;
    }

    public void Unlock()
    {
        _locked = false;
    }

}
