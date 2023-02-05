using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using System;

public class Vegetable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public enum VegetableType
    {
        potato,
        carrot,
        turnip,
        garlic
    }

   

    [SerializeField] int mSize = 0;
    [SerializeField] VegetableType mType = VegetableType.potato;

    [SerializeField] bool mInGround = true;
    [SerializeField] GameObject mInfoPanel;
    [SerializeField] TMP_Text mInfoPanelText;

    [SerializeField] float mTimerDelay = 0.5f;

    bool mInfoTextOn = false;
    bool mMouseOn = false;
    bool mTimerStarted = false;

    float mTimerStartTime;
    SpriteRenderer mSpriteRenderer;

    public void setType(VegetableType type)
    {
        mType = type;
    }

    public string getType()
    {
        return mType.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        mSpriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();
    }

    
    // Update is called once per frame
    void Update()
    {
        checkSprite();
        if (!mInfoTextOn && mMouseOn && mTimerStarted)
        {
            if (Time.time > mTimerStartTime + mTimerDelay)
            {
                generateText();
                mInfoPanel.SetActive(true);
                mInfoTextOn = true;
            }
        }
    }

    public void grow()
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

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("mousey is in the henhouse");
        if (!mTimerStarted)
        {
            mMouseOn = true;
            mTimerStarted = true;
            mTimerStartTime = Time.time;
        }
    }

    internal void setSize(int iRandomVegSize)
    {
        mSize = iRandomVegSize;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mMouseOn = false;
        mTimerStarted = false;
        if (mInfoTextOn)
        {
            mInfoTextOn = false;
            mInfoPanel.SetActive(false);
        }
    }


    void generateText()
    {
        string wText = "A";

        switch (mSize)
        {
            case 0:
                wText += " Seedling";
                break;
            case 1:
                wText += " Small";
                break;
            case 2:
                wText += " Medium Sized";
                break;
            case 3:
                wText += " Big";
                break;
            case 4:
                wText += " Huge";
                break;
            default:
                return;
        }
        switch (mType)
        {
            case VegetableType.potato:
                wText += "\nPotato";
                break;
            case VegetableType.carrot:
                wText += "\nCarrot";
                break;
            case VegetableType.turnip:
                wText += "\nTurnip";
                break;
            case VegetableType.garlic:
                wText += "\nGarlic Bulb";
                break;
            default:
                return;
        }

        if (mInGround) wText += "\nready for harvest";
        wText += ".";
        mInfoPanelText.SetText(wText);
    }
}
