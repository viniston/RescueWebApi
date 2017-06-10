using System;

namespace Development.Dal.Common.Models
{

    /// <summary>
    /// UserDao object for table 'IncidentsRescueMappings'.
    /// </summary>
    public partial class IncidentsRescueMappingsDao : BaseDao
    {
        public virtual int Id { get; set; }
        public virtual int IncidentID { get; set; }
        public virtual int RescuerID { get; set; }
        public virtual int ReporterID { get; set; }
        public virtual bool IsMissionComplete { get; set; }
        public virtual bool NeededAssistance { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual bool IsRead { get; set; }
    }

}
