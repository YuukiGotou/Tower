using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearChecker : MonoBehaviour
{
    public static bool[] playing;
    static ClearChecker()
    {
        playing = new bool[6];
        playing[0] = true;
        for(int i = 1;i < 6; i++)
        {
            playing[i] = false;
        }
    }
}
