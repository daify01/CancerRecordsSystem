using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCancerProject.Core;

namespace TheCancerProject.Data.Mappings
{
    public class HospitalMap : EntityMap<Hospital>
    {
        public HospitalMap()
        {
            //Map(x => x.Id);
            Map(x => x.Name);
            Map(x => x.PrimaryContactEmail);
            Map(x => x.PrimaryContactNumber);
            Map(x => x.Address);
        }
    }
}
