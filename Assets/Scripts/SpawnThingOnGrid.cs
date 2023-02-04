using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpawnThingOnGrid : MonoBehaviour
{

    //they are like a dictionary but im too lazy, make sure they have same length
    [SerializeField] Tilemap tilemap;
    [SerializeField] GameObject[] thingsToSpawn;
    [SerializeField] Vector3[] spawnPoints; 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RandomSpawner(float chanceToSpawn) //should be between 0 and 1
    {

        int gridX = 1;

        for (int i = gridX; i < 9; i++)//loop the rows
        {
            int gridY = -7;
            for (int j = gridY; j < 1; j++)
            {
                float randomF = Random.Range(0f, 1f);
                if (randomF < chanceToSpawn)
                {
                    Vector3 v3offset = thingsToSpawn[0].GetComponent<SpriteRenderer>().size / 2;
                    Vector3 v3 = new Vector3(i, j, 0) + v3offset;
                    SpawnThingAt(thingsToSpawn[0], v3);
                    Debug.Log("Spawned Seed at" + new Vector3(i, j, 0));
                }
            }
        }

    }

    public void SpawnAllThings()
    {
        

        for (int i = 0; i < thingsToSpawn.Length; i++)
        {

            Vector3 v3offset = thingsToSpawn[i].GetComponent<SpriteRenderer>().size / 2;
            //Debug.Log(v3offset);
            Vector3 v3 = spawnPoints[i] + v3offset; //so that sprite spawns on the center of tile

            SpawnThingAt(thingsToSpawn[i], v3);
            
        }
    }


    public void SpawnThingAt(GameObject thing, Vector3 spawnPointV3)
    {

        Instantiate(thing, spawnPointV3,Quaternion.identity);//instantiate under the grid
    }

    
}
