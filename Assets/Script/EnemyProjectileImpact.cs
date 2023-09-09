using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyProjectileImpact : MonoBehaviour {

    public float damage, projSpeed;
    private bool isEnemy;
    EntityStats enemy;
    // Start is called before the first frame update
    void Start(){

        gameObject.tag = transform.root.tag;
        GetComponent<Rigidbody2D>().velocity = transform.position*projSpeed;
    }

    public new void Setup(Vector2 direction){
        Vector2 position = direction;
    }

    // Update is called once per frame
    void Update(){

    }


    // Detect collision
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject); //inflict damage
            EntityStats enemy = collision.GetComponent<EntityStats>();
            enemy.Hit(damage);
        }
        Destroy(gameObject, 5f);
    }
}
