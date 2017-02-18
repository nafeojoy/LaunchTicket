using System;
using System.Collections.Generic;

namespace MvcApplication2.Models
{
    public partial class Launch_Count
    {
        public Launch_Count()
        {
            this.Tickets = new List<Ticket>();
        }

        public int LC_ID { get; set; }
        public int Ticket_No { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
