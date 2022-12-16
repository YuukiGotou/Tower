using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderUI : MonoBehaviour
{
    public void SetMaxValue(float value)
    {
        GetComponent<Slider>().maxValue = value;
        GetComponent<Slider>().value = value;
    }
    public void ValueSet(float value)
    {
        this.GetComponent<Slider>().value = value;
    }
}
