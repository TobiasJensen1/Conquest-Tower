using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Behavour : MonoBehaviour
{
    public float speed = 50f;
    Vector3 newPos;
    public Transform MoveTo;
    public Transform punkt;
    float step;


    bool reachA;
    bool reachB;
    // Start is called before the first frame update
    void Start()
    {

        reachA = true;
        reachB = false;
      MoveTo =  GameObject.Find("Canvas").transform.GetChild(5).transform;
        punkt = GameObject.Find("punkt").transform;
    }

    // Update is called once per frame
    void Update()
    {
        step = speed * Time.deltaTime;

        if (reachA)
        {
            newPos = transform.position = Vector3.MoveTowards(transform.position, punkt.position, step);
        }

        if (reachB)
        {
            speed = 75;
            newPos = transform.position = Vector3.MoveTowards(transform.position, MoveTo.position, step);
        }


        if (Vector3.Distance(transform.position, punkt.transform.position) < 0.001f)
        {

            reachA = false;
            reachB = true;
        }


        if (Vector3.Distance(transform.position, MoveTo.transform.position) < 0.001f)
        {
            Destroy(gameObject);
        }
    }
}
