using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpAndDown : MonoBehaviour {

    public float MoveRange;
    public float MoveSpeed;    

    private Vector2 startPosition;

    private void Start()
    {        
        startPosition = transform.position;
    }

    private void Update()
    {
        transform.position = startPosition + Vector2.up * (MoveRange * Mathf.Sin(Time.timeSinceLevelLoad * MoveSpeed));
    }
}
