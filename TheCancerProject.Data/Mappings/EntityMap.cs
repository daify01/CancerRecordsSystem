using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCancerProject.Core;

namespace TheCancerProject.Data.Mappings
{
    public class EntityMap<T> : ClassMap<T> where T : Entity
    {
        public EntityMap()
        {
            Id(x => x.Id).Unique().Not.Nullable();
            Map(x => x.DateCreated);
            Map(x => x.DateUpdated);
            Map(x => x.UniqueID).CustomSqlType("nvarchar(max)").Length(int.MaxValue).Unique();        //HINT:Manually Create
        }
    }
}
