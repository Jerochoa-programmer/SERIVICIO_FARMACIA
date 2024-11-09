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
    [RoutePrefix("api/producto")]
    public class productoController : ApiController
    {
            [HttpGet]
            [Route("consultar")]
            public PRODUCTO consultar(int idproducto)
            {
                clsproductos _producto = new clsproductos();
                return _producto.consultar(idproducto);
            }
            [HttpGet]
            [Route("listar")]
            public IQueryable listar()
            {
                clsproductos _producto = new clsproductos();
                return _producto.listarproductos();
            }

            [HttpPost]
            [Route("insertar")]
            public string insertar([FromBody] PRODUCTO p_objeto)
            {
                clsproductos _producto = new clsproductos();
                _producto.p_objeto = p_objeto;
                return _producto.insertar();
            }

            [HttpPut]
            [Route("actualizar")]
            public string actualizar([FromBody] PRODUCTO p_objeto)
            {
                clsproductos _producto = new clsproductos();
                _producto.p_objeto = p_objeto;
                return _producto.actualizar();
            }

            [HttpDelete]
            [Route("eliminar")]
            public string eliminar([FromBody] PRODUCTO p_objeto)
            {
                clsproductos _producto = new clsproductos();
                _producto.p_objeto = p_objeto;
                return _producto.eliminar();
            }
        }
    }
