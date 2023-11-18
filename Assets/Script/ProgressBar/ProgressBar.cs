using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Slider bar;
    public float progressSpeed;

    // Start is called before the first frame update
    void Start()
    {
        bar.enabled = false;
        bar.value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        bar.enabled = true;
        bar.value -= progressSpeed;
    }
}
