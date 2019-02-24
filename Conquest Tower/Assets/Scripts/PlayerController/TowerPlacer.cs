using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacer : MonoBehaviour
{
    //Test
    public GameObject Testers;
    //knapper
    public GameObject SellBut;
    public GameObject Upgradebut;
    //Towers
    public GameObject ArcherTower;
    public GameObject LaserTower;
    //til klikke kode
    bool CanBuild = false;
    public Camera camera;
    private GameObject Chosen;
    Ray placement;
    Vector3 clickPosition;

    // Start is called before the first frame update
    void Start() { 
   
        CanBuild = true;
      
        SellBut.SetActive(false);
        Upgradebut.SetActive(false);
    }

    // Update is called once per frame

   

    void Update()
    {
        if (Chosen != null)
        {

            Chosen.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));

        }
            if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                clickPosition = hit.point;
                print(hit.point);
                print("hallo");
                if (hit.point.y < 1f && CanBuild)
                {
                    Instantiate(Chosen, hit.point, Quaternion.identity);

                }

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
                else if(hit.transform.tag == "Untagged")
                {
                SellBut.SetActive(false);
                Upgradebut.SetActive(false);
                CanBuild = true;
            }
            }
        }

    }
        public void placeLaserTower()
        {
            Chosen = LaserTower;

        }

        public void placeArcherTower()
        {
            Chosen = ArcherTower;
       
    }

  




}
