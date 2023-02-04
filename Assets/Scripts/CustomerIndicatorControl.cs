using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CustomerIndicatorControl : MonoBehaviour
{
    private PlayerActions playerActions;



    private void Awake()
    {
        playerActions = new PlayerActions();
    }

    private void OnEnable()
    {
        playerActions.Enable();
    }

    private void OnDisable()
    {
        playerActions.Disable();
    }

    private void Start()
    {
        // Vector2 vec22 = playerActions.main.Movement.performed.
        playerActions.main.Movement.performed += ctx => Move(ctx.ReadValue<Vector2>());
        // playerActions
    }

    private void Move(Vector2 dir)
    {
        // print(dir);

        if (dir.x == 0)
        {
           
            transform.position += (Vector3) dir * 2;
        }
        else if (dir.y == 0)
        {
        
            transform.position += (Vector3) dir;


            // print(gameObject.transform.position);
        }

        // if (CanMove(dir)){
        //testing spawn thing on player pos 
        // Vector3Int gridPosition = groundTilemap.WorldToCell(transform.position);
        // thingspawner.SpawnThingAt(testSpawnObj, transform.position);

        //player moves
        transform.position += (Vector3) dir;
        // Debug.Log("moved to" + gridPosition);
        // }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // if (other.gameObject.CompareTag("xBound"))
        // {
        //     // CustomerIndicatorControl playerControlIndicator = other.GetComponent<CustomerIndicatorControl>();
        //     // playerControlIndicator.canMoveX = false;
        //     // print("xwall being touched");
        //     canMoveX = false;
        //     print(canMoveX);
        // }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        // if (other.CompareTag("xBound"))
        // {
        //     // CustomerIndicatorControl playerControlIndicator = other.GetComponent<CustomerIndicatorControl>();
        //     // playerControlIndicator.canMoveX = false;
        //     // print("xwall being touched");
        //     canMoveX = false;
        //     print(canMoveX);
        //
        // }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // if (other.CompareTag("xBound"))
        // {
        //     canMoveX = true;
        //     print("collide");
        // }
    }

    // private bool CanMove(Vector2 dir){
    //     Vector3Int gridPosition = groundTilemap.WorldToCell(transform.position + (Vector3)dir);
    //     if(!groundTilemap.HasTile(gridPosition)||collisionTilemap.HasTile(gridPosition))
    //         return false; //cant move if no ground tile or has a colision tile
    //     return true;
    // }
}