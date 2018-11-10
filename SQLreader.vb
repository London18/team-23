Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Namespace sqlreading

    Public Class sqltables
        'creates a table and displays the data to html table
        Public Function DisplayRow() As String

            Dim data As String = "<table border='1' class='table' style='table-layout: fixed; width: 100%'> <tr><th>Questions</th> <th>Answers</th> <th>Keywords</th> <th>Options</th> </tr>"
            Dim sql_command As String = "Select * FROM [Answers] "
            Dim con As New SqlConnection("Server=DESKTOP-3J246S1\SQLEXPRESS01;Database=Questions;User Id=kostas;Password=12345rondo;")
            Using cmd As New SqlCommand(sql_command, con)
                con.Open()
                Using r As SqlDataReader = cmd.ExecuteReader()
                    Dim id = 0
                    While r.Read
                        data += "<tr class='editable'>"
                        data += addColumn(r("Questions"))
                        data += addColumn(r("Answers"))
                        data += addColumn(r("Keywords"))
                        data += addColumn("<button id=" & id & " type='button' class='editbtn' class='btn btn-outline-primary'>Edit</button>")
                        data += "</tr>"
                        id = id + 1
                    End While
                End Using
                con.Close()
            End Using
            data += "</table>"
            Return data
        End Function

        Function customSQL(ByVal sqlCommand As String, Optional scalar As Boolean = False) As String
            Dim result As String = ""
            Try
                Dim myConnSTR As String = ConfigurationManager.ConnectionStrings("mainDatabase").ConnectionString
                Dim con As New SqlConnection(myConnSTR)
                Dim cmd As New SqlCommand(sqlCommand, con)
                con.Open()
                If scalar = True Then
                    result = cmd.ExecuteScalar()
                Else
                    result = cmd.ExecuteNonQuery()
                    result += " - ok"
                End If
                con.Close()
            Catch ex As Exception
                result = "Error: " & ex.Message
            End Try
            Return result
        End Function


        Public Function selectData(ByVal id As Integer) As String
            Dim sqlcommand As String = "SELECT [Questions] FROM [Answers] WHERE [id]=" & id & ";"
            Dim result = customSQL(sqlcommand, False)
            Return result
        End Function

        'add the specific column to the html table
        Private Function addColumn(ByVal ColumnName As String) As String
            Return "<td><div>" & ColumnName & "</div></td>"
        End Function


        Private Function getIndex() As String

        End Function

        'deletes all the previous data from the table and inserts the new data
        Public Function InsertData(ByVal question As String, ByVal answer As String, ByVal keywords As String) As String

            Dim data As String = String.Empty
            Dim query As String = String.Empty
            query &= "INSERT INTO Answers (Questions, Answers,Keywords) VALUES (@Questions, @Answers, @Keywords)"
            Try
                Using conn As New SqlConnection("Server=DESKTOP-3J246S1\SQLEXPRESS01;Database=Questions;User Id=kostas;Password=12345rondo;")
                    Using comm As New SqlCommand()
                        With comm
                            .Connection = conn
                            .CommandType = CommandType.Text
                            .CommandText = query
                            .Parameters.AddWithValue("@Questions", question)
                            .Parameters.AddWithValue("@Answers", answer)
                            .Parameters.AddWithValue("@Keywords", keywords)
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


End Namespace