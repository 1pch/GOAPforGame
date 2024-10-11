using CharacterController;
using Unity.VisualScripting;
namespace GOAP
{
    public struct GOAPAction
    {
        public GOAPAction(string name, short cost, bool[] Requirements)
        {
            Name = name;
            Cost = cost;
            //this.requirement = requirement;
            this.Requirements = Requirements;
        }
        string Name{get;}
        public short Cost{get;}
        //object[] RequirementConditions{get;}
        //public delegate bool Requirement();
        //Requirement requirement;

        public bool[] Requirements;
        /*private bool _isPossible
        {
            get
            {
                isPossible()
            }
        }*/
        public bool isPossible()
        {
            foreach(bool i in Requirements)
            {
                if(!i)
                {
                    return false;
                } 
            }
            return true;          
        }
    }
}