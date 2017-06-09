using System;
using System.ComponentModel.DataAnnotations;

namespace Development.Web.Models
{
    public class IncidentRequestDto
    {
        public string Lat { get; set; }
        public string Lang { get; set; }
        public int ReporterID { get; set; }
        public bool VictimCategory { get; set; }
        public string Summary { get; set; }
        public bool IsRescued { get; set; }
        public int PriorityLevel { get; set; }
    }
}