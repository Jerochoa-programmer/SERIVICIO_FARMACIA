using SERIVICIO_FARMACIA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SERIVICIO_FARMACIA.clases
{
    public class clscategoria
    {
        private BDFarmaciaEntities bdfarmacia = new BDFarmaciaEntities();

        public CATEGORIA c_objeto { get; set; }

        public List<CATEGORIA> listarcategorias()
        {
            return bdfarmacia.CATEGORIAs.ToList();
        }
    }
}