using System;
using System.Collections.Generic;
using UnityEngine;


namespace Player
{
    public class PlayerAttributes : MonoBehaviour
    {
        //player position
        [SerializeField] private Vector2 playerPosition;
    
        //AP
        [SerializeField] private int maxAP = 6;
        private int currentAP;
    
        //a enum that has powers
        public enum Powers
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


        //a list of all the vegetables the player has
        private List<Vegetable> vegetables = new List<Vegetable>();
        
        // a list of powers the player has
        private List<Powers> powers = new List<Powers>();
        
        //bool if the player has left
        private bool hasLeft = false;
        
        // Start is called before the first frame update
        void Start()
        {
            currentAP = maxAP;
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    
        //getters and setters
        public List<Vegetable> Vegetables
        {
            get => vegetables;
            set => vegetables = value;
        }

        //add a vegetable to the list
        public void AddVegetable(Vegetable vegetable)
        {
            vegetables.Add(vegetable);
        }
    
        //remove a vegetable from the list
        public void RemoveVegetable(Vegetable vegetable)
        {
            vegetables.Remove(vegetable);
        }
    
        //getter and setter for the player position
        public Vector2 PlayerPosition
        {
            get => playerPosition;
            set => playerPosition = value;
        }
    
        //getter and setter for has left
        public bool HasLeft
        {
            get => hasLeft;
            set => hasLeft = value;
        }

        private void MoveToGrid(Vector2 TargetPosition)
        {
            //move the player to the grid position
            if (!hasLeft)
            {
                //roundedUp = (int)Math.Ceiling(precise);
                int APNeeded = (int)Math.Ceiling(Math.Abs(TargetPosition.x - playerPosition.x) + Math.Abs(TargetPosition.y - playerPosition.y));
            
                if (APNeeded <= currentAP)
                {
                    currentAP -= APNeeded;
                    playerPosition = TargetPosition;
                }
            }
        }

    }
}

