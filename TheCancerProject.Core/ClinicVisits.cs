using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCancerProject.Core
{
    public class ClinicVisits : Entity
    {
        //public virtual long Id
        //{
        //    get; set;
        //}
        //public virtual Patient ThePatient
        //{
        //    get; set;
        //}
        public virtual DateTime AppointmentDate
        {
            get; set;
        }
        public virtual string MedicalSummaryAfterVisit
        {
            get; set;
        }
    }
}
