using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gibe.PCAPredict.Find;
using Gibe.PCAPredict.Retrieve;
using NUnit.Framework;

namespace Gibe.PCAPredict
{
	public class AddressLookupService : IAddressLookupService
	{
		private readonly IPCAPredictService _pcaPredictService;
		private readonly string _key;

		public AddressLookupService(IPCAPredictService pcaPredictService, string key)
		{
			_pcaPredictService = pcaPredictService;
			_key = key;
		}
		public IEnumerable<SearchResult> Search(string term, string country = "GB", string lastId = "")
		{
			var results = _pcaPredictService.Find(
				s =>
					s.CapturePlus_Interactive_Find_v2_10(_key, term, lastId, SearchFor.Everything.ToString(), country,
						"EN", 7, 100));

			return results.Select(SearchResult);
		}

		private SearchResult SearchResult(CapturePlus_Interactive_Find_v2_10_Results sr)
			=> new SearchResult(sr.Id, sr.Text, sr.Description, sr.Highlight, sr.Next);

		public AddressResult Address(string id)
			=>
				AddressResult(_pcaPredictService.Retrieve(
					s =>
						s.Capture_Interactive_Retrieve_v1_00(_key, id, null, null, null, null, null, null, null,
							null, null, null, null, null, null, null, null, null, null, null, null, null)).First());

		private AddressResult AddressResult(Capture_Interactive_Retrieve_v1_00_Results rr)
			=>
				new AddressResult(rr.Company, rr.Line1, rr.Line2, rr.Line3, rr.Line4, rr.Line5, rr.City,
					rr.ProvinceName, rr.PostalCode, rr.CountryName);

		private enum SearchFor
		{
			Everything,
			PostalCodes,
			Companies,
			Places
		}
	}

	internal class AddressLookupServiceTests
	{
		private string CountryName = "England";
		private const string Id = "FAKE|RESULT";
		private const string Postcode = "BS1 1AB";
		private const string Description = "A Street Downtown";
		private const string Highlight = "";
		private const string Next = "Find";
		private const string Company = "False Company";
		private const string Line1 = "123 A Street Downtown";
		private const string Line2 = "Eternity Row";
		private const string Line3 = "The Sixth Turtle Down";
		private const string Line4 = "Pillar Five";
		private const string Line5 = "Earth";
		private const string City = "Turtlopia";
		private const string Province = "Turtla";

		private AddressLookupService Service()
			=>
				new AddressLookupService(
					new FakePCAPredictService(find: new CapturePlus_Interactive_Find_v2_10_ArrayOfResults
						{
							new CapturePlus_Interactive_Find_v2_10_Results
							{
								Id = Id,
								Text = Postcode,
								Description = Description,
								Highlight = Highlight,
								Next = Next
							},
							new CapturePlus_Interactive_Find_v2_10_Results(),
							new CapturePlus_Interactive_Find_v2_10_Results(),
						},
						retrieve: new Retrieve.Capture_Interactive_Retrieve_v1_00_ArrayOfResults()
						{
							new Retrieve.Capture_Interactive_Retrieve_v1_00_Results
							{
								Company = Company,
								Line1 = Line1,
								Line2 = Line2,
								Line3 = Line3,
								Line4 = Line4,
								Line5 = Line5,
								City = City,
								ProvinceName = Province,
								PostalCode = Postcode,
								CountryName = CountryName
							}
						}
					), "KKEE YYYY KKEE YYYY");

		[Test]
		public void Search_returns_list_of_results()
		{
			var service = Service();

			var results = service.Search("BS1");

			Assert.That(results.Count(), Is.EqualTo(3));
			Assert.That(results.First(), Is.EqualTo(new SearchResult(Id, Postcode, Description, Highlight, Next)));
		}

		[Test]
		public void Retrieve_returns_specific_record_desired()
		{
			var service = Service();

			var result = service.Address(Id);

			Assert.That(result, Is.EqualTo(new AddressResult(Company, Line1, Line2, Line3, Line4, Line5, City, Province, Postcode, CountryName)));
		}
	}
}
