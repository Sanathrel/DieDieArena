using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUp : MonoBehaviour {

    public GameObject explosionBattery;
    public static bool gunTwo = false;
    public static bool gunThree = false;
    public static int powerUpCount = 1;

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

            if (powerUpCount == GameController.displayNextUpgrade * 2 && gunThree == false)
            {
                gunThree = true;
                powerUpCount = 1;
            }

            else if (powerUpCount == GameController.displayNextUpgrade && gunTwo == false)
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
