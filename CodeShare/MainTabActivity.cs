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
using Android.Support.V7.App;

namespace CodeShare
{
    [Activity(Label = "MainTabActivity")]
    public class MainTabActivity : Activity
    {
        [Obsolete]
        Fragment[] _fragmentsArray;
        string name = "Welcome To my App";
       

        [Obsolete]
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //SetContentView(Resource.Layout.activity_tab);

            string emailFromSignIn = Intent.GetStringExtra("mail");
            string passwordFromSignIn = Intent.GetStringExtra("password");
            string nameFromSignIn = Intent.GetStringExtra("name");
            var ageFsromSignIn = Intent.GetIntExtra("age", 0);

            RequestWindowFeature(WindowFeatures.ActionBar);

            //enable navigation mode to support tab layout

            //this.ActionBar.SetDisplayShowHomeEnabled(true);
            //this.ActionBar.SetDisplayShowTitleEnabled(true);

            this.ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
            SetContentView(Resource.Layout.activity_tab);



            // Create your application here
            _fragmentsArray = new Fragment[]
         {
            new CodeFragment(emailFromSignIn),
            new MyCodeFragment(),
            new AccountFragment(emailFromSignIn,passwordFromSignIn,nameFromSignIn,ageFsromSignIn)
         };


            AddTabToActionBar("Code"); //First Tab
            AddTabToActionBar("MyCode"); //Second Tab
            AddTabToActionBar("Account"); // Third Tab


           
        }

        

        [Obsolete]
        void AddTabToActionBar(string tabTitle)
        {
            Android.App.ActionBar.Tab tab = ActionBar.NewTab();
            tab.SetText(tabTitle);
            
           // tab.SetIcon(Android.Resource.Drawable.IcInputAdd);

            tab.TabSelected += TabOnTabSelected;

            ActionBar.AddTab(tab);
        }

        [Obsolete]
        void TabOnTabSelected(object sender, Android.App.ActionBar.TabEventArgs
            tabEventArgs)
        {
            Android.App.ActionBar.Tab tab = (Android.App.ActionBar.Tab)sender;

            //Log.Debug(Tag, "The tab {0} has been selected.", tab.Text);
            Fragment frag = _fragmentsArray[tab.Position];

            tabEventArgs.FragmentTransaction.Replace(Resource.Id.frameLayout1, frag);
        }

    }
}