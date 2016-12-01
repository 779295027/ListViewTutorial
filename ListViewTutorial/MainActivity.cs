using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using System;
using Android.Views;

namespace ListViewTutorial
{
	[Activity(Label = "ListViewTutorial", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		private List<string> mItems;
		private List<Person> list;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.Main);

			mItems = new List<string>();
			mItems.Add("赵");
			mItems.Add("钱");
			mItems.Add("孙");
			mItems.Add("李");
			ListView myListView = FindViewById<ListView>(Resource.Id.myListView);
			//ArrayAdapter adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, mItems);

			list = new List<Person>();
			list.Add(new Person() { 姓名 = "赵", 年龄 = "1", 性别 = "男" });
			list.Add(new Person() { 姓名 = "钱", 年龄 = "2", 性别 = "女" });
			list.Add(new Person() { 姓名 = "孙", 年龄 = "3", 性别 = "男" });
			list.Add(new Person() { 姓名 = "李", 年龄 = "4", 性别 = "女" });

			var myadapter = new MyListAdapter(list, this);

			//MyListAdapter adapter1 = new MyListAdapter();
			myListView.Adapter = myadapter;
			myListView.ItemClick += (sender, e) =>
			{
				Console.WriteLine("" + list[e.Position].姓名);
				Toast.MakeText(this, "" + list[e.Position].姓名, ToastLength.Short).Show();
			};
			//c#中可以添加n个click方法，会根据添加顺序逐个执行


			myListView.ItemClick += myListItemClick;
			myListView.ItemClick += myListItemClick2;


			myListView.ItemLongClick += (sender, e) =>
			{
				Console.WriteLine("" + list[e.Position].年龄);
				Toast.MakeText(this, "" + list[e.Position].年龄, ToastLength.Short).Show();
			};

		}

		void myListItemClick(object sender, AdapterView.ItemClickEventArgs e)
		{
			Console.WriteLine("first method" + list[e.Position].姓名);
		}

		void myListItemClick2(object sender, AdapterView.ItemClickEventArgs e)
		{
			Console.WriteLine("secound method" + list[e.Position].姓名);
		}


	}
}

