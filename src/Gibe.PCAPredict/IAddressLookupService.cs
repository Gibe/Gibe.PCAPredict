using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Gibe.PCAPredict
{
	public interface IAddressLookupService
	{
		[NotNull]
		[ItemNotNull]
		IEnumerable<SearchResult> Search([NotNull]string term, [NotNull]string country = "GB", [NotNull]string lastId = "");

		[NotNull]
		AddressResult Address([NotNull]string id);
	}
}
