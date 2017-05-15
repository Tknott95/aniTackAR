using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevelScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine("LevelSwitch");
	}

    private IEnumerator LevelSwitch()
    {
        yield return new WaitForSeconds(2);
        Application.LoadLevel(1);
    }
}
