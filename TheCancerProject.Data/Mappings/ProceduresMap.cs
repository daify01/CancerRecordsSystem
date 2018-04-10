using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCancerProject.Core;

namespace TheCancerProject.Data.Mappings
{
    public class ProceduresMap : EntityMap<Procedures>
    {
        public ProceduresMap()
        {
            Map(x => x.ProceduresDone);
            Map(x => x.PostOpOrders);
            Map(x => x.DischargeMedicationsWithDoses);
            Map(x => x.DischargeState);
        }
    }
}
