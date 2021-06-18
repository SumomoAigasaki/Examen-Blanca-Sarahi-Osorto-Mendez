using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using System.IO;

namespace E1201710110129.Droid
{
    [Activity(Label = "E1201710110129", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            //creacion Base de Datos
            string dbMapa = "DB.sqlite";

            //donde estara ubicada la base de datos 
            //obtener de manera directa un fald systemde manera directa
            string folderpath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            //combinar la base de datos y la ruta 
            string pathdb = Path.Combine(folderpath, dbMapa);


            //modificamos al constructor segundo 
            LoadApplication(new App(pathdb));
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}