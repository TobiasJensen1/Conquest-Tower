using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathDetector : MonoBehaviour
{

    public NavMeshAgent spawnPosition;
    Transform targetPosition;

    bool pathAvailable;
    NavMeshPath navMeshPath;
    

    // Start is called before the first frame update
    void Start()
    {
        navMeshPath = new NavMeshPath();
        targetPosition = GameObject.FindGameObjectWithTag("End").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (!CalculateNewPath())
        {

        }
        
    }

    bool CalculateNewPath()
    {
        spawnPosition.CalculatePath(targetPosition.position, navMeshPath);
        print("New path calculated");
        if (navMeshPath.status != NavMeshPathStatus.PathComplete)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
