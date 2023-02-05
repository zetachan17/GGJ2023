using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    List<KeyValuePair<Vector2Int, string>> mFarmContents;

    private void Awake()
    {
        
    }
    void Start()
    {
        if (mRound == 1)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void populateField()
    {

    }

    void saveField()
    {

    }
}
