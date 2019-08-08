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
    class Code
    {
        [PrimaryKey, AutoIncrement]
        public string CodeId { get; set; }

        public string CodeTitle { get; set; }

        public string CodeLink { get; set; }

        public string CodeDiscription { get; set; }

        public string ScreenshotPath { get; set; }
    }
}