using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCancerProject.Core
{
   public class Investigation : Entity
    {
        public virtual byte [] Image
        {
            get; set;
        }
        public virtual string Summary
        {
            get; set;
        }
        public virtual string PatientHospitalNumber
        {
            get; set;
        }
        public virtual string PatientUniqueID           //This still stores the "UniqueID" property in core entity, but is needed because this mirror property isn't unique for investiagtions entity
        {
            get; set;
        }
        //public virtual DateTime DateUploaded
        //{
        //    get; set;
        //}
    }
}
