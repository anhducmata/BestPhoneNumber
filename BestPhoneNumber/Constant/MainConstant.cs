using System;
using System.Collections.Generic;
using System.Text;

namespace BestPhoneNumber.Constant
{
    public class MainConstant
    {
        public static List<string> Ominous = new List<string>
        {
            "00", "66", "04", "45", "85", "27", "67", "17", "57", "97", "98", "58", "42", "82", "69"
        };

        public static List<string> Noble = new List<string>
        {
            "19", "24", "26", "37", "34"
        };

        public static List<List<int>> NiceSumOfNumber = new List<List<int>>
        {
            new List<int>
            {
                24,29
            },
            new List<int>
            {
                24,28
            }
        };

        public static int SumPhoneNumberTarget = 5;
    }
}
