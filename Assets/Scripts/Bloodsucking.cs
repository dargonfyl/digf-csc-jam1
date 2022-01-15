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

    // Start is called before the first frame update
    void Start()
    {
        _blood = 0;
        _isColliding = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _SuckingBlood = true;
        }

        if (_isColliding)
        {
            float dt = Time.deltaTime;

            if (_SuckingBlood)
            {
                _blood += bloodPool.SuckBlood(_currentTarget.GetInstanceID(), dt);
                Debug.Log(_blood);
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            _SuckingBlood = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Target"))
        {
            // Enable Bloodsucking
            _isColliding = true;
            _currentTarget = other.gameObject;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Target"))
        {
            // Disable Bloodsucking
            _isColliding = false;
            _currentTarget = null;
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
