using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FarmManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] int mStartPlayer;
    [SerializeField] int mActivePlayer;
    [SerializeField] int mRound;
    [SerializeField] int mTurn;
    [SerializeField] GameObject mGrid;

    [SerializeField] PlayerAttributes mPlayer1;
    [SerializeField] PlayerAttributes mPlayer2;
    [SerializeField] PlayerAttributes mPlayer3;
    [SerializeField] PlayerAttributes mPlayer4;

    List<KeyValuePair<Vector2Int, Vector2Int>> mFarmContents;



    private void Awake()
    {
        mRound = GameInfo.Instance.mRound;
        mStartPlayer = GameInfo.Instance.mStartPlayer;
        mPlayer1 = GameInfo.Instance.mPlayer1;
        mPlayer2 = GameInfo.Instance.mPlayer2;
        mPlayer3 = GameInfo.Instance.mPlayer3;
        mPlayer4 = GameInfo.Instance.mPlayer4;

    }
    void Start()
    {
        if (mRound == 1)
        {
            populateInitialField();
        }
        //TODO: Generate Customers - push info to UI and gameinfo instance
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void populateInitialField()
    {
        //TODO: Add logic to instantiate field for first time, add info to list
    }

    void seedField()
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
