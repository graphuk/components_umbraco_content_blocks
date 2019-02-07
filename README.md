# components_umbraco_content_blocks
Content blocks for Umbraco Grid

Dependencies:
* Skybrud.Umbraco.GridData - https://github.com/skybrud/Skybrud.Umbraco.GridData (install via nuget)
* UCreate - https://github.com/nicbell/ucreate (install via nuget)

Installation steps:
1. Install all dependencies
3. Copy all files to the folder 'ContentBlocks' to ~\App_Plugins\
5. Umbraco will create the data type on startup application

Example of usages:
```c#

Comming soon...

```

Model:
```c#
public GridDataModel ContentBlocks { get; set; } 
```

View:
```c#
@Html.Partial("~/App_Plugins/ContentBlocks/Views/GridLayout.cshtml", Model.ContentBlocks)
```