using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacer : MonoBehaviour
{

    Vector3 clickPosition;
    public GameObject ArcherTower;
    public GameObject LaserTower;
    public Camera camera;
    private GameObject Chosen;
    Ray placement;

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
                if (hit.point.y < 1f)
                {
                    Instantiate(Chosen, hit.point, Quaternion.identity);
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
