using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject meteor;

    private float spawnRange;
    private float meteorSpeed;
    private bool canStartSpawning;
    //spawn timers
    private float timeToSpawn;
    private float timeSinceSpawn;
    //upgrade timers
    private float timeToUpgrade;
    private float timeSinceUpgrade;

    void Start()
    {
        spawnRange = transform.localScale.x / 2;
        
        // initial meteor spawn values
        meteorSpeed = 7f;
        timeToSpawn = 1f;
        timeToUpgrade = 5f;
        
        StartCoroutine(WaitToSpawnMeteors()); 
    }

    private void Update()
    {
        if (canStartSpawning) // if cutscene is over then it starts spawning meteors 
        {
            StartSpawningMeteors();
        }

    }

    private IEnumerator WaitToSpawnMeteors() // Waits until the cutscene is over to allow the spawn of meteors
    {
        yield return new WaitForSeconds(CutsceneVars.CutsceneEnding);
        canStartSpawning = true;
    }


    private void StartSpawningMeteors()
    {
        timeSinceSpawn += Time.deltaTime;

        //Spawn meteors over time
        if(timeSinceSpawn > timeToSpawn)
        {
            timeSinceSpawn = 0;

            GameObject newMeteor = Instantiate(meteor) as GameObject;
            newMeteor.transform.position = new Vector2(Random.Range(transform.position.x - spawnRange, transform.position.x + spawnRange), transform.position.y);
            newMeteor.GetComponent<Meteor>().fallSpeed = meteorSpeed;
        }

        //Upgrades meteor spawn and meteors over time
        timeSinceUpgrade += Time.deltaTime;
        if (timeSinceUpgrade > timeToUpgrade)
        {
            timeSinceUpgrade = 0;
            if(timeToSpawn < 0.6)
            {
                timeToSpawn -= 0.05f;
            }
            else
            {
                timeToSpawn -= 0.1f;
            }

            meteorSpeed += 1f;
        }
    }
}
