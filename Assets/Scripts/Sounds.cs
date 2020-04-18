using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public static string CHOP_NAME = "Chop";
    public static string BURN_NAME = "Burn";

    public AudioSource chop;
    public AudioSource burn;

    void Start()
    {
        chop = transform.Find(CHOP_NAME).GetComponent<AudioSource>();
        burn = transform.Find(BURN_NAME).GetComponent<AudioSource>();
    }

    public void PlayChop()
    {
        chop.Play();
    }

    public void PlayBurn()
    {
        burn.Play();
    }
}
