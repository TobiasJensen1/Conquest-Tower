using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalProjectile : BaseProjectile
{
    Vector3 _direction;
    bool _fired;
    GameObject _launcher;
    GameObject _target;
    int _damage;

    // Update is called once per frame
    void Update()
    {
        if (_fired)
        {
            transform.position += _direction * (speed * Time.deltaTime);
        }
    }

    public override void FireProjectile(GameObject launcher, GameObject target, 
        int damage, float attackSpeed)
    {
        if (launcher && target)
        {
            _direction = (target.transform.position - launcher.transform.position).normalized;
            _fired = true;
            _launcher = launcher;
            _target = target;
            _damage = damage;

            Destroy(gameObject, 10.0f);
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