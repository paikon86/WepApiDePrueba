using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WepApiDePrueba.Helpers
{

    public class MisFiltrosDeAccion : IActionFilter
    {
        private readonly ILogger<MisFiltrosDeAccion> logger;
        
        public MisFiltrosDeAccion(ILogger<MisFiltrosDeAccion> logger)
        {
            this.logger = logger;
        }


        public void OnActionExecuted(ActionExecutedContext context)
        {
            throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
