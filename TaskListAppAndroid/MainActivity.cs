using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Collections.Generic;
using Android.Views;
using System.Linq;
using Android.Content;

namespace TaskListAppAndroid
{
    [Activity(Label = "Android TaskList", Theme = "@style/AppTheme", MainLauncher = false)]
    public class MainActivity : ListActivity
    {

        //AddTaskActivity addTaskActivity = new AddTaskActivity();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            var tasks = Intent.Extras.GetStringArrayList("tasks") ?? new string[0];
            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItemMultipleChoice, tasks);
            ListAdapter = adapter;

            Toolbar toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetActionBar(toolbar);
            ActionBar.Title = "My Toolbar";
        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.Menu1, menu);
            return base.OnCreateOptionsMenu(menu);
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            StartActivity(typeof(AddTaskActivity));
            return base.OnOptionsItemSelected(item);
        }

    }
}