using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHIMS.WebApi.Helpers
{
    public interface ICurrentUserService
    {
        string GetCurrentUsername();
    }
}
