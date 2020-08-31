using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerAttack : MonoBehaviour
{
    private List<GameObject> projectiles;
    private Vector2 projectileDirection;
    public GameObject projectilePrefab, projectile;
    private void Start()
    {
        projectiles = new List<GameObject>();
    }
    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && GetComponent<PlayerData>().electricity >= 10)
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                GetComponent<Animator>().SetBool("isFiring", true);
                int projectileSpeed = 100000;
                projectileDirection = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
                projectile = Instantiate(projectilePrefab, new Vector3(transform.position.x, transform.position.y + 0.1f, 0), Quaternion.identity);
                projectileDirection = projectileDirection.normalized;
                Vector2 projectileVelocity = new Vector2(projectileDirection.x, projectileDirection.y) * projectileSpeed;
                projectile.transform.rotation = Quaternion.Euler(0f, 0f, AngleBetweenTwoPoints(Camera.main.WorldToScreenPoint(transform.position), Input.mousePosition));
                projectile.GetComponent<Rigidbody2D>().AddForce(projectileVelocity * Time.deltaTime);
                projectiles.Add(projectile);
                GetComponent<PlayerData>().electricity -= 10;
            }
        }
        else if(Input.GetMouseButtonDown(1))
        {
            // play melee animation
        }
        else
        {
            GetComponent<Animator>().SetBool("isFiring", false);
        }
        while(projectiles.Count >= 10)
        {
            Destroy(projectiles[0]);
            projectiles.RemoveAt(0);
        }
    }
}
