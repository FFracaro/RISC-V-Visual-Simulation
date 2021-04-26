using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinaryToDecimal : MonoBehaviour
{
    public int BinToDec(string n)
    {
        string num = n;
        int dec_value = 0;

        // Initializing base value to 1,
        // i.e 2^0
        int base1 = 1;

        int len = num.Length;
        for (int i = len - 1; i >= 0; i--)
        {
            if (num[i] == '1')
                dec_value += base1;
            base1 = base1 * 2;
        }

        return dec_value;
    }
}
