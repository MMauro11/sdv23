using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class EntityStats : MonoBehaviour
{
    public float maxHealth, speed;
    //public GameObject ExplosionAnim;
    [SerializeField] private Transform bullet, shootPos, target; 
    public SliderController healthbar;
    public float fireRate;
    public Rigidbody2D rigidbod;

    // Start is called before the first frame update
    void Start()
    {
        //SliderController healthbar = gameObject.GetComponentInChildren<SliderController>();
        
        healthbar.MaxHealth = maxHealth;
        //rigidbod = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            // Play sound effect
            // GetComponent<AudioSource>().Play();
            if (!target.IsDestroyed()){
                InvokeRepeating(nameof(Shoot), 1f, fireRate);
            }
        }
    }

    public void Hit(float damage){
        healthbar.DecreaseSlider(damage);
        if (healthbar.Score<1){
            Death();
        }
    }

    void Death(){
        GameObject.Destroy(transform.parent.gameObject);

        //GameObject explosion = Instantiate(ExplosionAnim);

             // Set the position of the explosion
       // explosion.transform.position = transform.position;
    }

    void Shoot(){
        //Rotate this entity rigidbody2d
       
        Vector2 lookDir = target.transform.position - shootPos.position;

        //rotate rigidbody on target
        float angle = 0;
        Vector3 relative = transform.InverseTransformPoint(target.position);
        angle = Mathf.Atan2(relative.x, relative.y) * Mathf.Rad2Deg;
        transform.Rotate(0, 0, -angle);

        //istantiate bullet
        Transform proj = Instantiate(bullet, shootPos.position, shootPos.rotation);
        ProjectileImpact projImp = proj.GetComponent<ProjectileImpact>();
        //proj.tag = this.tag;
        if (this.tag == "Player"){
            proj.tag = "PlayerProj";
            projImp.Enemy = "Enemy";
            if (this.tag == "Enemy"){
                proj.tag = "EnemyProj";
                projImp.Enemy = "Player";

            }
        }

        Vector3 direction = lookDir.normalized;
        proj.GetComponent<ProjectileImpact>().Setup(direction);
    }

}
