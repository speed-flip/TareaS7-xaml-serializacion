using System;
using System.Collections.Generic;
using System.Text;

namespace TareaS7.Models
{
    [Serializable]
    public class Libros
    {
        public string nombre { get; set; }
        public string autor { get; set; }
        public DateTime fechaImpresion { get; set; }
        public List<Libros> libros { get; set; } = new List<Libros>();


        public override string ToString()
        {
            return $"{nombre} - {autor}";
        }

    }
}
