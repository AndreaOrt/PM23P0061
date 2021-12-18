using System;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using PM2Tarea3P201820110061.Models;
using Xamarin.Forms;
using Acr.UserDialogs;

namespace PM2Tarea3P201820110061.ViewModels
{
    public class EmpleadoListaViewModel: BaseViewModel
    {
        public EmpleadoListaViewModel(INavigation navigation)
        {
            Navigation = navigation;
            ListadoEmpleados();

            EditarEmpleCommand = new Command<Type>(async (pageType) => await EditarEmpleado(pageType));
            EliminarEmpleCommand = new Command(() => EliminarEmpleado());
        }

        async void ListadoEmpleados()
        {
            Empleados = new ObservableCollection<Empleado>();
            var empLista = await App.BaseDatos.ObtenerListaEmp();

            foreach (var e in empLista)
            {
                Empleados.Add(new Models.Empleado() { Id = e.Id, Nombre = e.Nombre, Apellidos = e.Apellidos, Edad = e.Edad, Direccion = e.Direccion, Puesto = e.Puesto });
            }
        }

        private ObservableCollection<Empleado> _empleados;

        public ObservableCollection<Empleado> Empleados
        {
            get { return _empleados; }
            set { _empleados = value; OnPropertyChange(); }
        }

        private Empleado _selectedEmp;

        public Empleado SelectedEmp
        {
            get { return _selectedEmp; }
            set { _selectedEmp = value; OnPropertyChange(); }
        }

        public ICommand EditarEmpleCommand { private set; get; }
        public ICommand EliminarEmpleCommand { private set; get; }

        public INavigation Navigation { get; set; }

        async Task EditarEmpleado(Type pageType)
        {
            if (SelectedEmp != null)
            {
                var page = (Page)Activator.CreateInstance(pageType);

                page.BindingContext = new EmpleadoViewModel()
                {
                    Id = SelectedEmp.Id,
                    Nombre = SelectedEmp.Nombre,
                    Apellidos = SelectedEmp.Apellidos,
                    Edad = SelectedEmp.Edad,
                    Direccion = SelectedEmp.Direccion,
                    Puesto = SelectedEmp.Puesto
                };

                await Navigation.PushAsync(page);
            }
            else
            {
                UserDialogs.Instance.Alert(new AlertConfig
                {
                    Message = "Por favor seleccione un empleado de la lista.",
                    OkText = "OK",
                    Title = "Alerta"
                });
            }
        }

        void EliminarEmpleado()
        {
            if (SelectedEmp != null)
            {
                var empEliminar = new Empleado()
                {
                    Id = SelectedEmp.Id,
                    Nombre = SelectedEmp.Nombre,
                    Apellidos = SelectedEmp.Apellidos,
                    Edad = SelectedEmp.Edad,
                    Direccion = SelectedEmp.Direccion,
                    Puesto = SelectedEmp.Puesto
                };

                App.BaseDatos.EliminarEmpleado(empEliminar);

                UserDialogs.Instance.Alert(new AlertConfig
                {
                    Message = "Empleado eliminado correctamente. \n\nPuede ver la lista actualizada presionando el botón de Listado de Empleado.",
                    OkText = "OK",
                    Title = "Confirmación"
                });

                Navigation.PopAsync();
            }
            else
            {
                UserDialogs.Instance.Alert(new AlertConfig
                {
                    Message = "Por favor seleccione un empleado de la lista.",
                    OkText = "OK",
                    Title = "Alerta"
                });
            }
        }
    }
}
