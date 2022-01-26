using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{
    float speed = 5f;
    float rotSpeed = 1f;
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
            randomPosition =  new Vector3(Random.Range(-1.6f, 1.7f), Random.Range(-4f, 3f), 0);
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
        //if (Vector3.Distance(transform.position, targetPos) < 0.3f)
        if (transform.position != targetPos)
        {
            elapsedTime += Time.deltaTime * speed;
            float percentageComplete = elapsedTime / desiredDuration;
            transform.position = Vector3.Lerp(startPos, targetPos, percentageComplete);
            LookAt2D(targetPos);
        }
        else
        {
            inProcess = false;
            elapsedTime = 0f;
        }

    }

    private void LookAt2D(Vector3 target)
    {
        Vector3 targetDirection = transform.position - target;
        float angle = (Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg)+90;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}

