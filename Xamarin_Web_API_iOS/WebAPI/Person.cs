using System;

namespace XamarinWebAPI
{
    public class Person
    {
		// Not sure if the API is returning something with "Name" or "name", so we accept both
		[RestSharp.Serializers.SerializeAs(Name = "name")]
		public string Name { get; set; }

		public override string ToString()
		{
			return Name;
		}
			
    }
}