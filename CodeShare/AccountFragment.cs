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
    public class AccountFragment : Fragment
    {
        public Activity myContext;
        UserDataModel udm = new UserDataModel();
        //public string myEmail, myPassword, myName, myAge;
        string email, password, name;
        int age;
        EditText et_email,et_password, et_name, et_age;
        Button btn_edit_profile,btn_add_code;

        string emailPrint;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public AccountFragment(string email, string password, string name, int age)
        {
            //myEmail = email;
            this.email = email;
            this.password = password;
            this.name = name;
            this.age = age;
            
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            View myView = inflater.Inflate(Resource.Layout.activity_account_tab, container, false);
            et_email = myView.FindViewById<EditText>(Resource.Id.editText_email);
            et_password = myView.FindViewById<EditText>(Resource.Id.editText_password);
            et_name = myView.FindViewById<EditText>(Resource.Id.editText_name);
            et_age = myView.FindViewById<EditText>(Resource.Id.editText_age);

            btn_edit_profile = myView.FindViewById<Button>(Resource.Id.button_edit_profile);
            btn_add_code = myView.FindViewById<Button>(Resource.Id.button_add_code);


            et_email.Text = email;
            et_password.Text = password;
            et_name.Text = name;
            et_age.Text = Convert.ToString(age);

            et_password.Enabled = false;
            et_name.Enabled = false;
            et_age.Enabled = false;
            et_email.Enabled = false;

            btn_edit_profile.Click += Btn_edit_profile_Click;
            btn_add_code.Click += Btn_add_code_Click;

            return myView;
            //return inflater.Inflate(Resource.Layout.activity_account_tab, container, false);

            //View myView = inflater.Inflate(Resource.Layout.activity_code_tab, container, false);
            //ListView myList = myView.FindViewById<ListView>(Resource.Id.listView1);
            //TextView mytext = myView.FindViewById<TextView>(Resource.Id.textView1);
            //myView.FindViewById<TextView>(Resource.Id.textView1).Text = myName;

            //mytext.Text = "Code List";
            ////myList.Adapter = new ArrayAdapter(myContext, Android.Resource.Layout.SimpleListItem1, movieArray);

            //return myView;

           // return base.OnCreateView(inflater, container, savedInstanceState);
        }

        private void Btn_add_code_Click(object sender, EventArgs e)
        {
            Intent addCodeScreen = new Intent(this.Activity, typeof(AddCodeActivity));
            addCodeScreen.PutExtra("mail", email);
            StartActivity(addCodeScreen);
        }

        private void Btn_edit_profile_Click(object sender, EventArgs e)
        {
            if (btn_edit_profile.Text == "Edit Profile")
            {
                et_password.Enabled = true;
                et_name.Enabled = true;
                et_age.Enabled = true;
                btn_edit_profile.Text = "Save";
            }
            else
            {
                var name = et_name.Text;
                var password = et_password.Text;
                int age = Convert.ToInt32(et_age.Text);
                //var email = this.email;
                udm.updateValue(this.Activity, password, name, age);
                new Utils().alertFunction("Update", "Successfull", this.Activity);
                et_password.Enabled = false;
                et_name.Enabled = false;
                et_age.Enabled = false;
                btn_edit_profile.Text = "Edit Profile";

            }
        }
    }
}