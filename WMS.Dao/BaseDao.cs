﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Dialect.Schema;
using WMS.Dao.Config;
using WMS.ServicesContract.Dao;

namespace WMS.Dao
{
    public abstract class BaseDao<TModel> : BaseDao<TModel, int> where TModel : class
		{
				
		}

		public abstract class BaseDao<TModel, TId> : IDao<TModel, TId> where TModel : class
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

				public virtual TModel Get(TId id) {
						return CurrentSession.Get<TModel>(id);
				}

				public virtual IList<TModel> GetAll()
				{
						ICriteria criteria = CurrentSession.CreateCriteria<TModel>();
						return criteria.List<TModel>();
				}
				
		}
}
