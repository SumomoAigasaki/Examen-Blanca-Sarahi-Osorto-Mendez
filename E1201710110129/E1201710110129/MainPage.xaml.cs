using System;
using SQLite;
using E1201710110129.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using Xamarin.Forms.Maps;
using Plugin.Geolocator;

namespace E1201710110129
{
    public partial class MainPage : ContentPage
    {
        
        public MainPage()
        {
            InitializeComponent();

            

            var localizacion = CrossGeolocator.Current;
            if (localizacion.IsGeolocationAvailable)//Servicio de Geolocalizacion existente
            {
                //DisplayAlert("Tiene Permisoso", "Tiene Permiso Ubicacion", "OK");

                if (!localizacion.IsGeolocationEnabled)//VALIDA QUE EL GPS ESTE APAGADO
                {
                    DisplayAlert("GPS Apagado", "Por favor salga y encienda el GPS/ Ubicacion y vuelva a entrar", "OK");

                }
                else
                {
                    
                }
            }else
            {

                DisplayAlert("Sin Permisos", "Active el permiso de Ubicacion", "OK");
            }
        }


        private async void Localizacion()
        {

            var localizacion = CrossGeolocator.Current;
            var posicion = await localizacion.GetPositionAsync();

            txtLongitud.Text = posicion.Longitude.ToString();
            txtLatitud.Text = posicion.Latitude.ToString();
            //lactitud = double.Parse(txtLatitud.Text);

        }

        private void btnNewUbication_Clicked(object sender, EventArgs e)
        {
            // Limpiar los Text para un Nuevo Registro
            //manda a llamar al contenedor
            Localizacion();
            txtDescripcion.Text = "";
            txtDescripcionCorta.Text = "";
        }

        private void Cargar()
        {
            Int32 resultado = 0;
            using (SQLiteConnection conexion = new SQLiteConnection(App.UbicacionDB))
            {   //mandamos a que tabla se guarda
                conexion.CreateTable<Mapa>();
                //mandamos los datos que guardamos en la clase 
                //asignamos un resultado que dice si inserto el Script

                //Primera Ubicacion Predeterminada
                var Location = new Mapa()
                {
                    Latitud = 13.376050848869307,
                    Longitud = -86.95442141354778,
                    DescripcionLarga = "Ubicada en San Marcos de Colon",
                    DescripcionCorta = "La Peña",
                };

                resultado = conexion.Insert(Location);


                //Segunda Ubicacion Predeterminada
                var Location2 = new Mapa()
                {
                    Latitud = 13.31415238095598,
                    Longitud = -87.19161111806798,
                    DescripcionLarga = "Salida a Choluteca",
                    DescripcionCorta = "Hotel Gualiqueme",
                };

                resultado = conexion.Insert(Location2);

                //Tercera Ubicacion Predeterminada
                var Location3 = new Mapa()
                {
                    Latitud = 13.465497133002827,
                    Longitud = -86.7309240180663,
                    DescripcionLarga = "San Marcos de Colon, Cerca de La Frotenra con Nicaragua",
                    DescripcionCorta = "Cañon Caulato",
                };

                resultado = conexion.Insert(Location3);

             }

        }

       
        private async void btnListUbication_Clicked(object sender, EventArgs e)
        {
            Cargar();
            await Navigation.PushAsync(new ListUbication());           
        }

        private async void btnSavedUbication_Clicked(object sender, EventArgs e)
        {
            Int32 resultado = 0;
            

            //validamos que los campos no esten vacios

            if (String.IsNullOrEmpty(txtDescripcion.Text))
            {
                await DisplayAlert("Campo Vacio", "Ingrese una Descripcion, Por favor ", "Ok");
            }else if (String.IsNullOrEmpty(txtDescripcionCorta.Text))
            {
                await  DisplayAlert("Campo Vacio", "Ingrese una Descripcion Corta, Por favor ", "Ok");
            }else
            {
                //NOS PREPARAMOS PARA GUARDAR

                using (SQLiteConnection conexion = new SQLiteConnection(App.UbicacionDB))
                {   //mandamos a que tabla se guarda
                    conexion.CreateTable<Mapa>();
                    //mandamos los datos que guardamos en la clase 
                    //asignamos un resultado que dice si inserto el Script
                    var Location = new Mapa()
                    {
                        Longitud = Convert.ToDouble(txtLongitud.Text),
                        Latitud= Convert.ToDouble(txtLatitud.Text),
                        DescripcionLarga = Convert.ToString(txtDescripcion.Text),
                        DescripcionCorta = Convert.ToString(txtDescripcionCorta.Text),
                    };

                    resultado = conexion.Insert(Location);

                    if (resultado > 0)
                    {

                        await DisplayAlert("Aviso", "Se Guardo Exitosamente ", "Ok");
                     
                    }
                    else
                    {
                        await  DisplayAlert("Aviso", "hubo un error al enviar los datos", "Ok");
                    }
                }
            }
            
        }
    }
}
