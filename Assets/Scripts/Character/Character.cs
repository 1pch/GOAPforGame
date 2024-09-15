using UnityEngine;
using EntityController;
using GOAP;
using System;
namespace CharacterController
{
    class Character : Entity
    {
        [SerializeField] GameObject[] gameObjects;
        InventoryManager inventoryManager;
        public int energy;
        void Start()
        {
            inventoryManager = new(3);
            movementSpeed = 3f;
        }
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space) && isMoving == false)
            {
                MoveTo(gameObjects[0]);
            }
        }
        void Action1()
        {
            GOAPAction action = new("doSomething", 1 , new bool[]{energy > 1, 2 < 3});
        }

        /*class HasEnergy : Conditioton
        {
            Conditiotons conditioton;
            public override Func<bool> Requirement()
            {
                Func<bool> a = b;
                bool b() => true;
                return a;
            }

            
        }
        class hasMaterials : Conditioton
        {
            Conditioton condition;
            public override bool Requirement() => 
        }

        class hasMoney*/
    }
            
}
