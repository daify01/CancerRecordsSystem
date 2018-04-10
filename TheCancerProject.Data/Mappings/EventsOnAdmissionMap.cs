using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCancerProject.Core;

namespace TheCancerProject.Data.Mappings
{
    public class EventsOnAdmissionMap : EntityMap<EventsOnAdmission>
    {
        public EventsOnAdmissionMap()
        {
            //Map(x => x.Id);
            //Map(x => x.AdmissionDate);
            Map(x => x.ChemotherapyRegimen);
            Map(x => x.ComplicationsManagedOnAdmission);
            Map(x => x.DailyUpdates);
            //Map(x => x.DischargeDate);
            //Map(x => x.DischargeMedications);
            //Map(x => x.FinalDiagnosis);
            //Map(x => x.InitialDiagnosis);
            //Map(x => x.Investigations);
            //Map(x => x.Plan); //Moved to Diagnosis Page
            //Map(x => x.PostOpOrders);
            //Map(x => x.ProceduresDone);
            Map(x => x.RadiotherapyRegimen);
            //Map(x => x.TheDischargeState);
        }
    }
}
