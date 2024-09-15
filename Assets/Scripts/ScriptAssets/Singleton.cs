using UnityEditorInternal;
using UnityEngine;

namespace GameUtils
{
    class Singleton<T> : MonoBehaviour where T: new()
    {
        protected static T instance;

        public static T GetInstace() 
        {
            if(instance == null)
            {
                instance = new T();
            }
            return instance;
        }
    }
}