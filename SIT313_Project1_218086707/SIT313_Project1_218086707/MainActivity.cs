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
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            EditText tv_Id = FindViewById<EditText>(Resource.Id.input_id);
            EditText tv_Pw = FindViewById<EditText>(Resource.Id.input_pw);



            Button bt_Login = FindViewById<Button>(Resource.Id.bt_Login);
            Button bt_Join = FindViewById<Button>(Resource.Id.bt_Join);


            bt_Login.Click += delegate 
            {
                if(tv_Id.Text =="")
                {
                    var toast = Toast.MakeText(ApplicationContext, "Enter Id Plz~", ToastLength.Short);
                    toast.Show();
                }
                else if (tv_Pw.Text == "")
                {
                    var toast = Toast.MakeText(ApplicationContext, "Enter Password Plz~", ToastLength.Short);
                    toast.Show();
                }
                else
                {
                    var intent = new Intent(this, typeof(indexActivity));
                    StartActivity(intent);
                }

            };

            bt_Join.Click += delegate 
            {
                var intent = new Intent(this, typeof(regiActivity));
                StartActivity(intent);
            };
           
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }


    }
}

