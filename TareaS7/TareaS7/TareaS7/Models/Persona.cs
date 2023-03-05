using System;
using System.Collections.Generic;
using System.Text;

namespace TareaS7.Models

/*
            Ejercicio de Clase

        1)	Crear una aplicación que tenga dos pestañas 
        2)	Vamos a Almacenar 
        a.	Libros: Nombre, Autor, Fecha de Impresión. 
        b.	Personas: Nombre, NumeroCuenta.
        3)	Implementar MVVM
 */
{
    [Serializable]
    public class Persona
    {
        public string nombre { get; set; }
        public int numeroCuenta { get; set; }
        public List<Libros> LibrosPersona { get; set; } = new List<Libros>();


        public override string ToString()
        {
            return $"{nombre} - {numeroCuenta}";
        }
    }
}
