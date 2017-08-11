Public Class Form5

    Dim sid, ftu, udt, upd As String
    Dim grade, graded, gradem, gradea As Double

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ComboBox1.Items.Add("First Name")
        ComboBox1.Items.Add("Last Name")
        ComboBox1.Items.Add("City")
        ComboBox1.Items.Add("Contact Number")
        ComboBox1.Items.Add("Email Address")
        ComboBox1.Items.Add("Grade Level")
        ComboBox1.Items.Add("Prelim Grade")
        ComboBox1.Items.Add("Midterm Grade")
        ComboBox1.Items.Add("Final Grade")

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        sid = TextBox1.Text
        ftu = ComboBox1.Text
        udt = TextBox2.Text

        Dim StudentExists As Boolean = False

        Dim cn As New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Dell\Desktop\midterm_project\srsdb.mdb")
        Dim cmd As OleDb.OleDbCommand = cn.CreateCommand()

        cmd.CommandText = "SELECT 1 FROM Students WHERE StudentID = @sid"

        cmd.Parameters.AddWithValue(sid, sid)

        cn.Open()

        StudentExists = Convert.ToBoolean(cmd.ExecuteScalar())

        cn.Close()

        If (StudentExists) Then

            If (sid IsNot "" AndAlso udt IsNot "" AndAlso ftu IsNot "") Then

                cn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Dell\Desktop\midterm_project\srsdb.mdb"

                cn.Open()

                If ftu = "First Name" Then
                    upd = "UPDATE Students SET FirstName = @udt WHERE StudentID = @sid"

                ElseIf ftu = "Last Name" Then
                    upd = "UPDATE Students SET LastName = @udt WHERE StudentID = @sid"

                ElseIf ftu = "City" Then
                    upd = "UPDATE Students SET City = @udt WHERE StudentID = @sid"

                ElseIf ftu = "Contact Number" Then
                    upd = "UPDATE Students SET ContactNumber = @udt WHERE StudentID = @sid"

                ElseIf ftu = "Email Address" Then
                    upd = "UPDATE Students SET EmailAdd = @udt WHERE StudentID = @sid"

                ElseIf ftu = "Grade Level" Then
                    upd = "UPDATE Students SET GradeLevel = @udt WHERE StudentID = @sid"
                End If

                If ftu = "Prelim Grade" Then
                    grade = TextBox2.Text
                    upd = "UPDATE Students SET PrelimExam = @udt WHERE StudentID = @sid"
                    udt = udt / 50
                    udt = udt * 50
                    udt = udt + 50

                ElseIf ftu = "Midterm Grade" Then
                    grade = TextBox2.Text

                    upd = "UPDATE Students SET MidtermExam = @udt WHERE StudentID = @sid"
                    udt = udt / 50
                    udt = udt * 50
                    udt = udt + 50

                ElseIf ftu = "Final Grade" Then
                    grade = TextBox2.Text

                    upd = "UPDATE Students SET FinalsExam = @udt WHERE StudentID = @sid"
                    udt = udt / 50
                    udt = udt * 50
                    udt = udt + 50

                Else
                    udt = TextBox2.Text
                End If


                cmd = New OleDb.OleDbCommand(upd, cn)

                cmd.Parameters.AddWithValue(udt, udt)
                    cmd.Parameters.AddWithValue(sid, sid)

                If grade <= 50 Then
                    Try
                        cmd.ExecuteNonQuery()
                        cmd.Dispose()
                        cn.Close()
                    Catch ex As Exception

                    End Try

                    MessageBox.Show("Data has been updated!")
                    TextBox1.Clear()
                    ComboBox1.ResetText()
                    TextBox2.Clear()
                Else
                    MessageBox.Show("Score can't be higher than 50")

                End If

                Else

                        MessageBox.Show("All fields required.")

            End If

        Else
                MessageBox.Show("No record available.")
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        TextBox1.Clear()
        ComboBox1.ResetText()
        TextBox2.Clear()

    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Me.Close()
        Form2.Show()

    End Sub

End Class