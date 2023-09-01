using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityStats : MonoBehaviour
{
    public int health=1, speed=1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void hit(int damage){
        health=health-damage;
        if (health<=0){
            death();
        }
    }

    void death(){
        /*object.Destroy(gameObject); */
    }

    void shoot(){
        
    }

}
