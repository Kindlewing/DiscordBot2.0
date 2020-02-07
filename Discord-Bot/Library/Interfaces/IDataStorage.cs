using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
	public interface IDataStorage
	{
		void StoreObject(string location, string key);
		List<T> RetrieveObject<T>(string location, string key);
	}
}
