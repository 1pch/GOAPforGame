using UnityEngine;
using EntityController;
using GOAP;
using CharacterActions;
using System.Data;
using System.Linq;
namespace CharacterController
{
    class Character : Entity
    {
        [SerializeField] public GameObject[] gameObjects;
        public InventoryManager inventoryManager;
        public int energy;
        ActionManager actionManager;
        void Start()
        {
            inventoryManager = new(3);
            movementSpeed = 3f;
            energy = 6;
            inventoryManager.Inventory[0] = new(ItemController.Items.Wool, 3);
            actionManager = GetComponent<ActionManager>();
            actionManager.SetAutor(this);
            //gameObjects[0] = GameObject.Find("Table");
        }
        void Update()
        {
            //if(Input.GetKeyDown(KeyCode.Space))
            //{
                PrintInventory();
                actionManager.MakeThread(new GOAPAction("makeThread", 2, new bool[]{2 <= energy,inventoryManager.HasItem(new ItemController.Item(ItemController.Items.Wool, 2))}));
                actionManager.PaintFabric(new GOAPAction("paintFabric", 1, new bool[]{1 <= energy,inventoryManager.HasItem(ItemController.Items.Fabric)}));
                actionManager.SellFabric(new GOAPAction("sellFabric", 1, new bool[]{1 <= energy,inventoryManager.HasItem(ItemController.Items.Fabric),inventoryManager.FindItem(ItemController.Items.Fabric).attributes.ContainsKey("Color")}));
                actionManager.Sleep(new GOAPAction("sleep", 0, new bool[]{0 <= energy}));
            //}

            if(isMoving)
            {
                //transform.position += new Vector3(movementSpeed, 0, 0);
                transform.position += transform.forward * movementSpeed * Time.deltaTime;
            }
            if(Input.GetKeyDown(KeyCode.E))
            {
                PrintInventory();
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

        public void PrintInventory()
        {
            string text = $"energy - {energy}; ";
            for(int i = 0; i < inventoryManager.Inventory.Length; i++)
            {
                if(inventoryManager.Inventory[i] != null)
                {
                    text += $"{inventoryManager.Inventory[i].item} - {inventoryManager.Inventory[i].amount} ";
                    if(inventoryManager.Inventory[i].attributes != null)
                    {
                        text += "[";
                        foreach(var att in inventoryManager.Inventory[i].attributes)
                        {
                            text += $"{att.Key}: {att.Value}";
                        }
                        text += "]";
                    }
                }
            }
            Debug.Log(text);
        }
    }
            
}
