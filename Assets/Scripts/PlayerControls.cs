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
            thingspawner.SpawnThingAt(testSpawnObj, gridPosition);

            //player moves
            transform.position += (Vector3)dir;
            Debug.Log("moved to" + gridPosition);
        }

    }

    private bool CanMove(Vector2 dir){
        Vector3Int gridPosition = groundTilemap.WorldToCell(transform.position + (Vector3)dir);
        if(!groundTilemap.HasTile(gridPosition)||collisionTilemap.HasTile(gridPosition))
            return false; //cant move if no ground tile or has a colision tile
        return true;
    }
}
