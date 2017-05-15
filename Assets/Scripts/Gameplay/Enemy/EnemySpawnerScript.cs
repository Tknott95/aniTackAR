using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour {
    public GameObject enemy;
    public Transform enemyPosition;
    public bool enableSpawner = true;

    public int howManyEnemies = 3;
    public float spawnRate = 5.0f;

    private IEnumerator coRout;

	// Use this for initialization
	void Start () {
        coRout = EnemySpawner();
        if (enableSpawner == true)
        {
            StartCoroutine(coRout);
        }
    }

    void Update ()
    {
    }

    private IEnumerator EnemySpawner()
    {
        while (howManyEnemies > 0)
        {
            yield return new WaitForSeconds(spawnRate);
            howManyEnemies--;
            Instantiate(enemy, enemyPosition.position, enemyPosition.rotation);
        }
    }
}
