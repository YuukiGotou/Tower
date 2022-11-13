using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class BlackGhost : Enemies
{
    protected override void Start()
    {
        base.Start();
        HP = 10;
        speed = 60;
        flying = false;
        mistbody = true;
    }
}
