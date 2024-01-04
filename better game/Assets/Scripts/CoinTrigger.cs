using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Checks if the object that enters the trigger is the player
        if (other.CompareTag("Player"))
        {
            //If the object is the player we increment the score by 1 and then delete the coin GO
            GameManager.Instance.Score++;
            Destroy(gameObject);
        }
    }
}
