using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Development.Dal.Common.Models
{
    public class NotificationInputDao
    {
        public virtual DateTime CreatedDate { get; set; }
        public virtual int ReporterID { get; set; }
        public virtual bool IsRead { get; set; }
        public virtual bool IsRescued { get; set; }
    }
}
