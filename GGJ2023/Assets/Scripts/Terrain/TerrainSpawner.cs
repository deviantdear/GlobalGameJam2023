using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainSpawner : PickUpSpawner
{

    // Start is called before the first frame update
    protected override void Start()
    {
        SetValues();
        SpawnLevel(40, 60, xoffset, zoffset, ypos);
       // SpawnLevel(float _xdistance, float _zdistance, float _xoffset, float zoffset, float ypos)
    }

    protected override void SetValues()
    {
        xoffset = -50f;
        zoffset = -205f;
        ypos = 90f;
    }

}
