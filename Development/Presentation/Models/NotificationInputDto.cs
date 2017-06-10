using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Development.Web.Models
{
    public class NotificationInputDto
    {
        public DateTime CreatedDate { get; set; }
        public int ReporterID { get; set; }
        public bool IsRead { get; set; }
        public bool IsRescued { get; set; }
    }
}