using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCancerProject.Core;

namespace TheCancerProject.Data.Mappings
{
   public class InvestigationMap : EntityMap<Investigation>
    {
        public InvestigationMap()
        {
            Map(x => x.Image).CustomSqlType("varbinary(max)").Length(int.MaxValue);
            Map(x => x.Summary);
            Map(x => x.PatientHospitalNumber);
            Map(x => x.PatientUniqueID);
            //Map(x => x.DateUploaded);
        }
    }
}
