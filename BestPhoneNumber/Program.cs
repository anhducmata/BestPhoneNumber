using System;
using BestPhoneNumber.Models;
using BestPhoneNumber.Services;

namespace BestPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            var bestPhone = new BestPhoneNumberService(new FileService());
            Console.WriteLine("\nInput your file path? ");
            var filePath = Console.ReadLine();
            var data = bestPhone.PrintBestPhoneNumber(filePath);
            Console.Write("\nPress any key to exit...");
            Console.ReadKey(true);
        }
    }
}
