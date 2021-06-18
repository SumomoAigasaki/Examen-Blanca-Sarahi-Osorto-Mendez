using System;
using SQLite;
using E1201710110129.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;

namespace E1201710110129
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListUbication : ContentPage
    {
        private Mapa seleccinarId;
        public ListUbication()
        {
             InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            using (SQLiteConnection conexion = new SQLiteConnection(App.UbicacionDB))
            {   //mandamos a que tabla se guarda
                conexion.CreateTable<Mapa>();

                var listmaps = conexion.Table<Mapa>().ToList();
                ListaUbicacion.ItemsSource = listmaps;

            }
        }

        private async void btnViewMap_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection conexion = new SQLiteConnection(App.UbicacionDB))
            {
                if (seleccinarId != null)
                {
                    var mapa = new
                    {
                        Id = seleccinarId.Id,
                        Latitud = seleccinarId.Latitud,
                        Longitud = seleccinarId.Longitud,
                        DescripcionCorta = seleccinarId.DescripcionCorta,
                        DescripcionLarga = seleccinarId.DescripcionLarga
                    };

                    //await DisplayAlert("Datos a Enviar> " + seleccinarId.Id + " " + seleccinarId.DescripcionCorta, " Ubicacion Larga> " + seleccinarId.DescripcionLarga + " Coordenadas >> " + seleccinarId.Latitud + " " + seleccinarId.Longitud, "OK");

                    var Page = new MapPage();
                    Page.BindingContext = mapa;
                    await Navigation.PushAsync(Page);
                }
                else
                    messagetSelect();
            }
        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {

            using (SQLiteConnection conexion = new SQLiteConnection(App.UbicacionDB))
            {
                if (seleccinarId != null)
                {
                    DisplayAlert("Aviso", "Se Eliminara el Campo Seleccionado(ID): " + seleccinarId.Id + " Nombre: " + seleccinarId.DescripcionCorta + " De la lista de Ubicaciones Guardadas", "Ok");

                    var ListaMapas = conexion.Delete<Mapa>(seleccinarId.Id);
                }
                else
                    messagetSelect();
            }

        }

        private void ListaUbicacion_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            seleccinarId=e.SelectedItem as Mapa;


            //Confirmamos que se seleccione
            DisplayAlert("Informacion de Registro> " + seleccinarId.Id + " " + seleccinarId.DescripcionCorta, " Ubicacion Larga> " + seleccinarId.DescripcionLarga + " Coordenadas >> " + seleccinarId.Latitud + " " + seleccinarId.Longitud, "OK");

            //DisplayAlert("campo seleccionado (id): " + seleccinarId.Id,
            //    "nombre " + seleccinarId.DescripcionLarga + " de la lista", "ok");

        }
        
           private async void messagetSelect()
        {
            await DisplayAlert("Sin Seleccion", "Por Favor Seleccione un Dato", "OK");
        }
    }
}