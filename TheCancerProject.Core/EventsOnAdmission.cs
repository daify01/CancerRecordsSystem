using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCancerProject.Core
{
    public class EventsOnAdmission : Entity
    {
        //public virtual long Id
        //{
        //    get; set;
        //}
        //public virtual Patient ThePatient
        //{
        //    get; set;
        //}
        //public virtual string InitialDiagnosis
        //{
        //    get; set;
        //}
        //public virtual string Plan        //Moved to Diagnosis Page
        //{
        //    get; set;
        //}
        public virtual string DailyUpdates
        {
            get; set;
        }
        public virtual string ChemotherapyRegimen
        {
            get; set;
        }
        public virtual string RadiotherapyRegimen
        {
            get; set;
        }
        //public virtual string Investigations
        //{
        //    get; set;
        //}
        public virtual string ComplicationsManagedOnAdmission
        {
            get; set;
        }
        //public virtual DateTime AdmissionDate
        //{
        //    get; set;
        //}
        //public virtual string ProceduresDone
        //{
        //    get; set;
        //}
        //public virtual string PostOpOrders
        //{
        //    get; set;
        //}
        //public virtual string DischargeMedications
        //{
        //    get; set;
        //}
        //public virtual DateTime DischargeDate
        //{
        //    get; set;
        //}
        //public virtual DischargeState TheDischargeState
        //{
        //    get; set;
        //}
        //public virtual string FinalDiagnosis
        //{
        //    get; set;
        //}
    }
}
