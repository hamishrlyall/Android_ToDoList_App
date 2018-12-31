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
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            var tasks = Intent.Extras.GetStringArrayList("tasks") ?? new string[0];
            this.ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItemMultipleChoice, tasks);

            Button addTaskView = FindViewById<Button>(Resource.Id.AddTaskViewButton);
            addTaskView.Click += (sender, e) =>
            {
                StartActivity(typeof(AddTaskActivity));
            };
        }
    }
}