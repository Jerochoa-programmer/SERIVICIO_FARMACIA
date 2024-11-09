using SERIVICIO_FARMACIA.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace SERIVICIO_FARMACIA.clases
{
    public class clsfarmaceuta
    {
        private BDFarmaciaEntities bdfarmacia = new BDFarmaciaEntities();
        public FARMACEUTA f_objeto { get; set; }

        public string insertar()
        {
            try
            {
                bdfarmacia.FARMACEUTAs.Add(f_objeto);
                bdfarmacia.SaveChanges();
                return "Se ingresó el farmaceuta con documento : " + f_objeto.Documento;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public IQueryable listarfarmaceutas()
        {
            return from s in bdfarmacia.Set<SUCURSAL>()
                   join f in bdfarmacia.Set<FARMACEUTA>()
                   on s.IDSucursal equals f.IDSucursal
                   select new
                   {
                       Documento = f.Documento,
                       Nombre = f.Nombre,
                       Cargo = f.Cargo,
                       Telefono = f.Telefono,
                       Correo = f.Correo,
                       FechaContratacion = f.FechaContratacion,
                       NombreSucursal = s.NombreSucursal,
                       Direccion = s.Direccion,
                        };
        }
        public string actualizar()
        {
            try { 
                FARMACEUTA _farmaceuta = consultar(f_objeto.Documento);
                if (_farmaceuta == null)
                {
                    return "No se encontró el elemento a actualizar";
                }
                else
                {
                    _farmaceuta.Nombre = f_objeto.Nombre;
                    _farmaceuta.Cargo = f_objeto.Cargo;
                    _farmaceuta.Telefono = f_objeto.Telefono;
                    _farmaceuta.Correo = f_objeto.Correo;
                    _farmaceuta.FechaContratacion = f_objeto.FechaContratacion;
                    _farmaceuta.IDSucursal = f_objeto.IDSucursal;
                    bdfarmacia.SaveChanges();
                    return "Se actualizó el farmaceuta con documento: " + f_objeto.Documento;
                }
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
                FARMACEUTA _farmaceuta = consultar(f_objeto.Documento);
                if (_farmaceuta == null)
                {
                    return "No se encontró el farmaceuta";
                }
                else
                {
                    bdfarmacia.FARMACEUTAs.Remove(_farmaceuta);
                    bdfarmacia.SaveChanges() ;
                    return "Se eliminó el farmaceuta con documento : " + f_objeto.Documento;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public FARMACEUTA consultar(long? documento)
        {
            try
            {
                return bdfarmacia.FARMACEUTAs.FirstOrDefault(f => f.Documento == documento);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al consultar el farmaceuta con ID {documento}: {ex.Message}", ex);
            }
            
        }
    }
}