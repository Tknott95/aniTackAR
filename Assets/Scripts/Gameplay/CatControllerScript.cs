using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CatControllerScript : MonoBehaviour {
    public float catSpeed = 2f;
    public float catHealth = 100f;
    private Animation anim;
    private Rigidbody rb;


	// Use this for initialization
	void Start () {
        anim = GetComponent<Animation> ();
        rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
        // anim.SetTrigger("Walking");

        float x = CrossPlatformInputManager.GetAxis("Horizontal");
        float y = CrossPlatformInputManager.GetAxis("Vertical");

        Vector3 movement = new Vector3(x, 0, y);

        rb.velocity = movement * catSpeed;

        if (x != 0 && y != 0)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(x, y) * Mathf.Rad2Deg, transform.eulerAngles.z);
        }

        if (x != 0 || y != 0)
        {
            anim.Play("run_fast");
        } else
        {
            anim.Play("idle_03");
        }
    }
}
