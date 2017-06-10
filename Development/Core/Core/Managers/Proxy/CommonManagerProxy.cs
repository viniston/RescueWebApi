using Development.Core.Core.Interface.Managers;
using Development.Core.Interface;
using Development.Dal.Common.Models;

namespace Development.Core.Core.Managers.Proxy
{
    internal partial class CommonManagerProxy : ICommonManager, IManagerProxy
    {
        // Reference to the DevelopmentManager

        /// <summary>
        /// Initializes a new instance of the <see cref="CommonManagerProxy"/> class.
        /// </summary>
        /// <param name="developmentManager">The Development manager.</param>
        internal CommonManagerProxy(DevelopmentManager developmentManager)
        {
            DevelopmentManager = developmentManager;

            // Do some initialization.... 
            // i.e. cache logged in user specific things (or maybe use lazy loading for that)
        }

        // Reference to the DevelopmentManager (only internal)
        /// <summary>
        /// Gets the Development manager.
        /// </summary>
        /// <value>
        /// The Development manager.
        /// </value>
        internal DevelopmentManager DevelopmentManager { get; }

        #region Availabilty Search

        public int SaveIncident(IncidentsDao request)
        {
            return CommonManager.Instance.SaveIncident(this, request);
        }

        public bool SaveIncidentsRescueMappings(IncidentsRescueMappingsDao request)
        {
            return CommonManager.Instance.SaveIncidentsRescueMappings(this, request.IncidentID);
        }

        public int SaveUserMaster(UserMasterDao request)
        {
            return CommonManager.Instance.SaveUserMaster(this, request);
        }

        #endregion




    }

}
