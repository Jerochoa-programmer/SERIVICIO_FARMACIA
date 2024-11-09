using SERIVICIO_FARMACIA.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace SERIVICIO_FARMACIA.clases
{

    public class clsproveedor
    {
        private BDFarmaciaEntities bdfarmacia = new BDFarmaciaEntities();

        public PROVEEDORE pr_objeto { get; set; }

        public List<PROVEEDORE> listarproveedores()
        {
            return bdfarmacia.PROVEEDORES.ToList();
        }
        public string Insertar()
        {
            try
            {

                bdfarmacia.PROVEEDORES.Add(pr_objeto);
                bdfarmacia.SaveChanges();
                return "Se grabó el proveedor: " + pr_objeto.Nombreproveedor;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public IQueryable listarprov()
        {
            return from p in bdfarmacia.Set<PROVEEDORE>()
                   select new
                   {
                       IDProveedor = p.IDProveedor,
                       Nombreproveedor = p.Nombreproveedor,
                       Telefono = p.Telefono,
                       Correo = p.Correo,
                       Direccion = p.Direccion,

                   };
        }
        public string Actualizar()
        {
            try
            {
                PROVEEDORE _proveedor = Consultar(pr_objeto.IDProveedor);
                if (_proveedor != null)
                {
                    bdfarmacia.PROVEEDORES.AddOrUpdate(pr_objeto);
                    bdfarmacia.SaveChanges();
                    return "Se actualizaron los datos del proveedor: " + pr_objeto.Nombreproveedor;
                }
                else
                {
                    return "El proveedor no se encuentra en la base de datos";
                }
                
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Eliminar()
        {
            try
            {

                PROVEEDORE _proveedor = Consultar(pr_objeto.IDProveedor);

                if (_proveedor == null)
                {

                    return "El proveedor no se encuentra en la base de datos";
                }
                else
                {
                    bdfarmacia.PROVEEDORES.Remove(_proveedor);
                    bdfarmacia.SaveChanges();
                    return "Se eliminó el PROVEEDORE: " + pr_objeto.IDProveedor;
                }
            }
            catch (Exception ex)
            {
                // Crear un mensaje detallado con las excepciones internas más profundas
                string errorMessage = $"Error al eliminar el proveedor con ID {pr_objeto.IDProveedor}. " +
                                      $"Mensaje de error: {ex.Message}. " +
                                      $"Stack Trace: {ex.StackTrace}";

                Exception inner = ex.InnerException;
                while (inner != null)
                {
                    errorMessage += $" Excepción interna: {inner.Message}. " +
                                    $"Stack Trace interna: {inner.StackTrace}";
                    inner = inner.InnerException;
                }

                return errorMessage;  // Retornar el mensaje detallado del error
            }
        }
        
        public PROVEEDORE Consultar(int id)
        {

            return bdfarmacia.PROVEEDORES.FirstOrDefault(p => p.IDProveedor == id);
        }
        public PROVEEDORE Consultarxnombre(string nombre)
        {

            return bdfarmacia.PROVEEDORES.FirstOrDefault(p => p.Nombreproveedor == nombre);
        }
    }
}