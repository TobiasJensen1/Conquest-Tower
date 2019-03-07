using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSellTower : MonoBehaviour
{


    Vector3 clickPosition;

    public GameObject SellBut;
    public GameObject Upgradebut;

    bool CanBuild = false;
    bool CanUpgradenew;


    //Tower Range
    SpriteRenderer sprite;
    List<GameObject> placedTowers = new List<GameObject>();





    // Start is called before the first frame update
    void Start()
    {

        

    }

     void OnEnable()
    {
        GameObject towercontroller = GameObject.Find("TowerController");
        TowerPlacer towerplacer = towercontroller.GetComponent<TowerPlacer>();
        CanUpgradenew = towerplacer.CanUpgrade;
        placedTowers = towerplacer.placedTowers;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            for (int i = 0; i < placedTowers.Count; i++)
            {
                placedTowers[i].gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
            }

            if (Physics.Raycast(ray, out hit))
            {
                clickPosition = hit.point;
               
                if ((hit.transform.tag == "Tower" && CanUpgradenew) && (hit.collider.gameObject.transform.tag != "TurretHitbox"))
                {
                    //poppe knapper op "upgrade" "Sell" "info om tower"
                    SpriteRenderer sprite = hit.collider.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();
                    print(hit.collider.gameObject.transform.GetChild(0));
                    sprite.enabled = true;
                    CanBuild = false;
                    Upgradebut.transform.position = new Vector3(hit.transform.position.x - 5, hit.transform.position.y + 10, hit.transform.position.z + 3);
                    SellBut.transform.position = new Vector3(hit.transform.position.x + 7, hit.transform.position.y + 10, hit.transform.position.z + 3);
                    SellBut.SetActive(true);
                    Upgradebut.SetActive(true);
                }
                else
                {
                    SellBut.SetActive(false);
                    Upgradebut.SetActive(false);
                    
                    CanBuild = true;
                }
            }
            
        }
    }
    



}

