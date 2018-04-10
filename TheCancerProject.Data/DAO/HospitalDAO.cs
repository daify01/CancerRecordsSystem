using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCancerProject.Core;
using TheCancerProject.Logic;

namespace TheCancerProject.Data.DAO
{
    public class HospitalDAO : CoreDAO<Hospital>
    {
        public List<Hospital> RetrieveByName(string hospitalName)
        {
            try
            {
                var results = new List<Hospital>();
                using (ISession session = GetSession())
                {
                    ICriteria criteria = session.CreateCriteria(typeof(Hospital));
                    criteria.Add(Expression.Eq("Name", hospitalName));
                    results = criteria.List<Hospital>().ToList();
                }

                return results;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
