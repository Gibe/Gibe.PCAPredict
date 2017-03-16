namespace Gibe.PCAPredict
{
	public class AddressResult
	{
		public AddressResult(string company, string address1, string address2, string address3,
			string address4, string address5, string town, string county, string postcode,
			string country)
		{
			Company = company;
			Address1 = address1;
			Address2 = address2;
			Address3 = address3;
			Address4 = address4;
			Address5 = address5;
			Town = town;
			County = county;
			Postcode = postcode;
			Country = country;
		}

		public string Company { get; }
		public string Address1 { get; }
		public string Address2 { get; }
		public string Address3 { get; }
		public string Address4 { get; }
		public string Address5 { get; }

		public string Town { get; }
		public string County { get; }

		public string Postcode { get; }
		public string Country { get; }

		protected bool Equals(AddressResult other)
		{
			return string.Equals(Company, other.Company) && string.Equals(Address1, other.Address1) &&
				   string.Equals(Address2, other.Address2) && string.Equals(Address3, other.Address3) &&
				   string.Equals(Address4, other.Address4) && string.Equals(Address5, other.Address5) &&
				   string.Equals(Town, other.Town) && string.Equals(County, other.County) &&
				   string.Equals(Postcode, other.Postcode) && string.Equals(Country, other.Country);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != GetType()) return false;
			return Equals((AddressResult)obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = Company != null ? Company.GetHashCode() : 0;
				hashCode = (hashCode * 397) ^ (Address1 != null ? Address1.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (Address2 != null ? Address2.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (Address3 != null ? Address3.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (Address4 != null ? Address4.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (Address5 != null ? Address5.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (Town != null ? Town.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (County != null ? County.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (Postcode != null ? Postcode.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (Country != null ? Country.GetHashCode() : 0);
				return hashCode;
			}
		}

		public static bool operator ==(AddressResult left, AddressResult right)
		{
			return Equals(left, right);
		}

		public static bool operator !=(AddressResult left, AddressResult right)
		{
			return !Equals(left, right);
		}
	}
}