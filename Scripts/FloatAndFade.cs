using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatAndFade : MonoBehaviour {
    
    public float speed;

    private void Update()
    {
        this.transform.Translate(Vector2.up * Time.deltaTime * speed);
    }
}
