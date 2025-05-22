
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_Jobster.API.Helpers
{
    public interface IApiKeyValidator
    {
        public bool IsValid(string apikey);
    }
}