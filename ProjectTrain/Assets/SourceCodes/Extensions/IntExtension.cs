public static class IntExtension
{
    public static bool isEvenNumber(this int number)
    {
        return (1 & number) == 0;
    }
    public static bool isOddNumber(this int number)
    {
        return (1 & number) != 0;
    }
}