using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcApplication2.Models
{
    public partial class Ticket
    {
        public Ticket()
        {
            this.CustomerTickets = new List<CustomerTicket>();
        }

        public int L_ID { get; set; }
        public string Start { get; set; }
        public string Destination { get; set; }
        public string L_Name { get; set; }
        public System.TimeSpan Dept_Time { get; set; }
        public int Fare_Deck { get; set; }
        public int Fare_1st_Class { get; set; }
        public int Fare_Cabin { get; set; }
        public Nullable<int> Max { get; set; }
        [NotMapped]
        public int TotalTicket { get; set; }
        public virtual ICollection<CustomerTicket> CustomerTickets { get; set; }
        public string Date { get; set;}

        public string DATE { get; set; }
    }

       
}
