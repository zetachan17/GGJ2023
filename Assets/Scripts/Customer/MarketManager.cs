using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class MarketManager : MonoBehaviour
{
    public GameObject spawnee;

    public Sprite[] mySpr;

    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(CreateCustomers), 0);
    }

    public void CreateCustomers()
    {
        Vector3 customerOnePos = new Vector3(-3, 1, -1);
        Vector3 customerTwoPos = new Vector3(-1, 1, -1);
        Vector3 customerThreePos = new Vector3(1, 1, -1);
        Vector3 customerFourPos = new Vector3(3, 1, -1);
        Vector3 customerFivePos = new Vector3(-3, -2, -1);
        Vector3 customerSixPos = new Vector3(-1, -2, -1);
        Vector3 customerSevenPos = new Vector3(1, -2, -1);
        Vector3 soupGuyPos = new Vector3(3, -2, -1);

        Vector3[] customersPos =
        {
            customerOnePos, customerTwoPos, customerThreePos, customerFourPos, customerFivePos, customerSixPos,
            customerSevenPos, soupGuyPos
        };

        int[] customerList = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12};
        Byte[] buffer = Guid.NewGuid().ToByteArray();
        int iSeed = BitConverter.ToInt32(buffer, 0);
        Random random = new Random(iSeed);
        var newList = customerList.OrderBy(x => random.Next()).ToArray();
        foreach (var integer in newList)
        {
            print(integer);
        }


        for (int i = 0; i < customersPos.Length-1; i++)
        {
            GameObject spawneee = Instantiate(spawnee, customersPos[i], transform.rotation);
            spawneee.AddComponent<Customer>().SetUpCustomers(newList[i]);
            
            spawneee.GetComponent<SpriteRenderer>().sprite = mySpr[newList[i]];
            
            
        }
        GameObject soupGuy =Instantiate(spawnee, customersPos[7], transform.rotation);
        soupGuy.AddComponent<Customer>().SetUpCustomers(13);
            
        soupGuy.GetComponent<SpriteRenderer>().sprite = mySpr[12];
    }


    // Update is called once per frame
    void Update()
    {
    }
}