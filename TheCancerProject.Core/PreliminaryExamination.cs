using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCancerProject.Core
{
    public class PreliminaryExamination : Entity
    {
        //public virtual long Id
        //{
        //    get; set;
        //}
        public virtual Patient ThePatient
        {
            get; set;
        }
        public virtual string MedicalHistory
        {
            get; set;
        }
        public virtual string PastSurgicalHistory
        {
            get; set;
        }
        public virtual string Parity
        {
            get; set;
        }
        //public virtual DateTime Menarche
        //{
        //    get; set;
        //}
        public virtual string Menarche
        {
            get; set;
        }
        public virtual string DurationOfMenses
        {
            get; set;
        }
        public virtual string LengthOfMestrualCycle
        {
            get; set;
        }
        public virtual string RoutineMedications
        {
            get; set;
        }
        public virtual string AllergicReactions
        {
            get; set;
        }
        
    }
}
