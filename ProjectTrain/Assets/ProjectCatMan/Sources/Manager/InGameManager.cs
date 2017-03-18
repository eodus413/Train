using UnityEngine;
using SingletonManager;
using UnityEngine.SceneManagement;

namespace ProjectCatMan
{
    public static class InGameManager
    {
        /// <summary>
        /// 고쳐야함 
        /// </summary>
        static UnitFactoryMethod factoryMethod = new KoreaUnitFactoryMethod();

        static UnitFactoryMethod koreaFactory = new KoreaUnitFactoryMethod();
        static UnitFactoryMethod chinaFactory = new ChinaUnitFactoryMethod();

        public static IUnitFactory currentFactory(UnitType type)
        {
            return factoryMethod.GetFactory(type);
        }
        public static void SetFactory(string sceneName)
        {
            if (sceneName == "Korea")
            {
                factoryMethod = koreaFactory;
            }
            else if (sceneName == "China")
            {
                factoryMethod = chinaFactory;
            }
        }
    }  
}