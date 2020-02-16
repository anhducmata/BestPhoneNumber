using System;
using System.Collections.Generic;
using System.Linq;
using BestPhoneNumber.Context;
using BestPhoneNumber.Dto;
using Microsoft.EntityFrameworkCore;

namespace BestPhoneNumber.Services
{
    /// <summary>
    /// Phone number service
    /// </summary>
    public class BestPhoneNumberService
    {
        // Init service and context
        public CommonService CommonService;
        protected readonly PhoneContext Context;

        // Injecting services
        public BestPhoneNumberService(CommonService commonService, PhoneContext context)
        {
            CommonService = commonService;
            Context = context;
        }

        /// <summary>
        /// Get list of best phone number
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public List<BestPhoneNumberDto> GetListBestPhoneNumber(string filePath)
        {
            // Read phone number from file
            var phoneList = CommonService.ReadPhoneNumberList(filePath);

            // Constant to catch condition
            var ominous = Constant.MainConstant.Ominous;
            var nobles = Constant.MainConstant.Noble;

            // Init result to contain the result
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

            // Order result by telecom Provider
            result = result.OrderBy(x => x.TelecomProvider).ToList();
            return result;
        }

        /// <summary>
        /// Validate phone number. Checking in DB that prefix number is accepted
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        public BestPhoneNumberDto ValidatePhoneNumber(string phoneNumber)
        {
            // List telecom Provider
            var telecomProvider = Context.TelecomHost.Select(x => new { x.Name, x.Id }).AsNoTracking().ToList();
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
