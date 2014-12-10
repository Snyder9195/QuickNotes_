using System;
using QuickNotes_.DL;
using SQLite;

namespace QuickNotes_
{
	public class Task : IBusinessEntity
	{
		public Task ()
		{
		}

		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public string Name{ get; set; }
		public String Notes { get; set; }
		public bool Done{ get; set; }
	}
}

