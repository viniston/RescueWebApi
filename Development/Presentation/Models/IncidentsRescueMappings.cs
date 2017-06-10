using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Development.Web.Models
{
    public class IncidentsRescueMappingsDto
    {
        public int ID { get; set; }
        public int IncidentID { get; set; }
        public int RescuerID { get; set; }
        public bool IsMissionComplete { get; set; }
        public bool NeededAssistance { get; set; }
        public DateTime DateCreated { get; set; }
        public int IsRead { get; set; }
    }
}