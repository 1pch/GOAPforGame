using UnityEngine;
using GOAP;
using EntityController;
using CharacterController;
using GameUtils;
using System;
using ItemController;
using Unity.VisualScripting;
using TMPro;
namespace CharacterActions
{
    class ActionManager : MonoBehaviour
    {
        public ActionManager(Character character)
        {
            _character = character;
        }

        public void SetAutor(Character character)
        {
            _character = character;
        }
        private Character _character;
        public void MakeThread(GOAPAction action)
        {
            if(action.isPossible())
            {
                _character.energy -= action.Cost;
                _character.MoveTo(_character.gameObjects[0]);
            }
        }

        public void PaintFabric(GOAPAction action)
        {
            if(action.isPossible())
            {
                _character.energy -= action.Cost;
                _character.MoveTo(_character.gameObjects[1]);
            }
        }

        public void SellFabric(GOAPAction action)
        {
            if(action.isPossible())
            {
                _character.energy -= action.Cost;
                _character.MoveTo(_character.gameObjects[2]);
            }
        }

        public void Sleep(GOAPAction action)
        {
            if(action.isPossible())
            {
                _character.energy -= action.Cost;
                _character.MoveTo(_character.gameObjects[3]);
            }
        }

        void OnTriggerEnter(Collider collider)
        {
            if(collider.tag == _character.gameObjects[0].tag)
            {
                _character.inventoryManager.RemoveItem(new Item(Items.Wool, 2));
                _character.inventoryManager.AddItem(new Item(Items.Fabric, 1));
                Debug.Log("Done Fabric");
            }
            if(collider.tag == _character.gameObjects[1].tag)
            {
                for(int i = 0; i < _character.inventoryManager.Inventory.Length; i++)
                {
                    if(_character.inventoryManager.Inventory[i].item == Items.Fabric)
                    {
                        _character.inventoryManager.Inventory[i].attributes.Add("Color", "Red");
                        return;
                    }
                }
                Debug.Log("Fabric painted");
            }
            if(collider.tag == _character.gameObjects[2].tag && _character.inventoryManager.HasItem(Items.Fabric))
            {
                _character.inventoryManager.wallet += _character.inventoryManager.GetItem(Items.Fabric).amount * 3;
                _character.inventoryManager.RemoveItem(Items.Fabric);
            }
            else if(collider.tag == _character.gameObjects[2].tag && _character.inventoryManager.wallet != 0)
            {
                _character.inventoryManager.AddItem(new Item(Items.Wool, (UInt16)(_character.inventoryManager.wallet/2)));
                _character.inventoryManager.wallet -= _character.inventoryManager.wallet/2;
            }
            if(collider.tag == _character.gameObjects[3].tag)
            {
                _character.energy += 5;
            }
        }
    }

    /*class MakeThread : ActionManager
    {
        public MakeThread(GOAPAction action, Character character) : base(action, character){}

        public override GOAPAction action { get; set; }
        public override Character character { get; set; }

        public void MakeThread()
        {
            if(action.isPossible)
            {
                character.MoveTo(Character.gameObjects[0]);
                while(character.isMoving);
            }
        }
    }*/
}




class Test
{
    void GetRectangleData(int width, int height, out int rectArea, out int rectPerimetr)
{
    rectArea = width * height;  
    rectPerimetr = (width + height) * 2; 
}
 void Do()
 {

    GetRectangleData(10, 20, out int area, out int perimetr);  
 }
}


abstract class ActionBase : MonoBehaviour
{
    public ActionBase(GOAPAction action, Character character)
    {
        this.action = action;
        this.character = character;
    }
    Character character {get; set;}
    GOAPAction action {get; set;}
   public abstract void Action();
}

class MakeFabric : ActionBase
{
    public MakeFabric(GOAPAction action, Character Autor) : base(action, Autor) {}
    Character character {get; set;}
    GOAPAction action {get; set;}
    public override void Action()
    {
        if(action.isPossible())
            {
                character.energy -= action.Cost;
                character.MoveTo(character.gameObjects[0]);
            }
    }
    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == character.gameObjects[0].tag)
        {
            character.inventoryManager.RemoveItem(new Item(Items.Wool, 2));
            character.inventoryManager.AddItem(new Item(Items.Fabric, 1));
            Debug.Log("Done Fabric");
        }
    }
}

class PaintFabric : ActionBase
{
    public PaintFabric(GOAPAction action, Character character) : base(action, character) {}
    Character character {get; set;}
    GOAPAction action {get; set;}

    public override void Action()
    {
        if(action.isPossible())
        {
            character.energy -= action.Cost;
            character.MoveTo(character.gameObjects[1]);
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == character.gameObjects[1].tag)
        {
            for(int i = 0; i < character.inventoryManager.Inventory.Length; i++)
            {
                if(character.inventoryManager.Inventory[i].item == Items.Fabric)
                {
                    character.inventoryManager.Inventory[i].attributes.Add("Color", "Red");
                    return;
                }
            }
            Debug.Log("Fabric painted");
        }
    }
}

class SellFabric : ActionBase
{
    public SellFabric(GOAPAction action, Character character) : base(action, character) {}
    Character character {get; set;}
    GOAPAction action {get; set;}

    public override void Action()
    {
        
    }
    void OnTriggerEnter(Collider collider)
    {
        
    }
}