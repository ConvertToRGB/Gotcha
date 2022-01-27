using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    GameObject runner;
    float elapsedTime;
    int counter = 1;
    [SerializeField]
    float delay = 3f;
    [SerializeField]
    float spawnSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        CreateRunner();
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        Debug.Log(Math.Round(elapsedTime));
        CreateRunnerInUpdate();
    }

    private void CreateRunner()
    {
        Vector3 pos = GetSpriteStartingPosition();
        GameObject runnerObject = Instantiate(runner, pos, Quaternion.identity);
    }

    private void CreateRunnerInUpdate()
    {
        float elapsedTimeRound = Mathf.Round(elapsedTime);
        float remain = (float)Math.Round(elapsedTimeRound - (delay * (counter*spawnSpeed)));
        
        if (remain > 0)
        {
            counter += 1;
            CreateRunner();
            elapsedTime = 0f;
        }
    }

    public Vector3 GetSpriteStartingPosition()
    {
        Vector3 pos = new Vector3(0, -5, 0);
        return pos;
    }
}
