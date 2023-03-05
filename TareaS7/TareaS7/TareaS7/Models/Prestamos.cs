using System;
using System.Collections.Generic;
using System.Text;

namespace TareaS7.Models
{
    [Serializable]
    public class Prestamos
    {
        public Libros libro { get; set; }
        public Persona persona { get; set; }
        public DateTime fechaPrestamo { get; set; }
        public DateTime fechaDevolucion { get; set; }

        public override string ToString()
        {
            return $"El libro {libro} se presto a {persona} el dia {fechaPrestamo} y lo devolvio {fechaDevolucion}";
        }
    }
}
