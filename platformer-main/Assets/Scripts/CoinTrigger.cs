using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTrigger : MonoBehaviour
{
    public AudioSource coinSource;

    private void Awake()
    {
        coinSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            coinSource.Play();
            GameManager.Instance.Score++;
            GetComponent<Collider>().enabled = false;
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
