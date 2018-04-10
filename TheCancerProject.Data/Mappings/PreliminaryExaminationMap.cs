using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCancerProject.Core;

namespace TheCancerProject.Data.Mappings
{
    public class PreliminaryExaminationMap : EntityMap<PreliminaryExamination>
    {
        public PreliminaryExaminationMap()
        {
            //Map(x => x.Id);
            Map(x => x.AllergicReactions);            
            Map(x => x.DurationOfMenses);            
            Map(x => x.LengthOfMestrualCycle);
            Map(x => x.MedicalHistory);
            Map(x => x.Menarche);
            Map(x => x.Parity);
            Map(x => x.PastSurgicalHistory);            
            Map(x => x.RoutineMedications);
        }
    }
}
