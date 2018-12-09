Imports MySql.Data.MySqlClient

Public Class frmaddproduct

    Dim price As Decimal
    Dim quantity As Integer

    Private Sub frmaddproduct_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        modes()
        loadbrand()
        loadcolor()
        loadsupplier()

    End Sub

    Private Sub modes()

        If productmode = "View Mode" Then
            Label8.Text = "View Product"
            txtprodid.Enabled = False
            cboitem.Enabled = False
            cbobrand.Enabled = False
            txtsize.Enabled = False
            cbobyte.Enabled = False
            cbocolor.Enabled = False
            cbosupplier.Enabled = False
            dtparrival.Enabled = False
            txtprice.Enabled = False
            txtquantity.Enabled = False
            txttotalprice.Enabled = False
            btnadd.Text = "Add"
            btnedit.Text = "Edit"
            btnedit.Enabled = True
            btndelete.Enabled = True
        ElseIf productmode = "Add Mode" Then
            Label8.Text = "Add Product"
            getlastproductid()
            txtprodid.Enabled = True
            cboitem.Enabled = True
            cbobrand.Text = ""
            cbobrand.Enabled = True
            txtsize.Text = ""
            txtsize.Enabled = True
            cbobyte.Text = "MB"
            cbobyte.Enabled = True
            cbocolor.Text = ""
            cbocolor.Enabled = True
            cbosupplier.Text = ""
            cbosupplier.Enabled = True
            dtparrival.Value = Now
            dtparrival.Enabled = True
            txtprice.Text = ""
            txtprice.Enabled = True
            txtquantity.Text = ""
            txtquantity.Enabled = True
            txttotalprice.Text = "Php "
            txttotalprice.Enabled = True
            cbobyte.Text = "GB"
            btnadd.Text = "Enter"

            btnedit.Enabled = False
            btndelete.Enabled = False
        ElseIf productmode = "Edit Mode" Then
            Label8.Text = "Edit Product"
            txtprodid.Enabled = True
            cboitem.Enabled = True
            cbobrand.Enabled = True
            txtsize.Enabled = True
            cbobyte.Enabled = True
            cbocolor.Enabled = True
            cbosupplier.Enabled = True
            dtparrival.Enabled = True
            txtprice.Enabled = True
            txtquantity.Enabled = True
            txttotalprice.Enabled = True
            btnedit.Text = "Update"
            btnedit.Enabled = True
            btndelete.Enabled = True
        End If

    End Sub

    Private Sub loadbrand()

        connecttodb()
        cbobrand.Items.Clear()
        Dim ds As New DataSet
        Dim sql As String

        sql = "select brand from tbl_item_brand"
        sqlda = New MySqlDataAdapter(sql, con)

        sqlda.Fill(ds, "fd")
        For Each r As DataRow In ds.Tables(0).Rows
            cbobrand.Items.Add(r("brand"))
        Next

        con.Close()

    End Sub

    Private Sub loadcolor()

        connecttodb()
        cbocolor.Items.Clear()
        Dim ds As New DataSet
        Dim sql As String

        sql = "select color from tbl_item_color"
        sqlda = New MySqlDataAdapter(sql, con)

        sqlda.Fill(ds, "fd")
        For Each r As DataRow In ds.Tables(0).Rows
            cbocolor.Items.Add(r("color"))
        Next

        con.Close()

    End Sub

    Private Sub loadsupplier()

        connecttodb()
        cbosupplier.Items.Clear()
        Dim ds As New DataSet
        Dim sql As String

        sql = "select supplier from tbl_item_supplier"
        sqlda = New MySqlDataAdapter(sql, con)

        sqlda.Fill(ds, "fd")
        For Each r As DataRow In ds.Tables(0).Rows
            cbosupplier.Items.Add(r("supplier"))
        Next

        con.Close()

    End Sub

    Private Sub getlastproductid()

        connecttodb()
        cmd = New MySqlCommand("SELECT MAX(product_id) FROM tbl_stocks", con)
        Dim replaceid As String = Convert.ToString(cmd.ExecuteScalar()).Replace("FD", "")
        If replaceid <> "" Then
            Dim newid As String = replaceid + 1
            If newid < 10 And newid > 0 Then
                txtprodid.Text = "FD00" & newid
            ElseIf newid < 100 And newid > 9 Then
                txtprodid.Text = "FD0" & newid
            ElseIf newid > 99 Then
                txtprodid.Text = "FD" & newid
            End If
        Else
            txtprodid.Text = "FD001"
        End If

    End Sub

    Private Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click

        If btnadd.Text = "Add" Then
            btnadd.Text = "Enter"
            productmode = "Add Mode"
            modes()
        ElseIf btnadd.Text = "Enter" Then

            connecttodb()
            If cbobrand.Text <> "" Then
                cmd.CommandText = "Select brand from tbl_item_brand where brand = '" & cbobrand.Text & "'"
                reader = cmd.ExecuteReader
                If reader.HasRows = False Then
                    reader.Close()
                    cmd = New MySqlCommand("INSERT INTO `tbl_item_brand`(`brand`) VALUES ('" & cbobrand.Text & "')", con)
                    cmd.ExecuteNonQuery()
                End If
                reader.Close()
            End If

            If cbocolor.Text <> "" Then
                cmd.CommandText = "Select color from tbl_item_color where color = '" & cbocolor.Text & "'"
                reader = cmd.ExecuteReader
                If reader.HasRows = False Then
                    reader.Close()
                    cmd = New MySqlCommand("INSERT INTO `tbl_item_color`(`color`) VALUES ('" & cbocolor.Text & "')", con)
                    cmd.ExecuteNonQuery()
                End If
                reader.Close()
            End If

            If cbosupplier.Text <> "" Then
                cmd.CommandText = "Select supplier from tbl_item_supplier where supplier = '" & cbosupplier.Text & "'"
                reader = cmd.ExecuteReader
                If reader.HasRows = False Then
                    reader.Close()
                    cmd = New MySqlCommand("INSERT INTO `tbl_item_supplier`(`supplier`) VALUES ('" & cbosupplier.Text & "')", con)
                    cmd.ExecuteNonQuery()
                End If
                reader.Close()
            End If

            Dim unitprice As Decimal = txtprice.Text
            Dim totalprice As Decimal = txttotalprice.Text.Replace("Php", "")
            cmd = New MySqlCommand("INSERT INTO `tbl_stocks`(`product_id`,`item`,`brand`,`size`,`byte`,`capacity`,`color`,`supplier`,`arrival_date`,`unit_price`,`quantity`,`total_price`) VALUES ('" & txtprodid.Text & "','" & cboitem.Text & "','" & cbobrand.Text & "','" & txtsize.Text & "','" & cbobyte.Text & "','" & txtsize.Text & " " & cbobyte.Text & "','" & cbocolor.Text & "','" & cbosupplier.Text & "','" & dtparrival.Text & "','" & unitprice & "','" & txtquantity.Text & "','" & totalprice & "')", con)
            cmd.ExecuteNonQuery()

            MessageBox.Show("Item Successfully added.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            getlastproductid()
            con.Close()

            cbobrand.Text = ""
            txtsize.Text = ""
            cbocolor.Text = ""
            cbosupplier.Text = ""
            dtparrival.Value = Now
            txtprice.Text = ""
            txtquantity.Text = ""
            txttotalprice.Text = "Php "
            frmmain.btnstocksrefresh.PerformClick()

        End If

    End Sub

    Private Sub txtprice_TextChanged(sender As Object, e As EventArgs) Handles txtprice.TextChanged

        Try
            If txtprice.Text <> "" Then
                price = txtprice.Text
                If txtquantity.Text <> "" Then
                    Dim totalprice As Decimal = price * txtquantity.Text
                    If totalprice > 999 Then
                        txttotalprice.Text = "Php " & Format((totalprice), "0,00.00")
                    ElseIf totalprice < 1000 Then
                        txttotalprice.Text = "Php " & Format((totalprice), "0.00")
                    End If
                End If
            Else
                txttotalprice.Text = "Php "
            End If
        Catch ex As Exception
            MessageBox.Show("Price must be a number!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtprice.Text = ""
        End Try

    End Sub

    Private Sub txtprice_LostFocus(sender As Object, e As EventArgs) Handles txtprice.LostFocus

        Dim price As Decimal = txtprice.Text
        If price > 999 Then
            txtprice.Text = Format((price), "0,00.00")
        ElseIf price < 1000 Then
            txtprice.Text = Format((price), "0.00")
        End If

    End Sub

    Private Sub txtquantity_TextChanged(sender As Object, e As EventArgs) Handles txtquantity.TextChanged

        Try
            If txtquantity.Text <> "" Then
                quantity = txtquantity.Text
                If txtprice.Text <> "" Then
                    Dim totalprice As Decimal = quantity * txtprice.Text
                    If totalprice > 999 Then
                        txttotalprice.Text = "Php " & Format((totalprice), "0,00.00")
                    ElseIf totalprice < 1000 Then
                        txttotalprice.Text = "Php " & Format((totalprice), "0.00")
                    End If
                End If
            Else
                txttotalprice.Text = "Php "
            End If
        Catch ex As Exception
            MessageBox.Show("Quantity must be a number!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtquantity.Text = ""
        End Try

    End Sub

    Private Sub btndelete_Click(sender As Object, e As EventArgs) Handles btndelete.Click
        confirm = MessageBox.Show("Are you sure?", "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
        If confirm = vbOK Then
            connecttodb()
            cmddelete = "DELETE FROM `tbl_stocks` where product_id='" & txtprodid.Text & "'"
            sqlda = New MySqlDataAdapter(cmddelete, con)
            ds = New DataSet()
            sqlda.Fill(ds)
            displaystocks()
            Me.Close()
        End If
    End Sub

    Private Sub btnedit_Click(sender As Object, e As EventArgs) Handles btnedit.Click

        If btnedit.Text = "Edit" Then
            btnedit.Text = "Update"
            productmode = "Edit Mode"
            modes()
        ElseIf btnedit.Text = "Update" Then

            connecttodb()
            If cbobrand.Text <> "" Then
                cmd.CommandText = "Select brand from tbl_item_brand where brand = '" & cbobrand.Text & "'"
                reader = cmd.ExecuteReader
                If reader.HasRows = False Then
                    reader.Close()
                    cmd = New MySqlCommand("INSERT INTO `tbl_item_brand`(`brand`) VALUES ('" & cbobrand.Text & "')", con)
                    cmd.ExecuteNonQuery()
                End If
                reader.Close()
            End If

            If cbocolor.Text <> "" Then
                cmd.CommandText = "Select color from tbl_item_color where color = '" & cbocolor.Text & "'"
                reader = cmd.ExecuteReader
                If reader.HasRows = False Then
                    reader.Close()
                    cmd = New MySqlCommand("INSERT INTO `tbl_item_color`(`color`) VALUES ('" & cbocolor.Text & "')", con)
                    cmd.ExecuteNonQuery()
                End If
                reader.Close()
            End If

            If cbosupplier.Text <> "" Then
                cmd.CommandText = "Select supplier from tbl_item_supplier where supplier = '" & cbosupplier.Text & "'"
                reader = cmd.ExecuteReader
                If reader.HasRows = False Then
                    reader.Close()
                    cmd = New MySqlCommand("INSERT INTO `tbl_item_supplier`(`supplier`) VALUES ('" & cbosupplier.Text & "')", con)
                    cmd.ExecuteNonQuery()
                End If
                reader.Close()
            End If

            Dim unitprice As Decimal = txtprice.Text
            Dim totalprice As Decimal = txttotalprice.Text.Replace("Php", "")
            cmd = New MySqlCommand("UPDATE `tbl_stocks` SET `item`= '" & cboitem.Text & "' ,`brand`= '" & cbobrand.Text & "' ,`size`= '" & txtsize.Text & "' , `byte`= '" & cbobyte.Text & "' ,`capacity`= '" & txtsize.Text & " " & cbobyte.Text & "' ,`color`= '" & cbocolor.Text & "' , `supplier`= '" & cbosupplier.Text & "' , `arrival_date`= '" & dtparrival.Text & "' ,`unit_price`= '" & unitprice & "' ,`quantity`= '" & txtquantity.Text & "' , `total_price`= '" & totalprice & "' where product_id='" & txtprodid.Text & "'", con)
            cmd.ExecuteNonQuery()

            MessageBox.Show("Item has been successfully updated.", "information", MessageBoxButtons.OK, MessageBoxIcon.Information)

            productmode = "View Mode"
            modes()
            displaystocks()
            con.Close()
        End If

    End Sub
End Class