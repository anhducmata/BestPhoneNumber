using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BestPhoneNumber.Services
{
    public class CommonService
    {
        public List<string> ReadPhoneNumberList(string filePath)
        {
            var result = new List<string>();
            using (var streamReader = File.OpenText(filePath))
            {
                var lines = streamReader.ReadToEnd().Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                result.AddRange(lines);
            }

            return result;
        }

        public bool CheckEndCondition(string number, List<string> filterList, bool expectResult)
        {


            foreach (var omi in filterList)
            {
                if (number.EndsWith(omi)) return expectResult;
            }

            return !expectResult;
        }

        public bool ValidatePhoneSumNumber(string phoneNumber, int targetNumber)
        {
            var firstTargetNumberString = phoneNumber.Substring(0, targetNumber);
            var lastTargetNumberString = phoneNumber.Substring(phoneNumber.Length - targetNumber);
            foreach (var niceSum in Constant.MainConstant.NiceSumOfNumber)
            {
                if (niceSum[0] == SumStringNumber(firstTargetNumberString) && niceSum[1] == SumStringNumber(lastTargetNumberString))
                {
                    return true;
                }

            }
            return false;
        }

        public int SumStringNumber(string stringNumber)
        {
            int result = 0;
            var stringExtract = stringNumber.ToCharArray();
            foreach (var item in stringExtract)
            {
                var temp = int.Parse(item.ToString());
                result += temp;
            }

            return result;
        }
    }
}
