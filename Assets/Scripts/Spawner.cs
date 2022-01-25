using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    GameObject runner;

    // Start is called before the first frame update
    void Start()
    {
        CreateRunner();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreateRunner()
    {
        Vector3 pos = new Vector3(0, -5, 0);
        GameObject runnerObject = Instantiate(runner, pos, Quaternion.identity);
    }
}
