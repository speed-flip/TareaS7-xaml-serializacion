using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using TareaS7.Models;
using Xamarin.Forms;

namespace TareaS7.ViewModel
{
    public class VMPrestamos : INotifyPropertyChanged
    {
        public VMPrestamos() {
            try { 
                listaLibros = App.Current.Properties["listaLibros"] as ObservableCollection<Libros>;
                listaPersonas = App.Current.Properties["listaPersonas"] as ObservableCollection<Persona>;

            } catch (Exception ex){ }

            PrestarLibro = new Command(() => {
                personaSeleccionada.LibrosPersona.Add(libroSeleccionado);
            });
        }

        Libros libro;
        public Libros Libro
        {

            get => libro;
            set
            {
                libro = value;
                var arg = new PropertyChangedEventArgs(nameof(libro));
                PropertyChanged?.Invoke(this, arg);
            }
        }

        Persona persona;
        public Persona Person
        {
            get => persona;
            set
            {
                persona = value;
                var arg = new PropertyChangedEventArgs(nameof(Person));
                PropertyChanged?.Invoke(this, arg);
            }
        }

        DateTime fechaPrestamo;
        public DateTime FechaPrestamo
        {
            get => fechaPrestamo;
            set
            {
                fechaPrestamo = value;
                var arg = new PropertyChangedEventArgs(nameof(FechaPrestamo));
                PropertyChanged?.Invoke(this, arg);
            }
        }

        DateTime fechaDevolucion;
        public DateTime FechaDevolucion
        {
            get => fechaDevolucion;
            set
            {
                fechaDevolucion = value;
                var arg = new PropertyChangedEventArgs(nameof(FechaDevolucion));
                PropertyChanged?.Invoke(this, arg);
            }
        }

        Persona personaSeleccionada = new Persona();
        public Persona PersonaSeleccionada {
        
            get => personaSeleccionada;
            set {
                personaSeleccionada = value;
                var arg = new PropertyChangedEventArgs(nameof(PersonaSeleccionada));
                PropertyChanged?.Invoke(this, arg);
            }
        }

        Libros libroSeleccionado = new Libros();
        public Libros LibroSeleccionado {
            get => libroSeleccionado;
            set {
                libroSeleccionado = value;
                var arg = new PropertyChangedEventArgs(nameof(LibroSeleccionado));
                PropertyChanged?.Invoke(this, arg);
            }
        }

        public Command PrestarLibro { get; }
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Persona> listaPersonas { get; set; } = new ObservableCollection<Persona>();
        public ObservableCollection<Libros> listaLibros { get; set; } = new ObservableCollection<Libros>();


    }
}
