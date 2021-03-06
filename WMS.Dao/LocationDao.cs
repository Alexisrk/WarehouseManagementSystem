﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spring.Transaction.Interceptor;
using WMS.Model.Domain;
using WMS.ServiceCommon.Dao;

namespace WMS.Dao
{
    public class LocationDao : BaseDao<Location>, ILocationDao
    {
        [Transaction(ReadOnly = true)]
        public Location Get(string customerId)
        {
            return CurrentSession.Get<Location>(customerId);
        }

        //[Transaction(ReadOnly = true)]
        //public IList<Location> GetAll()
        //{
        //    var list = GetAll<Location>();
        //    return list;
        //}
    }
}
