using System;
using BestPhoneNumber.Context;
using BestPhoneNumber.Models;
using BestPhoneNumber.Services;

namespace BestPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nInput your file path? ");
            var filePath = Console.ReadLine();
            var bestPhone = new BestPhoneNumberService(new CommonService(), new PhoneContext());
            var result = bestPhone.PrintBestPhoneNumber(filePath);
            foreach (var phoneNumberDto in result)
            {
                Console.Write("\nTelecom Provider: {0}",phoneNumberDto.TelecomProvider);
                Console.Write("\nPhone Number: {0}", phoneNumberDto.PhoneNumber);
            }
            Console.Write("\nPress any key to exit...");
            Console.ReadKey(true);
        }
    }
}
