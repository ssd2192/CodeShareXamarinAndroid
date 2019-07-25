using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;

namespace CodeShare
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Button btn_sign_in, btn_sign_up;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            btn_sign_in = FindViewById<Button>(Resource.Id.button_sign_in);
            btn_sign_up = FindViewById<Button>(Resource.Id.button_sign_up);

            btn_sign_in.Click += delegate
            {
                Intent signInScreen = new Intent(this, typeof(SignInActivity));
                StartActivity(signInScreen);
            };

            btn_sign_up.Click += delegate
            {
                Intent signUpScreen = new Intent(this, typeof(SignUpActivity));
                StartActivity(signUpScreen);
            };
        }
    }
}