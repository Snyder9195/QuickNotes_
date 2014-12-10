using System;
using System.Collections.Generic;
using System.Linq;
using QuickNotes_.DL;
using SQLite;
//using QuickNotes_.BL;

namespace QuickNotes_.DL
{
	public class TaskDatabase : SQLiteConnection
	{

		static object locker = new object();

		public TaskDatabase (string path) :base (path)
		{
			//create the tables
			CreateTable<Task> ();
		}

		public IEnumerable<T> GetItems<T>() where T:IBusinessEntity,new()
		{
			lock (locker) {
				return (from i in Table<T> ()
				        select i).ToList ();
			}
		}

		public T GetItem<T> (int id) where T : IBusinessEntity, new()
		{
			lock (locker) {
				return Table<T> ().FirstOrDefault (x => x.ID == id);
			}
		}

		public int SaveItem<T> (T item) where T : IBusinessEntity
		{
			lock (locker) {
				if (item.ID != 0) {
					Update (item);
					return item.ID;
				} else {
					return Insert (item);
				}
			}
		}

		public int DeleteItem<T> (int id) where T: IBusinessEntity, new()
		{
			lock (locker) {
				return Delete<T> (new T () { ID = id });
			}
		}

	}
}

