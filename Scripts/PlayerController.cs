using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject shot;
    public Transform shotSpawn_1;
    public Transform shotSpawn_2;
    public Transform shotSpawn_3;
    public Sprite twoGunSprite;
    public Sprite threeGunSprite;
    public static float displaySpeed;
    public float fireRate;
    public float fireRateIncrease;

    private SpriteRenderer sr;
    private Vector3 objectPosition;
    private float nextFire;
    private float angle;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        objectPosition = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        angle = Mathf.Atan2(objectPosition.y, objectPosition.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(angle - 20, Vector3.forward);        

        if (PowerUp.gunThree)
        {
            sr.sprite = threeGunSprite;
        }

        else if (PowerUp.gunTwo)
        {
            sr.sprite = twoGunSprite;
        }

        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + (fireRate - PowerUp.powerUpCount * fireRateIncrease);

            Instantiate(shot, shotSpawn_1.position, shotSpawn_1.rotation);
            
            if (PowerUp.gunTwo)
            {
                Instantiate(shot, shotSpawn_2.position, shotSpawn_2.rotation);
            }

            if (PowerUp.gunThree)
            {
                Instantiate(shot, shotSpawn_3.position, shotSpawn_3.rotation);
            }
        }

        if (displaySpeed <= 100)
        {
            displaySpeed = (PowerUp.powerUpCount * fireRateIncrease - fireRateIncrease) * 200;
        }        
    }
}
