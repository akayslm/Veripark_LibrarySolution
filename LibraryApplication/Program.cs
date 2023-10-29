using System;
using System.Collections.Generic;
using System.Text;
using LibraryBusiness;
using System.Configuration;
using System.Xml;
using System.Collections.Specialized;
using System.Xml.Linq;
using System.Linq;

namespace LibraryApplication
{
    public class Program
    {
        static void Main(string[] args)
        {
            getStartEndValue(out DateTime startDate, out DateTime endDate);

            countryCalculation();

            //THERE IS NO TIME TO FINISH

            //if (args == null || args.Length != 3)
            //{
            //    PrintUsage();
            //    return;
            //}
            //String fee = "";
            //try
            //{
            //    /* Description,
            //     * please implement PenaltyFeeCalculator class
            //     * feel free to make any changes (if necessary) 
            //     * to PenaltyFeeCalculator class method and constructor signatures,
            //     * as well as here this very portion of the main method
            //     * You should not need to change any other methods in this class.
            //     */
            //    fee = new PenaltyFeeCalculator().Calculate();
            //}
            //catch (Exception e)
            //{
            //    PrintErrorMessage(e);
            //}
            //PrintResultMessage(fee);

        }

        private static void getStartEndValue(out DateTime startDate, out DateTime endDate)
        {
            while (true)
            {
                Console.Write("Enter Start Date: ");
                DateTime.TryParse(Console.ReadLine(), out startDate);

                Console.Write("Enter End Date: ");
                DateTime.TryParse(Console.ReadLine(), out endDate);

                if (endDate >= startDate)
                {
                    break;
                }
                else
                {
                    Console.Write("Start Date Cannot Be Greater Than End Date!!!\n**********************\n");
                }
            }
        }

        private static void countryCalculation()
        {
            while (true)
            {
                Console.Write("Write TR for Türkiye, AE for the United Arab Emirates: ");
                string country = Console.ReadLine().ToUpper();

                if (country == "TR" || country == "AE")
                {
                    break;
                }
                else
                {
                    Console.Write("Try again!!\n ");
                }
            }
        }

        private static List<DateTime> GetHoliday()
        {
            //NameValueCollection sAll = (NameValueCollection)ConfigurationManager.GetSection("HolidaySetting");
            string holidaySetting = ConfigurationManager.AppSettings["HolidaySetting"];
            List<DateTime> holidayDates = new List<DateTime>();

            if (!string.IsNullOrEmpty(holidaySetting))
            {
                try
                {
                    XDocument xdoc = XDocument.Parse(holidaySetting);
                    var holidayElements = xdoc.Descendants("HolidaySetting").Elements("Holiday");

                    foreach (var holidayElement in holidayElements)
                    {
                        string dateStr = holidayElement.Attribute("Date").Value;
                        if (DateTime.TryParse(dateStr, out DateTime date))
                        {
                            holidayDates.Add(date);
                        }
                    }
                }
                catch (Exception ex)
                {                    
                    Console.WriteLine("Exception: " + ex.Message);
                }
            }

            return holidayDates;
        }

        private static decimal GetCountryPenaltyFee(string country)
        {
            XDocument xdoc = XDocument.Parse(ConfigurationManager.AppSettings["LibrarySetting"]);

            var countryElement = xdoc.Descendants("Country")
                                    .FirstOrDefault(c => c.Attribute("Culture").Value == country);

            if (countryElement != null)
            {
                string penaltyFeeStr = countryElement.Attribute("DailyPenaltyFee").Value;
                if (decimal.TryParse(penaltyFeeStr, out decimal penaltyFee))
                {
                    return penaltyFee;
                }
            }

            return 0;
        }



        //private static void PrintUsage()
        //{
        //    Console.WriteLine("Please provide these parameters (without brackets) : <CountryCode> <DateStart> <DateEnd>");
        //    PrintAnyKeyMessage();
        //    Console.ReadKey();
        //}
        //private static void PrintAnyKeyMessage()
        //{
        //    Console.WriteLine("Press any key to continue");
        //}
        //private static void PrintResultMessage(string fee)
        //{
        //    Console.WriteLine("Penalty Fee is {0}", fee);
        //    PrintAnyKeyMessage();
        //    Console.ReadKey();
        //}
        //private static void PrintErrorMessage(Exception e)
        //{
        //    Console.WriteLine("Exception : " + e.Message);
        //    Console.WriteLine("Stacktrace : ");
        //    Console.WriteLine(e.StackTrace);
        //    PrintAnyKeyMessage();
        //    Console.ReadKey();
        //}

    }
}


