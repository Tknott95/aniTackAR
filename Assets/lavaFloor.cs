using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lavaFloor : MonoBehaviour {

    public bool isDamaging;
    public float damage = 10;
    /* Ten damage every second */

    private void OnTriggerStay(Collider col)
    {
       if(col.tag == "Player")
        {
            col.SendMessage((isDamaging) ? "TakeDamage" : "HealDamage", Time.deltaTime * damage);
        }
    }
}
