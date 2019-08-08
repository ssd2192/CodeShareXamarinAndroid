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
using SQLite;

namespace CodeShare.Models
{
    class User
    {
        [PrimaryKey]
        public string Email { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public int Age { get; set; }
    }

}