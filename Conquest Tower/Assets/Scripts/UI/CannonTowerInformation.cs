using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CannonTowerInformation : MonoBehaviour
{

    public GameObject sprite;
    public Text text;
    public Text titleText;
    public GameObject cannon;
    SpriteRenderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = sprite.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseOver()
    {



        titleText.text = "Cannon";
        text.text = "Damage: " + cannon.transform.gameObject.transform.GetChild(1).GetComponent<CannonBehaviour>().CannonBall.GetComponent<CannonBulletCollision>().damage + "" +
            "\nSpeed: " + cannon.transform.gameObject.transform.GetChild(1).GetComponent<CannonBehaviour>().CannonBallSpeed + "" +
            "\nRange: " + cannon.transform.gameObject.transform.GetChild(1).GetComponent<CannonBehaviour>().range + "";

    }

    void OnMouseExit()
    {
        text.text = "";
        titleText.text = "";
    }
}
