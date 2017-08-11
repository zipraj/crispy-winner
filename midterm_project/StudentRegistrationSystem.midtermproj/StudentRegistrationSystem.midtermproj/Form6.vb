Public Class Form6

    Dim sid, delete As String



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        sid = TextBox1.Text

        Dim StudentsExists As Boolean = False

        Dim cn As New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Dell\Desktop\midterm_project\srsdb.mdb")
        Dim cmd As OleDb.OleDbCommand = cn.CreateCommand()
        cmd.CommandText = "SELECT 1 FROM Students WHERE StudentID = @sid"

        cmd.Parameters.AddWithValue(sid, sid)

        cn.Open()

        StudentsExists = Convert.ToBoolean(cmd.ExecuteScalar)

        cn.Close()

        If (StudentsExists) Then

            If (sid IsNot "") Then

                cn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Dell\Desktop\midterm_project\srsdb.mdb"
                cn.Open()

                delete = "DELETE * FROM Students WHERE StudentID = @sid"

                cmd = New OleDb.OleDbCommand(delete, cn)

                cmd.Parameters.AddWithValue(sid, sid)

                Try
                    cmd.ExecuteNonQuery()
                    cmd.Dispose()
                    cn.Close()
                Catch ex As Exception

                End Try

                MessageBox.Show("Data has been deleted!")
                TextBox1.Clear()

            End If

        Else
            MessageBox.Show("Please input valid Student ID number")
        End If



    End Sub



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Clear()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
        Form2.Show()
    End Sub
End Class