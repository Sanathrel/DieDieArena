using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUp : MonoBehaviour {

    public GameObject explosionBattery;
    public static bool gunTwo = false;
    public static bool gunThree = false;
    public static int powerUpCount = 1;
    public static int displayNextUpgrade;
    public int nextUpgrade;
    

    private void Start()
    {
        displayNextUpgrade = nextUpgrade;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Boundary"))
        {
            return;
        }

        else if (other.gameObject.CompareTag("Bolt"))
        {
            Instantiate(explosionBattery, transform.position, transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);

            if (powerUpCount == nextUpgrade * 2 && gunThree == false)
            {
                gunThree = true;
                powerUpCount = 1;
            }

            else if (powerUpCount == nextUpgrade && gunTwo == false)
            {
                gunTwo = true;
                powerUpCount = 1;
            }

            else
            {
                powerUpCount++;                
            }
        }
    }
}
