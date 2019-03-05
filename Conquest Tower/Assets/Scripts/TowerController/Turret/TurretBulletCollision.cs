using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBulletCollision : MonoBehaviour
{

    float health;
    float damage = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnCollisionEnter(Collision collision)
    {

        //Hits ground etc.
        if(collision.gameObject.tag == "Untagged")
        {
            Destroy(this.gameObject);
        }
       
        //Hits Enemy
        if (collision.gameObject.tag == "Ground")
        {
            health = collision.gameObject.GetComponent<NpcStats>().health;
            float hp = health - damage;
            collision.gameObject.GetComponentInChildren<TextMesh>().text = "" + hp;
            collision.gameObject.GetComponent<NpcStats>().health = hp;
            Destroy(this.gameObject);

            if(collision.gameObject.GetComponent<NpcStats>().health <= 0)
            {
                Destroy(collision.gameObject);
            }
        }
        
    }
    
}
