using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCancerProject.Core
{
    public class Hospital : Entity
    {
        //public virtual long Id
        //{
        //    get; set;
        //}
        public virtual string Name
        {
            get; set;
        }
        public virtual string Address
        {
            get; set;
        }
        public virtual string PrimaryContactEmail
        {
            get; set;
        }
        public virtual string PrimaryContactNumber
        {
            get; set;
        }
    }
}
