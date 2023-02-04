using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawner : MonoBehaviour
{
    public List<Transform> prefabToSpawn;
    private int pick;
    public int numPrefabs;
    protected float xoffset;
    protected float zoffset;
    protected float ypos;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        SetValues();
        SpawnLevel(9,10, xoffset, zoffset,ypos);
        //2nd wave values
        xoffset = 0f;
        zoffset = 0f;
        SpawnLevel(7,10, xoffset, zoffset, ypos);
    }

    protected virtual void SpawnLevel(float _xdistance, float _zdistance, float _xoffset, float zoffset, float ypos)
    {
        float xdistanceBetween = _xdistance;
        float zdistanceBetween = _zdistance;
        for (int i = 0; i < numPrefabs; i++)
        {
            for (int j = 0; j < numPrefabs; j++)
            {
                float xpos = transform.position.x + i * xdistanceBetween;
                float zpos = transform.position.z + j * zdistanceBetween;
                pick = Random.Range(0, prefabToSpawn.Count);
                Object instanceObj = Instantiate(prefabToSpawn[pick], new Vector3(xpos + xoffset, ypos, zpos +zoffset), Quaternion.identity);
            }
        }
    }

    protected virtual void SetValues()
    {
        xoffset = 20f;
        zoffset = 200f;
        ypos = 100.5f;
    }

}
