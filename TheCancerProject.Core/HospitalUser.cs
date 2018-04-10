using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCancerProject.Core
{
   public class HospitalUser : Entity
    {
        //public virtual long Id
        //{
        //    get; set;
        //}
        public virtual Hospital TheHospital
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
        public virtual string UserName
        {
            get; set;
        }
        public virtual string Password
        {
            get; set;
        }
        public virtual string SessionID
        {
            get; set;
        }
        public virtual string LastLoginDate
        {
            get; set;
        }
        public virtual bool IsLoggedIn
        {
            get; set;
        }
        public virtual bool IsHospitalAdmin
        {
            get; set;
        }
        public virtual bool IsSuperAdmin
        {
            get; set;
        }
        public virtual string Email
        {
            get; set;
        }
        public virtual string Phone
        {
            get; set;
        }
        public virtual UserRole UserRole
        {
            get; set;
        }
        public virtual bool IsFirstLogin
        {
            get; set;
        }
    }
}
