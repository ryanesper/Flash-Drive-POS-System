Imports MySql.Data.MySqlClient

Public Class frmregister

    Private Sub btnok_Click(sender As Object, e As EventArgs) Handles btnok.Click

        If txtusername.Text = "" And txtpassword.Text <> "" Then
            MessageBox.Show("Username is empty!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtusername.Focus()
        ElseIf txtpassword.Text = "" And txtusername.Text <> "" Then
            MessageBox.Show("Password is empty!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtpassword.Focus()
        ElseIf txtpassword.Text = "" And txtusername.Text = "" Then
            MessageBox.Show("Fields are empty!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtusername.Focus()
        Else
            connecttodb()
            cmd = New MySqlCommand("INSERT INTO `tbl_admin`(`username`, `password`) VALUES ('" & txtusername.Text & "','" & txtpassword.Text & "')", con)
            cmd.ExecuteNonQuery()

            MessageBox.Show("You have successfully created an Account", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information)
            con.Close()
            frmlogin.Show()
            Me.Close()
        End If

    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click

        Me.Close()

    End Sub
End Class