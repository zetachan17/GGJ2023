using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class Customer : MonoBehaviour
{
    // GameObject _gameObject
    public PlayerAttributes.Powers power;
    // private enum Power
    // {
    //     Fire,
    //     Action,
    //     Block,
    //     Ice,
    //     Cat,
    //     Dog,
    //     Hairball
    // }
    

    public void SetUpCustomers(int type)
    {
        switch (type)
        {
            case 1:
                power = PlayerAttributes.Powers.Action;
                break;
            case 2:
                power = PlayerAttributes.Powers.Block;
                break;
            case 3:
                power = PlayerAttributes.Powers.Cat;
                break;
            case 4:
                power = PlayerAttributes.Powers.Dog;
                break;
            case 5:
                power = PlayerAttributes.Powers.Fire;
                break;
            case 6:
                power = PlayerAttributes.Powers.Hairball;
                break;
            case 7:
                power = PlayerAttributes.Powers.Ice;
                break;
            case 8:
                power = PlayerAttributes.Powers.None;
                break;
            case 9:
                power = PlayerAttributes.Powers.None;
                break;
            case 10:
                power = PlayerAttributes.Powers.None;
                break;
            case 11:
                power = PlayerAttributes.Powers.None;
                break;
            case 12:
                power = PlayerAttributes.Powers.None;
                break;
            case 13:
                power = PlayerAttributes.Powers.None;
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        gameObject.transform.localScale+=new Vector3(1,1,0);
        print("this is highlighted");
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        gameObject.transform.localScale-=new Vector3(1,1,0);
        print("this is leaving forever");
    }
    // private void OnColliderEnter2D(Collider2D other)
    // {
    //     print("this is highlighted");
    // }
}