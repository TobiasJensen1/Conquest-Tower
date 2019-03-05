using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawTowerRange : MonoBehaviour
{

    

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        sprite.color = new Color(1,1,1, .3f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
