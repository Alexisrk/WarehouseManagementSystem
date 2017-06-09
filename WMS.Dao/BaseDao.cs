using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Dialect.Schema;
using WMS.Dao.Config;
using WMS.ServiceCommon.Dao;
using System.Linq.Expressions;
using NHibernate.Linq;
using WMS.Dao.Mapping;
using WMS.Dao.Exceptions;
using Spring.Transaction.Interceptor;
using Spring.Stereotype;

namespace WMS.Dao
{
		[Repository]
		public abstract class BaseDao<TModel> : BaseDao<TModel, int> where TModel : class
		{
				
		}

		[Repository]
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
								var session = SessionFactory.GetCurrentSession();
								session.FlushMode = FlushMode.Always;
								session.CacheMode = CacheMode.Ignore;

								return session;
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

				public virtual IList<TModel> GetAll(Expression<Func<TModel, bool>> condition)
				{
						return this.CurrentSession.Query<TModel>().Where(condition).ToList();
				}

				public virtual TModel Get(Expression<Func<TModel, bool>> condition)
				{
						return this.CurrentSession.Query<TModel>().Where(condition).ToList().SingleOrDefault();
				}

			 [Transaction]
				public virtual void Save(TModel entity)
				{
						CheckActiveTransaction();
						CurrentSession.Save(entity);
						//CurrentSession.Flush();
				}

				[Transaction]
				public virtual void Update(TModel entity)
				{
						CheckActiveTransaction();
						CurrentSession.Update(entity);
					 CurrentSession.Flush();
				}

				[Transaction]
				public virtual void SaveOrUpdate(TModel entity)
				{
						CheckActiveTransaction();
						CurrentSession.SaveOrUpdate(entity);
				}

				[Transaction]
				public virtual void Delete(TModel entity)
				{
						CheckActiveTransaction();
						CurrentSession.Delete(entity);
				}



				protected virtual void CheckActiveTransaction()
				{
						if (!CurrentSession.Transaction.IsActive)
						{
								throw new NoActiveTransactionException();
						}
				}
		}
}
