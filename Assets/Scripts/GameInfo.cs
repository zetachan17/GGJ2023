using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameInfo : MonoBehaviour
{

    public static GameInfo Instance;

    //FarmContents
    public Dictionary<Vector2Int, Vector2Int> mFarmContents { get; set; }

    //PlayerInfo

    /*
    public List<Vector2Int> mPlayer1Inventory { get; set; }
    public List<Vector2Int> mPlayer2Inventory { get; set; }
    public List<Vector2Int> mPlayer3Inventory { get; set; }
    public List<Vector2Int> mPlayer4Inventory { get; set; }
    public int mPlayer1Score { get; set; }
    public int mPlayer2Score { get; set; }
    public int mPlayer3Score { get; set; }
    public int mPlayer4Score { get; set; }
    public string mPlayer1Name { get; set; }
    public string mPlayer2Name { get; set; }
    public string mPlayer3Name { get; set; }
    public string mPlayer4Name { get; set; }
    public int mPlayer1Avatar { get; set; }
    public int mPlayer2Avatar { get; set; }
    public int mPlayer3Avatar { get; set; }
    public int mPlayer4Avatar { get; set; }
    public List<int> mPlayer1Powers { get; set; }
    public List<int> mPlayer2Powers { get; set; }
    public List<int> mPlayer3Powers { get; set; }
    public List<int> mPlayer4Powers { get; set; }

    

    public bool mPlayer1LeftFarm { get; set; }
    public bool mPlayer2LeftFarm { get; set; }
    public bool mPlayer3LeftFarm { get; set; }
    public bool mPlayer4LeftFarm { get; set; }

    public int mFirstToLeaveFarm { get; set; }
    public int mSecondToLeaveFarm { get; set; }
    public int mThirdToLeaveFarm { get; set; }
    public int mFourthToLeaveFarm { get; set; }
    */

    [SerializeField] public PlayerAttributes mPlayer1;
    [SerializeField] public PlayerAttributes mPlayer2;
    [SerializeField] public PlayerAttributes mPlayer3;
    [SerializeField] public PlayerAttributes mPlayer4;
    public int mRound { get; set; }

    public int mStartPlayer { get; set; }
    //Customers
    public int mCustomer1 { get; set; }
    public int mCustomer2 { get; set; }
    public int mCustomer3 { get; set; }
    public int mCustomer4 { get; set; }
    public int mCustomer5 { get; set; }
    public int mCustomer6 { get; set; }

    public List<int> mCustomer1Demand { get; set; }
    public List<int> mCustomer2Demand { get; set; }
    public List<int> mCustomer3Demand { get; set; }
    public List<int> mCustomer4Demand { get; set; }
    public List<int> mCustomer5Demand { get; set; }

    public List<int> mCustomer6Demand { get; set; }

    // Start is called before the first frame update
    void Awake()
    {
        mFarmContents = new Dictionary<Vector2Int, Vector2Int>();
        DontDestroyOnLoad(gameObject);
        Instance = this;
        mRound = 1;
    }


    // Update is called once per frame



}
