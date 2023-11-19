using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public GameObject canvas;

    public Slider bar;
    public float progressSpeed;

    private const float INITIAL_PROGRESS_SPEED = 0.01f;

    public bool isActive()
    {
        if(canvas.activeInHierarchy == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void doProgress()
    {
        canvas.SetActive(true);
        bar.enabled = true;
        bar.value = 1;
    }

    public void setProgressSpeed(float newSpeed)
    {
        progressSpeed = newSpeed;
    }
   
    // Start is called before the first frame update
    void Start()
    {
        bar.enabled = false;
        progressSpeed = INITIAL_PROGRESS_SPEED;
    }

    // Update is called once per frame
    void Update()
    {
        bar.value -= progressSpeed;
        if(bar.value <= 0)
        {
            canvas.SetActive(false);
            bar.enabled = false;
        }
    }
}
