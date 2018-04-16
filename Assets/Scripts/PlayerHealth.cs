using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    private int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public bool dead;

	// Use this for initialization
	void Start () {
        currentHealth = startingHealth;
        Debug.Log(currentHealth);
	}
	
	// Update is called once per frame
	void Update () {
        //check if health is below zero
        if(currentHealth <= 0)
        {
            dead = true;
        }
        //if below zero - then dead;
        if(dead)
        {
            Dead();
        }
	}

    public void ApplyDamage(int amount)
    {
        currentHealth -= amount;
        healthSlider.value = currentHealth;
        //development - to see if amout is set 
        Debug.Log(currentHealth);
    }

    void Dead()
    {
        gameObject.SetActive(false);
    }
}
