using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSpider : MonoBehaviour
{
    public GameObject MoveTo1;
    public GameObject MoveTo2;
    public GameObject MoveTo3;
    public float speed = 2.0f;
    Vector3 newPos;
    float step;


    public GameObject bullet;
    public GameObject Explosion;



    //Switch
    public bool Startmove;
    public bool Startmove2;
    public bool Startmove3;

    public bool startPlay;


    void Start()
    {
        startPlay = false;
        Startmove = true;
        Startmove2 = false;
        Startmove3 = false;
       gameObject.GetComponent<Animation>().Play("run");
    }

    // Update is called once per frame
    void Update()

    {
        print(startPlay);
        step = speed * Time.deltaTime;
        if (Startmove)
        {
            transform.LookAt(MoveTo1.transform);
            newPos = transform.position = Vector3.MoveTowards(transform.position, MoveTo1.transform.position, step);
        }

        if (Startmove2)
        {

            newPos = transform.position = Vector3.MoveTowards(transform.position, MoveTo3.transform.position, step);
        }

        if (Startmove3)
        {
            newPos = transform.position = Vector3.MoveTowards(transform.position, MoveTo2.transform.position, step);
        }



        if (Vector3.Distance(transform.position, MoveTo1.transform.position) < 0.001f)
        {

            if (!startPlay)
            {
                transform.LookAt(MoveTo3.transform);
                Startmove = false;
                Startmove2 = true;
            }
            else
            {
                transform.LookAt(MoveTo2.transform);
                Startmove = false;
                Startmove2 = false;
                Startmove3 = true;
                speed = 20;

            }
           
        }


        if (Vector3.Distance(transform.position, MoveTo3.transform.position) < 0.001f)
        {


            if (!startPlay)
            {
                transform.LookAt(MoveTo1.transform);
                Startmove = true;
                Startmove2 = false;
            }
            else
            {
                transform.LookAt(MoveTo2.transform);
                Startmove = false;
                Startmove2 = false;
                Startmove3 = true;
                speed = 20;
            }
        }

       

            if ( startPlay && Vector3.Distance(transform.position, MoveTo2.transform.position) < 0.001f)
            {

            StartCoroutine("OnplayAnimation");
            startPlay = false;
               
            }

    }


    public void OnPlay()
    {
        print(startPlay);
        startPlay = true;
        speed = 20;
    }

    IEnumerator OnplayAnimation()
    {
        gameObject.GetComponent<Animation>().Play("idle");
        bullet.GetComponent<Rigidbody>().useGravity = true;
        bullet.GetComponent<Rigidbody>().AddForce(1, -1000, 1);

        yield return new WaitForSeconds(1);
        GetComponent<AudioSource>().Play();
        Instantiate(Explosion, gameObject.transform.position, gameObject.transform.rotation);
        gameObject.GetComponent<Animation>().Play("death1");
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("ConquestTower");
    }



}
