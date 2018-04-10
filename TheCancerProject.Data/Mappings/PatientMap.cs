using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCancerProject.Core;

namespace TheCancerProject.Data.Mappings
{
    public class PatientMap : EntityMap<Patient>
    {
        public PatientMap()
        {
            //Map(x => x.Id);
            References(x => x.LastUserAdministeringTreatment).Not.LazyLoad();
            References(x => x.TheBiodata).Not.LazyLoad();
            References(x => x.TheBreastAndAxillaryExamination).Not.LazyLoad();
            References(x => x.TheComplaints).Not.LazyLoad();
            References(x => x.TheEventsOnAdmission).Not.LazyLoad();
            References(x => x.TheGeneralExamination).Not.LazyLoad();
            References(x => x.TheHospital).Not.LazyLoad();
            References(x => x.ThePreliminaryExamination).Not.LazyLoad();
            References(x => x.TheClinicVisits).Not.LazyLoad();
            References(x => x.TheInvestigation).Not.LazyLoad();
            References(x => x.TheProcedures).Not.LazyLoad();
            References(x => x.TheDiagnoses).Not.LazyLoad();
            //Map(x => x.UniqueID).CustomSqlType("nvarchar(max)").Length(int.MaxValue).Unique();        //HINT:Manually Create
        }
    }
}
