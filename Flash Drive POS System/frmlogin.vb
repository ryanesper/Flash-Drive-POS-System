Imports MySql.Data.MySqlClient

Public Class frmlogin

    Private Sub frmlogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        connecttodb()
        cmd = New MySqlCommand("SELECT COUNT(username) as count from tbl_admin", con)
        reader = cmd.ExecuteReader
        While (reader.Read())
            If reader("count") = 0 Then
                frmregister.Show()
                Me.Close()
            End If
        End While
        reader.Close()
        con.Close()

    End Sub

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

            cmd.CommandText = "Select * from tbl_admin where username = '" & txtusername.Text & "' and password = '" & txtpassword.Text & "'"
            reader = cmd.ExecuteReader
            If reader.HasRows Then
                reader.Close()
                frmmain.Show()
                con.Close()
                Me.Close()
            Else
                MessageBox.Show("Account doesn't exist!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                reader.Close()
                txtusername.Text = ""
                txtpassword.Text = ""
                txtusername.Focus()
            End If
        End If

    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click

        Me.Close()

    End Sub
End Class
