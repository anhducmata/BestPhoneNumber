using System;
using System.Collections.Generic;
using System.Linq;
using BestPhoneNumber.Context;
using BestPhoneNumber.Dto;

namespace BestPhoneNumber.Services
{
    public class BestPhoneNumberService
    {
        public CommonService CommonService;
        protected readonly PhoneContext Context;

        public BestPhoneNumberService(CommonService commonService, PhoneContext context)
        {
            CommonService = commonService;
            Context = context;
        }

        public List<BestPhoneNumberDto> PrintBestPhoneNumber(string filePath)
        {
            var phoneList = CommonService.ReadPhoneNumberList(filePath);
            var ominous = Constant.MainConstant.Ominous;
            var nobles = Constant.MainConstant.Noble;
            var result = new List<BestPhoneNumberDto>();
            foreach (var phoneNumber in phoneList)
            {
                if (CommonService.CheckEndCondition(phoneNumber, ominous, false) &&
                    CommonService.CheckEndCondition(phoneNumber, nobles, true) &&
                    CommonService.ValidatePhoneSumNumber(phoneNumber, Constant.MainConstant.SumPhoneNumberTarget))
                {
                    var tempResult = ValidatePhoneNumber(phoneNumber);
                    result.Add(tempResult);
                }
            }

            result = result.OrderBy(x => x.TelecomProvider).ToList();
            return result;
        }

        public BestPhoneNumberDto ValidatePhoneNumber(string phoneNumber)
        {
            var telecomProvider = Context.TelecomHost.ToList();
            var prefixList = Context.NumberProvide.ToList();
            var result = new BestPhoneNumberDto();
            foreach (var prefix in prefixList)
            {
                if (phoneNumber.StartsWith(prefix.PrefixNumber))
                {
                    var tempTelecom = telecomProvider.Find(x => x.Id == prefix.TelecomHostId);
                    if (tempTelecom != null)
                    {
                        var telecomProviderName = tempTelecom.Name;
                        result = new BestPhoneNumberDto(phoneNumber, telecomProviderName);
                    }
                    return result;
                }
            }
            return result;
        }
    }
}
