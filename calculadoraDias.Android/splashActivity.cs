
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;

namespace calculadoraDias.Droid
{
    [Activity(Label = "Calculadora Dias", Theme = "@style/SplashTheme",
        MainLauncher = true, NoHistory = true, 
        ConfigurationChanges = ConfigChanges.ScreenSize)]
    public class splashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));

            // Create your application here
        }
    }
}