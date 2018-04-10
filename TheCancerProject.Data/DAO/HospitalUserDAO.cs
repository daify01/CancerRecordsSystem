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
    public class HospitalUserDAO : CoreDAO<HospitalUser>
    {
        public List<HospitalUser> RetrieveByLoginDetails(Hospital TheHospital, string TheUserName, string ThePassword)
        {
            try
            {
                var results = new List<HospitalUser>();
                using (ISession session = GetSession())
                {
                    ICriteria criteria = session.CreateCriteria(typeof(HospitalUser));
                    criteria.Add(Expression.Eq("TheHospital", TheHospital));
                    criteria.Add(Expression.Eq("UserName", TheUserName));
                    criteria.Add(Expression.Eq("Password", new HospitalUserLogic().HashPassword(ThePassword)));
                    results = criteria.List<HospitalUser>().ToList();
                }

                return results;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public List<HospitalUser> RetrieveAdminUser(string TheUserName)
        {
            try
            {
                var results = new List<HospitalUser>();
                using (ISession session = GetSession())
                {
                    ICriteria criteria = session.CreateCriteria(typeof(HospitalUser));
                    criteria.Add(Expression.Eq("UserName", TheUserName));
                    results = criteria.List<HospitalUser>().ToList();
                }

                return results;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public List<HospitalUser> RetrieveUser(string TheUserName, UserRole Role, Hospital hospital)
        {
            try
            {
                var results = new List<HospitalUser>();
                using (ISession session = GetSession())
                {
                    ICriteria criteria = session.CreateCriteria(typeof(HospitalUser));
                    criteria.Add(Expression.Eq("UserName", TheUserName));
                    criteria.Add(Expression.Eq("UserRole", TheUserName));
                    criteria.Add(Expression.Eq("TheHospital", hospital));
                    results = criteria.List<HospitalUser>().ToList();
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
