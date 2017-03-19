namespace ProjectCatMan
{
    //초기화할 방법 생각
    public class ItemFactoryMethod
    {

        IItem[] weapons;
        public IItem GetWeapon(int code)
        {
            return weapons[code];
        }
    }
}