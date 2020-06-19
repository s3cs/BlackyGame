using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantPickup : MonoBehaviour
{




    private void OnTriggerEnter2D(Collider2D cl2d)
    {
        if(cl2d.tag == "Player")
        {
            Destroy(gameObject);
            PC2.plantsPickedUp += 1;
        }
    }
}
