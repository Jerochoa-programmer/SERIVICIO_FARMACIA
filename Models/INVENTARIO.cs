//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SERIVICIO_FARMACIA.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class INVENTARIO
    {
        public int IDInventario { get; set; }
        public Nullable<int> IDProducto { get; set; }
        public Nullable<int> IDSucursal { get; set; }
        public Nullable<int> Cantidad { get; set; }
        public Nullable<System.DateTime> FechaIngreso { get; set; }
        public Nullable<System.DateTime> FechaVencimiento { get; set; }
    
        public virtual PRODUCTO PRODUCTO { get; set; }
        public virtual SUCURSAL SUCURSAL { get; set; }
    }
}
