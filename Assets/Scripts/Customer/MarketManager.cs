using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Random = System.Random;

public class MarketManager : MonoBehaviour
{
    public GameObject spawnee;

    public GameObject vegeList;

    public Sprite[] mySpr;

    public Sprite[] powerSprites;

    public Sprite[] vegeSprite;

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

        int[] customerList = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11};
        Byte[] buffer = Guid.NewGuid().ToByteArray();
        int iSeed = BitConverter.ToInt32(buffer, 0);
        Random random = new Random(iSeed);
        var newList = customerList.OrderBy(x => random.Next()).ToArray();
        // foreach (var integer in newList)
        // {
        //     print(integer);
        // }


        for (int i = 0; i < customersPos.Length - 2; i++)
        {
            GameObject spawneee = Instantiate(spawnee, customersPos[i], transform.rotation);
            spawneee.AddComponent<Customer>().SetUpCustomers(newList[i]);
            spawneee.GetComponent<SpriteRenderer>().sprite = mySpr[newList[i] - 1];

            string power = spawneee.GetComponent<Customer>().getPower();
            print(power);
            if (!power.Equals("None"))
            {
                switch (power)
                {
                    case "DoublePoints":
                        spawneee.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = powerSprites[0];
                        break;
                    case "Teleport":
                        spawneee.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = powerSprites[1];
                        break;
                    case "ApBoost":
                        spawneee.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = powerSprites[2];
                        break;
                    case "AdjacentVeggie":
                        spawneee.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = powerSprites[3];
                        break;
                    case "ReducePull":
                        spawneee.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = powerSprites[4];
                        break;
                    case "Block":
                        spawneee.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = powerSprites[5];
                        break;
                    case "PriceBoost":
                        spawneee.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = powerSprites[6];
                        break;
                }
            }

            Dictionary<Vegetable.VegetableType, int> quest = spawneee.GetComponent<Customer>().getQuest();
            int counter = 1;
            foreach (var vege in quest)
            {
                switch (vege.Key)
                {
                    case Vegetable.VegetableType.carrot:
                        
                        spawneee.transform.GetChild(counter).GetComponent<SpriteRenderer>().sprite = vegeSprite[0];
                        for(int j = 0; j < vege.Value; j++)
                        {
                            Instantiate(spawneee.transform.GetChild(counter), new Vector3(spawneee.transform.GetChild(counter).transform.position.x + 0.1f * (j + 1), spawneee.transform.GetChild(counter).transform.position.y, spawneee.transform.GetChild(counter).transform.position.z), Quaternion.identity, spawneee.transform);
                        }
                        // print("1 "+spawneee.transform.GetChild(counter).GetChild(0));
                        // print("2 "+ spawneee.transform.GetChild(counter).GetChild(0).GetChild(0));
                        // print("3 "+spawneee.transform.GetChild(counter).GetChild(0).GetChild(0).GetChild(0));
                        spawneee.transform.GetChild(counter).GetChild(0).GetChild(0).GetComponent<TMP_Text>()
                            .SetText(" x ");
                        ;
                        counter++;
                        break;
                    case Vegetable.VegetableType.potato:
                        spawneee.transform.GetChild(counter).GetComponent<SpriteRenderer>().sprite = vegeSprite[1];

                        for (int j = 0; j < vege.Value; j++)
                        {
                            Instantiate(spawneee.transform.GetChild(counter), new Vector3(spawneee.transform.GetChild(counter).transform.position.x + 0.1f * (j + 1), spawneee.transform.GetChild(counter).transform.position.y, spawneee.transform.GetChild(counter).transform.position.z), Quaternion.identity, spawneee.transform);
                        }

                        spawneee.transform.GetChild(counter).GetChild(0).GetChild(0).GetComponent<TMP_Text>()
                            .SetText(" x ");

                        counter++;
                        break;
                    case Vegetable.VegetableType.turnip:
                        spawneee.transform.GetChild(counter).GetComponent<SpriteRenderer>().sprite = vegeSprite[2];

                        for (int j = 0; j < vege.Value; j++)
                        {
                            Instantiate(spawneee.transform.GetChild(counter), new Vector3(spawneee.transform.GetChild(counter).transform.position.x + 0.1f*(j+1), spawneee.transform.GetChild(counter).transform.position.y, spawneee.transform.GetChild(counter).transform.position.z), Quaternion.identity, spawneee.transform);
                        }
                        spawneee.transform.GetChild(counter).GetChild(0).GetChild(0).GetComponent<TMP_Text>()
                            .SetText(" x ");

                        counter++;
                        break;
                }
            }

            while (counter <= 3)
            {
                spawneee.transform.GetChild(counter).GetComponent<SpriteRenderer>().sprite = null;
                counter++;
            }
        }

        GameObject coolGuy = Instantiate(spawnee, customersPos[6], transform.rotation);
        coolGuy.AddComponent<Customer>().SetUpCustomers(12);
        coolGuy.GetComponent<SpriteRenderer>().sprite = mySpr[11];
        coolGuy.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = powerSprites[7];
        foreach (var vege in coolGuy.GetComponent<Customer>().getQuest())
        {
            switch (vege.Key)
            {
                case Vegetable.VegetableType.carrot:
                    coolGuy.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = vegeSprite[0];
                    break;
                case Vegetable.VegetableType.potato:
                    coolGuy.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = vegeSprite[1];
                    break;
                case Vegetable.VegetableType.turnip:
                    coolGuy.transform.GetChild(3).GetComponent<SpriteRenderer>().sprite = vegeSprite[2];
                    break;
            }
        }


        GameObject soupGuy = Instantiate(spawnee, customersPos[7], transform.rotation);
        soupGuy.AddComponent<Customer>().SetUpCustomers(13);
        soupGuy.GetComponent<SpriteRenderer>().sprite = mySpr[12];
        soupGuy.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = null;
        soupGuy.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = null;
        soupGuy.transform.GetChild(3).GetComponent<SpriteRenderer>().sprite = null;
    }


    // Update is called once per frame
    void Update()
    {
    }
}