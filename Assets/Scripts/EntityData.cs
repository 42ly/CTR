using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityData : MonoBehaviour
{
    private int health = 100;

    public void damageEntity(int damage)
    {
        health -= damage;
    }
    public int getHealth()
    {
        return health;
    }
    private void Update()
    {
        if(health <= 0)
        {
            if(this.gameObject.tag == "Enemy")
            {
                Destroy(GetComponent<EnemyData>().detector);
            }
            Destroy(this.gameObject);
        }
    }
}
