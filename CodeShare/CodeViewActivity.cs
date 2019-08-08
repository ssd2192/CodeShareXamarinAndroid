using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace CodeShare
{
    [Activity(Label = "CodeViewActivity")]
    public class CodeViewActivity : Activity
    {
        TextView tv_title, tv_link, tv_disc;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_code_view);

            tv_title = FindViewById<TextView>(Resource.Id.textView1);
            tv_link = FindViewById<TextView>(Resource.Id.textView2);
            tv_disc = FindViewById<TextView>(Resource.Id.textView3);

            string title_intent = Intent.GetStringExtra("title");

            tv_title.Text = title_intent;



            // Create your application here
        }
    }
}