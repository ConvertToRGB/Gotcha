using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{
    float speed = 1f;
    float firstRunSpeed = 2f;
    bool firstRun = true;

    // Update is called once per frame
    void Update()
    {
        if (firstRun)
        {
            FirstRun();
            
        }
        else
        {
            Run();
        }
    }
    private void Run()
    {
        transform.position += transform.up * (Time.deltaTime * speed);
    }

    private void FirstRun()
    {
        if (transform.position.y < 0)
        {
            transform.position += transform.up * (Time.deltaTime * firstRunSpeed);
        }
        else
        {
            firstRun = false;
        }
    }
}

