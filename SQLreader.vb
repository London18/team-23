Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Namespace sqlreading

    Public Class sqltables
        'creates a table and displays the data to html 
        Public Function DisplayRow() As String

            Dim data As String = "<table border='1' class='table'> <tr><th>Questions</th> <th>Answers</th> <th>Keywords</th> </tr>"
            Dim sql_command As String = "Select * FROM [Answers] "
            Dim con As New SqlConnection("Server=DESKTOP-3J246S1\SQLEXPRESS01;Database=Questions;User Id=kostas;Password=12345rondo;")
            Using cmd As New SqlCommand(sql_command, con)
                con.Open()
                Using r As SqlDataReader = cmd.ExecuteReader()
                    While r.Read
                        data += "<tr>"
                        data += addColumn(r("Questions"))
                        data += addColumn(r("Answers"))
                        data += addColumn(r("Keywords"))
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
        Public Function InsertData(ByVal question As String, ByVal answer As String, ByVal keywords As String) As String

            Dim data As String = String.Empty
            Dim query As String = String.Empty
            query &= "INSERT INTO Answers (Questions, Answers,Keywords  ) VALUES (@Questions, @Answers, @Keywords)"
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

