using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MageTowerInformation : MonoBehaviour
{

    public GameObject sprite;
    public Text text;
    public Text titleText;
    public GameObject cannon;
    SpriteRenderer rend;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseOver()
    {



        titleText.text = "Mage Tower";
        text.text = "Damage: " + cannon.transform.gameObject.transform.GetChild(1).GetComponent<MageTowerBehaviour>().Crystal.GetComponent<CannonBulletCollision>().damage + "" +
            "\nSpeed: " + cannon.transform.gameObject.transform.GetChild(1).GetComponent<MageTowerBehaviour>().CrystalSpeed + "" +
            "\nRange: " + cannon.transform.gameObject.transform.GetChild(1).GetComponent<MageTowerBehaviour>().range + "";

    }

    void OnMouseExit()
    {
        text.text = "";
        titleText.text = "";
    }
}
