using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerProjectileImpact : MonoBehaviour
{
    private float damage = 1, projSpeed = 10f;
    private bool isEnemy;
    EntityStats enemy;
    private Vector2 shootDir;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = transform.root.tag;
    }

    public void Setup(Vector2 direction) {
        shootDir = direction;
    }

    // Update is called once per frame
    void Update()
    {
             // Get the bullet's current position
       // Vector2 position = transform.position;

        // Compute the bullet's new position
        //position = new Vector2(position.x, position.y + projSpeed * Time.deltaTime);

        // Update the bullet's position
        shootDir = new Vector2(shootDir.x, shootDir.y + projSpeed * Time.deltaTime);

        // Update the bullet's position
        transform.position = shootDir;

        // Get the top-right point of the screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        // If the bullet goes outside the screen on the top, destroy it
        if (transform.position.y > max.y)
        {
            Destroy(gameObject);
        }
    }


    // Detect collision
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Enemy")){
            Destroy(gameObject); //inflict damage
            EntityStats enemy = collision.GetComponent<EntityStats>();
            enemy.Hit(damage);
        }
        Destroy(gameObject,5f);
    }
}
