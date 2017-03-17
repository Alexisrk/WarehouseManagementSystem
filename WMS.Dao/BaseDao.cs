using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Dialect.Schema;
using WMS.Dao.Config;

namespace WMS.Dao
{
    public abstract class BaseDao
    {
        public ISessionFactory SessionFactory { get; set; }
    
        /// <summary>
        /// Get's the current active session. Will retrieve session as managed by the 
        /// Open Session In View module if enabled.
        /// </summary>
        protected ISession CurrentSession
        {
            get
            {
                return SessionFactory.GetCurrentSession();
            }
        }

        protected IList<T> GetAll<T>() where T : class
        {
            ICriteria criteria = CurrentSession.CreateCriteria<T>();
            return criteria.List<T>();
        }
    }
    
}
