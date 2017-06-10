using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using Development.Core.Core.Managers.Proxy;
using Development.Core.Interface;
using Development.Dal.Common.Models;
using Development.Dal.Error.Model;

namespace Development.Core.Core.Managers
{
    internal class CommonManager : IManager
    {

        /// <summary>
        /// The instance
        /// </summary>
        private static CommonManager instance = new CommonManager();

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        internal static CommonManager Instance => instance;

        /// <summary>
        /// Initializes the specified Development manager.
        /// </summary>
        /// <param name="developmentManager">The Development manager.</param>
        void IManager.Initialize(IDevelopmentManager developmentManager)
        {
            // Cache and initialize things here...
        }

        /// <summary>
        /// Commit all caches since the transaction has been commited.
        /// </summary>
        void IManager.CommitCaches()
        {
        }

        /// <summary>
        /// Rollback all caches since the transaction has been rollbacked.
        /// </summary>
        void IManager.RollbackCaches()
        {
        }

        #region SaveError
        public bool SaveError(CommonManagerProxy proxy, ErrorDao error)
        {
            try
            {
                using (ITransaction tx = proxy.DevelopmentManager.GetTransaction())
                {
                    tx.PersistenceManager.UserRepository.Save(error);
                    tx.Commit();
                }

                return true;
            }

            catch (DBConcurrencyException ex)
            {
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        #endregion

        #region LogError
        public bool LogError(CommonManagerProxy proxy, Exception ex)
        {
            try
            {
                ErrorDao errDao = new ErrorDao
                {
                    DateCreated = DateTime.Now,
                    StackTrace = ex.StackTrace,
                    Message = ex.Message
                };
                SaveError(proxy, errDao);
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region Saving Incident

        public int SaveIncident(CommonManagerProxy proxy, IncidentsDao request)
        {
            try
            {
                using (ITransaction tx = proxy.DevelopmentManager.GetTransaction())
                {
                    tx.PersistenceManager.UserRepository.Save(request);
                    tx.Commit();
                    SaveIncidentsRescueMappings(proxy, request.Id);
                    return request.Id;
                }
            }
            catch (Exception ex)
            {
                LogError(proxy, ex);
                return 0;
            }
        }

        //


        #endregion

        public bool SaveIncidentsRescueMappings(CommonManagerProxy proxy, int incidentId)
        {
            try
            {
                var list = new List<IncidentsRescueMappingsDao>();
                using (ITransaction tx = proxy.DevelopmentManager.GetTransaction())
                {
                    var listOfRescuer =
                       tx.PersistenceManager.UserRepository.GetAll<UserMasterDao>().Where(u => u.Category == 1);
                    foreach (var person in listOfRescuer)
                    {
                        var request = new IncidentsRescueMappingsDao
                        {
                            IncidentID = incidentId,
                            IsMissionComplete = false,
                            IsRead = false,
                            NeededAssistance = false,
                            RescuerID = person.Id,
                            DateCreated = DateTime.Now
                        };
                        list.Add(request);
                        tx.PersistenceManager.UserRepository.Save(request);
                    }
                    //if (list.Count > 0)
                    //{
                    //    tx.PersistenceManager.UserRepository.Save(list);
                    //}
                    tx.Commit();
                    return true;
                }
            }
            catch (Exception ex)
            {
                LogError(proxy, ex);
                return false;
            }
        }

        public int SaveUserMaster(CommonManagerProxy proxy, UserMasterDao request)
        {
            try
            {
                using (ITransaction tx = proxy.DevelopmentManager.GetTransaction())
                {
                    tx.PersistenceManager.UserRepository.Save(request);
                    tx.Commit();
                    return request.Id;
                }
            }
            catch (Exception ex)
            {
                LogError(proxy, ex);
                return 0;
            }
        }

    }
}




