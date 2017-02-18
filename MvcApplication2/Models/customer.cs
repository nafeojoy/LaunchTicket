using System;
using System.Collections.Generic;

namespace MvcApplication2.Models
{
    public partial class customer
    {
        public customer()
        {
            this.CustomerTickets = new List<CustomerTicket>();
        }

        public int ID { get; set; }
        public string user_name { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string address { get; set; }
        public string contact_no { get; set; }
        public string gender { get; set; }
        public string occupation { get; set; }
        public string password { get; set; }
        public string confirmpassword { get; set; }
        public string email { get; set; }
        public virtual ICollection<CustomerTicket> CustomerTickets { get; set; }
    }
}
