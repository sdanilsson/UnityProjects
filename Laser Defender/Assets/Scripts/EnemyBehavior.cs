using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {
    public float health = 150;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Projectile missile = collision.gameObject.GetComponent<Projectile>();
        if(missile){
            missile.Hit();
            health -= missile.GetDamage();
            if (health <= 0){
                Destroy(gameObject);
            }

        }
    }
}
