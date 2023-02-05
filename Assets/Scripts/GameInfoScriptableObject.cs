using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "GameInfoScriptableObject", menuName = "Scriptable/GameInfoScriptableObject")]
public class GameInfoScriptableObject : ScriptableObject
{


    List<KeyValuePair<Vector2Int, Vector2Int>> mFarmContents;
    List<Vector2Int> mPlayer1Inventory;
    List<Vector2Int> mPlayer2Inventory;
    List<Vector2Int> mPlayer3Inventory;
    List<Vector2Int> mPlayer4Inventory;
    int mPlayer1Score;
    int mPlayer2Score;
    int mPlayer3Score;
    int mPlayer4Score;

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
