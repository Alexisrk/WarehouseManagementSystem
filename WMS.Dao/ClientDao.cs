﻿using System.Collections.Generic;
using Spring.Stereotype;
using Spring.Transaction.Interceptor;
using WMS.Model.Domain;
using WMS.ServiceCommon.Dao;
using System;

namespace WMS.Dao
{
    [Repository]
    public class ClientDao : BaseDao<Client, string>, IClientDao
		{

		}
}
