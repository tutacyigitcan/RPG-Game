using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryPointer : MonoBehaviour
{

    private Transform player;
    

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    
    }

    
    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= 1.1f)
        {
            Destroy(gameObject);
        }
    }
}//class






























