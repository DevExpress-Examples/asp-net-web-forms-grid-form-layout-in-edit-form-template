Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports DevExpress.Web.Mvc
Imports MVCxGridViewDataBinding.Models

Namespace Q588216.Controllers
    Public Class HomeController
        Inherits Controller
        '
        ' GET: /Home/

        Public Function Index() As ActionResult
            Return View()
        End Function

        Public ReadOnly Property Data() As List(Of MyModel)

            Get
                Dim l As List(Of MyModel) = TryCast(Session("data"), List(Of MyModel))
                If (l Is Nothing) Then
                    l = MyModel.GetModelList()
                    Session("data") = l
                End If
                Return l
            End Get
        End Property
        <ValidateInput(False)> _
        Public Function GridViewPartial() As ActionResult


            Return PartialView("_GridViewPartial", Data)
        End Function

        <HttpPost, ValidateInput(False)> _
        Public Function GridViewPartialAddNew(ByVal item As MVCxGridViewDataBinding.Models.MyModel) As ActionResult
            ViewData("Item") = item
            Dim model = MyModel.GetModelList()
            If ModelState.IsValid Then
                Try
                    MyModel.InsertModel(Data, item)
                Catch e As Exception
                    ViewData("EditError") = e.Message
                End Try
            Else
                ViewData("EditError") = "Please, correct all errors."
            End If
            Return PartialView("_GridViewPartial", model)
        End Function
        <HttpPost, ValidateInput(False)> _
        Public Function GridViewPartialUpdate(ByVal item As MVCxGridViewDataBinding.Models.MyModel) As ActionResult

            ViewData("Item") = item
            If ModelState.IsValid Then
                Try
                    ' Insert here a code to update the item in your model
                    MyModel.UpdateModel(Data, item)
                Catch e As Exception
                    ViewData("EditError") = e.Message
                End Try
            Else
                ViewData("EditError") = "Please, correct all errors."
            End If
            Return PartialView("_GridViewPartial", Data)
        End Function
        <HttpPost, ValidateInput(False)> _
        Public Function GridViewPartialDelete(ByVal ModelID As Int32) As ActionResult
            If ModelID >= 0 Then
                Try
                    MyModel.DeleteModel(Data, ModelID)
                Catch e As Exception
                    ViewData("EditError") = e.Message
                End Try
            End If
            Return PartialView("_GridViewPartial", Data)
        End Function
    End Class
End Namespace
