using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Bloodsucking blood;

    // Update is called once per frame
    void Update()
    {
        Slider slider = GetComponent<Slider>();
        slider.value = blood.GetBloodFill();
    }
}
