using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PM2Tarea3P201820110061.Views
{
    public partial class ListaEmpleadosViews : ContentPage
    {
        public ListaEmpleadosViews()
        {
            InitializeComponent();
            BindingContext = new ViewModels.EmpleadoListaViewModel(Navigation);
        }
    }
}
