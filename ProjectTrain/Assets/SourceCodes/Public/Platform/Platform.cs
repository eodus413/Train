public static class Platform
{
    public enum Type
    {
        Mobile,
        PC
    }

    //Platform Default Mode
    static Type _type = Type.Mobile;
    public static Type type { get { return _type; } private set { _type = value; } }
    public static bool isPC()
    {
        return type == Type.PC;
    }
    public static void SetPC() { type = Type.PC; }
    public static void SetMobile() { type = Type.Mobile; }
}