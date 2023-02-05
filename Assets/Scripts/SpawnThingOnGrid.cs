using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpawnThingOnGrid : MonoBehaviour
{

    [SerializeField] Tilemap tilemap;

    //they are like a dictionary but im too lazy, make sure they have same length
    [SerializeField] GameObject[] vegPrefab; //ur potats and carots
    [SerializeField] float[] spawnProbability;//their respective spawn chance, should be between 0 and 1

    //these 2 values are linked
    public List<GameObject> plantedVegetables;
    public List<Vector3> plantedVegetableLocations; 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RandomSpawner(GameObject go,float chanceToSpawn) //should be between 0 and 1
    {
        int gridX = 1;

        for (int i = gridX; i < 9; i++)//loop the rows
        {
            int gridY = -7;
            for (int j = gridY; j < 1; j++)
            {
                Vector3 v3offset = go.transform.GetChild(0).GetComponent<SpriteRenderer>().size / 2;
                Vector3 v3 = new Vector3(i, j, 0) + v3offset;
                if (!plantedVegetableLocations.Contains(new Vector3(i,j,0)))
                {
                    float randomF = Random.Range(0f, 1f);
                    if (randomF < chanceToSpawn)
                    {
                        //SpawnThingAt(vegPrefab[0], v3);
                        GameObject newVeg = Instantiate(go, v3, Quaternion.identity); //Plant Seed!!
                        plantedVegetables.Add(newVeg);
                        plantedVegetableLocations.Add(new Vector3(i, j, 0));

                        Debug.Log("Spawned " + go.transform.GetComponentInChildren<Vegetable>().getType() + " Seed at" + new Vector3(i, j, 0));
                        //keep track of what got planted

                    }
                }
                else
                {
                    Debug.Log("tile occupied");
                }


                
            }
        }

    }

    public void SpawnAllSeeds()
    {
        for(int i = 0; i< vegPrefab.Length; i++)
        {
            RandomSpawner(vegPrefab[i],spawnProbability[i]);
        }
    }


    public void growAll() //all vegetable grows a cycle
    {
        foreach(GameObject go in plantedVegetables)
        {
            go.GetComponentInChildren<Vegetable>().grow();
        }
    }


    /*

    public void SpawnThingAt(GameObject thing, Vector3 spawnPointV3)
    {
        Instantiate(thing, spawnPointV3,Quaternion.identity);//instantiate under the grid
    }

    */


}
