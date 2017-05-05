namespace VirtualJoyStick
{
    using System.Collections.Generic;
    public static class JoyStickManager
    {
        static List<JoyStick> joySticks = new List<JoyStick>();
        public static int GetNewID()
        {
            int lenght = joySticks.Count;
            int newID = 0;
            for(int i=0;i<lenght;++i)
            {
                if (joySticks[i].id != newID) return newID;
                ++newID;
            }
            return 0;
        }
        public static void AddJoyStick(JoyStick newJoyStick)
        {
            newJoyStick.id = GetNewID();
            joySticks.Add(newJoyStick);
        }
        public static JoyStick GetJoyStick(int id)
        {
            int lenght = joySticks.Count;
            for(int i=0;i<lenght;++i)
            {
                if (joySticks[i].id == id) return joySticks[i];
            }
            return null;
        }
    }
}
