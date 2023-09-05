using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class EntityStats : MonoBehaviour
{
    public float health=1, speed=1;
    //public GameObject ExplosionAnim;
    public GameObject bullet;
    public float fireRate = 1;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

                // Play sound effect
           // GetComponent<AudioSource>().Play();

            InvokeRepeating(nameof(Shoot), 1f, fireRate);
        }
    }

    public void Hit(float damage){
        health=health-damage;
        if (health<=0){
            Death();
        }
    }

    void Death(){
        GameObject.Destroy(gameObject);

        //GameObject explosion = Instantiate(ExplosionAnim);

             // Set the position of the explosion
       // explosion.transform.position = transform.position;
    }

    void Shoot(){
        GameObject target = GameObject.FindGameObjectWithTag("Enemy");
        GameObject proj = Instantiate(bullet, transform.position,transform.rotation);
        Vector2 direction = (target.transform.position - transform.position).normalized;
        proj.GetComponent<PlayerProjectileImpact>().Setup(direction);
    }

}
