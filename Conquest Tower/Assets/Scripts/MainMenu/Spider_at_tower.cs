using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider_at_tower : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Animation>().Play("idle");
        StartCoroutine("PlayAnimation");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator PlayAnimation()
    {
        while (true)
        {
            gameObject.GetComponent<Animation>().Play("attack1");
            yield return new WaitForSeconds(1);
            gameObject.GetComponent<Animation>().Play("idle");
            yield return new WaitForSeconds(4);

        }
    }
}
