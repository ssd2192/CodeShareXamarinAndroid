using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace CodeShare
{
    public class CodeFragment : Fragment
    {

        string[] movieArray = { "A-Moive", "B-Moive",
                "C-Moive", "D-Moive", "E-Moive", "F - Moive", "G  - Moive", "H  - Moive", "I  - Moive"};


        public String myName;
        public Activity myContext;

        public CodeFragment(string name, Activity context)
        {
            myName = name;
            myContext = context;
        }

        public CodeFragment()
        {
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment

            View myView = inflater.Inflate(Resource.Layout.activity_code_tab, container, false);
            ListView myList = myView.FindViewById<ListView>(Resource.Id.listView1);
            TextView mytext = myView.FindViewById<TextView>(Resource.Id.textView1);
            myView.FindViewById<TextView>(Resource.Id.textView1).Text = myName;

            mytext.Text = "Code List";
            //myList.Adapter = new ArrayAdapter(myContext, Android.Resource.Layout.SimpleListItem1, movieArray);

            return myView;


            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            //return base.OnCreateView(inflater, container, savedInstanceState);


        }
    }
}