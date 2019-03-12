using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class NpcMove : MonoBehaviour
{

    [SerializeField]
    Transform _destination;

    NavMeshAgent _navMeshAgent;
    PlayerInfo playerinfo;
    



    // Start is called before the first frame update
    void Start()
    {
        GameObject tc = GameObject.Find("TowerController");
        playerinfo = tc.GetComponent<PlayerInfo>();

        _navMeshAgent = this.GetComponent<NavMeshAgent>();

        if(_navMeshAgent == null)
        {
            print("The Nav Mesh Agent Component is Not Attached to " + gameObject.name);
        }
        else
        {
            InvokeRepeating("SetDestination", 0f, 1f);
        }
            
    }

    void Update()
    {
        DestinationReached();
    }

        private void SetDestination()
    {
        if(_destination != null)
        {
            Vector3 targetVector = _destination.transform.position;
            _navMeshAgent.SetDestination(targetVector);
        }
    }

    private void DestinationReached()
    {
        if (_navMeshAgent.gameObject.name == "rockgolem(Clone)" && _navMeshAgent.pathStatus == NavMeshPathStatus.PathComplete && _navMeshAgent.remainingDistance <= 1)
        {
            playerinfo.Health -= 1000;
        }
        if (_navMeshAgent.pathStatus == NavMeshPathStatus.PathComplete && _navMeshAgent.remainingDistance <= 1)
        {
            if (playerinfo.Health >= 0)
            {
                playerinfo.Health -= 1;
                Destroy(gameObject);
            }

        }
        
    }



}
