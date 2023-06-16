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
	public partial class AddTarea : ContentPage
	{
		public AddTarea ()
		{
			InitializeComponent ();
		}

		private async void Clicked_Guardar(Object sender, EventArgs e)
		{
			try
			{
				var items = new TareaItems
				{
					Tarea = tarea.Text,
				};
				var result = await App.Content.InsertItem(items);
				if(result == 1)
				{
					await Navigation.PopAsync();
				}
				else
				{
					await DisplayAlert("Error", "Error", "OK");
				}
			}
			catch
			{
				await DisplayAlert("Error al Guardar", "Debe Agregar Una Tarea", "OK");
			}
		}
	}
}