using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {
    
    public GameObject explosion;
    public GameObject explosionPlayer;
    public GameObject popUp;
    public int scoreValue;

    private GameController gameController;
    private GameObject[] hazardOnScreen;

    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");

        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    { 
        if (other.gameObject.CompareTag("Boundary"))
        {
            return;
        }

        else if (other.gameObject.CompareTag("Bolt"))
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Instantiate(popUp, transform.position, transform.rotation);
            gameController.AddScore(scoreValue);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        else if (other.gameObject.CompareTag("Player"))
        {
            hazardOnScreen = GameObject.FindGameObjectsWithTag("Enemy");

            for (int i = 0; i < hazardOnScreen.Length; i++)
            {
                Instantiate(explosion, hazardOnScreen[i].transform.position, hazardOnScreen[i].transform.rotation);
                Destroy(hazardOnScreen[i]);
            }

            Instantiate(explosionPlayer, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
            gameController.GameOver();
        }              
    }
}
