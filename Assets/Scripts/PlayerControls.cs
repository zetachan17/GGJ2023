using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerControls: MonoBehaviour
{

    [SerializeField]private Tilemap groundTilemap;
    [SerializeField]private Tilemap collisionTilemap;
    [SerializeField]private PlayerActions playerActions;
    [SerializeField] private SpawnThingOnGrid spawner;
    [SerializeField] private GameObject testSpawnObj; // 

    [SerializeField] private List<Vector3Int> plantedSeedsPos;

    [SerializeField] private PlayerAttributes playerAttributes;
    
    private void Awake() {
        playerActions = new PlayerActions();
    }

    private void OnEnable() {
        playerActions.Enable();
    }

    private void OnDisable() {
        playerActions.Disable();
    }

    private void Start() {
        playerActions.main.Movement.performed +=ctx => Move(ctx.ReadValue<Vector2>());
    }
    
    private void Move(Vector2 dir){
        if (CanMove(dir)){
            //testing spawn thing on player pos 
            Vector3Int gridPosition = groundTilemap.WorldToCell(transform.position);
            Vector3 v3 = (Vector3)gridPosition;

            //spawner.SpawnThingAt(testSpawnObj, transform.position);

            /*
            //Add planted seeds to list of pos that has seeds
            foreach(Vector3Int v3i in plantedSeedsPos)
            {
                if (v3i.x==gridPosition.x)
                {
                    Debug.Log("Already has a seed");
                }
                else
                {
                    Debug.Log("seed planted");
                    plantedSeedsPos.Add(gridPosition);
                    //check if it already has a thing
                }
            }
            */


            //player moves
            //if (playerAttributes.CurrentAP > 0)
            {
                playerAttributes.CurrentAP--;
                transform.position += (Vector3)dir;//moved
                Debug.Log("AP left: " + playerAttributes.CurrentAP);
                
                Vector3Int newgridPosition = groundTilemap.WorldToCell(transform.position);
                Debug.Log("player moved to" + newgridPosition + "!!");
                if (spawner.plantedVegetableLocations.Contains(newgridPosition))
                {
                    Vector3 newv3 = (Vector3)newgridPosition;
                    
                    for(int i = 0; i < spawner.plantedVegetableLocations.Count; i++)
                    {
                        if(spawner.plantedVegetableLocations[i] == newv3)
                        {
                            Debug.Log(spawner.plantedVegetables[i].GetComponentInChildren<Vegetable>().getType() + "is at"+ newgridPosition + "!!!!");
                        }
                    }

                }

            }
            


        }

    }

    private bool CanMove(Vector2 dir){
        Vector3Int gridPosition = groundTilemap.WorldToCell(transform.position + (Vector3)dir);
        if(!groundTilemap.HasTile(gridPosition)||collisionTilemap.HasTile(gridPosition))
            return false; //cant move if no ground tile or has a colision tile
        return true;
    }
}
