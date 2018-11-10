Imports System.Data
Imports System.Data.SqlClient

Partial Class _Default
    Inherits System.Web.UI.Page


    Private Sub Data_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Title = "Homepage"
        myTable.InnerHtml += DisplayRow()
    End Sub


    'creates a table and displays the data to html 
    Private Function DisplayRow() As String

        Dim data As String = "<table border='1' class='table'> <tr> <th>Questions</th>  </tr>"
        Dim sql_command As String = "Select * FROM [Answers] "
        Dim con As New SqlConnection("Server=DESKTOP-3J246S1\SQLEXPRESS01;Database=Questions;User Id=kostas;Password=12345rondo;")
        Using cmd As New SqlCommand(sql_command, con)
            con.Open()
            Using r As SqlDataReader = cmd.ExecuteReader()
                While r.Read
                    data += "<tr>"
                    data += addColumn(r("Answers"))
                    data += "</tr>"
                End While
            End Using
            con.Close()
        End Using
        data += "</table>"
        Return data
    End Function

    'add the specific column to the html table
    Private Function addColumn(ByVal ColumnName As String) As String
        Return "<td><div>" & ColumnName & "</div></td>"
    End Function

    'deletes all the previous data from the table and inserts the new data
    Private Function InsertData(ByVal answer As String, ByVal datalist As List(Of Double)) As String

        Dim data As String = String.Empty
        Dim query As String = String.Empty
        'query &= "TRUNCATE TABLE [IntradayData];"
        query &= "INSERT INTO IntradayData (Answers) "
        query &= "VALUES (@Answers)"
        Try
            Using conn As New SqlConnection("Server=DESKTOP-3J246S1\SQLEXPRESS01;Database=StockMarket;User Id=kostas;Password=123;")
                Using comm As New SqlCommand()
                    With comm
                        .Connection = conn
                        .CommandType = CommandType.Text
                        .CommandText = query
                        .Parameters.AddWithValue("@Answers", answer)
                    End With
                    Try
                        conn.Open()
                        comm.ExecuteScalar()
                    Catch ex As SqlException
                        data = data & "<hr/>" & query & "<hr/>" & ex.ToString
                    End Try
                End Using
            End Using
        Catch ex As Exception
            data = data & "<hr/>" & query & "<hr/>" & ex.ToString
        End Try

        Return data
    End Function




End Class
