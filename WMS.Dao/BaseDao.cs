using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace WMS.Dao
{
    public abstract class BaseDao
    {
        private ISessionFactory sessionFactory;

        /// <summary>
        /// Session factory for sub-classes.
        /// </summary>
        public ISessionFactory SessionFactory
        {
            protected get { return sessionFactory; }
            set { sessionFactory = value; }
        }

        /// <summary>
        /// Get's the current active session. Will retrieve session as managed by the 
        /// Open Session In View module if enabled.
        /// </summary>
        protected ISession CurrentSession
        {
            get { return sessionFactory.GetCurrentSession(); }
        }

        protected IList<T> GetAll<T>() where T : class
        {
            ICriteria criteria = CurrentSession.CreateCriteria<T>();
            return criteria.List<T>();
        }
    }
    
}
