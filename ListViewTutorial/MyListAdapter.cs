using System;
using System.Collections.Generic;
using Android.Content;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace ListViewTutorial
{
	public class MyListAdapter : BaseAdapter<Person>
	{
		private List<Person> list;
		private LayoutInflater inflater;
		public MyListAdapter(List<Person> list, Context context)
		{
			this.list = list;
			inflater = LayoutInflater.From(context);
		}

		public override int Count
		{
			get
			{
				return list != null ? list.Count : 0;
			}
		}

		public override Person this[int position]
		{
			get
			{
				return list != null ? list[position] : null;
			}
		}

		public override long GetItemId(int position)
		{
			return list != null ? position : 0;
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			View view = convertView;
			if (view == null)
			{
				view = inflater.Inflate(Resource.Layout.listview_row, null, false);
			}

			Person person = this[position];


			TextView txtName = view.FindViewById<TextView>(Resource.Id.txtName);
			txtName.Text = person.姓名;
			TextView txtAge = view.FindViewById<TextView>(Resource.Id.txtAge);
			txtAge.Text = person.年龄;
			TextView txtSex = view.FindViewById<TextView>(Resource.Id.txtSex);
			txtSex.Text = person.性别;

			return view;
		}


	}
}
