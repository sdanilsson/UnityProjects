using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float health = 150;
    public float projectileSpeed;
    public GameObject projectile;


    void Update(){
        Vector3 startPosition = transform.position + new Vector3(0, -1, 0);
        GameObject missile =  Instantiate<GameObject>(projectile, startPosition, Quaternion.identity);
        missile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Projectile missile = collision.gameObject.GetComponent<Projectile>();
        if (missile)
        {
            missile.Hit();
            health -= missile.GetDamage();
            if (health <= 0)
            {
                Destroy(gameObject);
            }

        }
    }
}
