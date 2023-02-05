using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FarmManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] int mStartPlayer;
    [SerializeField] int mActivePlayer;
    [SerializeField] int mRound = 1;
    [SerializeField] int mTurn;
    [SerializeField] GameObject mGrid;

    

    [SerializeField] PlayerAttributes mPlayer1;
    [SerializeField] PlayerAttributes mPlayer2;
    [SerializeField] PlayerAttributes mPlayer3;
    [SerializeField] PlayerAttributes mPlayer4;

    Dictionary<Vector2Int, Vector2Int> mFarmContents;

    [SerializeField] GameObject vegetablePrefab;

    private void Awake()
    {


    }
    void Start()
    {
        mRound = GameInfo.Instance.mRound;
        mStartPlayer = GameInfo.Instance.mStartPlayer;
        mPlayer1 = GameInfo.Instance.mPlayer1;
        mPlayer2 = GameInfo.Instance.mPlayer2;
        mPlayer3 = GameInfo.Instance.mPlayer3;
        mPlayer4 = GameInfo.Instance.mPlayer4;
        if (mRound == 1)
        {
            mFarmContents = new Dictionary<Vector2Int, Vector2Int>();
            mStartPlayer = 1;
            populateInitialField();
        }
        else
        {
            mFarmContents = GameInfo.Instance.mFarmContents;

            mStartPlayer = GameInfo.Instance.mStartPlayer;
        }
        //TODO: Generate Customers - push info to UI and gameinfo instance
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void populateInitialField()
    {
        int wSeedsPlanted = 0;
        int wXPos;
        int wYPos;
        Vector2Int wTempGridPosition = new Vector2Int();
        Vector3 wInstantiationOffset = new Vector3(1.5f, -6.5f, 0f);
        while (wSeedsPlanted < 61)
        {
            wXPos = Random.Range(0, 9);
            wYPos = Random.Range(0, 9);
            wTempGridPosition.x = wXPos;
            wTempGridPosition.y = wYPos;
            if (!mFarmContents.ContainsKey(wTempGridPosition) && 
                !((wXPos == 0 && (wYPos == 0 || wYPos == 8)) || (wXPos == 8 && (wYPos == 0 || wYPos == 8)))){
                GameObject wSeed = Instantiate(vegetablePrefab,
                    new Vector3(wTempGridPosition.x+wInstantiationOffset.x,
                        wTempGridPosition.y + wInstantiationOffset.y,
                        +wInstantiationOffset.z),
                    Quaternion.identity);
                int wRandomVegType = Random.Range(0, 3);
                switch (wRandomVegType){
                    case 0:
                        wSeed.GetComponentInChildren<Vegetable>().setType(Vegetable.VegetableType.potato);
                        break;
                    case 1:
                        wSeed.GetComponentInChildren<Vegetable>().setType(Vegetable.VegetableType.carrot);
                        break;
                    case 2:
                        wSeed.GetComponentInChildren<Vegetable>().setType(Vegetable.VegetableType.turnip);
                        break;
                }

                int wRandomVegSize = Random.Range(1, 5);
                wSeed.GetComponentInChildren<Vegetable>().setSize(wRandomVegSize);
                mFarmContents.Add(wTempGridPosition, new Vector2Int(wRandomVegType, wRandomVegSize));
                wSeedsPlanted++;
            }
        }

    }

    void seedField()
    {
        int wSeedsPlanted = 0;
        int wXPos;
        int wYPos;
        Vector2Int wTempGridPosition = new Vector2Int();
        Vector3 wInstantiationOffset = new Vector3(1.5f, -6.5f, 0f);
        while (wSeedsPlanted < 16)
        {
            wXPos = Random.Range(0, 9);
            wYPos = Random.Range(0, 9);
            wTempGridPosition.x = wXPos;
            wTempGridPosition.y = wYPos;
            if (!mFarmContents.ContainsKey(wTempGridPosition) &&
                !((wXPos == 0 && (wYPos == 0 || wYPos == 8)) || (wXPos == 8 && (wYPos == 0 || wYPos == 8))))
            {
                GameObject wSeed = Instantiate(vegetablePrefab,
                    new Vector3(wTempGridPosition.x + wInstantiationOffset.x,
                        wTempGridPosition.y + wInstantiationOffset.y,
                        +wInstantiationOffset.z),
                    Quaternion.identity);
                int wRandomVegType = Random.Range(0, 3);
                switch (wRandomVegType)
                {
                    case 0:
                        wSeed.GetComponentInChildren<Vegetable>().setType(Vegetable.VegetableType.potato);
                        break;
                    case 1:
                        wSeed.GetComponentInChildren<Vegetable>().setType(Vegetable.VegetableType.carrot);
                        break;
                    case 2:
                        wSeed.GetComponentInChildren<Vegetable>().setType(Vegetable.VegetableType.turnip);
                        break;
                }

                mFarmContents.Add(wTempGridPosition, new Vector2Int(wRandomVegType, 0));
                wSeedsPlanted++;
            }
        }


    }
    void loadField()
    {
        


    }

    void growField()
    {

    }

    void doneFarmPhase()
    {
        seedField();
        GameInfo.Instance.mFarmContents = mFarmContents;
        GameInfo.Instance.mPlayer1 = mPlayer1;
        GameInfo.Instance.mPlayer2 = mPlayer2;
        GameInfo.Instance.mPlayer3 = mPlayer3;
        GameInfo.Instance.mPlayer4 = mPlayer4;
        SceneManager.LoadScene("MarketScene");
    }
}
