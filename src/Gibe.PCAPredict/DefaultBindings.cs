using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;

namespace Gibe.PCAPredict
{
	public class DefaultBindings : NinjectModule
	{
		private readonly string _pcaKey;

		public DefaultBindings(string pcaKey) => _pcaKey = pcaKey;

		public override void Load()
		{
			Bind<IPCAPredictService>().To<PCAPredictService>();
			Bind<IAddressLookupService>().To<AddressLookupService>().WithConstructorArgument("key", _pcaKey);
		}
	}
}
