using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCancerProject.Core
{
    public class Biodata : Entity
    {
        //public virtual long Id
        //{
        //    get; set;
        //}
        public virtual Title Title
        {
            get; set;
        }
        public virtual string FirstName
        {
            get; set;
        }
        public virtual string LastName
        {
            get; set;
        }
        public virtual string OtherNames
        {
            get; set;
        }
        private string theName;
        public virtual string Name
        {
            get
            {
                return theName = this.FirstName + " " + this.LastName + " " + this.OtherNames;
            }
            set
            {
                Name = value;
            }
        }
        public virtual string HospitalNumber
        {
            get; set;
        }
        public virtual Hospital TheHospital
        {
            get; set;
        }
        public virtual Sex Sex
        {
            get; set;
        }
        public virtual string Address
        {
            get; set;
        }
        public virtual State StateOfResidence
        {
            get; set;
        }
        public virtual Religion Religion
        {
            get; set;
        }
        public virtual string Occupation
        {
            get; set;
        }
        public virtual string PhoneNumber
        {
            get; set;
        }
        public virtual string NextOfKinName
        {
            get; set;
        }
        public virtual string NextOfKinEmail
        {
            get; set;
        }
        public virtual string NextOfKinPhone
        {
            get; set;
        }
        public virtual Relationship NextOfKinRelationship
        {
            get; set;
        }

        public virtual MaritalStatus MaritalStatus
        {
            get; set;
        }
        public virtual DateTime DateOfBirth
        {
            get; set;
        }
        public virtual string Age
        {
            get; set;
        }
    }
}
