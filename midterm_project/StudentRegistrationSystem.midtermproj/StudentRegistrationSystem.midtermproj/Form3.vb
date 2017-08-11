Public Class Form3

    Dim insert, sfirst, slast, city, email, grade, cnum As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        sfirst = TextBox1.Text
        slast = TextBox2.Text
        city = TextBox3.Text
        cnum = TextBox4.Text
        email = TextBox5.Text
        grade = TextBox6.Text

        Dim FieldsRequired As Boolean = False

        Dim cn As New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Dell\Desktop\midterm_project\srsdb.mdb")

        insert = "INSERT INTO Students ([FirstName], [LastName], [City], [ContactNumber], [EmailAdd], [GradeLevel]) VALUES (?,?,?,?,?,?)"

        Dim cmd As OleDb.OleDbCommand = New OleDb.OleDbCommand(insert, cn)



        cmd.Parameters.Add(New OleDb.OleDbParameter("FirstName", sfirst))
        cmd.Parameters.Add(New OleDb.OleDbParameter("LastName", slast))
        cmd.Parameters.Add(New OleDb.OleDbParameter("City", city))
        cmd.Parameters.Add(New OleDb.OleDbParameter("ContactNumber", cnum))
        cmd.Parameters.Add(New OleDb.OleDbParameter("EmailAdd", email))
        cmd.Parameters.Add(New OleDb.OleDbParameter("GradeLevel", grade))

        cn.Open()

        If (sfirst IsNot "" AndAlso slast IsNot "" AndAlso city IsNot "" AndAlso cnum IsNot "" AndAlso email IsNot "" AndAlso grade IsNot "") Then

            Try

                cmd.ExecuteNonQuery()
                cmd.Dispose()
                cn.Close()
                TextBox1.Clear()
                TextBox2.Clear()
                TextBox3.Clear()
                TextBox4.Clear()
                TextBox5.Clear()
                TextBox6.Clear()
                MessageBox.Show("Student profile created.")

            Catch ex As Exception

            End Try

        Else
            MessageBox.Show("Fields can't be blank!")
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
        Form2.Show()
    End Sub

End Class