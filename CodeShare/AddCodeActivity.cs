using System;
using System.IO;
using Android;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Widget;
using Plugin.Media;

namespace CodeShare
{
    [Activity(Label = "AddCodeActivity")]
    public class AddCodeActivity : Activity
    {
        readonly string[] permissionGroup =
       {
            Manifest.Permission.ReadExternalStorage,
            Manifest.Permission.WriteExternalStorage,
            Manifest.Permission.Camera
        };
        Bitmap bitmap;
        string mystr = "";

        EditText editText_title_add, editText_link_add, editText_disc_add;
        Button button_screenshot_add, button_insert_code;
        ImageView imageView_screen;

        string emailFromMaintab;

        //Android.Net.Uri uri;

        byte[] imageArray;



        DataConnection myDB;

        CodeDataModel cdm = new CodeDataModel();

        //public static readonly int PickImageId = 1000;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_add_code);

            editText_title_add = FindViewById<EditText>(Resource.Id.editText_title_add) ;
            editText_link_add = FindViewById<EditText>(Resource.Id.editText_link_add);
            editText_disc_add = FindViewById<EditText>(Resource.Id.editText_disc_add);
            imageView_screen = FindViewById<ImageView>(Resource.Id.imageView_screen);

            emailFromMaintab = Intent.GetStringExtra("mail");
            button_screenshot_add = FindViewById<Button>(Resource.Id.button_screenshot_add);
            button_insert_code = FindViewById<Button>(Resource.Id.button_insert_code);

            button_screenshot_add.Click += Button_screenshot_add_Click;
            button_insert_code.Click += Button_insert_code_Click;

           // button_screenshot_add.Click += Button_screenshot_add_Click2;


        }


        // Add ScreenShots Button ***************************
        //private void Button_screenshot_add_Click(object sender, EventArgs e)
        //{
        //    Intent = new Intent();
        //    Intent.SetType("image/*");
        //    Intent.SetAction(Intent.ActionGetContent);
        //    StartActivityForResult(Intent.CreateChooser(Intent, "Select Picture"), PickImageId);
        //}

        //protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        //{
        //    if ((requestCode == PickImageId) && (resultCode == Result.Ok) && (data != null))
        //    {

        //        uri = data.Data;
                
        //        imageView_screen.SetImageURI(uri);


        //    }
        //}
        //Bitmap***************

        private void Button_screenshot_add_Click(object sender, EventArgs e)
        {
            UploadPhoto();
        }
        async void UploadPhoto()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                Toast.MakeText(this, "Upload not supported on this device", ToastLength.Short).Show();
                return;
            }

            var file = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Full,
                CompressionQuality = 40

            });

            // Convert file to byre array, to bitmap and set it to our ImageView

            imageArray = System.IO.File.ReadAllBytes(file.Path);
            bitmap = BitmapFactory.DecodeByteArray(imageArray, 0, imageArray.Length);
            imageView_screen.SetImageBitmap(bitmap);

            using (var stream = new MemoryStream())
            {
                bitmap.Compress(Bitmap.CompressFormat.Jpeg, 0, stream);

                var bytes = stream.ToArray();
                var str = Convert.ToBase64String(bytes);
                mystr = str;
            }

        }


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
        {
            Plugin.Permissions.PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

       

        //End Add ScreenShots Button ***************************


        // Button to insrt Code 
        private void Button_insert_code_Click(object sender, EventArgs e)
        {
            var title = editText_title_add.Text;
            var link = editText_link_add.Text;
            var disc = editText_disc_add.Text;
            if (title.Trim().Equals("") || title.Length < 0 ||
                link.Trim().Equals("") || link.Length < 0 ||
                disc.Trim().Equals("") || disc.Length < 0 )
            {
                new Utils().alertFunction("Error", "Please Complete all the fields", this);
            }
            else{
                //udm.insertValue(this, emailValue, passwordValue, nameValue, ageValue);
                cdm.insertValue(this, emailFromMaintab, title, link, disc, mystr);

                new Utils().alertFunction("Code Added Successfull", "Click Ok", this);

            }
        }
    }
}