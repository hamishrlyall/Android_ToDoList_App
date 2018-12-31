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

namespace TaskListAppAndroid
{
    [Activity(Label = "AddTaskActivity", Theme = "@style/AppTheme", MainLauncher = true)]
    public class AddTaskActivity : Activity
    {
        static readonly List<string> Tasks = new List<string>();
        public List<string> GetTaskList()
        {
            return Tasks;
        }
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.AddNewTasks);

            // Create your application here
            // Get our UI controls from the loaded layout
            TextView showTask = FindViewById<TextView>(Resource.Id.ShowTask);
            EditText taskEntryText = FindViewById<EditText>(Resource.Id.TaskEntryText);
            Button addTaskButton = FindViewById<Button>(Resource.Id.AddTaskButton);
            Button cancelButton = FindViewById<Button>(Resource.Id.CancelButton);

            string task = string.Empty;
            addTaskButton.Click += (sender, e) =>
            {

                // Button Click Code
                task = Core.TaskAdder.AddTask(taskEntryText.Text);
                if (string.IsNullOrWhiteSpace(task))
                {
                    showTask.Text = "";
                }
                else
                {
                    showTask.Text = task;
                    Tasks.Add(task);
                    //taskEntryText.Text = task;
                }
                //Return to MainActivity
                var intent = new Intent(this, typeof(MainActivity));
                intent.PutStringArrayListExtra("tasks", Tasks);
                StartActivity(intent);
            };

            cancelButton.Click += (sender, e) =>
            {
                //Return to Main Activity
                //StartActivity(typeof(MainActivity));
                var intent = new Intent(this, typeof(MainActivity));
                intent.PutStringArrayListExtra("tasks", Tasks);
                StartActivity(intent);
            };
        }
    }
}