using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject meteor;

    private float spawnRange;
    private float spawnFrequency;
    private float meteorSpeed;

    // Start is called before the first frame update
    void Start()
    {
        spawnRange = transform.localScale.x / 2;
        spawnFrequency = 1f;
        meteorSpeed = 10f;
        StartCoroutine(SpawnMeteors());
    }

    IEnumerator SpawnMeteors()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnFrequency);
            
            GameObject newMeteor = Instantiate(meteor) as GameObject;
            newMeteor.transform.position = new Vector2(Random.Range(transform.position.x - spawnRange, transform.position.x + spawnRange), transform.position.y);
            newMeteor.GetComponent<Meteor>().fallSpeed = meteorSpeed;

            //

        }
    }
}
