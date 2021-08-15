using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AddressBookUsingADO.Net
{

	public class AddressBookModel
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Address { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string ZipCode { get; set; }
		public string PhoneNumber { get; set; }
		public string EmailId { get; set; }
	}
}

