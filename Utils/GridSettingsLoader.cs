using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Graph.Components.ContentBlocks
{
	public class GridSettingsLoader
	{
		public string GetSettings()
		{
			var result = new ContentBlocksGridSettings
			{
				Styles = new object[0],
				Columns = 12,
				Templates = new []
				{
					new Template
					{
						Name = "Content Blocks",
						Sections = new List<Section>()
						{
							new Section
							{
								Grid = 12,
								AllowAll = true
							}

						}
					}
				},
				Layouts = new List<Layout>(),
				Config = new List<Config>()
			};

			var configsPropierties = GetType().Assembly
				.GetTypes()
				.Where(x => typeof(IGridConfigLoader).IsAssignableFrom(x))
				.Where(x => x.IsInterface == false)
				.Select(Activator.CreateInstance)
				.Cast<IGridConfigLoader>()
				.SelectMany(x => x.GetType()
					.GetFields()
					.Select(p => new { p.Name, Value = p.GetValue(x), Type = p.FieldType}
					)
				).ToArray();

			foreach (var propierty in configsPropierties)
			{
				if (propierty.Type == typeof(Layout[]))
				{
					result.Layouts.AddRange((Layout[])propierty.Value);
				}

				if (propierty.Type == typeof(Config[]))
				{
					result.Config.AddRange((Config[]) propierty.Value);
				}
			}
			
			return JsonConvert.SerializeObject(result, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver()});
		}

		public interface IGridConfigLoader
		{
			
		}


		public class Prevalue
		{
			public string Label { get; set; }
			public string Value { get; set; }
		}

		public class Config
		{
			public string Label { get; set; }
			public string Description { get; set; }
			public string Key { get; set; }
			public string View { get; set; }
			public Dictionary<string, string> ApplyTo { get; set; }
			public string Modifier { get; set; }
			public Prevalue[] Prevalues { get; set; }
		}

		public class Section
		{
			public int Grid { get; set; }
			public bool AllowAll { get; set; }
		}

		public class Template
		{
			public string Name { get; set; }
			public List<Section> Sections { get; set; }
		}

		public class Area
		{
			public int Grid { get; set; }
			public List<string> Editors { get; set; }
			public bool AllowAll { get; set; }
			public int MaxItems { get; set; }
		}

		public class Layout
		{
			public string Label { get; set; }
			public string Name { get; set; }
			public Area[] Areas { get; set; }
		}

		public class ContentBlocksGridSettings
		{
			public object[] Styles { get; set; }
			public List<Config> Config { get; set; }
			public int Columns { get; set; }
			public Template[] Templates { get; set; }
			public List<Layout> Layouts { get; set; }
		}
	}
}
