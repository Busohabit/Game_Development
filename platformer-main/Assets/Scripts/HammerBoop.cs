using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerBoop : MonoBehaviour
{
    public float boopForce = 10f;

    public bool forwards;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 hitDir = other.transform.position - transform.position;
            hitDir = hitDir.normalized;

            BoopPlayer(other.gameObject, hitDir);
        }
    }

    void BoopPlayer(GameObject player, Vector3 hitDir)
    {
        player.GetComponent<PlayerMovement>().Knockback(new Vector3(0, 1, forwards ? boopForce : -boopForce));
    }


}
