Public Class Form4

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim cn As New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Dell\Desktop\midterm_project\srsdb.mdb")

        Dim ds As New DataSet
            Dim dt As New DataTable
            ds.Tables.Add(dt)
            Dim da As New OleDb.OleDbDataAdapter


            da = New OleDb.OleDbDataAdapter("SELECT * FROM Students", cn)

            da.Fill(dt)

            DataGridView1.DataSource = dt

            cn.Close()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        DataGridView1.DataSource = vbEmpty
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
        Form2.Show()
    End Sub

End Class