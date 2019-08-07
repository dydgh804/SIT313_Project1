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
    [Activity(Label = "@string/app_name")]
    public class regiActivity : Activity
    {
        string DBPath = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "CustomerDB.db");
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.registration);

            Button bt_Submit = FindViewById<Button>(Resource.Id.bt_Submit);
            Button bt_Reset = FindViewById<Button>(Resource.Id.bt_Reset);

            EditText et_Name = FindViewById<EditText>(Resource.Id.et_Name);
            EditText et_Id = FindViewById<EditText>(Resource.Id.et_Id);
            EditText et_Pw = FindViewById<EditText>(Resource.Id.et_Pw);
            EditText et_Pwc = FindViewById<EditText>(Resource.Id.et_Pwc);

            bt_Reset.Click += delegate 
            {
                et_Name.Text = "";
                et_Id.Text = "";
                et_Pw.Text = "";
                et_Pwc.Text = "";

            };

            bt_Submit.Click += delegate 
            {
                //validation method
                if(et_Name.Text=="" || et_Id.Text==""||et_Pw.Text==""||et_Pwc.Text=="")
                {
                    var toast = Toast.MakeText(ApplicationContext,"Fill all Textboxes Please", ToastLength.Short);
                    toast.Show();
                }
                else if(et_Pw.Text != et_Pwc.Text)
                {
                    var toast = Toast.MakeText(ApplicationContext, "Please Check your Password agian", ToastLength.Short);
                    toast.Show();
                    et_Pwc.SetBackgroundColor(Android.Graphics.Color.ParseColor("#FE3939"));

                }
                else
                {
                    var db = new SQLiteConnection(DBPath);
                    db.CreateTable<CustomerTable>();

                    if(db.Table<CustomerTable>().Count() ==0)
                    {
                        var newCTable = new CustomerTable();
                        newCTable.CustomerName = et_Name.Text;
                        newCTable.CustomerID = et_Id.Text;
                        newCTable.CustomerPW = et_Pw.Text;

                        db.Insert(newCTable);
                     }
                    else
                    {
                      //  string sqlquery = "Select * from CustomerTable where CustomerID '"+ et_Id +"' ;";
                        var checkID = from s in db.Table<CustomerTable>() where s.CustomerID.Equals(et_Id.Text) select s;
                        int cnt = 0;
                        foreach(var s in checkID)
                        {
                            cnt ++;
                        }

                        if (cnt>0)
                        {
                            var errorToast = Toast.MakeText(ApplicationContext, "This Id is already exist, please use other Id ", ToastLength.Short);
                            errorToast.Show();
                        }
                        else
                        {
                            var newCTable = new CustomerTable();
                            newCTable.CustomerName = et_Name.Text;
                            newCTable.CustomerID = et_Id.Text;
                            newCTable.CustomerPW = et_Pw.Text;

                            db.Insert(newCTable);

                            var toast = Toast.MakeText(ApplicationContext, "Registration Success!!", ToastLength.Short);
                            toast.Show();
                            var intent = new Intent(this, typeof(MainActivity));
                            StartActivity(intent);
                        }

                    }

                   
                }

            };





        }

    }
}
