using NicBell.UCreate;
using Umbraco.Core;

namespace Graph.Components.ContentBlocks
{
	public class SyncContentBlocksDataType : IApplicationEventHandler
	{
		public void OnApplicationInitialized(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
		{
		}

		public void OnApplicationStarting(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
		{
		}

		public void OnApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
		{
			CmsSyncManger.Synchronize();
		}
	}
}
