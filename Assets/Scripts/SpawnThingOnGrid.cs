using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpawnThingOnGrid : MonoBehaviour
{

    //they are like a dictionary but im too lazy, make sure they have same length
    [SerializeField] GameObject[] thingsToSpawn;
    [SerializeField] Vector3Int[] spawnPoints; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnAllThings()
    {
        for(int i = 0; i < thingsToSpawn.Length; i++)
        {
            SpawnThingAt(thingsToSpawn[i], spawnPoints[i]);
        }
    }


    public void SpawnThingAt(GameObject thing, Vector3Int spawnPointV3)
    {
        Instantiate(thing, spawnPointV3,Quaternion.identity);
    }

    
}
