using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour {
    public float speed;
    Rigidbody2D rb2d;
    private int scoreValue = 1;
    public int damage = 10;
    private GameController gameController;
    private GameObject player;
    private PlayerHealth playerHealth;
	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        if(gameControllerObject !=null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if(gameControllerObject == null)
        {
            Debug.Log("NO game controller object");
        }
	}
	
	// Update is called once per frame
	void Update () {
        rb2d.velocity = -transform.up * speed;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            Destroy(gameObject);
            gameController.AddScore(scoreValue);
        }
        else if(collision.tag == "Player")
        {
            playerHealth.ApplyDamage(damage);
            Destroy(gameObject);
        }
    }

}
