using System;
using System.Collections.Generic;

namespace MvcApplication2.Models
{
    public partial class CustomerTicket
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public int TicketID { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public virtual customer customer { get; set; }
        public virtual Ticket Ticket { get; set; }
    }
}
