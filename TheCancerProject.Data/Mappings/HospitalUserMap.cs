using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCancerProject.Core;

namespace TheCancerProject.Data.Mappings
{
    public class HospitalUserMap : EntityMap<HospitalUser>
    {
        public HospitalUserMap()
        {
            //Map(x => x.Id);
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.OtherNames);
            Map(x => x.IsLoggedIn);
            Map(x => x.LastLoginDate);
            Map(x => x.Password);
            Map(x => x.SessionID);
            References(x => x.TheHospital);
            Map(x => x.UserName);
            Map(x => x.IsHospitalAdmin);
            Map(x => x.IsSuperAdmin);
            Map(x => x.Email);
            Map(x => x.Phone);
            Map(x => x.UserRole);
            Map(x => x.IsFirstLogin);
        }
    }
}
