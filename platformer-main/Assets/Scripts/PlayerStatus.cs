using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



//when player touches enemy body they 'die'/respawn
public class PlayerStatus : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Body")) 
        {
            Die();
        }
    }

    //method that makes the player reset
    void Die()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<PlayerMovement>().enabled = false;
        //reloads level a bit later than 1 second.
        Invoke(nameof(ReloadLevel), 1.3f);
    }

    void ReloadLevel()
    {
        //Respawns player to beginnning of level
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
