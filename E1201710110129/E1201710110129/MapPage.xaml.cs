using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using Xamarin.Forms.Maps;
using E1201710110129.Model;

namespace E1201710110129
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        

        public MapPage()
        {
            InitializeComponent();


        }


        protected async override void OnAppearing( )
        {
            base.OnAppearing();
            Mapa Coordenada = new Mapa();

            await DisplayAlert("Informacion de Registro> " + Coordenada.Id+" "+ Coordenada.DescripcionCorta," Ubicacion Larga> "+ Coordenada.DescripcionLarga+ " Coordenadas >> " +Coordenada.Latitud + " "+ Coordenada.Longitud,"OK" );

            var ubicacion = new Pin
            {
                Label = Coordenada.DescripcionCorta,
                Address = Coordenada.DescripcionLarga,
                Type = PinType.Place,
                Position = new Position(double.Parse(Coordenada.Latitud), double.Parse(Coordenada.Longitud))
            };
            mpMapa.Pins.Add(ubicacion);


            mpMapa.MoveToRegion( new MapSpan ( ubicacion.Position , 1 ,1 ));


            //Pin ubicacion = new Pin();

            //ubicacion.Label = "Mi Casita";
            //ubicacion.Address = "Barrio Alegria";
            //ubicacion.Type = PinType.Place;
            //ubicacion.Position = new Position(13.311822943924373, -87.19127738389874);
            //mpMapa.Pins.Add(ubicacion);

            //var localizacion = await Geolocation.GetLastKnownLocationAsync();
            //if (localizacion == null)
            //{
            //    localizacion = await Geolocation.GetLocationAsync();
            //}
            //mpMapa.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(localizacion.Latitude, localizacion.Longitude), Distance.FromKilometers(1)));
        }

        //private async void AddPins()
        //{
        //    foreach (Mapa Coordenada in DataRepository.LoadCustomerData())
        //    {
        //        }

        //}

    }
}