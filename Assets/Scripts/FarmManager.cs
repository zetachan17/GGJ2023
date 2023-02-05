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
    [SerializeField] int mTurn = 1;
    [SerializeField] GameObject mGrid;

    [SerializeField] PlayerAttributes mPlayer1;
    [SerializeField] PlayerAttributes mPlayer2;
    [SerializeField] PlayerAttributes mPlayer3;
    [SerializeField] PlayerAttributes mPlayer4;

    [SerializeField] GameObject mPlayer1GameObject;
    [SerializeField] GameObject mPlayer2GameObject;
    [SerializeField] GameObject mPlayer3GameObject;
    [SerializeField] GameObject mPlayer4GameObject;

    public Dictionary<Vector2Int, Vector2Int> mFarmContents;

    [SerializeField] GameObject vegetablePrefab;

    [SerializeField] Sprite mCatSprite;
    [SerializeField] Sprite mDogSprite;
    [SerializeField] Sprite mCapybaraSprite;
    [SerializeField] Sprite mDonkeySprite;


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
        mTurn = 1;
        setPlayerObjectSprites();
        mActivePlayer = mStartPlayer;
        if (mRound == 1)
        {
            mFarmContents = new Dictionary<Vector2Int, Vector2Int>();
            mStartPlayer = 1;
            populateInitialField();
        }
        else
        {
            mFarmContents = GameInfo.Instance.mFarmContents;
            loadField();
            mStartPlayer = GameInfo.Instance.mStartPlayer;
        }
        //TODO: Check if any player has teleport power
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void endPlayerTurn(PlayerAttributes iPlayerAttributes, Vector2Int iPlayerPosition)
    {
        mActivePlayer++;
        if (mActivePlayer == 5) mActivePlayer = 1;
        if (mActivePlayer == mStartPlayer) mTurn++;
        if (mTurn == 6) doneFarmPhase();

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
                !((wXPos == 0 && (wYPos == 0 || wYPos == 8)) || (wXPos == 8 && (wYPos == 0 || wYPos == 8)))) {
                GameObject wSeed = Instantiate(vegetablePrefab,
                    new Vector3(wTempGridPosition.x + wInstantiationOffset.x,
                        wTempGridPosition.y + wInstantiationOffset.y,
                        +wInstantiationOffset.z),
                    Quaternion.identity);
                int wRandomVegType = Random.Range(0, 3);
                switch (wRandomVegType) {
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
                wSeed.name = "Veg_" + wTempGridPosition.x + "_" + wTempGridPosition.y;
                wSeedsPlanted++;
            }
        }

    }

    void seedField()
    {
        int wSeedsPlanted = 0;
        int wFailedAttempts = 0;
        int wXPos;
        int wYPos;
        Vector2Int wTempGridPosition = new Vector2Int();
        Vector3 wInstantiationOffset = new Vector3(1.5f, -6.5f, 0f);
        while (wSeedsPlanted < 16 && wFailedAttempts < 81)
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
                wSeed.name = "Veg_" + wTempGridPosition.x + "_" + wTempGridPosition.y;
                wSeedsPlanted++;
            }
            else 
                wFailedAttempts++;
        }


    }
    void loadField()
    {
        Vector3 wInstantiationOffset = new Vector3(1.5f, -6.5f, 0f);
        foreach (KeyValuePair<Vector2Int, Vector2Int> wEntry in mFarmContents)
        {
            GameObject wSeed = Instantiate(vegetablePrefab,
                    new Vector3(wEntry.Key.x + wInstantiationOffset.x,
                        wEntry.Key.y + wInstantiationOffset.y,
                        +wInstantiationOffset.z),
                    Quaternion.identity);
            switch (wEntry.Value.x)
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
            wSeed.GetComponentInChildren<Vegetable>().setSize(wEntry.Value.y);
            wSeed.name = "Veg_" + wEntry.Key.x + "_" + wEntry.Key.y;
        }


    }

    public void harvestVegetable(Vector2Int iPosition)
    {
        mFarmContents.Remove(iPosition);
    }

    void growField()
    {
        foreach (KeyValuePair<Vector2Int, Vector2Int> wEntry in mFarmContents)
        {
            if (wEntry.Value.y > 4)
            {
                Vector2Int wNewVeg = new Vector2Int(wEntry.Value.x, wEntry.Value.y + 1);
                Vector2Int wLocation = wEntry.Key;
                mFarmContents.Remove(wEntry.Key);
                mFarmContents.Add(wLocation, wNewVeg);
            }
        }
        
    }

    void setPlayerObjectSprites()
    {

        switch (mPlayer1.ChosenAnimal)
        {
            case 1:
                mPlayer1GameObject.GetComponent<SpriteRenderer>().sprite = mCatSprite;
                break;
            case 2:
                mPlayer1GameObject.GetComponent<SpriteRenderer>().sprite = mDogSprite;
                break;
            case 3:
                mPlayer1GameObject.GetComponent<SpriteRenderer>().sprite = mCapybaraSprite;
                break;
            case 4:
                mPlayer1GameObject.GetComponent<SpriteRenderer>().sprite = mDonkeySprite;
                break;
        }
        switch (mPlayer2.ChosenAnimal)
        {
            case 1:
                mPlayer2GameObject.GetComponent<SpriteRenderer>().sprite = mCatSprite;
                break;
            case 2:
                mPlayer2GameObject.GetComponent<SpriteRenderer>().sprite = mDogSprite;
                break;
            case 3:
                mPlayer2GameObject.GetComponent<SpriteRenderer>().sprite = mCapybaraSprite;
                break;
            case 4:
                mPlayer2GameObject.GetComponent<SpriteRenderer>().sprite = mDonkeySprite;
                break;
        }
        switch (mPlayer3.ChosenAnimal)
        {
            case 1:
                mPlayer3GameObject.GetComponent<SpriteRenderer>().sprite = mCatSprite;
                break;
            case 2:
                mPlayer3GameObject.GetComponent<SpriteRenderer>().sprite = mDogSprite;
                break;
            case 3:
                mPlayer3GameObject.GetComponent<SpriteRenderer>().sprite = mCapybaraSprite;
                break;
            case 4:
                mPlayer3GameObject.GetComponent<SpriteRenderer>().sprite = mDonkeySprite;
                break;
        }
        switch (mPlayer4.ChosenAnimal)
        {
            case 1:
                mPlayer4GameObject.GetComponent<SpriteRenderer>().sprite = mCatSprite;
                break;
            case 2:
                mPlayer4GameObject.GetComponent<SpriteRenderer>().sprite = mDogSprite;
                break;
            case 3:
                mPlayer4GameObject.GetComponent<SpriteRenderer>().sprite = mCapybaraSprite;
                break;
            case 4:
                mPlayer4GameObject.GetComponent<SpriteRenderer>().sprite = mDonkeySprite;
                break;
        }
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
