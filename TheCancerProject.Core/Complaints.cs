using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCancerProject.Core
{
    public class Complaints : Entity
    {
        //public virtual long Id
        //{
        //    get; set;
        //}
        public virtual string TheComplaints
        {
            get; set;
        }
        public virtual string DurationOfComplaints
        {
            get; set;
        }
        public virtual string HistoryOfPresentingComplaints
        {
            get; set;
        }
        public virtual string TheCause
        {
            get; set;
        }
        public virtual string TheComplications
        {
            get; set;
        }
        public virtual string TheCare
        {
            get; set;
        }
    }
}
