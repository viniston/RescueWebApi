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
        public ServiceResponse SearchAvailabilty(IncidentRequestDto dto)
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
    }
}