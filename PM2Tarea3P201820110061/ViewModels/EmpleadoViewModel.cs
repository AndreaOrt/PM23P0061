using System;
using System.Windows.Input;
using PM2Tarea3P201820110061.Models;
using Xamarin.Forms;
using System.Diagnostics;
using Acr.UserDialogs;

namespace PM2Tarea3P201820110061.ViewModels
{
    public class EmpleadoViewModel: BaseViewModel
    {
        public EmpleadoViewModel()
        {
            ClearCommand = new Command(() => Clear());
            GuardarEmpCommand = new Command(() => GuardarEmpleado());

        }

        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChange(); }
        }

        private string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; OnPropertyChange(); }
        }

        private string _apellidos;

        public string Apellidos
        {
            get { return _apellidos; }
            set { _apellidos = value; OnPropertyChange(); }
        }

        private int _edad;

        public int Edad
        {
            get { return _edad; }
            set { _edad = value; OnPropertyChange(); }
        }

        private string _direccion;

        public string Direccion
        {
            get { return _direccion; }
            set { _direccion = value; OnPropertyChange(); }
        }

        private string _puesto;

        public string Puesto
        {
            get { return _puesto; }
            set { _puesto = value; OnPropertyChange(); }
        }


        public ICommand ClearCommand { private set; get; }
        public ICommand GuardarEmpCommand { set; get; }
        public ICommand DialogsCommand { private set; get; }


        void Clear()
        {
            Nombre = string.Empty;
            Apellidos = string.Empty;
            Edad = 0;
            Direccion = string.Empty;
            Puesto = string.Empty;
        }

        void GuardarEmpleado()
        {
            if (System.String.IsNullOrWhiteSpace(Nombre))
            {
                UserDialogs.Instance.Alert(new AlertConfig
                {
                    Message = "Por favor agregue el Nombre del Empleado.",
                    OkText = "OK",
                    Title = "Alerta"
                });
                return;
            }
            else if (System.String.IsNullOrWhiteSpace(Apellidos))
            {
                UserDialogs.Instance.Alert(new AlertConfig
                {
                    Message = "Por favor agregue el apellido del Empleado.",
                    OkText = "OK",
                    Title = "Alerta"
                });
                return;
            }
            else if (System.String.IsNullOrWhiteSpace(Convert.ToString(Edad)) || Edad == 0)
            {
                UserDialogs.Instance.Alert(new AlertConfig
                {
                    Message = "Por favor agregue la edad.",
                    OkText = "OK",
                    Title = "Alerta"
                });
                return;
            }
            else if (System.String.IsNullOrWhiteSpace(Direccion))
            {
                UserDialogs.Instance.Alert(new AlertConfig
                {
                    Message = "Por favor agregue la Dirección.",
                    OkText = "OK",
                    Title = "Alerta"
                });
                return;
            }
            else if (System.String.IsNullOrWhiteSpace(Puesto))
            {
                UserDialogs.Instance.Alert(new AlertConfig
                {
                    Message = "Por favor agregue el Puesto del Empleado.",
                    OkText = "OK",
                    Title = "Alerta"
                });
                return;
            }

            Empleado empleado = new Empleado()
            {
                Id = Id,
                Nombre = Nombre,
                Apellidos = Apellidos,
                Edad = Edad,
                Direccion = Direccion,
                Puesto = Puesto
            };

            App.BaseDatos.GuardarEmpleado(empleado);

            if (Id != 0)
            {
                UserDialogs.Instance.Alert(new AlertConfig
                {
                    Message = "Se ha modificado el empleado correctamente. \n\nPuede ver la modificación presionando el botón de listado de Empleados.",
                    OkText = "OK",
                    Title = "Confirmación"
                });
            }
            else
            {
                UserDialogs.Instance.Alert(new AlertConfig
                {
                    Message = "Se ha registrado el empleado correctamente. \n\nPuede verlo en el listado de Empleado.",
                    OkText = "OK",
                    Title = "Confirmación"
                });
            }

        }
    }
}
