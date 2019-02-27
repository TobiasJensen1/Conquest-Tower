using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingProjectile : BaseProjectile
{
    GameObject _target;
    GameObject _launcher;
    int _damage;

    Vector3 _lastKnownPosition;

    // Update is called once per frame
    void Update()
    {
        if (_target)
        {
            _lastKnownPosition = _target.transform.position;
        }
        else
        {
            if (transform.position == _lastKnownPosition)
            {
                Destroy(gameObject);
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, _lastKnownPosition, speed * Time.deltaTime);
    }

    public override void FireProjectile(GameObject launcher, GameObject target, 
        int damage, float attackSpeed)
    {
        if (target)
        {
            _target = target;
            _lastKnownPosition = target.transform.position;
            _launcher = launcher;
            _damage = damage;
        }
    }

    //to be checked on
    //void OnCollisionEnter(Collision other)
    //{
    //    if (other.gameObject == m_target)
    //    {
    //        DamageData dmgData = new DamageData();
    //        dmgData.damage = m_damage;

    //        MessageHandler msgHandler = m_target.GetComponent<MessageHandler>();

    //        if (msgHandler)
    //        {
    //            msgHandler.GiveMessage(MessageType.DAMAGED, m_launcher, dmgData);
    //        }
    //    }

    //    if (other.gameObject.GetComponent<BaseProjectile>() == null)
    //        Destroy(gameObject);
    //}
}
