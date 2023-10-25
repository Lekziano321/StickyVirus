using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Normal_Movement : MonoBehaviour
{
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    Vector2 targetPosition;

    public float minSpeed;
    public float maxSpeed;

    private float speed;

    public float secondsToMaxDifficulty;

    

    void Start()
    {
        targetPosition = NormalMove();
    }

    void Update()
    {
        if ((Vector2)transform.position != targetPosition)
        {
            speed = Mathf.Lerp(minSpeed, maxSpeed, GetDifficultyPercent());
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
        else
        {
            targetPosition = NormalMove();
        }
    }

    Vector2 NormalMove()
    {
        float moveX = Random.Range(minX, maxX);
        float moveY = Random.Range(minY, maxY);

        return new Vector2(moveX, moveY);
    }

    

    float GetDifficultyPercent()
    {
        return (Time.timeSinceLevelLoad / secondsToMaxDifficulty);
     }
}
