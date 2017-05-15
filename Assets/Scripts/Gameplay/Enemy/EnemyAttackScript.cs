using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackScript : MonoBehaviour {

    public bool isDamaging;
    public float damage = 55;

    public float fpsTargetDistance = 10;
    public float enemyLookDistance = 9;
    public float attackDistance = 8;
    public float enemyMovementSpeed = 1f;
    public float lookingRotation = 20f;
    public GameObject explosionParticle;
    public Transform fpsTarget;
    Rigidbody rb;
    Renderer myRender;

	// Use this for initialization
	void Start () {
        myRender = GetComponent<Renderer> ();
        rb = GetComponent<Rigidbody> ();
    }

    // Update is called once per frame
    void FixedUpdate () {
        /* Gives Distance From Enemy Bruh Bruh */
        fpsTargetDistance = Vector3.Distance(fpsTarget.position, transform.position);

        if (fpsTargetDistance < enemyLookDistance)
        {
            myRender.material.color = Color.red;
            lookAtPlayer();
            print("Look at that mothaf$ck1n kitty");
        }

        if (fpsTargetDistance < attackDistance)
        {
            attackEnemy();
            print("ATTACKING ENEMY!");
        } else
        {
            myRender.material.color = Color.blue;
        }
	}

    void lookAtPlayer () {
        Quaternion rotation = Quaternion.LookRotation(fpsTarget.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * lookingRotation);
    }

    void attackEnemy () {
        rb.AddForce(transform.forward * enemyMovementSpeed);
        Destroy(explosionParticle);
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player")
        {
            col.SendMessage((isDamaging) ? "TakeDamage" : "HealDamage", Time.deltaTime * damage);
        }
    }
}
