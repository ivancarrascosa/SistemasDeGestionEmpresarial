using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class ListaMisionesConMisionElegida
    {
        List<Mision> listaMisiones { get; }

        Mision? misionElegida { get; }

        public List<Mision> ListaMisiones
        {
            get { return listaMisiones; }
        }

        public Mision? MisionElegida
        {
            get { return misionElegida; }
        }
        public ListaMisionesConMisionElegida(List<Mision> listaMisiones, int misionElegidaId)
        {
            this.listaMisiones = listaMisiones;
            this.misionElegida = null;
            foreach (Mision mision in listaMisiones)
            {
                if (mision.Id == misionElegidaId)
                {
                    this.misionElegida = mision;
                    break;
                }
            }
        }

        public ListaMisionesConMisionElegida(List<Mision> listaMisiones)
        {
            this.listaMisiones = listaMisiones;
            this.misionElegida = null;
        }
    }
}
