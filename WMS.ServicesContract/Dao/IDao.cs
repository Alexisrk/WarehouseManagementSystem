using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.ServicesContract.Dao
{
		public interface IDao<TModel> : IDao<TModel, int>
		{

		}

		public interface IDao<TEntity, TId>
    {
        TEntity Get(TId id);

        IList<TEntity> GetAll();

    }
}
