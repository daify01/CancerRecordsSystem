using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCancerProject.Core
{
    public class Patient : Entity
    {
        //public virtual virtual long Id
        //{
        //    get; set;
        //}
        public virtual Biodata TheBiodata
        {
            get; set;
        }
        public virtual Hospital TheHospital
        {
            get; set;
        }
        public virtual HospitalUser LastUserAdministeringTreatment
        {
            get; set;
        }
        public virtual Complaints TheComplaints
        {
            get; set;
        }
        public virtual PreliminaryExamination ThePreliminaryExamination
        {
            get; set;
        }
        public virtual GeneralExamination TheGeneralExamination
        {
            get; set;
        }
        public virtual BreastAndAxillaryExamination TheBreastAndAxillaryExamination
        {
            get; set;
        }
        public virtual EventsOnAdmission TheEventsOnAdmission
        {
            get; set;
        }
        public virtual ClinicVisits TheClinicVisits
        {
            get; set;
        }
        public virtual Investigation TheInvestigation
        {
            get; set;
        }
        public virtual Procedures TheProcedures
        {
            get; set;
        }
        public virtual Diagnosis TheDiagnoses
        {
            get; set;
        }
        public virtual string UniqueID
        {
            get; set;
        }
        //public virtual DateTime LastDateUpdated   //Don't use this since there's the "Date Updated" property in Entity class
        //{
        //    get; set;
        //}
    }
}
