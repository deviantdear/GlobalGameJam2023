using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGrass : MonoBehaviour
{
    // Matt Thompson
    // Last Modified 2/4/23

    // A script for generating objects around the map outisde of the player's view and without intersecting with existing objects

    // adjust these to the dimensions of the game world
    [SerializeField] float minX = -200;
    [SerializeField] float maxX = 200;
    [SerializeField] float minY = -200;
    [SerializeField] float maxY = 200;

    // adjust these to change difficulty, max roots that can exist at the same time, etc.
    [SerializeField] int startingCount = 6;
    [SerializeField] int currentMaxRootsSpawned = 10;
    [SerializeField] int ceilingMaxRootsSpawned = 20;
    [SerializeField] int floorMaxRootsSpawned = 5;
    [SerializeField] int currentRootsSpawned = 0;

    // every X roots, decrease the max that can co-exist (so the game gets harder over time)
    [SerializeField] int maxDecreaseThreshold = 5;

    // spawn a root every X seconds
    [SerializeField] float spawnDelay = 2f;

    // the object we are spawning, in this case grass/roots
    [SerializeField] GameObject rootObject;
    [SerializeField] GameObject playerCharacter;

    // How far away from any other object we want roots to spawn
    [SerializeField] float spawnAvoidance = 1.0f;
    [SerializeField] float maxDistanceFromPlayer = 20.0f;

    // the main game camera
    [SerializeField] Camera camera;

    // mostly used for logging/etc. tracks the total number of roots that have been spawned so far
    public int rootsSpawnedCount = 0;

    private bool gameRunning = true;

    // Spawn a handful of roots at the beginning of the game, then kick off the coroutine to spawn more over time
    void Start()
    {
        //for (int i = 0; i < startingCount; i++) { SpawnRootsCheck(); }

        //StartCoroutine("SpawnTimer");
    }

    void Update()
    {
        // if the game is over kill coroutines
        if (GetComponent<GameStateManager>().gameOver == true && gameRunning == true)
        {
            StopCoroutine("SpawnRoots");
            gameRunning = false;
            //Debug.Log("Killed coroutine because game ended");
        }
    }

    //// spawn a root every x seconds, decrease the max roots that can co-exist every Y roots that are spawned (to increase difficulty over time)
    //IEnumerator SpawnTimer()
    //{
    //    for(; ; )
    //    {
    //        SpawnRootsCheck();

    //        if (rootsSpawnedCount % maxDecreaseThreshold == 0) { DecrementMax(); }

    //        yield return new WaitForSeconds(spawnDelay);
    //    }
    //}


    // generate a set of coords, if the coords are OFF camera and do not overlap with another item spawn a root
    //public void SpawnRootsCheck()
    //{
    //    if (currentRootsSpawned < currentMaxRootsSpawned)
    //    {
    //        float spawnX = Random.Range(minX, maxX);
    //        float spawnY = Random.Range(minY, maxY);

    //        Vector2 spawnCoords = new Vector2(spawnX, spawnY);
    //        Vector3 spawnCoords3D = new Vector3(spawnX, spawnY, 1);

    //        // Debug.Log(Physics2D.OverlapCircle(spawnCoords, spawnAvoidance));

    //        float distanceFromPlayer = Vector3.Distance(playerCharacter.transform.position, spawnCoords3D);

    //        if ((distanceFromPlayer < maxDistanceFromPlayer) && isOffCamera(spawnX, spawnY) && ((Physics2D.OverlapCircle(spawnCoords, spawnAvoidance) == null)))
    //        {
    //            Instantiate(rootObject, spawnCoords3D, Quaternion.identity);
    //            currentRootsSpawned++;
    //            rootsSpawnedCount++;
    //        }
    //        else
    //        {
    //            SpawnRootsCheck();
    //        }
    //    }
    //}

    // small functions for incrementing/decrementing values
    void IncrementMax()
    {
        if (currentMaxRootsSpawned < ceilingMaxRootsSpawned) { currentMaxRootsSpawned++; }
    }

    // small functions for incrementing/decrementing values
    void DecrementMax()
    {
        if (floorMaxRootsSpawned < currentMaxRootsSpawned) { currentMaxRootsSpawned--; }
    }

    // small functions for incrementing/decrementing values
    public void DecrementCount()
    {
        if (currentRootsSpawned > 0) { currentRootsSpawned--; }
    }



    // Check if a 2d coordinate pair is outside the bounds of the camera or not
    bool isOffCamera(float spawnX, float spawnY)
    {
        Vector3 viewPos = camera.WorldToViewportPoint(new Vector3(spawnX, spawnY, 1));
        
        if ((viewPos.x < 0.0 || viewPos.x > 1.0) && (viewPos.y < 0.0 || viewPos.y > 1.0))
        {
            return true;
        }
        return false;
    }

}
