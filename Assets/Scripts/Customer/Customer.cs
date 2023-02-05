using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    // GameObject _gameObject
    private Power _power;
    
    public void SetUpCustomers(int type)
    {
        switch (type)
        {
            case 1:
                _power = Power.Action;
                break;
            case 2:
                _power = Power.Block;
                break;
            case 3:
                _power = Power.Cat;
                break;
            case 4:
                _power = Power.Dog;
                break;
            case 5:
                _power = Power.Fire;
                break;
            case 6:
                _power = Power.Hairball;
                break;
            case 7:
                _power = Power.Ice;
                break;
            case 8:
                _power = Power.None;
                break;
            case 9:
                _power = Power.None;
                break;
            case 10:
                _power = Power.None;
                break;
            case 11:
                _power = Power.None;
                break;
            case 12:
                _power = Power.None;
                break;
            case 13:
                _power = Power.None;
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

    public string getPower()
    {
        return _power.ToString();
        
    }
    // private void OnColliderEnter2D(Collider2D other)
    // {
    //     print("this is highlighted");
    // }
}

public enum Power
{
    Fire,
    Action,
    Block,
    Ice,
    Cat,
    Dog,
    Hairball,
    None
    
}