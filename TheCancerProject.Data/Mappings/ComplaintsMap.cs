using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCancerProject.Core;

namespace TheCancerProject.Data.Mappings
{
    public class ComplaintsMap : EntityMap<Complaints>
    {
        public ComplaintsMap()
        {
            //Map(x => x.Id);
            Map(x => x.DurationOfComplaints);
            Map(x => x.HistoryOfPresentingComplaints);
            Map(x => x.TheCare);
            Map(x => x.TheCause);
            Map(x => x.TheComplaints);
            Map(x => x.TheComplications);
        }
    }
}
