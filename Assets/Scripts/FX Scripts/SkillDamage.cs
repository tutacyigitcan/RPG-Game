using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillDamage : MonoBehaviour
{
    public LayerMask enemyLayer;
    public float radius = .5f;
    public float damageCount = 10f;

    private EnemyHealth enemyHealth;
    private bool colided;

    
    void Update()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, radius, enemyLayer);

        foreach(Collider c in hits)
        {
            /* if (c.isTrigger)
                 continue; */
            enemyHealth = c.gameObject.GetComponent<EnemyHealth>();
            colided = true;
        }
        if(colided)
        {
            enemyHealth.TakeDamage(damageCount);
            enabled = false;
        }

    }
}
