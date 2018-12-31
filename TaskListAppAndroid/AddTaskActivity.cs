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
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.AddNewTasks);

            TextView showTask = FindViewById<TextView>(Resource.Id.ShowTask);
            EditText taskEntryText = FindViewById<EditText>(Resource.Id.TaskEntryText);
            Button addTaskButton = FindViewById<Button>(Resource.Id.AddTaskButton);
            Button cancelButton = FindViewById<Button>(Resource.Id.CancelButton);

            string task = string.Empty;
            addTaskButton.Click += (sender, e) =>
            {
                task = Core.TaskAdder.AddTask(taskEntryText.Text);
                if (string.IsNullOrWhiteSpace(task))
                {
                    showTask.Text = "";
                    return;
                }
                else
                {
                    showTask.Text = task;
                    Tasks.Add(task);
                }
                var intent = new Intent(this, typeof(MainActivity));
                intent.PutStringArrayListExtra("tasks", Tasks);
                StartActivity(intent);
            };

            cancelButton.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(MainActivity));
                intent.PutStringArrayListExtra("tasks", Tasks);
                StartActivity(intent);
            };
        }
    }
}