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
    
    public partial class DESCUENTO
    {
        public int IDDescuento { get; set; }
        public Nullable<int> IDCliente { get; set; }
        public Nullable<double> PorcentajeDescuento { get; set; }
        public Nullable<System.DateTime> FechaExpiracion { get; set; }
    
        public virtual CLIENTE CLIENTE { get; set; }
    }
}
