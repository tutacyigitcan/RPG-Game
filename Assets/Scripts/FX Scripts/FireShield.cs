using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireShield : MonoBehaviour
{
    private PlayerHealth playerHealth;

    private void Awake()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }
    private void OnEnable()
    {
        playerHealth.Shielded = true;
        Debug.Log("Player is shilded");
    }

    private void OnDisable()
    {
        playerHealth.Shielded = false;
        Debug.Log("Player is NOT shilded");
    }

}
