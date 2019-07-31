using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace SIT313_Project1_218086707
{
    [Activity(Label = "@string/app_name")]
    public class indexActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.index);


            Button bt_Menu = FindViewById<Button>(Resource.Id.bt_Menu);
            Button bt_Book = FindViewById<Button>(Resource.Id.bt_Book);
            Button bt_AboutUs = FindViewById<Button>(Resource.Id.bt_AboutUs);


            bt_Menu.Click += delegate 
            {
                var intent = new Intent(this, typeof(menuActivity));
                StartActivity(intent);

            };

            bt_Book.Click += delegate 
            {
                var toast = Toast.MakeText(ApplicationContext, "Coming Soon...", ToastLength.Short);
                toast.Show();
            };

            bt_AboutUs.Click += delegate
            {
                var toast = Toast.MakeText(ApplicationContext, "Coming Soon...", ToastLength.Short);
                toast.Show();
            };

        }

    }
}