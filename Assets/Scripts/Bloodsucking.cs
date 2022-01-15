using UnityEngine;
using System.Collections.Generic;


public class Bloodsucking : MonoBehaviour
{
    // Amount of blood needed, in seconds
    private float _blood;
    private const float MaxBlood = 50.0f;

    private bool _isColliding;
    private GameObject _currentTarget = null;

    public BloodPool bloodPool;
    private static bool _SuckingBlood = false;

    private const float escapeTime = 1.5f; // Grace period before sticking onto another 
    private float _currentEscapeTime = 0.0f;

    public Fly movement;

    // Start is called before the first frame update
    void Start()
    {
        _blood = 0;
        _isColliding = false;
    }

    // Update is called once per frame
    void Update()
    {
        float dt = Time.deltaTime;

        if (Input.GetButtonDown("Fire1"))
        {
            _SuckingBlood = true;
        }

        _currentEscapeTime = _currentEscapeTime >= dt ? _currentEscapeTime - dt : 0.0f;

        if (_isColliding)
        {
            if (_SuckingBlood)
            {
                _blood += bloodPool.SuckBlood(_currentTarget.GetInstanceID(), dt);
                Debug.Log(_blood);
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                // Remove the collision and prevent sticking for a while
                _isColliding = false;
                _currentTarget = null;
                Destroy(GetComponent<FixedJoint>());
                _currentEscapeTime = escapeTime;
                movement.Unlock();
            }
        }

        if (Input.GetButtonUp("Fire1"))
        {
            _SuckingBlood = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Target"))
        {
            if (_currentEscapeTime == 0.0) // Only attach if not in escape
            {
                // Enable Bloodsucking
                _isColliding = true;
                _currentTarget = other.gameObject;

                // Stick to the object
                FixedJoint joint = transform.gameObject.AddComponent<FixedJoint>();
                joint.connectedBody = other.rigidbody;
                movement.Lock(); // Disable movement so vibrations don't happen
            }
        }
    }

    public float GetBloodFill()
    {
        return _blood / MaxBlood;
    }

    public bool Victory()
    {
        return _blood - MaxBlood < 0.001;
    }
}
