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

        #endregion

    }
}
