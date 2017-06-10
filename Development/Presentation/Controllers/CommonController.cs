using Development.Core;
using Development.Core.Interface;
using Development.Web.Controllers;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Web.Http;
using Development.Dal.Common.Models;
using Development.Web.Models;

namespace Development.Web.Controllers
{

    [RoutePrefix("api/Common")]
    public class CommonController : ApiController
    {

        ServiceResponse _result;

        [HttpPost]
        [Route("Incident")]
        public ServiceResponse Incident(IncidentRequestDto dto)
        {
            _result = new ServiceResponse();
            try
            {

                Guid systemSession = DevelopmentManagerFactory.GetSystemSession();
                IDevelopmentManager developmentManager = DevelopmentManagerFactory.GetDevelopmentManager(systemSession);
                _result.StatusCode = (int) HttpStatusCode.OK;
                var dao = new IncidentsDao
                {
                    IsRescued = false,
                    Lang = dto.Lang,
                    Lat = dto.Lat,
                    PriorityLevel = dto.PriorityLevel,
                    ReporterID = dto.ReporterID,
                    Summary = dto.Summary,
                    VictimCategory = dto.VictimCategory,
                    DateCreated = DateTime.Now.Date
                };

                _result.Response = developmentManager.CommonManager.SaveIncident(dao);

            }
            catch
            {
                _result.StatusCode = (int) HttpStatusCode.MethodNotAllowed;
                _result.Response = null;
            }
            return _result;
        }

        [HttpPost]
        [Route("IncidentsRescueMappings")]
        public ServiceResponse IncidentsRescueMappings(IncidentsRescueMappingsDto dto)
        {
            _result = new ServiceResponse();
            try
            {

                Guid systemSession = DevelopmentManagerFactory.GetSystemSession();
                IDevelopmentManager developmentManager = DevelopmentManagerFactory.GetDevelopmentManager(systemSession);
                _result.StatusCode = (int)HttpStatusCode.OK;
                var dao = new IncidentsRescueMappingsDao
                {
                    IncidentID = dto.IncidentID,
                    RescuerID = dto.RescuerID,
                    IsMissionComplete = dto.IsMissionComplete,
                    NeededAssistance = dto.NeededAssistance,
                    DateCreated = DateTime.Now.Date,
                    IsRead = false
                };

                _result.Response = developmentManager.CommonManager.SaveIncidentsRescueMappings(dao);

            }
            catch
            {
                _result.StatusCode = (int)HttpStatusCode.MethodNotAllowed;
                _result.Response = null;
            }
            return _result;
        }

        [HttpPost]
        [Route("UserMaster")]
        public ServiceResponse UserMaster(UserMasterDto dto)
        {
            _result = new ServiceResponse();
            try
            {

                Guid systemSession = DevelopmentManagerFactory.GetSystemSession();
                IDevelopmentManager developmentManager = DevelopmentManagerFactory.GetDevelopmentManager(systemSession);
                _result.StatusCode = (int)HttpStatusCode.OK;
                var dao = new UserMasterDao
                {
                    UserName = dto.UserName,
                    MobileNumber = dto.MobileNumber,
                    Address = dto.Address,
                    Street = dto.Street,
                    City = dto.City,
                    State = dto.State,
                    Category = dto.Category,
                    InterestedIn = dto.InterestedIn,
                    RadiusOnWhereCanOperate = dto.RadiusOnWhereCanOperate,
                    AreaWhereCanOperate = dto.AreaWhereCanOperate
                };

                _result.Response = developmentManager.CommonManager.SaveUserMaster(dao);

            }
            catch
            {
                _result.StatusCode = (int)HttpStatusCode.MethodNotAllowed;
                _result.Response = null;
            }
            return _result;
        }

        [HttpGet]
        [Route("GetIncidentDetails/{incidentID}/{rescuerID}")]
        public ServiceResponse GetIncidentDetails(int incidentID, int rescuerID)
        {
            _result = new ServiceResponse();
            try
            {

                Guid systemSession = DevelopmentManagerFactory.GetSystemSession();
                IDevelopmentManager developmentManager = DevelopmentManagerFactory.GetDevelopmentManager(systemSession);
                _result.StatusCode = (int)HttpStatusCode.OK;
                
                _result.Response = developmentManager.CommonManager.GetIncidentDetails(incidentID, rescuerID);

            }
            catch
            {
                _result.StatusCode = (int)HttpStatusCode.MethodNotAllowed;
                _result.Response = null;
            }
            return _result;
        }

        [HttpPost]
        [Route("GetNotifications")]
        public ServiceResponse GetNotifications(IncidentsRescueMappingsDto dto)
        {
            _result = new ServiceResponse();
            try
            {

                Guid systemSession = DevelopmentManagerFactory.GetSystemSession();
                IDevelopmentManager developmentManager = DevelopmentManagerFactory.GetDevelopmentManager(systemSession);
                _result.StatusCode = (int)HttpStatusCode.OK;
                var dao = new IncidentsRescueMappingsDao
                {
                    DateCreated = DateTime.Now.Date,
                    IsRead = false
                };
                _result.Response = developmentManager.CommonManager.GetNotifications(dao);

            }
            catch
            {
                _result.StatusCode = (int)HttpStatusCode.MethodNotAllowed;
                _result.Response = null;
            }
            return _result;
        }

    }
}