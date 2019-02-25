﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSellTower : MonoBehaviour
{


    Vector3 clickPosition;

    public GameObject SellBut;
    public GameObject Upgradebut;

    bool CanBuild = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                clickPosition = hit.point;
                print(hit.point);
                print("hallo");


                if (hit.transform.tag == "Tower")
                {
                    //poppe knapper op "upgrade" "Sell" "info om tower"
                    print("Tower siger hej");
                    CanBuild = false;
                    Upgradebut.transform.position = new Vector3(hit.transform.position.x - 20, hit.transform.position.y + 10, hit.transform.position.z);
                    SellBut.transform.position = new Vector3(hit.transform.position.x + 20, hit.transform.position.y + 10, hit.transform.position.z);
                    SellBut.SetActive(true);
                    Upgradebut.SetActive(true);

                }
                else if (hit.transform.tag == "Untagged")
                {
                    SellBut.SetActive(false);
                    Upgradebut.SetActive(false);
                    CanBuild = true;
                }
            }
        }
    }
}

