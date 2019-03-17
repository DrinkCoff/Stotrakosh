using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V4.Content;
using Android;
using Xamarin.Forms;
using Android.Support.V4.App;
using System.IO;
using Android.Support.Design.Widget;
using Android.Util;

namespace Stotrakosh.Droid
{
    [Activity(Label = "Stotrakosh", Icon = "@drawable/Icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        static readonly int REQUEST_STORAGE = 0;
        static readonly string TAG = "MainActivity";

        Android.Views.View layout;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            this.StoragePermission();
            LoadApplication(new App());
        }



        private void StoragePermission()
        {
            if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.WriteExternalStorage) == (int)Permission.Granted)
            {
                // We have permission, go ahead and use the camera.
                this.CopyDatabasesFromAsset();
            }
            else
            {
                // Storage permission is not granted. If necessary display rationale & request.
                this.StoragePermissionRationale();
            }
        }

        private void CopyDatabasesFromAsset()
        {
            //string databaseFileName = Helpers.Settings.DatabaseName;
            string[] databseFileNames = Resources.GetStringArray(Resource.Array.databaseName);
            Settings.DatabaseDirectory = Android.OS.Environment.ExternalStorageDirectory.ToString();

            foreach (string databaseFileName in databseFileNames)
            {
                CopyDatabaseFile(databaseFileName);
            }
        }

        private void StoragePermissionRationale()
        {
            //SetContentView(Resource.Layout.activity_main);
            this.layout = new Android.Views.View(this.BaseContext);

            var activity = (Activity)Forms.Context;
            var view = activity.FindViewById(Android.Resource.Id.Content);

            if (ActivityCompat.ShouldShowRequestPermissionRationale(this, Manifest.Permission.WriteExternalStorage))
            {
                // Provide an additional rationale to the user if the permission was not granted
                // and the user would benefit from additional context for the use of the permission.
                // For example if the user has previously denied the permission.
                Log.Info(TAG, "Displaying camera permission rationale to provide additional context.");

                var requiredPermissions = new String[] { Manifest.Permission.WriteExternalStorage };
                Snackbar.Make(view,
                               "Database file need to be copied on the storage.",
                               Snackbar.LengthIndefinite)
                        .SetAction("OK",
                                   new Action<Android.Views.View>(delegate (Android.Views.View obj) {
                                       ActivityCompat.RequestPermissions(this, requiredPermissions, REQUEST_STORAGE);
                                   }
                        )
                ).Show();
            }
            else
            {
                ActivityCompat.RequestPermissions(this, new String[] { Manifest.Permission.WriteExternalStorage }, REQUEST_STORAGE);
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            var activity = (Activity)Forms.Context;
            var view = activity.FindViewById(Android.Resource.Id.Content);

            if (requestCode == REQUEST_STORAGE)
            {
                // Received permission result for camera permission.
                Log.Info(TAG, "Received response for Storage permission request.");

                // Check if the only required permission has been granted
                if (grantResults.Length == 1 && grantResults[0] == Permission.Granted)
                {
                    // Camera permission has been granted, preview can be displayed
                    Log.Info(TAG, "Storage permission has now been granted. Showing preview.");
                    Snackbar.Make(view, "Storage permission granted.", Snackbar.LengthShort).Show();
                    CopyDatabasesFromAsset();
                }
                else
                {
                    Log.Info(TAG, "Storage permission was NOT granted.");
                    Snackbar.Make(layout, "Storage permission was NOT granted.", Snackbar.LengthShort).Show();
                }
            }
            else
            {
                base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            }
        }

        public void CopyDatabaseFile(string databaseFileName)
        {
            string databaseFilePath = Path.Combine(Settings.DatabaseDirectory, databaseFileName);

            if (!File.Exists(databaseFilePath))
            {
                using (BinaryReader br = new BinaryReader(Android.App.Application.Context.Assets.Open(databaseFileName)))
                {
                    using (
                        BinaryWriter bw = new BinaryWriter(new FileStream(databaseFilePath, FileMode.Create)))
                    {
                        byte[] buffer = new byte[2048];
                        int len = 0;
                        while ((len = br.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            bw.Write(buffer, 0, len);
                        }
                    }
                }
            }
        }

        public bool CheckPermission(Android.Content.Context context)
        {
            bool permission = (ContextCompat.CheckSelfPermission(context, Manifest.Permission.WriteExternalStorage) == (int)Permission.Granted);
            return permission;

        }
    }
}