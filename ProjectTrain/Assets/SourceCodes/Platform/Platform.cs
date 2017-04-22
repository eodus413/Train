public static class Platform
{
    enum Type
    {
        Mobile,
        PC
    }
    static Type type = Type.Mobile;
    public static bool isPC()
    {
        return type == Type.PC;
    }
    public static void SetPC() { type = Type.PC; }
    public static void SetMobile() { type = Type.Mobile; }
}