using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCancerProject.Core
{
    public class Procedures : Entity
    {
        //public virtual DateTime AdmissionDate
        //{
        //    get; set;
        //}
        public virtual string ProceduresDone
        {
            get; set;
        }
        public virtual string PostOpOrders
        {
            get; set;

        }
        public virtual string DischargeMedicationsWithDoses
        {
            get; set;
        }
        //public virtual DateTime DischargeDate
        //{
        //    get; set;

        //}
        public virtual DischargeState DischargeState
        {
            get; set;
        }
        //public virtual string FinalDIagnosis  // -----> Moved all such commented properties in this class to a new page called diagnosis.
        //{
        //    get; set;
        //}
    }
}
