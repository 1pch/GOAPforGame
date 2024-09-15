using UnityEngine;
using EntityController;
using GOAP;
using CharacterActions;
namespace CharacterController
{
    class Character : Entity
    {
        [SerializeField] public static GameObject[] gameObjects;
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
                ActionManager.MakeThread(new GOAPAction("makeThread", 1, new bool[]{inventoryManager.HasItem(new ItemController.Item(ItemController.Items.Wool, 2))}), this);
            }

            if(isMoving)
            {
                //transform.position += new Vector3(movementSpeed, 0, 0);
                transform.position += transform.forward * movementSpeed * Time.deltaTime;
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
