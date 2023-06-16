using ListadeTareas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListadeTareas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Main : ContentPage
    {
        public Main()
        {
            InitializeComponent();
            
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadTareas();
        }
        private async void LoadTareas()
        {
            var tareas = await App.Content.GetTareas();
            lista_tareas.ItemsSource = tareas;
        }

        private async void Agregar_Tarea(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddTarea());
        }

        private async void Delete_Tarea(object sender, EventArgs e)
        {
            if (await DisplayAlert("Eliminar Tarea", "Desea Eliminar Esta Tarea?",  "Ok", "Cancelar"))
            {
                var tarea = (TareaItems)(sender as MenuItem).CommandParameter;
                var result =  await App.Content.DeleteTarea(tarea);
                if (result == 1)
                {
                    LoadTareas();
                }
            }
        }

        private async void Update_Tarea(object sender, EventArgs e)
        {
            var tarea = (TareaItems)(sender as MenuItem).CommandParameter;
            var result = await App.Content.DeleteTarea(tarea);
            if (result == 1)
            {
                await Navigation.PushAsync(new AddTarea());
                LoadTareas();
            }
        }
    }
}