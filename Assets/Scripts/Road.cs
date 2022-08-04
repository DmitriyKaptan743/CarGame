using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Road : MonoBehaviour
{
    public int number;

    private void Start()
    {
        GetComponentInChildren<Renderer>().material.color = Random.ColorHSV();
    }
}
