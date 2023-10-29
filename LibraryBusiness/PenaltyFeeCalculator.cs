using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Remoting.Messaging;
using System.Text;
using LibraryConfigUtilities;

namespace LibraryBusiness
{
    /* Description,
     * settingList member holds configuration parameters stored in the App.config file, 
     * please explore the properties and methods in the Country class to get a better understanding.
     * 
     * Please implement this class accordingly to accomplish requirements.
     * Feel free to add any parameters, methods, class members, etc. if necessary
     */

    //public static int BusinessDays(DateTime firstDay, DateTime lastDay, List<DateTime> holidays)
    //{
    //    firstDay = firstDay.Date;
    //    lastDay = lastDay.Date;
    //    if(firstDay>lastDay)
    //        throw new Exception();
                
    //    TimeSpan span = lastDay - firstDay;
    //    int businessDays = span.Days + 1;
    //    int weekCount = businessDays / 7;

    //    //there is no time to complete

    //}

    public class PenaltyFeeCalculator
    {

        private List<Country> settingList = new LibrarySetting().LibrarySettingList;

        public PenaltyFeeCalculator()
        {

        }

        public String Calculate()
        {
            return "not implemented yet";
        }
    }
}
