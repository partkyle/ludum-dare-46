using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overlay : MonoBehaviour
{
    public static string LOOKUP_NAME = "Overlay";

    GameObject overlay;

    private void Start()
    {
       overlay = transform.Find(LOOKUP_NAME).gameObject;
    }

    public void Activate()
    {
        overlay.SetActive(true);
    }

    public void Deactivate()
    {
        overlay.SetActive(false);
    }
}
