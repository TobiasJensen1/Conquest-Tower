using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CannonBulletCollision : MonoBehaviour
{

    float health;
    public float damage = 5f;

    public GameObject Explosion;



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
            //Destroy(this.gameObject);
            this.gameObject.GetComponent<SphereCollider>().enabled = false;
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            Destroy(this.gameObject, 10);
        }
       
        //Hits Enemy
        if (collision.gameObject.tag == "Ground")
        {

            float random = Random.Range(0, 20);

            if (random == 5)
            {
                GetComponent<AudioSource>().Play();
                Instantiate(Explosion, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            }


            health = collision.gameObject.GetComponent<NpcStats>().health;
            float hp = health - damage;
            collision.gameObject.GetComponentInChildren<TextMesh>().text = "" + hp;
            collision.gameObject.GetComponent<NpcStats>().health = hp;

            this.gameObject.GetComponent<SphereCollider>().enabled = false;
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            Destroy(this.gameObject,10);

            if(collision.gameObject.GetComponent<NpcStats>().health <= 0)
            {
                
                collision.gameObject.GetComponent<Animation>().Play("death1");
                collision.gameObject.GetComponent<NavMeshAgent>().speed = 0;
                


               
                
                    collision.gameObject.GetComponent<NpcStats>().health = 0;
                collision.gameObject.tag = "End";

                Destroy(collision.gameObject,2);

                //Destroy(collision.gameObject);
            }
        }

        Destroy(this.gameObject, 5);

        
        
    }
    
}
