using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Database;
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

        public string email;
        public string myName;
        public Activity myContext;

        CodeDataModel cdm = new CodeDataModel();

        ArrayAdapter myAdapterarray;
        ArrayList listCode = new ArrayList();
        
        public static string codeTitle = "title";
        public static string codelink = "link";
        public static string codeDesc = "discription";


        public CodeFragment(string email)
        {
            this.email = email;
        }

        public CodeFragment()
        {
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment

            View myView = inflater.Inflate(Resource.Layout.activity_code_tab, container, false);
            ListView myList = myView.FindViewById<ListView>(Resource.Id.listView1);

            TextView mytext = myView.FindViewById<TextView>(Resource.Id.textView1);
            SearchView mySearch = myView.FindViewById<SearchView>(Resource.Id.searchView1);

            myView.FindViewById<TextView>(Resource.Id.textView1).Text = myName;

           // mytext.Text = "Code List";
            //myList.Adapter = new ArrayAdapter(myContext, Android.Resource.Layout.SimpleListItem1, movieArray);

            // Code to display Code List
            
            ICursor myresult = cdm.PrintCodeList(this.Activity);
            string title, link, disc = "";

            listCode.Clear();

            while (myresult.MoveToNext())
            {
                //myEmail = myresult.GetString(myresult.GetColumnIndexOrThrow(emailValue));
                // working code
                title = myresult.GetString(myresult.GetColumnIndexOrThrow(codeTitle));
                link = myresult.GetString(myresult.GetColumnIndexOrThrow(codelink));
                disc = myresult.GetString(myresult.GetColumnIndexOrThrow(codeDesc));

                listCode.Add(myresult.GetString(myresult.GetColumnIndexOrThrow(codeTitle)));

                //custom Adaptor addition
            }
            myAdapterarray = new ArrayAdapter(this.Activity, Android.Resource.Layout.SimpleListItem1, listCode);
            myList.Adapter = myAdapterarray;
            myList.ItemClick += MyList_ItemClick;
            mySearch.QueryTextChange += MySearch_QueryTextChange;
            return myView;

            


            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            //return base.OnCreateView(inflater, container, savedInstanceState);


        }

        private void MySearch_QueryTextChange(object sender, SearchView.QueryTextChangeEventArgs e)
        {
            
        }

        private void MyList_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var index = e.Position;
            string myvalue = (string)listCode[index];

            Intent newScreen = new Intent(this.Activity, typeof(CodeViewActivity));
            newScreen.PutExtra("email", email);
            newScreen.PutExtra("title", myvalue);
            //newScreen.PutExtra("desc", desc);
            StartActivity(newScreen);






        }
    }
}