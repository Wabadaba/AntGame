using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject insPrefab;
    public GameObject glucPrefab;

    private float totalObjectTime;      // time elapsed since last object spawn
    public float objectSpawnerInterval; // amount of time needed for an object to spawn

    private const float TIMETODESTROY = 3; // time until object gets destroyed

    private int[] randomNumber = new int[] { 0, 1 };
    private int randomNum;

    // Update is called once per frame
    void Update()
    {
        // spawn a pipe if the time reaches the spawner interval
        if (totalObjectTime > objectSpawnerInterval)
        {
            SpawnObject();
            totalObjectTime = 0; // reset time so it can climb back up to the spawnerinterval
        }


        // Time.deltaTime counts time since last draw frame
        // this is important to keeping timing in the Update method consistent
        // NOTE: if you want to do this in FixedUpdate, you need to use Time.fixedDeltaTime
        totalObjectTime += Time.deltaTime;
    }

    void SpawnObject()
    {
        // sets spawn position and spawns the pipe

        int randomNumberIndex = Random.Range(0, randomNumber.Length);
        randomNum = randomNumber[randomNumberIndex];

        if (randomNum == 0)
        {
            Vector3 SpawnPos = new Vector3(transform.position.x, -2f, 0);
            GameObject spawnedObject = Instantiate(glucPrefab, SpawnPos, Quaternion.identity);
            Destroy(spawnedObject, TIMETODESTROY);
        }
        else if (randomNum == 1)
        {
            Vector3 SpawnPos = new Vector3(transform.position.x, 0, 0);
            GameObject spawnedObject = Instantiate(insPrefab, SpawnPos, Quaternion.identity);
            Destroy(spawnedObject, TIMETODESTROY);
        }
    }
}
