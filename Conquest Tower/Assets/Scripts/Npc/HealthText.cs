using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthText : MonoBehaviour
{
     


    // Start is called before the first frame update
    void Start()
    {
        this.GetComponentInChildren<TextMesh>().text = "10";
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }
}
