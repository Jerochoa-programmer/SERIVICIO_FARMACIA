using SERIVICIO_FARMACIA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace SERIVICIO_FARMACIA.clases
{
    public class clsCliente
    {
        public CLIENTE cliente { get; set; }
        private BDFarmaciaEntities dbFarmacia = new BDFarmaciaEntities();
        public string Insertar()
        {
            try
            {
                dbFarmacia.CLIENTES.Add(cliente);
                dbFarmacia.SaveChanges();
                return "Se ingresó el cliente con Documento: " + cliente.Documento;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                var errorMessages = dbEx.EntityValidationErrors
                    .SelectMany(eve => eve.ValidationErrors)
                    .Select(ve => ve.ErrorMessage);

                return "Errores de validación: " + string.Join("; ", errorMessages);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public IQueryable listarclientes()
        {
            return from c in dbFarmacia.Set<CLIENTE>()
                   select new
                   {
                       IDCliente = c.IDCliente,
                       Nombre = c.Nombre,
                       Documento = c.Documento,
                       Telefono = c.Telefono,
                       CorreoElectronico = c.CorreoElectronico,
                       Direccion = c.Direccion,
                   };
        }
        public string Actualizar()
        {
            try
            {
                CLIENTE _cliente = Consultar(cliente.Documento);
                if (_cliente == null)
                {
                    return "El cliente con Documento: " + cliente.Documento + ", no existe en la base de datos.";
                }
                _cliente.Nombre = cliente.Nombre;
                _cliente.Documento = cliente.Documento;
                _cliente.Telefono = cliente.Telefono;
                _cliente.CorreoElectronico = cliente.CorreoElectronico;
                _cliente.Direccion = cliente.Direccion;
                dbFarmacia.SaveChanges();
                return "Se actualizó el cliente: " + cliente.Documento;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public CLIENTE Consultar(long documento)
        {
            return dbFarmacia.CLIENTES.FirstOrDefault(c => c.Documento == documento);
        }
        public string Eliminar()
        {
            CLIENTE _cliente = Consultar(cliente.Documento);
            if (_cliente == null)
            {
                return "El cliente con  Documento: " + cliente.Documento + " no existe en la base de datos.";
            }
            try
            {
                dbFarmacia.CLIENTES.Remove(_cliente);
                dbFarmacia.SaveChanges();
                return "Se eliminó el cliente con Documento: " + cliente.Documento;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}