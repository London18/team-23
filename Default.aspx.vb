Imports System.Data
Imports System.Data.SqlClient
Imports sqlreading

Partial Class _Default
    Inherits System.Web.UI.Page


    Private Sub Data_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Title = "Homepage"
        myTable.InnerHtml += New sqltables().DisplayRow()
    End Sub


End Class
