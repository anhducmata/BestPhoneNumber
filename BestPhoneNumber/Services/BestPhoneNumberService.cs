using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Logging.Abstractions;

namespace BestPhoneNumber.Services
{
    public class BestPhoneNumberService
    {
        public FileService FileService;
        public BestPhoneNumberService(FileService fileService)
        {
            FileService = fileService;
        }

        public List<string> PrintBestPhoneNumber(string filePath)
        {
            var phoneList = FileService.ReadPhoneNumberList(filePath);
            var ominous = Constant.MainConstant.Ominous;
            var nobles = Constant.MainConstant.Noble;
            var result = new List<string>();
            foreach (var phoneNumber in phoneList)
            {
                if (this.CheckCondition(phoneNumber, ominous, false) && 
                    this.CheckCondition(phoneNumber, nobles, true))
                {
                    result.Add(phoneNumber);
                }
            }
            return result;
        }


        protected bool CheckEndCondition(string number, List<string> filterList, bool expectResult)
        {
            

            foreach (var omi in filterList)
            {
                if (number.EndsWith(omi)) return expectResult;
            }

            return !expectResult;
        }
    }
}
