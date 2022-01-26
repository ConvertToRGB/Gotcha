using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    GameObject runner;
    float elapsedTime;
    float counter = 1f;

    // Start is called before the first frame update
    void Start()
    {
        CreateRunner();
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.time;
        Debug.Log("Current Elapsed Time: " + elapsedTime);
        CreateRunnerInUpdate();
        Debug.Log(Math.Round(elapsedTime/100, 0));

    }

    private void CreateRunner()
    {
        Vector3 pos = GetSpriteStartingPosition();
        GameObject runnerObject = Instantiate(runner, pos, Quaternion.identity);
    }

    private void CreateRunnerInUpdate()
    {
        float whenToStart = Mathf.Round(elapsedTime / 100);
        double remain = Math.Round(elapsedTime / 100, 0) - Convert.ToDouble((100f*counter));
        Debug.Log("REMAIN: " + remain + "ELAPSED TIME: " + elapsedTime);
        
        if (whenToStart > 5f)
        {
            if (remain > 0f)
            {
                counter += 1f;
                CreateRunner();
                elapsedTime = 0f;
                //StartCoroutine(CrtRunner());
                Debug.Log("ELAPSED TIME: " + elapsedTime);
                Debug.Log("Остаток: " + remain);
            }
            
        }
    }

    IEnumerator CrtRunner()
    {
        CreateRunner();
        yield return new WaitForSeconds(5000f);
    }

    public Vector3 GetSpriteStartingPosition()
    {
        Vector3 pos = new Vector3(0, -5, 0);
        return pos;
    }
}
