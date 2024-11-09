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
    [RoutePrefix("api/proveedores")]
    public class proveedoresController : ApiController
    {
        [HttpGet]
        [Route("listartodos")]
        public List<PROVEEDORE> listartodos()
        {
            clsproveedor _proveedor = new clsproveedor();
            return _proveedor.listarproveedores();
        }
        [HttpGet]
        [Route("Consultar")]
        public PROVEEDORE Consultar(int id)
        {

            clsproveedor _proveedor = new clsproveedor();
            return _proveedor.Consultar(id);
        }
        [HttpGet]
        [Route("Consultarxnombre")]
        public PROVEEDORE Consultarxnombre(string nombre) 
        {

            clsproveedor _proveedor = new clsproveedor();
            return _proveedor.Consultarxnombre(nombre);
        }
        [HttpGet]
        [Route("listar")]
        public IQueryable listar()
        {
            clsproveedor proveedor = new clsproveedor();
            return proveedor.listarprov();
        }
        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] PROVEEDORE Proveedor)
        {
            clsproveedor _proveedor = new clsproveedor();
            _proveedor.pr_objeto = Proveedor;
            return _proveedor.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] PROVEEDORE Proveedor)
        {
            clsproveedor _proveedor = new clsproveedor();
            _proveedor.pr_objeto = Proveedor;
            return _proveedor.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] PROVEEDORE Proveedor)
        {
             clsproveedor _proveedor = new clsproveedor();
            _proveedor.pr_objeto = Proveedor;
            return _proveedor.Eliminar();
        }
    }
}