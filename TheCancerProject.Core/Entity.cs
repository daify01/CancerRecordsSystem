using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCancerProject.Core
{
    public class Entity : IEntity
    {
        public virtual long Id
        {
            get; set;
        }


        public virtual DateTime DateCreated
        {
            get; set;
        }

        public virtual DateTime DateUpdated
        {
            get; set;
        }
        public virtual string UniqueID
        {
            get; set;
        }
    }

    public interface IEntity
    {
        long Id
        {
            get; set;
        }
    }
}
