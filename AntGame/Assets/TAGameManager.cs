using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TAGameManager : MonoBehaviour
{

    const float SPAWNLOWERBOUND = 0.2f;
    const float SPAWNUPPERBOUND = 1f;

    public GameObject walkingMook;
    public GameObject runningMook;

    private int mooksBeforeRunning;

    private float nextMookTime;
    private float elapsedTime;

    // Start is called before the first frame update
    void Start()
    {
        elapsedTime = 0;
        mooksBeforeRunning = 2;

        nextMookTime = GetNextMookTime();
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        if(elapsedTime >= nextMookTime)
        {
            if (mooksBeforeRunning > 0 || mooksBeforeRunning < 0)
            {
                Instantiate(walkingMook, transform.position, Quaternion.identity);
            }
            else if (mooksBeforeRunning == 0)
            {
                Instantiate(runningMook, transform.position, Quaternion.identity);
            }

            mooksBeforeRunning -= 1;
            elapsedTime = 0;
            nextMookTime = GetNextMookTime();
        }
    }

    void SpawnMook()
    {

    }

    float GetNextMookTime()
    {
        return Random.Range(SPAWNLOWERBOUND, SPAWNUPPERBOUND);
    }
}
