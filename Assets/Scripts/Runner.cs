using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{
    float speed = 1f;
    float firstRunSpeed = 3f;
    bool firstRun = true;
    bool inProcess = false;
    float elapsedTime = 0f;
    float desiredDuration = 5f;
    Vector3 startPosition;
    Vector3 randomPosition;
    Vector3 endPosition = new Vector3(0, 0, 0);
    [SerializeField]
    private AnimationCurve curve;

    private void Start()
    {
        startPosition = FindObjectOfType<Spawner>().GetSpriteStartingPosition();
        Debug.Log("Start Position: " + startPosition);
    }
    
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
        Debug.Log("Process Status: " + inProcess);
    }

    private void Run()
    {
        SetRandomPosition();
        SetStartingPosition();
        Move(startPosition, randomPosition);
//        StartCoroutine(MoveCrt());
//        transform.position += transform.up * (Time.deltaTime * speed);
    }

    private void FirstRun()
    {
        elapsedTime += Time.deltaTime*firstRunSpeed;
        float percentageComplete = elapsedTime / desiredDuration;
        if (transform.position.y < -1)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, curve.Evaluate(percentageComplete));
        }
        else
        {
            firstRun = false;
            startPosition = transform.position;
            elapsedTime = 0f;
        }
    }

    private void SetRandomPosition()
    {
        if (!inProcess)
        {
            randomPosition =  new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f), 0);
        }
    }
    private void SetStartingPosition()
    {
        if (!inProcess)
        {
            startPosition = transform.position;
        }
    }

    private void Move(Vector3 startPos, Vector3 targetPos)
    {
        inProcess = true;
        if (transform.position != targetPos)
        {
            elapsedTime += Time.deltaTime * speed;
            float percentageComplete = elapsedTime / desiredDuration;
            transform.position = Vector3.Lerp(startPos, targetPos, percentageComplete);
        }
        else
        {
            inProcess = false;
        }

    }
}

