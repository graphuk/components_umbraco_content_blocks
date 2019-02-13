# components_umbraco_content_blocks
Content blocks for Umbraco Grid

Dependencies:
* UmbracoGridConfigLoader - https://github.com/graphuk/umbraco_grid_config_loader/ (install via nuget)
* Skybrud.Umbraco.GridData - https://github.com/skybrud/Skybrud.Umbraco.GridData (install via nuget)
* UCreate - https://github.com/nicbell/ucreate (install via nuget)

Installation steps:
1. Install all dependencies
2. Copy all files to the folder 'ContentBlocks' to ~\App_Plugins\
3. Umbraco will create the data type on startup application
4. Add to Umbraco document type:
```c#
[DocType(Name = "Content Composition")]
public class ContentComposition
{
	[Property(TypeName = "Content Blocks", Name = "Content Blocks", TabName = "Content", Alias = "contentBlocks")]
	public string ContentBlocks { get; set; }
}
```
You can inferit the home page from this composition
```c#
[DocType(Name = "Home Page", AllowedAsRoot = true, Icon = "icon-home",
		AllowedChildTypes = new []
		{
			...
		},
		CompositionTypes = new []
		{
			typeof(ContentComposition),
		})]
public class HomePage
{
}
```
5. Add property to he Home page View Model:
```c#
public class HomePageModel
{
	public GridDataModel ContentBlocks { get; set; }
} 
```
6. Add Partial to the Home page view:
```c#
@Html.Partial("~/App_Plugins/ContentBlocks/Views/GridLayout.cshtml", Model.ContentBlocks)
```
