using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTest
{
    public class BasicService : IBasicService
    {
        public string GetMessage()
        {
            return "Test service message";
        }
    }
}
