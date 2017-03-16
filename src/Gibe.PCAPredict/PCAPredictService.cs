using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Gibe.PCAPredict.Find;

namespace Gibe.PCAPredict
{
	public interface IPCAPredictService
	{
		A Find<A>(Expression<Func<Find.PostcodeAnywhere_SoapClient, A>> f);
		A Retrieve<A>(Expression<Func<Retrieve.PostcodeAnywhere_SoapClient, A>> f);
	}

	public class PCAPredictService : IPCAPredictService
	{
		private PostcodeAnywhere_SoapClient FindClient()
			=> new Find.PostcodeAnywhere_SoapClient();

		private Retrieve.PostcodeAnywhere_SoapClient RetrieveClient()
			=> new Retrieve.PostcodeAnywhere_SoapClient();

		public A Find<A>(Expression<Func<Find.PostcodeAnywhere_SoapClient, A>> f)
			=> f.Compile()(FindClient());

		public A Retrieve<A>(Expression<Func<Retrieve.PostcodeAnywhere_SoapClient, A>> f)
			=> f.Compile()(new Retrieve.PostcodeAnywhere_SoapClient());
	}

	internal class FakePCAPredictService : IPCAPredictService
	{
		private readonly object _find;
		private readonly object _retrieve;

		public FakePCAPredictService(object find = null, object retrieve = null)
		{
			_find = find;
			_retrieve = retrieve;
		}

		public A Find<A>(Expression<Func<PostcodeAnywhere_SoapClient, A>> f)
			=> (A)_find;

		public A Retrieve<A>(Expression<Func<Retrieve.PostcodeAnywhere_SoapClient, A>> f)
			=> (A)_retrieve;
	}
}
