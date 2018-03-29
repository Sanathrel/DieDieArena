using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverEnemy : MonoBehaviour {

    public float duration;
    public float durationDecrease;

    private SpriteRenderer sr;
    private Vector2 endPoint = new Vector2(0.0f, 0.0f);
    private Vector2 startPoint;
    private static int level;
    private float startTime; 

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();        

        startPoint = transform.position;

        if (startPoint.x > 0)
        {
            sr.flipX = true;
        }

        startTime = Time.time;                        
    }

    private void Update()
    {
        transform.position = Vector2.Lerp(startPoint, endPoint, (Time.time - startTime) / (duration - GameController.levelCount * durationDecrease));
    }
}
