using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication2.Models
{
    public class TrainDetailsModel
    {
        public int ID { get; set; }
        public string trainName { get; set; }
        public string depertureTimeString { get; set; }
        public DateTime departureTime { get; set; }
        public string departurePlace { get; set; }
        public string destinationPlace { get; set; }
        public int noOfBogie { get; set; }
        public int fare { get; set; }
    }

    public class BogieModel
    {
        public int ID { get; set; }
        public string bogieTitle { get; set; }
        public int noOfSeats { get; set; }
        public string TrainTitle { get; set; }
        public int trainID { get; set; }
    }

    public class SeatModel
    {
        public int ID { get; set; }
        public string SeatNumber { get; set; }
        public bool IsAvailable { get; set; }
        public int BogieID { get; set; }
    }

}