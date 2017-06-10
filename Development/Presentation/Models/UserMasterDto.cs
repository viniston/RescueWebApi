using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Development.Web.Models
{
    public class UserMasterDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Category { get; set; }
        public string InterestedIn { get; set; }
        public int RadiusOnWhereCanOperate { get; set; }
        public string AreaWhereCanOperate { get; set; }
    }

    public enum CategoryType
    {
        Reporter = 1,
        Rescuer = 2
    }
}