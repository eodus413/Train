using UnityEngine;
using SingletonManager;
using UnityEngine.SceneManagement;

namespace ProjectCatMan
{
    public class InGameManager
    {
        static UnitFactoryMethod factoryMethod;
        public static IUnitFactory currentFactory(UnitType type)
        {
            return factoryMethod.GetFactory(type);
        }
        public static void SetFactory(string sceneName)
        {
            if (sceneName == "Korea")
            {
                factoryMethod = new KoreaUnitFactoryMethod();
            }
            else if (sceneName == "China")
            {
                factoryMethod = new ChinaUnitFactoryMethod();
            }
        }
    }  
}