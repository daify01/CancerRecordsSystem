using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCancerProject.Core;

namespace TheCancerProject.Data.Mappings
{
    public class BiodataMap : EntityMap<Biodata>
    {
        public BiodataMap()
        {
            //Map(x => x.Id);
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.OtherNames);
            Map(x => x.Address);
            Map(x => x.NextOfKinEmail);
            Map(x => x.NextOfKinName);
            Map(x => x.NextOfKinPhone);
            Map(x => x.NextOfKinRelationship);
            Map(x => x.Occupation);
            Map(x => x.PhoneNumber);
            Map(x => x.Religion);
            Map(x => x.Sex);
            Map(x => x.StateOfResidence);
            Map(x => x.Title);
            Map(x => x.HospitalNumber);
            References(x => x.TheHospital);
            Map(x => x.MaritalStatus);
            Map(x => x.DateOfBirth);
            Map(x => x.Age);
        }
    }
}
