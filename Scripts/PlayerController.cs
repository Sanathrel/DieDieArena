using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float fireRate;
    public GameObject shot;
    public Transform shotSpawn;

    private float nextFire;
    private Vector3 objectPosition;

    private void Update()
    {
        objectPosition = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(objectPosition.y, objectPosition.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 20, Vector3.forward);

        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }        
    }
}
