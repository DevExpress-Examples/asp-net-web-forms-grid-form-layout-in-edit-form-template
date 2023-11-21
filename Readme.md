<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128549399/14.1.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T102593)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# Grid View for ASP.NET Web Forms - How to define FormLayout inside edit form template
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/t102593/)**
<!-- run online end -->

This example demonstrates how to use the [SetEditFormTemplateContent](https://docs.devexpress.com/AspNetMvc/DevExpress.Web.Mvc.GridViewSettings.SetEditFormTemplateContent(System.Action-DevExpress.Web.GridViewEditFormTemplateContainer-)) method to define the [FormLayout](https://docs.devexpress.com/AspNetMvc/16028/components/site-navigation-and-layout/formlayout) extension in edit form template.

![](form-layout-in-grid-edit-form.png)

```csharp
settings.SetEditFormTemplateContent(c => {
    var editItem = ViewData["Item"] != null ? ViewData["Item"] : c.DataItem;
    Html.DevExpress().FormLayout(set => {
        set.Name = "FormLayout";
        // ...               
    }).Render();
  // ...
});
```

## Files to Review

* [_GridViewPartial.cshtml](./CS/Q588216/Views/Home/_GridViewPartial.cshtml)
* [HomeController.cs](./CS/Q588216/Controllers/HomeController.cs) (VB: [HomeController.vb](./VB/Q588216/Controllers/HomeController.vb))
