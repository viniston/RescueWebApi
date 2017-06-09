using System;

namespace Development.Dal.Common.Models
{

    /// <summary>
    /// UserDao object for table 'Incidents'.
    /// </summary>
    public class IncidentsDao : BaseDao
    {
        public virtual int Id { get; set; }
        public virtual string Lat { get; set; }
        public virtual string Lang { get; set; }
        public virtual int ReporterID { get; set; }
        public virtual bool VictimCategory { get; set; }
        public virtual string Summary { get; set; }
        public virtual bool IsRescued { get; set; }
        public virtual int PriorityLevel { get; set; }
        public virtual DateTime DateCreated { get; set; }

    }

}
