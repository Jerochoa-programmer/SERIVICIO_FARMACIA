using SERIVICIO_FARMACIA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SERIVICIO_FARMACIA.clases
{
    public class clssucursal
    {
        private BDFarmaciaEntities bdfarmacia = new BDFarmaciaEntities();

        public SUCURSAL s_objeto { get; set; }

        public List<SUCURSAL> listarsucursales()
        {
            return bdfarmacia.SUCURSALs.ToList();
        }
    }
}