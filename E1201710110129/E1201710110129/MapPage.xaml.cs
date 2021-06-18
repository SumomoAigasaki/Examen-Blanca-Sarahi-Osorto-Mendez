using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using Xamarin.Forms.Maps;
using Plugin.Geolocator;

using E1201710110129.Model;

namespace E1201710110129
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        Double lactitud;
        Double Longitud;

        public MapPage()
        {
            InitializeComponent();


        }


        protected async override void OnAppearing( )
        {
            base.OnAppearing();

          

                    Longitud = Convert.ToDouble(txtLongitudMap.Text);
                    lactitud = Convert.ToDouble(txtLactitudMap.Text);

                    Pin ubicacion = new Pin();
                    {
                        ubicacion.Label = txtShortDesciptionMap.Text;
                        ubicacion.Address = txtLargeDescriptionMap.Text;
                        ubicacion.Type = PinType.Place;
                        ubicacion.Position = new Position(lactitud, Longitud);

                    }
                    mpMapa.Pins.Add(ubicacion);


                    var localizacion = await Geolocation.GetLastKnownLocationAsync();

                    if (localizacion == null)
                    {

                        localizacion = await Geolocation.GetLocationAsync();
                    }
                    mpMapa.MoveToRegion(MapSpan.FromCenterAndRadius(ubicacion.Position, Distance.FromKilometers(1)));
                }

    }
}