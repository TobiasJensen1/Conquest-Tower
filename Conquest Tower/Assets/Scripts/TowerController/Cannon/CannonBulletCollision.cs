using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CannonBulletCollision : MonoBehaviour
{

    float health;
    public float damage = 1f;

    public GameObject Coins;

    public GameObject Explosion;

    public AudioClip hit;
    public AudioClip dead;
    public AudioClip golem;

   


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
            Destroy(this.gameObject, 4);
        }
       
        //Hits Enemy
        if (collision.gameObject.tag == "Ground")
        {
            if(gameObject.name == "MageOrb(Clone)")
            {
                
                Instantiate(Explosion, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            }
            GetComponent<AudioSource>().clip = hit;
            if(collision.gameObject.name == "rockgolem(Clone)")
            {
                GetComponent<AudioSource>().clip = golem;
            }

            GetComponent<AudioSource>().Play();


            health = collision.gameObject.GetComponent<NpcStats>().health;
            float hp = health - damage;
            collision.gameObject.GetComponentInChildren<TextMesh>().text = "" + hp;
            collision.gameObject.GetComponent<NpcStats>().health = hp;

            this.gameObject.GetComponent<SphereCollider>().enabled = false;
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            Destroy(this.gameObject,0.5f);

            if(collision.gameObject.GetComponent<NpcStats>().health <= 0)
            {
                GetComponent<AudioSource>().clip = dead;
                GetComponent<AudioSource>().Play();

                collision.gameObject.GetComponent<Animation>().Play("death1");
                collision.gameObject.GetComponent<NavMeshAgent>().speed = 0;
                Instantiate(Coins, collision.gameObject.transform.position, collision.gameObject.transform.rotation);

                collision.gameObject.GetComponent<NpcStats>().health = 0;
                collision.gameObject.transform.GetChild(10).transform.GetComponent<TextMesh>().gameObject.SetActive(false);

                collision.gameObject.tag = "End";
                

              Destroy(collision.gameObject,2);

                
            }
        }

       Destroy(this.gameObject, 5);

        
        
    }
    
}
