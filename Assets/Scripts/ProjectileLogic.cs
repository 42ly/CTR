using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLogic : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EntityData>().damageEntity(GameObject.Find("GameManager").GetComponent<LevelData>().playerInstance.GetComponent<PlayerData>().damage);
            Destroy(this.gameObject);
        }
        else if(other.gameObject.tag != "Player" && other.gameObject.tag != "Detection")
        {
            Destroy(this.gameObject);
        }
    }
}
