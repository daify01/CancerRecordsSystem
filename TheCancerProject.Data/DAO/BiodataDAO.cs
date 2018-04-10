using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCancerProject.Core;

namespace TheCancerProject.Data.DAO
{
    public class BiodataDAO : CoreDAO<Biodata>
    {
        public List<Biodata> RetrieveByHospitalAndHospitalNumber(Hospital TheHospital, string HospitalNumber)
        {
            try
            {
                var results = new List<Biodata>();
                using (ISession session = GetSession())
                {
                    ICriteria criteria = session.CreateCriteria(typeof(Biodata));
                    criteria.Add(Expression.Eq("TheHospital", TheHospital));
                    criteria.Add(Expression.Eq("HospitalNumber", HospitalNumber));
                    results = criteria.List<Biodata>().ToList();
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
