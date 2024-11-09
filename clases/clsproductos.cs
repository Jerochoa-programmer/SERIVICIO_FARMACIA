using SERIVICIO_FARMACIA.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace SERIVICIO_FARMACIA.clases
{
    public class clsproductos
    {
        private BDFarmaciaEntities bdfarmacia = new BDFarmaciaEntities();
        public PRODUCTO p_objeto { get; set; }

        public string insertar()
        {
            try
            {
                bdfarmacia.PRODUCTOS.Add(p_objeto);
                bdfarmacia.SaveChanges();
                return "Se ingresó el producto con id : " + p_objeto.IDProducto;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
           
        }
        public IQueryable listarproductos()
        {
            return from p in bdfarmacia.Set<PRODUCTO>()
                   join c in bdfarmacia.Set<CATEGORIA>()
                   on p.IDCategoria equals c.IDCategoria
                   join pr in bdfarmacia.Set<PROVEEDORE>()
                   on p.IDProveedor equals pr.IDProveedor
                   select new
                   {
                       IDProducto = p.IDProducto,
                       Nombreproducto = p.Nombreproducto,
                       Descripcion = p.Descripcion,
                       Presentacion = p.Presentacion,
                       Cantidad = p.Cantidad,
                       PrecioUnitario = p.PrecioUnitario,
                       Nombrecategoria = c.Nombrecategoria,
                       Nombreproveedor = pr.Nombreproveedor,
                   };
        }
        public string actualizar()
        {
            try
            {
                bdfarmacia.PRODUCTOS.AddOrUpdate(p_objeto);
                bdfarmacia.SaveChanges();
                return "Se actualizó el farmaceuta con id :" + p_objeto.IDProducto;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string eliminar()
        {
            try
            {
                PRODUCTO _producto = consultar(p_objeto.IDProducto);
                if (_producto == null)
                {
                    return "No se encontró el farmaceuta";
                }
                else
                {
                    bdfarmacia.PRODUCTOS.Remove(_producto);
                    bdfarmacia.SaveChanges();
                    return "Se eliminó el farmaceuta con id : " + p_objeto.IDProducto;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public PRODUCTO consultar(int idproducto)
        {
            
            return bdfarmacia.PRODUCTOS.FirstOrDefault(p => p.IDProducto == idproducto);
            

        }
    }
}