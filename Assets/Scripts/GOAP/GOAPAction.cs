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
        public delegate bool Requirement();
        //Requirement requirement;

        public bool[] Requirements;
        public bool isPossible
        {
            get
            {
                IsPossible();
                return isPossible;
            }
            set
            {
                isPossible = value;
            }
        }
        private void IsPossible()
        {
            isPossible = true;
            foreach(bool i in Requirements)
                if(!i)
                {
                    isPossible = false;
                    return;
                } 
                    
        }
    }
}