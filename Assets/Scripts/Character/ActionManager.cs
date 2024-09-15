using UnityEngine;
using GOAP;
using EntityController;
using CharacterController;
namespace CharacterActions
{
    class ActionManager : MonoBehaviour
    {
        public static void MakeThread(GOAPAction action, Character character)
        {
            if(action.isPossible)
            {
                character.MoveTo(Character.gameObjects[0]);
                while(character.isMoving);
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