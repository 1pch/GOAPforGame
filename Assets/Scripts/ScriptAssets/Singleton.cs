using UnityEditorInternal;

namespace GameUtils
{
    class Singleton<T> where T: new()
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