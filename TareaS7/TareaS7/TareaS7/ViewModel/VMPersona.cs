using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Numerics;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using TareaS7.Models;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

namespace TareaS7.ViewModel
{

    public class VMPersona : INotifyPropertyChanged
    {

        public VMPersona()
        {
            AbrirListaPersonas();

            AgregarPersona = new Command(() => {

                Persona p = new Persona()
                {

                    nombre = this.nombre,
                    numeroCuenta = this.numeroCuenta,
                };

                ListaPersonas.Add(p);

                //Serializacion
                BinaryFormatter formatter = new BinaryFormatter();
                string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "personas.pe");
                Stream file = new FileStream(ruta, FileMode.Create, FileAccess.Write, FileShare.None);

                formatter.Serialize(file, ListaPersonas);
                file.Close();

                //Fin de Serializar

                App.Current.Properties["listaPersonas"] = ListaPersonas;


            });
        }

        private void AbrirListaPersonas() {
            try
            {

                /*Proceso de Deserializacion (Ingeniera Inversa de Serializar, leer archivos) */
                BinaryFormatter formatter = new BinaryFormatter();
                string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "personas.pe");
                Stream archivo = new FileStream(ruta, FileMode.Open, FileAccess.Read, FileShare.None);

                ListaPersonas = (ObservableCollection<Persona>)formatter.Deserialize(archivo);

                archivo.Close();

                App.Current.Properties["listaPersonas"] = ListaPersonas;

            }
            catch (Exception ex)
            {
                ListaPersonas = new ObservableCollection<Persona>();
            }
        }

        string nombre;
        public string Nombre{

            get => nombre;
            set{
                nombre = value;
                var arg = new PropertyChangedEventArgs(nameof(Nombre));
                PropertyChanged?.Invoke(this, arg);
            }
        }

        int numeroCuenta;
        public int NumeroCuenta {
            get => numeroCuenta;
            set {
                numeroCuenta = value;
                var arg = new PropertyChangedEventArgs(nameof(NumeroCuenta));
                PropertyChanged?.Invoke(this, arg);
            }
        }

        ObservableCollection<Persona> listaPersonas = new ObservableCollection<Persona>();

        public ObservableCollection<Persona> ListaPersonas
        {

            get => listaPersonas;
            set
            {

                listaPersonas = value;
                var arg = new PropertyChangedEventArgs(nameof(ListaPersonas));
                PropertyChanged?.Invoke(this, arg);
            }
        }

        public Command AgregarPersona { get; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
