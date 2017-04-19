using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WMS.ServiceCommon.Dao
{
		public interface IDao<TModel> : IDao<TModel, int>
		{

		}

		public interface IDao<TEntity, TId>
    {
        TEntity Get(TId id);

				TEntity Get(Expression<Func<TEntity, bool>> condition);

				IList<TEntity> GetAll();

				void Save(TEntity entity);

				void Update(TEntity entity);
		}
}
