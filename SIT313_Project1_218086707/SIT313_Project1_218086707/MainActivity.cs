using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using SQLite;

namespace SIT313_Project1_218086707
{


    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        string DBPath = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "CustomerDB.db");

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            //DB existance check
            var db = new SQLiteConnection(DBPath);
            if(!System.IO.File.Exists(DBPath))
            {
                Console.WriteLine("Database Create:" + DBPath);
            }
            else
            {
                Console.WriteLine("Already Database Created: " + DBPath);
            }

            EditText tv_Id = FindViewById<EditText>(Resource.Id.input_id);
            EditText tv_Pw = FindViewById<EditText>(Resource.Id.input_pw);



            Button bt_Login = FindViewById<Button>(Resource.Id.bt_Login);
            Button bt_Join = FindViewById<Button>(Resource.Id.bt_Join);

    
            db.CreateTable<CustomerTable>();

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
                    var checkID = from s in db.Table<CustomerTable>() where s.CustomerID.Equals(tv_Id.Text) select s;
                    int cnt=0;
                    string tablePW = null; 
                    foreach (var s in checkID)
                    {
                        cnt++;
                        tablePW = s.CustomerPW;
                    }

                    if (cnt == 0)
                    {
                        var errorToast = Toast.MakeText(ApplicationContext, "This Id is not exsist ", ToastLength.Short);
                        errorToast.Show();
                    }
                    else
                    {
                        if(tablePW == tv_Pw.Text )
                        {
                            var intent = new Intent(this, typeof(indexActivity));
                            StartActivity(intent);
                        }
                        else
                        {
                            var errorToast = Toast.MakeText(ApplicationContext, "Check Your Password " , ToastLength.Short);
                            errorToast.Show();
                        }
                    }

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

