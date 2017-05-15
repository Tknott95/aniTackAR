using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarScript : MonoBehaviour {

    public Image currentHealthbar;
    public Text ratioText;

    private float startingHealth = 100;
    /* Percentage stays private */
    public float hitpoint = 150;  /* currHealth */
    public float maxHitpoint = 150; /* maxHealth */

    private Animation anim;
    private Renderer myRender;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animation>();
        UpdateHealthbar();
	}
	
    private void UpdateHealthbar()
    {
        float ratio = hitpoint / maxHitpoint;
        currentHealthbar.rectTransform.localScale = new Vector3(ratio, 1, 1);
        ratioText.text = (ratio * startingHealth).ToString("0") + "%";
        /* "0" in the toString() allows for text not to have floating points */
    }

    private void TakeDamage(float damage)
    {
        hitpoint -= damage;

        if (hitpoint <= 0)
        {
            hitpoint = 0;
            /* anim.Play("death") here */
            Destroy(gameObject);
            Debug.Log("Dead");
            Application.LoadLevel(2);

            //StartCoroutine("DeadPlayer");
        }

        UpdateHealthbar();
    }

    private void HealDamage (float heal)
    {
        hitpoint += heal;
        if (hitpoint > maxHitpoint)
        {
            hitpoint = maxHitpoint;
        }

        UpdateHealthbar();
    }

    private IEnumerator DeadPlayer()
    {
        yield return new WaitForSeconds(1);
        Application.LoadLevel(2);
    }
}
