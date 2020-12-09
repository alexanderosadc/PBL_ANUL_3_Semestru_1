using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBLSecurity.Controllers
{

    [Microsoft.AspNetCore.Components.Route("api/3Dmodel")]
    [ApiController]
    public class D3ModelController
    {
        D3ModelManager d3Model;

        public D3ModelController()
        {
            d3Model = new D3ModelManager();
        }

        [HttpGet("getModel")]
        public String Get()
        {
            return d3Model.Get3DmodelBytes();
        }
    }
}
