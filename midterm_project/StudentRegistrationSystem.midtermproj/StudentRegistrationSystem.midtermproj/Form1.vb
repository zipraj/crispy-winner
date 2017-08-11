Public Class Form1

    Dim unm, pwd As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        unm = TextBox1.Text
        pwd = TextBox2.Text

        Dim UserExists As Boolean = False

        Dim cn As New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Dell\Desktop\midterm_project\srsdb.mdb")
        Dim cmd As OleDb.OleDbCommand = cn.CreateCommand()

        cmd.CommandText = "SELECT 1 FROM Users WHERE Username = @unm AND Password = @pwd"

        cmd.Parameters.AddWithValue(unm, unm)
        cmd.Parameters.AddWithValue(pwd, pwd)

        cn.Open()

        UserExists = Convert.ToBoolean(cmd.ExecuteScalar())

        If (UserExists) Then

            Me.Hide()
            form2.show

        Else

            MessageBox.Show("Please input valid login access.")

        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()
    End Sub

End Class
