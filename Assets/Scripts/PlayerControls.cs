using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerControls: MonoBehaviour
{
    [SerializeField]private Tilemap groundTilemap;
    [SerializeField]private Tilemap collisionTilemap;
    private PlayerActions playerActions;
    private SpawnThingOnGrid thingspawner;
    [SerializeField] private GameObject testSpawnObj; // 

    [SerializeField] private List<Vector3Int> plantedSeedsPos;

    [SerializeField] private PlayerAttributes playerAttributes;
    
    private void Awake() {
        playerActions = new PlayerActions();
        thingspawner = new SpawnThingOnGrid();
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
            thingspawner.SpawnThingAt(testSpawnObj, transform.position);

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
                transform.position += (Vector3)dir;
                Debug.Log("moved to" + groundTilemap.WorldToCell(transform.position));
                Debug.Log("AP left: " + playerAttributes.CurrentAP);
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
