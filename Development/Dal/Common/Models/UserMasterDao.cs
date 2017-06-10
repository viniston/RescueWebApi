using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Development.Dal.Common.Models
{
    public partial class UserMasterDao : BaseDao
    {
        public virtual int Id { get; set; }
        public virtual string UserName { get; set; }
        public virtual string MobileNumber { get; set; }
        public virtual string Address { get; set; }
        public virtual string Street { get; set; }
        public virtual string City { get; set; }
        public virtual string State { get; set; }
        public virtual int Category { get; set; }
        public virtual string InterestedIn { get; set; }
        public virtual int RadiusOnWhereCanOperate { get; set; }
        public virtual string AreaWhereCanOperate { get; set; }
    }
}
