using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCancerProject.Core;

namespace TheCancerProject.Data.Mappings
{
   public class DiagnosisMap : EntityMap<Diagnosis>
    {
        public DiagnosisMap()
        {
            Map(x =>x.InitialDiagnosis);
            Map(x => x.ThePlan);
            Map(x => x.FinalDiagnosis);
            Map(x => x.AdmissionDate);
            Map(x => x.DischargeDate);
        }
    }
}
