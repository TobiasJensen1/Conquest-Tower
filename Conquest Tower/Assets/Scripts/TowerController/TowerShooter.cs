using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShooter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        print("collision");
        if (collider.gameObject.CompareTag("Ground"))
        {
            print("SKyd for faaanden");
            collider.GetComponentInChildren<TextMesh>().text = "0";
        }
    }
}
