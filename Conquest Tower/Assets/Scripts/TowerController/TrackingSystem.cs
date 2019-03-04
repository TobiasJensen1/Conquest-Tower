using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Link used: https://forum.unity.com/threads/unity-turret-tutorial.341866/
public class TrackingSystem : MonoBehaviour
{
    public float speed = 3.0f;

    public GameObject _target;
    Vector3 _lastKnownPosition = Vector3.zero;
    Quaternion _lookAtRotation;

    // Update is called once per frame
    void Update()
    {
        if (_target)
        {
            //searches for target 
            if (_lastKnownPosition != _target.transform.position)
            {
                _lastKnownPosition = _target.transform.position;
                _lookAtRotation = Quaternion.LookRotation(_lastKnownPosition - transform.position);
            }
            //locks on target
            if (transform.rotation != _lookAtRotation)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, _lookAtRotation, speed * Time.deltaTime);
            }
        }
    }

    public void SetTarget(GameObject target)
    {
        _target = target;
    }
}
