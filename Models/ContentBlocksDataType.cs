using Umbraco.Core.Models;
using System.Collections.Generic;
using NicBell.UCreate.Interfaces;
using NicBell.UCreate.Attributes;

namespace Graph.Components.ContentBlocks
{
	[DataType(Name = "Content Blocks", EditorAlias = "Umbraco.Grid", Key = "e4492a18-fcb3-47bf-bc75-8650d6a0cf89", DBType = DataTypeDatabaseType.Ntext)]
	public class ContentBlocksDataType : IHasPreValues
	{
		public IDictionary<string, PreValue> PreValues => new Dictionary<string, PreValue>
		{
			{"items", new PreValue(new GridSettingsLoader().GetSettings())},
			{"rte", new PreValue(ContentBlocksRteConfigs)},
		};

		private const string ContentBlocksRteConfigs = @"{
			  ""toolbar"": [
			    ""code"",
			    ""styleselect"",
			    ""bold"",
			    ""italic"",
			    ""alignleft"",
			    ""aligncenter"",
			    ""alignright"",
			    ""bullist"",
			    ""numlist"",
			    ""outdent"",
			    ""indent"",
			    ""link"",
			    ""umbmediapicker"",
			    ""umbmacro"",
			    ""umbembeddialog""
			  ],
			  ""stylesheets"": [],
			  ""dimensions"": {
			    ""height"": 500
			  },
			  ""maxImageSize"": 500
			}";
	}
}
