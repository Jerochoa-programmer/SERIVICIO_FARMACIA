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
    [RoutePrefix("api/farmaceuta")]
    public class farmaceutaController : ApiController
    {
        [HttpGet]
        [Route("consultar")]
        public FARMACEUTA consultar(long documento)
        {
            clsfarmaceuta _farmaceuta = new clsfarmaceuta();
            return _farmaceuta.consultar(documento);
        }
        [HttpGet]
        [Route("listar")]
        public IQueryable listar()
        {
            clsfarmaceuta _farmaceuta = new clsfarmaceuta();
            return _farmaceuta.listarfarmaceutas();
        }

        [HttpPost]
        [Route("insertar")]
        public string insertar([FromBody] FARMACEUTA f_objeto)
        {
            clsfarmaceuta _farmaceuta = new clsfarmaceuta();
            _farmaceuta.f_objeto = f_objeto;
            return _farmaceuta.insertar();
        }

        [HttpPut]
        [Route("actualizar")]
        public string actualizar([FromBody] FARMACEUTA f_objeto)
        {
            clsfarmaceuta _farmaceuta = new clsfarmaceuta();
            _farmaceuta.f_objeto = f_objeto;
            return _farmaceuta.actualizar();
        }

        [HttpDelete]
        [Route("eliminar")]
        public string eliminar([FromBody] FARMACEUTA f_objeto)
        {
            clsfarmaceuta _farmaceuta = new clsfarmaceuta();
            _farmaceuta.f_objeto = f_objeto;
            return _farmaceuta.eliminar();
        }
    }
}