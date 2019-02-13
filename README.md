# components_umbraco_content_blocks
Content blocks for Umbraco Grid

Nuget:
* Install-Package UmbracoGridConfigLoader
* Install-Package Skybrud.Umbraco.GridData
* Install-Package UCreate

Installation steps:
1. Install Nuget packages
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
