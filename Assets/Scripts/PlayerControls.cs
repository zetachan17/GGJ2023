using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerControls: MonoBehaviour
{

    [SerializeField] private Tilemap groundTilemap;
    [SerializeField] private Tilemap collisionTilemap;
    [SerializeField] private PlayerActions playerActions;
    [SerializeField] public Vector2Int mPlayerPosition;
    [SerializeField] public FarmManager mFarmManager;

    [SerializeField] public GameObject GoHomeButton;

    //[SerializeField] private List<Vector3Int> plantedSeedsPos;
    public List<Vector2Int> mBlockedSpots;
    private PlayerAttributes mPlayerAttributes = new PlayerAttributes();
    private int mMaxAp = 6;
    public int mCurrentAp = 6;
    private Vector2Int mCurrentPosition;

    [SerializeField] Vector2Int mStartPosition;

    BoxCollider2D mCollider;

    bool mOnHomeTile;

    private void Awake() {
        playerActions = new PlayerActions();
        mCollider = GetComponent<BoxCollider2D>();
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
    public void startTurn(PlayerAttributes iPlayerAttributes, List<Vector2Int> iBlockedSpots)
    {
        if (iPlayerAttributes.HasLeft) //TODO: add endturn logic
            mFarmManager.endPlayerTurn(mPlayerAttributes, mCurrentPosition); 
        this.mPlayerAttributes = iPlayerAttributes;
        mBlockedSpots = iBlockedSpots;
        this.mCurrentAp = mMaxAp;

    }

    private void Move(Vector2 dir) {
        if (CanMove(dir)) {
            Vector3Int gridPosition = groundTilemap.WorldToCell(transform.position);
            Vector3 v3 = (Vector3)gridPosition;

            mCurrentAp--;
            transform.position += (Vector3)dir;//moved
            //Debug.Log("player moved to" + gridPosition + "!!");

            Vector3 wTempVec = (transform.position - new Vector3(1.5f, -6.5f, 0f));
            mCurrentPosition = new Vector2Int((int)wTempVec.x, (int)wTempVec.y);
            //Debug.Log("player moved to" + mCurrentPosition + "!!");


        }
    }   



    private bool CanMove(Vector2 dir){

        Vector3Int gridPosition = groundTilemap.WorldToCell(transform.position + (Vector3)dir);
        foreach (Vector2Int v in mBlockedSpots)
        {
            if (transform.position + (Vector3)dir == new Vector3(v.x + 1.5f, v.y - 6.5f, 0f)) return false; // Can't move if other player present
        }
        if (!groundTilemap.HasTile(gridPosition)||collisionTilemap.HasTile(gridPosition))
            return false; //cant move if no ground tile or has a collision tile
        return true;
    }

    private void Harvest()
    {
        if (mFarmManager.mFarmContents.ContainsKey(mCurrentPosition))
        {
            Vector2Int wTempVegInfo = mFarmManager.mFarmContents[mCurrentPosition];
            if (mCurrentAp >= wTempVegInfo.y)
            {
                mPlayerAttributes.AddVegetable(wTempVegInfo);
                mCurrentAp -= wTempVegInfo.y;
                mFarmManager.harvestVegetable(mCurrentPosition);
                GameObject wTempGameObject = GameObject.Find("Veg_" + mCurrentPosition.x + "_" + mCurrentPosition.y);
                if (wTempGameObject)
                {
                    Destroy(wTempGameObject.gameObject);
                }

            }
        }
    }

    public void sendHome()
    {
        mPlayerAttributes.HasLeft = true;
        mPlayerAttributes.playerLeaveOrder = mFarmManager.mHowManyPlayersHaveLeft;
        mFarmManager.mHowManyPlayersHaveLeft++;
    }

    private void Update()
    {
        if (mCurrentAp < 1)
        {
            mFarmManager.endPlayerTurn(mPlayerAttributes, mCurrentPosition);
        }
        if (Input.GetKeyDown("space"))
        {
            Harvest();
        }
    }
}
