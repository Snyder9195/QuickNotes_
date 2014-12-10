using System;
using System.Collections.Generic;
using System.IO;

namespace QuickNotes_.DAL
{
	public class TaskRepository
	{
		DL.TaskDatabase db = null;
		protected static string dbLocation;
		protected static TaskRepository me;

		static TaskRepository ()
		{
			me = new TaskRepository ();
		}

		protected TaskRepository()
		{
			dbLocation = DatabaseFilePath;
			db = new QuickNotes_.DL.TaskDatabase (dbLocation);
		}

		public static string DatabaseFilePath{
			get{
				var sqliteFilename = "TaskDB.db3";
				#if SILVERLIGHT
					//windows phone expects a local path, not absolute
				//var path = sqliteFilename;
				#else 
				#if __ANDROID__

				//string libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
				#else
			
				#endif
				string libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

				var path = Path.Combine(libraryPath, sqliteFilename);
				#endif
				return path;
			}

		}

		public static Task GetTask(int id)
		{
			return me.db.GetItem<Task> (id);
		}
		public static IEnumerable<Task> GetTasks()
		{
			return me.db.GetItems<Task>();
		}
		public static int SaveTask(Task item)
		{
			return me.db.SaveItem<Task> (item);
		}
		public static int DeleteTask(int id)
		{
			return me.db.DeleteItem<Task> (id);
		}


	}
}
