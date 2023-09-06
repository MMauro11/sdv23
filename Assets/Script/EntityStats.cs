using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.UIElements;

public class EntityStats : MonoBehaviour
{
    public float health=1, speed=1;
    //public GameObject ExplosionAnim;
    public GameObject bullet;
    public Slider healthbar;
    public float fireRate = 1;


    // Start is called before the first frame update
    void Start()
    {
        Slider healthbar = gameObject.FindGameObjectWithTag("Health");
        healthbar.highValue = health;
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
        healthbar.value=healthbar.value-damage;
        if (healthbar.value<=0){
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
        Vector3 direction = ((target.transform.position)-(proj.transform.position)).normalized;
        proj.GetComponent<PlayerProjectileImpact>().Setup(direction);
    }

}
