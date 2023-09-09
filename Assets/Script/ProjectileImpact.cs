using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ProjectileImpact : MonoBehaviour
{
    public float damage, projSpeed;
    string enemy;
    private Vector3 shootDir;
    Rigidbody2D rigidbod;

    public float getDamage(){
            return this.damage;
    }

    public string Enemy
    {
        get
        {
            return this.enemy;
        }
        set
        {
            this.enemy = value;
        }
    }

    void Start()
    {
        if (gameObject.tag == "PlayerProj"){
            enemy = "Enemy";
        }
        if (gameObject.tag == "EnemyProj"){
            enemy = "Player";
        }

        //destroy after some inactivity seconds
        Destroy(gameObject,7f);
    }

    public void Setup(Vector3 shootDir) {
        this.shootDir = shootDir;

        rigidbod = GetComponent<Rigidbody2D>();
        rigidbod.velocity = shootDir * projSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        // Get the top-right point of the screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        // If the bullet goes outside the screen on the top, destroy it
        if (transform.position.y > max.y)
        {
            Destroy(gameObject);
        }
     */
    }


    // Detect collision
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag(enemy)){
            Destroy(gameObject);
            //inflict damage
            EntityStats enemy = collision.GetComponent<EntityStats>();
            enemy.Hit(damage);
        }
    }
}
