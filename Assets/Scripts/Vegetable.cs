using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vegetable : MonoBehaviour
{
    enum VegetableType
    {
        potato,
        carrot,
        turnip,
        garlic
    }

   

    [SerializeField] int mSize;
    [SerializeField] VegetableType mType;

    [SerializeField] bool mInGround = true;



    SpriteRenderer mSpriteRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        mSpriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        checkSprite();
    }

    void grow()
    {
        if (mSize < 4) mSize += 1;
    }

    void checkSprite()
    {
        string wSpritePath = "VeggieSprites/";
        switch (mType)
        {
            case VegetableType.potato:
                wSpritePath += "Potato";
                break;
            case VegetableType.carrot:
                wSpritePath += "Carrot";
                break;
            case VegetableType.turnip:
                wSpritePath += "Turnip";
                break;
            case VegetableType.garlic:
                wSpritePath += "Garlic";
                break;
            default:
                return;
        }
        switch (mSize)
        {
            case 0:
                wSpritePath += "Seed";
                break;
            case 1:
                wSpritePath += "Small";
                break;
            case 2:
                wSpritePath += "Medium";
                break;
            case 3:
                wSpritePath += "Big";
                break;
            case 4:
                wSpritePath += "Huge";
                break;
            default:
                return;
        }

        if(!mInGround) wSpritePath += "Not";
        wSpritePath += "InGround";
        Sprite wSprite;
        try
        {
            wSprite = Resources.Load<Sprite>(wSpritePath);
        }
        catch
        {
            return;
        }
        mSpriteRenderer.sprite = wSprite;

    }

}
