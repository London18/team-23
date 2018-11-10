<%@ WebHandler Language="VB" Class="Handler" %>

Imports System
Imports System.Web
Imports System.Web.SessionState
Imports System.Net.Mail
Imports System.Web.Configuration
Imports System.Net
Imports System.Data.SqlClient
Imports sqlreading

Public Class Handler : Implements IHttpHandler, IRequiresSessionState

    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        context.Response.ContentType = "text/plain"
        Dim action As String = context.Request("action")

        If action = "saveNewQuestion" Then

            context.Response.Write(New sqltables().InsertData(context.Request("question"), context.Request("answer"), context.Request("tags")))
        End If

        If action = "getData" Then
            context.Response.Write(New sqltables().selectData(context.Request("id")))

        End If

    End Sub


    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property



End Class