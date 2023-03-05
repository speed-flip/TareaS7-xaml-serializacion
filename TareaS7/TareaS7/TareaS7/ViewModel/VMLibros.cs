using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using TareaS7.Models;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

namespace TareaS7.ViewModel
{

    public class VMLibros : INotifyPropertyChanged
    {
        public VMLibros() {
            AbrirListaPersonas();

            AgregarLibro = new Command(() => {

                Libros lb = new Libros() {
                
                    nombre = this.nombre,
                    autor = this.autor,
                    fechaImpresion = this.fechaImpresion,
                };

                ListaLibros.Add(lb);

                //Serializacion
                BinaryFormatter formatter = new BinaryFormatter();
                string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "libros.lb");
                Stream file = new FileStream(ruta, FileMode.Create, FileAccess.Write, FileShare.None);

                formatter.Serialize(file, ListaLibros);
                file.Close();

                //Fin de Serializar

                App.Current.Properties["listaLibros"] = ListaLibros;

            });
        }

        private void AbrirListaPersonas() {
            try
            {

                /*Proceso de Deserializacion (Ingeniera Inversa de Serializar, leer archivos) */
                BinaryFormatter formatter = new BinaryFormatter();
                string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "libros.lb");
                Stream archivo = new FileStream(ruta, FileMode.Open, FileAccess.Read, FileShare.None);

                ListaLibros = (ObservableCollection<Libros>)formatter.Deserialize(archivo);

                archivo.Close();

                App.Current.Properties["listaLibros"] = ListaLibros;

            }
            catch (Exception ex)
            {
                ListaLibros = new ObservableCollection<Libros>();
            }
        }

        string nombre;
        public string Nombre {

            get => nombre;
            set {
                nombre = value;
                var arg = new PropertyChangedEventArgs(nameof(Nombre));
                PropertyChanged?.Invoke(this, arg);
            }
        }


        string autor;
        public string Autor
        {

            get => autor;
            set
            {
                autor = value;
                var arg = new PropertyChangedEventArgs(nameof(Autor));
                PropertyChanged?.Invoke(this, arg);
            }
        }

        DateTime fechaImpresion;
        public DateTime FechaImpresion
        {

            get => fechaImpresion;
            set
            {
                fechaImpresion = value;
                var arg = new PropertyChangedEventArgs(nameof(FechaImpresion));
                PropertyChanged?.Invoke(this, arg);
            }
        }

        ObservableCollection<Libros> listaLibros = new ObservableCollection<Libros>();

        public ObservableCollection<Libros> ListaLibros
        {

            get => listaLibros;
            set
            {

                listaLibros = value;
                var arg = new PropertyChangedEventArgs(nameof(ListaLibros));
                PropertyChanged?.Invoke(this, arg);
            }
        }

        public Command AgregarLibro { get; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
