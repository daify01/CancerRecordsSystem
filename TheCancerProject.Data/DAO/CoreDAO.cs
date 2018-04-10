using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Linq;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCancerProject.Core;
using TheCancerProject.Data.Mappings;

namespace TheCancerProject.Data.DAO
{
    public class CoreDAO <T> where T : Entity
    {
        private ISessionFactory factory;
        protected ISession GetSession()
        {
            if (factory == null)
            {
                factory = CreateSessionFactory();
            }
            return factory.OpenSession();
        }

        //public static ISession OpenSession()
        //{
        //    string Connection = ConfigurationSettings.AppSettings["ConnectionString"];
        //    ISessionFactory sessionFactory = Fluently.Configure()
        //        .Database(MsSqlConfiguration.MsSql2008
        //          .ConnectionString(Connection)
        //                      .ShowSql()
        //        )
        //       .Mappings(m =>
        //                  m.FluentMappings
        //        //.AddFromAssemblyOf<T>())
        //        .AddFromAssemblyOf<BiodataMap>())
        //        .ExposeConfiguration(CreateSchema)
        //                        .BuildConfiguration()
        //                        .BuildSessionFactory();
        //}

        ISessionFactory CreateSessionFactory()
        {
            string connString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            return Fluently.Configure()
                            .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connString))
                            //.Mappings(m => m.FluentMappings
                            //                    .AddFromAssemblyOf<BiodataMap>())
                                 .Mappings(m => m.FluentMappings
                                                .AddFromAssemblyOf<BiodataMap>())
                                .ExposeConfiguration(CreateSchema)
                                .BuildConfiguration()
                                .BuildSessionFactory();
        }

        private static void CreateSchema(NHibernate.Cfg.Configuration cfg)
        {
            new SchemaUpdate(cfg).Execute(false, true);
        }

        public static void Save(T obj)
        {
            try
            {
                using (ISession session = new CoreDAO<T>().GetSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(obj);
                        transaction.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public T Retrieve(long id)
        {
            try
            {
                T result;
                //var result = (T)new object();
                using (ISession session = new CoreDAO<T>().GetSession())
                {
                    result = session.Get<T>(id);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public static IList<T> RetrieveAll()
        {
            IList<T> theList = new List<T>();
            using (var session = new CoreDAO<T>().GetSession())
            {
                using (var trans = session.BeginTransaction())
                {
                    theList = session.Query<T>().ToList();
                    trans.Commit();
                }

            }

            return theList;
        }
        public T RetrieveByUniqueID(string UniqueID)
        {
            try
            {
                UniqueID = !(string.IsNullOrWhiteSpace(UniqueID)) ? UniqueID.Trim() : string.Empty;
                //var results = new List<Patient>();
                T result;
                using (ISession session = GetSession())
                {
                    result = session.CreateCriteria(typeof(T))
                    .Add(NHibernate.Criterion.Expression.Eq("UniqueID", UniqueID)).SetMaxResults(1).UniqueResult<T>();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public static void Update(T Obj)
        {
            try
            {
                using (ISession session = new CoreDAO<T>().GetSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Update(Obj);
                        transaction.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public static void Delete(T Obj)
        {
            try
            {
                using (ISession session = new CoreDAO<T>().GetSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Delete(Obj);
                        transaction.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

    }
}
