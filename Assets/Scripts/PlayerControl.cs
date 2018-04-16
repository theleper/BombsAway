using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Bounds
{
    public float minX, maxX;
}



public class PlayerControl : MonoBehaviour {
    public float speed = 10f;
    private Rigidbody2D rb2d;
    public Bounds bounds;
    public GameObject bullet;
    public Transform shotSpawn;
    public float nextFire;
    public float fireRate;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        //movemt on the X axis
        float moveH = Input.GetAxis("Horizontal");
        rb2d.velocity = Vector2.right * speed * moveH;
        Vector2 position = rb2d.position;

        //sets the bounds 
        rb2d.position = new Vector2(Mathf.Clamp(rb2d.position.x, bounds.minX, bounds.maxX), rb2d.position.y);

        //shooting bullets
        if (Input.GetButton("Fire1") && Time.time >= nextFire)
        {
            nextFire = Time.time + fireRate;
            Shoot();
        }
       
	}

    void Shoot()
    {
        Instantiate(bullet, shotSpawn.position,shotSpawn.rotation);
    }
}
