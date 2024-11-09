using SERIVICIO_FARMACIA.clases;
using SERIVICIO_FARMACIA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SERIVICIO_FARMACIA.Controllers
{
    [EnableCors(origins: "http://localhost:65006", headers: "*", methods: "*")]
    [RoutePrefix("api/sucursal")]
    public class sucursalController : ApiController
    {
        [HttpGet]
        [Route("listartodos")]
        public List<SUCURSAL> listartodos()
        {
            clssucursal _sucursal = new clssucursal();
            return _sucursal.listarsucursales();
        }
    }
}