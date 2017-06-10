using System.Collections.Generic;
using Development.Dal.Common.Models;

namespace Development.Core.Core.Interface.Managers
{
    public interface ICommonManager
    {

        #region Instance of Classes In ServiceLayer reference
        /// <summary>
        /// Returns File class.
        /// </summary>

        #endregion

        #region Methods

        int SaveIncident(IncidentsDao request);

        bool SaveIncidentsRescueMappings(IncidentsRescueMappingsDao request);

        int SaveUserMaster(UserMasterDao request);

        IncidentsDao GetIncidentDetails(int incidentID, int rescuerID);

        List<IncidentsRescueMappingsDao> GetNotifications(IncidentsRescueMappingsDao request);

        #endregion

    }
}
