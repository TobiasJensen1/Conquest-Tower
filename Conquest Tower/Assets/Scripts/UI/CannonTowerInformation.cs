using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CannonTowerInformation : MonoBehaviour
{

    public GameObject sprite;
    public Text text;
    public Text titleText;
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
   
        sprite.SetActive(true);
        
        text.text = "Cannon";
        titleText.text = "Cannon";
        
        
    }

    void OnMouseExit()
    {
        sprite.SetActive(false);
    }
}
