using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaCORE.Models
{
    public class ResumenEmpresas
    {
        public string codCliente { get; set; }
        public string empresa { get; set; }
        public string contacto { get; set; }
        public string cargo { get; set; }
        public string ciudad { get; set; }
        public string telefono { get; set; }

        public List<Pedido> Pedidos { get; set; }
    }
}
