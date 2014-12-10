using System;
using QuickNotes_.DL;
using SQLite;

namespace QuickNotes_
{
	public class BusinessEntityBase : IBusinessEntity
	{
		public BusinessEntityBase ()
		{
		}

		[PrimaryKey, AutoIncrement]
		public int ID{get; set;}
	}
}

