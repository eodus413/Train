using UnityEngine;

public static class LayerMaskExtension
{
    public static int ToValue(this LayerMask mask)
    {
        int value = 0;
        int count = 0;
        int number = mask.value;
        while (number > 0)
        {
            if (number.isOddNumber())
            {
                count += value;
            }
            number /= 2;
            ++value;
        }
        return count;
    }
    public static bool isIncludeIt(this LayerMask mask, int layer)
    {
        return (layer & mask.ToValue()) > 0;
    }
}