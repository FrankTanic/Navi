using System;
using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Locations;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Widget;
using System.Text;
using System.Threading.Tasks;
using Android.Content;
using Navi.Android.Services;

namespace Navi.Android
{
    [Activity(Label = "Navi.Android", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        static readonly string TAG = "X:" + typeof(MainActivity).Name;
        TextView _addressText;
        TextView _locationText;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            StartService(new Intent(this, typeof(LocationService)));

            _addressText = FindViewById<TextView>(Resource.Id.address_text);
            _locationText = FindViewById<TextView>(Resource.Id.location_text);
        }
 
        protected override void OnResume()
        {
            base.OnResume();
        }

        protected override void OnPause()
        {
            base.OnPause();
        }
    }
}

