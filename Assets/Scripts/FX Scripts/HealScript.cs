using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealScript : MonoBehaviour
{

    public float healAmount = 20f;

    private void Start()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().HealPlayer (healAmount);
    }
}
