using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderValueText : MonoBehaviour
{
    public void onSliderChange(float value)
    {
        this.GetComponent<UnityEngine.UI.Text>().text = value.ToString("0.0");
    }
}
