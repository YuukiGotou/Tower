using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_Units : MonoBehaviour
{
    private GameObject empty;
    private GameObject full;
    void Start()
    {
        empty = this.transform.Find("Empty").gameObject;
        full = this.transform.Find("Full").gameObject;
    }
    public void ShowPlace()
    {
        empty.SetActive(true);
        full.SetActive(true);
    }

    public void ErasePlace()
    {
        empty.SetActive(false);
        full.SetActive(false);
    }
}
