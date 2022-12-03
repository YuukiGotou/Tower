using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderUI : CharacterMover
{
    public void StartUP(float speed)
    {

    }
    protected override void Update()
    {
        base.Update();
        this.GetComponent<Slider>().value = speed;
    }
}
