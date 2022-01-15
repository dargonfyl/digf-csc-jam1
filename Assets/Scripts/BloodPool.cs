using System.Collections.Generic;
using UnityEngine;

public class BloodPool : MonoBehaviour
{
    private Dictionary<int, float> _bloodAmounts = new Dictionary<int, float>();

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform childTransform in transform.GetComponentsInChildren<Transform>()) {
            GameObject child = childTransform.gameObject;

            if (child.CompareTag("Target"))
                _bloodAmounts.Add(child.GetInstanceID(), 15.0f); // Might want varying blood amounts
        }

        foreach (int key in _bloodAmounts.Keys)
            Debug.Log(key + " " + _bloodAmounts[key]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float SuckBlood(int targetID, float amount)
    {
        if (_bloodAmounts[targetID] >= amount)
        {
            _bloodAmounts[targetID] = _bloodAmounts[targetID] - amount;
            return amount;
        }
        float remaining = _bloodAmounts[targetID];
        _bloodAmounts[targetID] = 0.0f;
        return remaining;
    }
}
