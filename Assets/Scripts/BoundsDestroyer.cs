using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsDestroyer : MonoBehaviour {

	void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            return;
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}
