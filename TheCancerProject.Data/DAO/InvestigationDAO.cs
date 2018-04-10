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
   public class InvestigationDAO : CoreDAO<Investigation>
    {
        public List<Investigation> RetrieveByPatientHospitalNumber(string PatientHospitalNumber)
        {
            try
            {
                var results = new List<Investigation>();
                using (ISession session = GetSession())
                {
                    ICriteria criteria = session.CreateCriteria(typeof(Investigation));
                    criteria.Add(Expression.Eq("PatientHospitalNumber", PatientHospitalNumber));
                    results = criteria.List<Investigation>().ToList();
                }

                return results;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public List<Investigation> RetrieveByPatientUniqueID(string PatientUniqueID)
        {
            try
            {
                var results = new List<Investigation>();
                using (ISession session = GetSession())
                {
                    ICriteria criteria = session.CreateCriteria(typeof(Investigation));
                    criteria.Add(Expression.Eq("PatientUniqueID", PatientUniqueID));
                    results = criteria.List<Investigation>().ToList();
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
