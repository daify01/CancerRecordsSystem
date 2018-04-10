using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCancerProject.Core
{
    public class Diagnosis : Entity
    {
        public virtual string InitialDiagnosis
        {
            get; set;
        }
        public virtual string ThePlan        //Moved to Diagnosis Page
        {
            get; set;
        }
        public virtual string FinalDiagnosis  // -----> Move all such commented properties in this class to a new page called diagnosis.
        {
            get; set;
        }
        public virtual DateTime? AdmissionDate
        {
            get; set;
        }
        public virtual DateTime? DischargeDate
        {
            get; set;

        }
    }
}
