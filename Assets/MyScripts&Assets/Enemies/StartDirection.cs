using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDirection : MonoBehaviour
{
    [SerializeField]
    private Vector2 startdirection;
    // Start is called before the first frame update
    public Vector2 GetStartDirection()
    {
        return startdirection;
    }
}
