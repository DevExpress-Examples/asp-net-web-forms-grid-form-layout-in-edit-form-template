@Code
Dim grid = Html.DevExpress().GridView( Sub(settings)
        settings.Name = "GridView"
        settings.CallbackRouteValues = New With { Key. Controller = "Home", Key. Action = "GridViewPartial" }
        settings.SettingsEditing.AddNewRowRouteValues = New With {Key .Controller = "Home", Key .Action = "GridViewPartialAddNew"}
        settings.SettingsEditing.UpdateRowRouteValues =  New With { Key. Controller = "Home",  Key. Action = "GridViewPartialUpdate" }
        settings.SettingsEditing.DeleteRowRouteValues = New With { Key. Controller = "Home", Key. Action = "GridViewPartialDelete" }
        settings.SettingsEditing.Mode = GridViewEditingMode.EditFormAndDisplayRow
        settings.SettingsBehavior.ConfirmDelete = True
        settings.CommandColumn.Visible = True
        settings.CommandColumn.ShowNewButton = True
        settings.CommandColumn.ShowDeleteButton = True
        settings.CommandColumn.ShowEditButton = True

        settings.KeyFieldName = "ModelID"
        settings.SetEditFormTemplateContent(Sub(c)                
           Html.DevExpress().FormLayout(Sub(fmset)
Dim editItem 
           If(ViewData("Item") IsNot Nothing)
              editItem = ViewData("Item")
           Else
              editItem = c.DataItem
           End If
                   fmset.Name = "FormLayout"
                   fmset.Items.AddGroupItem(Sub(groupSettings)                  
                       groupSettings.Caption = "ModelGroup"
                       groupSettings.Name = "group"
                       groupSettings.Items.Add( Sub(item)                      
                           item.NestedExtensionType = FormLayoutNestedExtensionItemType.TextBox
                           item.Name = item.Caption = "Name"
                           item.SetNestedContent(Sub()                           
                               Html.DevExpress().TextBox(Sub(tb)                               
                                   tb.Name = "ModelName"
                                   tb.ShowModelErrors = True
                               End Sub).Bind(DataBinder.Eval(editItem, "ModelName")).Render()
                           End Sub)
                       End Sub)
                       groupSettings.Items.Add(Sub(item)                      
                          item.NestedExtensionType = FormLayoutNestedExtensionItemType.DateEdit
                          item.Name = item.Caption = "Date"
                          item.SetNestedContent(Sub()                           
                              Html.DevExpress().DateEdit(Sub(tb)                              
                                  tb.Name = "ModelDate"
                                  tb.ShowModelErrors = True
                              End Sub).Bind(DataBinder.Eval(editItem, "ModelDate")).Render()
                          End Sub)
                      End Sub)
                       groupSettings.Items.Add(Sub(item)
                      
                          item.NestedExtensionType = FormLayoutNestedExtensionItemType.CheckBox
                          item.Name = item.Caption = "State"
                          item.SetNestedContent(Sub()
                          
                              Html.DevExpress().CheckBox(Sub(chkb)                               
                                  chkb.Name = "ModelState"
                                  chkb.ShowModelErrors = True
                              End Sub).Bind(DataBinder.Eval(editItem, "ModelState")).Render()
                          End Sub)
                      End Sub)
                   End Sub)           
               End Sub).Render()
            Html.DevExpress().Button(Sub (btnSettings)
               
                   btnSettings.Name = "btnUpdate"
                   btnSettings.UseSubmitBehavior = False
                   btnSettings.Text = "Update"
                   btnSettings.ClientSideEvents.Click = "function(s, e){ GridView.UpdateEdit(); }"
               
           End Sub).Render()
            Html.DevExpress().Button(
                Sub(btnSettings)                
                    btnSettings.Name = "btnCancel"
                    btnSettings.UseSubmitBehavior = False
                    btnSettings.Text = "Cancel"
                    btnSettings.ClientSideEvents.Click = "function(s, e){ GridView.CancelEdit(); }"
                End Sub
            ).Render()            
        End Sub)
        settings.SettingsPager.Visible = True
        settings.Settings.ShowGroupPanel = True
        settings.Settings.ShowFilterRow = True
        settings.SettingsBehavior.AllowSelectByRowClick = False
        settings.Columns.Add("ModelID")
        settings.Columns.Add("ModelName")
        settings.Columns.Add("ModelState")
        settings.Columns.Add("ModelDate")
    End Sub)
     If ViewData("EditError") IsNot Nothing Then
		grid.SetEditErrorText(CStr(ViewData("EditError")))
 End If
End Code
@grid.Bind(Model).GetHtml()