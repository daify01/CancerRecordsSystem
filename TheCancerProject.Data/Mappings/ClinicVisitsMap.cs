using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCancerProject.Core;

namespace TheCancerProject.Data.Mappings
{
    public class ClinicVisitsMap : EntityMap<ClinicVisits>
    {
        public ClinicVisitsMap()
        {
            //Map(x => x.Id);
            //References(x => x.ThePatient);
            Map(x => x.AppointmentDate);
            Map(x => x.MedicalSummaryAfterVisit);
        }
    }
}
