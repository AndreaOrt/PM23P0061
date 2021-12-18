using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PM2Tarea3P201820110061.Views
{
    public partial class EmpleadoViews : ContentPage
    {
        public EmpleadoViews()
        {
            InitializeComponent();
        }

        async void btnVerLista_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new Views.ListaEmpleadosViews());
        }
    }
}
