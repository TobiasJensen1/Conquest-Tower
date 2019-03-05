﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class NpcMove : MonoBehaviour
{

    [SerializeField]
    Transform _destination;

    NavMeshAgent _navMeshAgent;



    // Start is called before the first frame update
    void Start()
    {


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

    }

        private void SetDestination()
    {
        print("set");
        if(_destination != null)
        {
            Vector3 targetVector = _destination.transform.position;
            _navMeshAgent.SetDestination(targetVector);
        }
    }



}
