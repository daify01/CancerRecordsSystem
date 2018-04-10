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
   public class PatientDAO : CoreDAO<Patient>
    {
        public bool DoesUniqueIDAlreadyExist(string UniqueID)
        {
            bool retVal = false;
            try
            {
                var results = new List<Patient>();
                using (ISession session = GetSession())
                {
                    ICriteria criteria = session.CreateCriteria(typeof(Patient));
                    criteria.Add(Expression.Eq("UniqueID", UniqueID));
                    results = criteria.List<Patient>().ToList();
                }

                if (results != null && results.Count > 0)
                    retVal = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return retVal;
        }

        public Patient RetrieveByUniqueID(string UniqueID)
        {
            try
            {
                UniqueID = !(string.IsNullOrWhiteSpace(UniqueID)) ? UniqueID.Trim() : string.Empty;
                //var results = new List<Patient>();
                Patient result = null;
                using (ISession session = GetSession())
                {
                    result = session.CreateCriteria(typeof(Patient))
                    .Add(Expression.Eq("UniqueID", UniqueID)).SetMaxResults(1).UniqueResult<Patient>();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public string CreateUniqueID()
        {
            string uniqueID = string.Empty;
            try
            {                
                if (DoesUniqueIDAlreadyExist(CreatePasskey(out uniqueID)))
                {
                    bool hasUniqueIDBeenCreated = false;
                    int retries = 1;
                    while (hasUniqueIDBeenCreated == false)
                    {
                        retries++;
                        if (retries > 1000)
                        {
                            throw new ApplicationException("Could Not Create Unique ID for Patient After 1000 tries. Kinldy Contact Administrator to resolve");
                        }
                        if (DoesUniqueIDAlreadyExist(CreatePasskey(out uniqueID)))
                        {
                            //Stay IN LOOP UNTIL UNIQUE ID IS CREATED
                            continue;
                        }
                        else
                        {
                            hasUniqueIDBeenCreated = true;
                            break;
                        }
                    }
                }
                else
                {
                    return uniqueID;
                }
                return uniqueID;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }            
        }

        public string CreatePasskey(out string retVal)
        {
            string passkey = String.Format("{0}{1:yMdhhmmssfff}", Guid.NewGuid().ToString().Replace("-", "").Substring(0, 30), DateTime.Now);
            retVal = passkey;
            return passkey;
        }
    }
}
