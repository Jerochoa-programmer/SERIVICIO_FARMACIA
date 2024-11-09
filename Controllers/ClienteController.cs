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
    [RoutePrefix("api/Cliente")]
    public class ClienteController : ApiController
    {
        [HttpGet]
        [Route("Get")]
        public CLIENTE Get(long D)
        {
            clsCliente cliente = new clsCliente();
            return cliente.Consultar(D);
        }
        [HttpGet]
        [Route("listar")]
        public IQueryable listar()
        {
            clsCliente cliente = new clsCliente();
            return cliente.listarclientes();
        }
        [HttpPost]
        [Route("Post")]
            public string Post([FromBody] CLIENTE Cliente)
            {
                clsCliente _cliente = new clsCliente();
                _cliente.cliente = Cliente;
                return _cliente.Insertar();
            }
        [HttpPut]
        [Route("Put")]
        public string Put([FromBody] CLIENTE Cliente)
            {
                clsCliente _cliente = new clsCliente();
                _cliente.cliente = Cliente;
                return _cliente.Actualizar();
            }
        [HttpDelete]
        [Route("Delete")]
        public string Delete(CLIENTE Cliente)
            {
                clsCliente _cliente = new clsCliente();
                _cliente.cliente = Cliente;
                return _cliente.Eliminar();
            }
        }

    }
