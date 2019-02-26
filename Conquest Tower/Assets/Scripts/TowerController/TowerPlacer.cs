using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

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
    public bool CanUpgrade = false;
    public Camera camera;
    private GameObject Chosen;
    Ray placement;
    Vector3 clickPosition;
    //Information text
    public Text text;



    // Start is called before the first frame update
    void Start()
    {

        CanBuild = true;
        CanUpgrade = false;
        SellBut.SetActive(false);
        Upgradebut.SetActive(false);

    }

    // Update is called once per frame



    void Update()
    {
        //Future use
        if (Chosen != null)
        {

            Chosen.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));

        }
 
        //Current use
        choseTowerPositionText(Chosen);
        

        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                clickPosition = hit.point;

                if (hit.point.y < 1f && CanBuild)
                {
                    if (Chosen != null)
                    {
                        Instantiate(Chosen, hit.point, Quaternion.identity);
                        placerText(Chosen);
                    }
                    CanUpgrade = true;

                    GetComponent<UpgradeSellTower>().enabled = true;
                    
                    
                    Chosen = null; 
                }
            }
        }
    }
    public void placeLaserTower()
    {
        Chosen = LaserTower;
        CanUpgrade = false;
        GetComponent<UpgradeSellTower>().enabled = false;
        SellBut.SetActive(false);
        Upgradebut.SetActive(false);

    }

    public void placeArcherTower()
    {
        Chosen = ArcherTower;
        CanUpgrade = false;
        GetComponent<UpgradeSellTower>().enabled = false;
        SellBut.SetActive(false);
        Upgradebut.SetActive(false);

    }


    public void placerText(GameObject Chosen)
    {
        if (Chosen == LaserTower)
        {
            text.text = "Laser Tower Placed!";
        }
        if (Chosen == ArcherTower)
        {
            text.text = "Archer Tower Placed!";
        }
    }

    public void choseTowerPositionText(GameObject Chosen)
    {
        if (Chosen == LaserTower)
        {
            text.text = "Click where you want to place a Laser Tower!";
        }
        if (Chosen == ArcherTower)
        {
            text.text = "Click where you want to place an Archer Tower!";
        }
    }
}