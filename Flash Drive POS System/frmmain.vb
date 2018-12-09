Imports MySql.Data.MySqlClient

Public Class frmmain

    Dim srp As Decimal
    Dim newtransaction As Boolean = False
    Dim isselecteditemequaltoone As Boolean
    Dim col0 As String
    Dim col1 = "", col2 = "", col3 = "", col4 = "", col5 = "", col6 = "", col7 = "", col8 = "", col9 = "", col10 = "", col11 = "", col12 As String = ""
    Dim rtl0 As String = ""
    Dim rtl1 = "", rtl2 = "", rtl3 = "", rtl4 = "", rtl5 = "", rtl6 = "", rtl7 = "", rtl8 = "", rtl9 = "", rtl10 = "", rtl11 = "", rtl12 As String = ""

    Private Sub btnminimize_Click(sender As Object, e As EventArgs) Handles btnminimize.Click

        Me.WindowState = FormWindowState.Minimized

    End Sub

    Private Sub btnexit_Click(sender As Object, e As EventArgs) Handles btnexit.Click

        frmlogin.Show()
        Me.Close()

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lviitemstosell.Columns.Add("Item", 100, HorizontalAlignment.Left)
        lviitemstosell.Columns.Add("Brand", 100, HorizontalAlignment.Left)
        lviitemstosell.Columns.Add("Size", 0, HorizontalAlignment.Left)
        lviitemstosell.Columns.Add("Byte", 0, HorizontalAlignment.Left)
        lviitemstosell.Columns.Add("Capacity", 100, HorizontalAlignment.Left)
        lviitemstosell.Columns.Add("Color", 100, HorizontalAlignment.Left)
        lviitemstosell.Columns.Add("Supplier", 0, HorizontalAlignment.Left)
        lviitemstosell.Columns.Add("Arrival Date", 0, HorizontalAlignment.Left)
        lviitemstosell.Columns.Add("Price", 100, HorizontalAlignment.Left)
        lviitemstosell.Columns.Add("SRP", 100, HorizontalAlignment.Left)
        lviitemstosell.Columns.Add("Quantity", 80, HorizontalAlignment.Left)
        lviitemstosell.Columns.Add("Total Price", 100, HorizontalAlignment.Left)
        lviitemstosell.Columns.Add("Product ID", 0, HorizontalAlignment.Left)

        'lvitotalitemstosell.Columns.Add("Total", 450, HorizontalAlignment.Left)

        lvistocks.Columns.Add("Item", 100, HorizontalAlignment.Left)
        lvistocks.Columns.Add("Brand", 100, HorizontalAlignment.Left)
        lvistocks.Columns.Add("Size", 0, HorizontalAlignment.Left)
        lvistocks.Columns.Add("Byte", 0, HorizontalAlignment.Left)
        lvistocks.Columns.Add("Capacity", 100, HorizontalAlignment.Left)
        lvistocks.Columns.Add("Color", 100, HorizontalAlignment.Left)
        lvistocks.Columns.Add("Supplier", 100, HorizontalAlignment.Left)
        lvistocks.Columns.Add("Arrival Date", 100, HorizontalAlignment.Left)
        lvistocks.Columns.Add("Price", 100, HorizontalAlignment.Left)
        lvistocks.Columns.Add("Quantity", 80, HorizontalAlignment.Left)
        lvistocks.Columns.Add("Total Price", 100, HorizontalAlignment.Left)
        lvistocks.Columns.Add("Product ID", 0, HorizontalAlignment.Left)

        lvisales.Columns.Add("Transaction No.", 110, HorizontalAlignment.Left)
        lvisales.Columns.Add("Date Sold", 90, HorizontalAlignment.Left)
        lvisales.Columns.Add("Client", 100, HorizontalAlignment.Left)
        lvisales.Columns.Add("Address", 100, HorizontalAlignment.Left)
        lvisales.Columns.Add("Contact No.", 0, HorizontalAlignment.Left)
        lvisales.Columns.Add("Item", 0, HorizontalAlignment.Left)
        lvisales.Columns.Add("Brand", 100, HorizontalAlignment.Left)
        lvisales.Columns.Add("Color", 100, HorizontalAlignment.Left)
        lvisales.Columns.Add("Capacity", 100, HorizontalAlignment.Left)
        lvisales.Columns.Add("SRP", 100, HorizontalAlignment.Left)
        lvisales.Columns.Add("Quantity", 80, HorizontalAlignment.Left)
        lvisales.Columns.Add("Cash", 100, HorizontalAlignment.Left)
        lvisales.Columns.Add("Change", 100, HorizontalAlignment.Left)
        lvisales.Columns.Add("Total Payment", 100, HorizontalAlignment.Left)

        displaystocks()
        loadbrand()
        loadcapacity()
        loadbrand2()
        loadcapacity2()
        displaysales()

    End Sub

    Private Sub loadbrand()
        connecttodb()
        Dim ds As New DataSet
        Dim sql As String

        sql = "select distinct brand from tbl_stocks"
        sqlda = New MySqlDataAdapter(sql, con)

        sqlda.Fill(ds, "fd")
        For Each r As DataRow In ds.Tables(0).Rows
            cbobrand.Items.Add(r("brand"))
        Next

        con.Close()
    End Sub

    Private Sub loadcapacity()
        connecttodb()
        Dim ds As New DataSet
        Dim sql As String

        sql = "select distinct capacity from tbl_stocks"
        sqlda = New MySqlDataAdapter(sql, con)

        sqlda.Fill(ds, "fd")
        For Each r As DataRow In ds.Tables(0).Rows
            cbocapacity.Items.Add(r("capacity"))
        Next

        con.Close()
    End Sub

    Private Sub loadbrand2()
        connecttodb()
        Dim ds As New DataSet
        Dim sql As String

        sql = "select distinct brand from tbl_sales"
        sqlda = New MySqlDataAdapter(sql, con)

        sqlda.Fill(ds, "fd")
        For Each r As DataRow In ds.Tables(0).Rows
            cbosalesbrand.Items.Add(r("brand"))
        Next

        con.Close()
    End Sub

    Private Sub loadcapacity2()
        connecttodb()
        Dim ds As New DataSet
        Dim sql As String

        sql = "select distinct capacity from tbl_sales"
        sqlda = New MySqlDataAdapter(sql, con)

        sqlda.Fill(ds, "fd")
        For Each r As DataRow In ds.Tables(0).Rows
            cbosalescaapcity.Items.Add(r("capacity"))
        Next

        con.Close()
    End Sub

    Private Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click

        productmode = "Add Mode"
        frmaddproduct.ShowInTaskbar = False
        frmaddproduct.ShowDialog()

    End Sub

    Private Sub btnstocksdelete_Click(sender As Object, e As EventArgs) Handles btnstocksdelete.Click

        confirm = MessageBox.Show("Are you sure?", "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
        If confirm = vbOK Then
            connecttodb()
            For Each item As ListViewItem In lvistocks.Items
                If lvistocks.SelectedItems.Count > 0 Then
                    item = lvistocks.SelectedItems.Item(0)
                    cmddelete = "DELETE FROM `tbl_stocks` where product_id='" & item.SubItems(11).Text & "'"
                    sqlda = New MySqlDataAdapter(cmddelete, con)
                    ds = New DataSet()
                    sqlda.Fill(ds)
                End If
                item.Remove()
            Next
            displaystocks()
        End If

    End Sub

    Private Sub btnedit_Click(sender As Object, e As EventArgs) Handles btnedit.Click

        frmaddproduct.Label8.Text = "Edit Product"
        productmode = "Edit Mode"
        frmaddproduct.txtprodid.Text = lvistocks.SelectedItems.Item(0).SubItems(11).Text
        frmaddproduct.cbobrand.Text = lvistocks.SelectedItems.Item(0).SubItems(1).Text
        frmaddproduct.txtsize.Text = lvistocks.SelectedItems.Item(0).SubItems(2).Text
        frmaddproduct.cbobyte.Text = lvistocks.SelectedItems.Item(0).SubItems(3).Text
        frmaddproduct.cbocolor.Text = lvistocks.SelectedItems.Item(0).SubItems(5).Text
        frmaddproduct.cbosupplier.Text = lvistocks.SelectedItems.Item(0).SubItems(6).Text
        frmaddproduct.dtparrival.Text = lvistocks.SelectedItems.Item(0).SubItems(7).Text
        frmaddproduct.txtprice.Text = lvistocks.SelectedItems.Item(0).SubItems(8).Text.Replace("Php ", "")
        frmaddproduct.txtquantity.Text = lvistocks.SelectedItems.Item(0).SubItems(9).Text
        frmaddproduct.txttotalprice.Text = lvistocks.SelectedItems.Item(0).SubItems(10).Text
        frmaddproduct.ShowInTaskbar = False
        frmaddproduct.ShowDialog()

    End Sub

    Private Sub btnstocksrefresh_Click(sender As Object, e As EventArgs) Handles btnstocksrefresh.Click

        lvistocks.Columns.Clear()
        lvistocks.Columns.Add("Item", 100, HorizontalAlignment.Left)
        lvistocks.Columns.Add("Brand", 100, HorizontalAlignment.Left)
        lvistocks.Columns.Add("Size", 0, HorizontalAlignment.Left)
        lvistocks.Columns.Add("Byte", 0, HorizontalAlignment.Left)
        lvistocks.Columns.Add("Capacity", 100, HorizontalAlignment.Left)
        lvistocks.Columns.Add("Color", 100, HorizontalAlignment.Left)
        lvistocks.Columns.Add("Supplier", 100, HorizontalAlignment.Left)
        lvistocks.Columns.Add("Arrival Date", 100, HorizontalAlignment.Left)
        lvistocks.Columns.Add("Price", 100, HorizontalAlignment.Left)
        lvistocks.Columns.Add("Quantity", 80, HorizontalAlignment.Left)
        lvistocks.Columns.Add("Total Price", 100, HorizontalAlignment.Left)
        lvistocks.Columns.Add("Product ID", 0, HorizontalAlignment.Left)
        displaystocks()
        undisplay()
        cbobrand.Items.Clear()
        cbocapacity.Items.Clear()
        cbobrand.Text = ""
        cbocapacity.Text = ""
        loadbrand()
        loadcapacity()


    End Sub

    Private Sub cbobrand_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbobrand.SelectedIndexChanged

        filterbrandinstocks()

    End Sub

    Private Sub cbocapacity_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbocapacity.SelectedIndexChanged

        filtercapacityinstocks()

    End Sub

    Private Sub btnnew_Click(sender As Object, e As EventArgs) Handles btnnew.Click

        newtransaction = True
        btnnew.Enabled = False
        btnsell.Enabled = True
        btncancel.Enabled = True
        btnselect.Enabled = True
        btnrestock.Enabled = True
        btnedit.Enabled = False
        btnstocksdelete.Enabled = False
        getlasttransactionid()
        dtpdatesold.Enabled = True
        txtclient.ReadOnly = False
        txtaddress.ReadOnly = False
        txtcontactno.ReadOnly = False
        txtcash.ReadOnly = False
        lvistocks.MultiSelect = False
        txtclient.Focus()
        displaystocks()

    End Sub

    Private Sub getlasttransactionid()

        connecttodb()
        cmd = New MySqlCommand("SELECT MAX(transaction_no) FROM tbl_transactions", con)
        Dim replaceid As String = Convert.ToString(cmd.ExecuteScalar()).Replace("TRN", "")
        If replaceid <> "" Then
            Dim newid As String = replaceid + 1
            If newid < 10 And newid > 0 Then
                txttrnno.Text = "TRN00" & newid
            ElseIf newid < 100 And newid > 9 Then
                txttrnno.Text = "TRN0" & newid
            ElseIf newid > 99 Then
                txttrnno.Text = "TRN" & newid
            End If
        Else
            txttrnno.Text = "TRN001"
        End If

    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click

        newtransaction = False
        txtsrp.ReadOnly = True
        btnsave.Enabled = False
        btnnew.Enabled = True
        btnsell.Enabled = False
        btncancel.Enabled = False
        btnselect.Enabled = False
        btnrestock.Enabled = False
        btnedit.Enabled = True
        btnstocksdelete.Enabled = True
        txttrnno.Text = ""
        txtclient.Text = ""
        txtaddress.Text = ""
        txtcontactno.Text = ""
        txtsrp.Text = ""
        txtitemstosellquantity.Text = ""
        txtitemstosellgrandtotal.Text = ""
        lviitemstosell.Items.Clear()
        dtpdatesold.Enabled = False
        txtclient.ReadOnly = True
        txtaddress.ReadOnly = True
        txtcontactno.ReadOnly = True
        txtcash.ReadOnly = True
        lvistocks.MultiSelect = True
        nupitemqty.Minimum = 0
        nupitemqty.Value = 0
        nupitemqty.Enabled = False
        nuprestock.Minimum = 0
        nuprestock.Value = 0
        nuprestock.Enabled = False
        displaystocks()
        undisplay()

    End Sub

    Private Sub lvistocks_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvistocks.SelectedIndexChanged

        If newtransaction = True Then
            For Each item As ListViewItem In lvistocks.Items
                If lvistocks.SelectedItems.Count = 1 Then
                    nupitemqty.Enabled = True
                    item = lvistocks.SelectedItems.Item(0)
                    nupitemqty.Minimum = 1
                    nupitemqty.Maximum = item.SubItems(9).Text
                    nupitemqty.Value = 1
                    'MsgBox("selected item is 1")
                ElseIf lvistocks.SelectedItems.Count > 1 Then
                    nupitemqty.Maximum = lvistocks.SelectedItems.Count
                    nupitemqty.Value = lvistocks.SelectedItems.Count
                    nupitemqty.Enabled = False
                    'MsgBox("selected item is greater than 1")
                ElseIf lvistocks.SelectedItems.Count = 0 Then
                    nupitemqty.Enabled = False
                    nupitemqty.Minimum = 0
                    nupitemqty.Value = 0
                    'MsgBox("selected item is 0")
                End If
            Next
        End If

    End Sub

    Private Sub btnselect_Click(sender As Object, e As EventArgs) Handles btnselect.Click

        If nupitemqty.Text <> 0 Then
            Dim counter As Integer = 0
            Dim quantity As Integer = 0
            Dim itemtoremove As Integer = 0
            Dim allowexecution As Boolean
            Dim startcounter As Boolean
            Dim stopcounter As Boolean
            If newtransaction = True Then
                For Each item As ListViewItem In lvistocks.Items
                    If lvistocks.SelectedItems.Count > 0 Then
                        item = lvistocks.SelectedItems.Item(0)
                        If lviitemstosell.Items.Count = 0 Then
                            Dim lvi As New ListViewItem(item.SubItems(0).Text)
                            lvi.SubItems.Add(item.SubItems(1).Text)
                            lvi.SubItems.Add(item.SubItems(2).Text)
                            lvi.SubItems.Add(item.SubItems(3).Text)
                            lvi.SubItems.Add(item.SubItems(4).Text)
                            lvi.SubItems.Add(item.SubItems(5).Text)
                            lvi.SubItems.Add(item.SubItems(6).Text)
                            lvi.SubItems.Add(item.SubItems(7).Text)
                            lvi.SubItems.Add(item.SubItems(8).Text)
                            lvi.SubItems.Add(item.SubItems(8).Text)
                            lvi.SubItems.Add(nupitemqty.Value)
                            Dim unitprice As Decimal = item.SubItems(8).Text.Replace("Php ", "")
                            Dim totalprice As Decimal = unitprice * nupitemqty.Value
                            If totalprice > 999 Then
                                lvi.SubItems.Add("Php " & Format((totalprice), "0,00.00"))
                            ElseIf totalprice < 1000 Then
                                lvi.SubItems.Add("Php " & Format((totalprice), "0.00"))
                            End If
                            lvi.SubItems.Add(item.SubItems(11).Text)
                            lviitemstosell.Items.Add(lvi)
                            allowexecution = False
                        ElseIf lviitemstosell.Items.Count > 0 Then
                            allowexecution = True
                            For Each item1 As ListViewItem In lviitemstosell.Items
                                item1.Selected = True
                            Next
                            For Each item1 As ListViewItem In lviitemstosell.Items
                                item1 = lviitemstosell.SelectedItems.Item(0)
                                If item1.SubItems(12).Text <> item.SubItems(11).Text Then
                                    If counter = 1 Then
                                        counter = 1
                                    Else
                                        counter = 0
                                    End If

                                    If stopcounter = False Then
                                        If startcounter = False Then
                                            itemtoremove = 0
                                            startcounter = True
                                            quantity = item1.SubItems(10).Text
                                        Else
                                            itemtoremove += 1
                                            startcounter = True
                                            quantity = item1.SubItems(10).Text
                                        End If
                                    End If
                                ElseIf item1.SubItems(12).Text = item.SubItems(11).Text Then
                                    counter = 1
                                    If stopcounter = False Then
                                        If startcounter = False Then
                                            itemtoremove = 0
                                            startcounter = True
                                            stopcounter = True
                                            quantity = item1.SubItems(10).Text
                                        Else
                                            itemtoremove += 1
                                            startcounter = True
                                            stopcounter = True
                                            quantity = item1.SubItems(10).Text
                                        End If
                                    End If

                                End If
                                item1.Selected = False
                            Next
                        End If

                        If allowexecution = True Then
                            If counter = 0 Then
                                Dim lvi As New ListViewItem(item.SubItems(0).Text)
                                lvi.SubItems.Add(item.SubItems(1).Text)
                                lvi.SubItems.Add(item.SubItems(2).Text)
                                lvi.SubItems.Add(item.SubItems(3).Text)
                                lvi.SubItems.Add(item.SubItems(4).Text)
                                lvi.SubItems.Add(item.SubItems(5).Text)
                                lvi.SubItems.Add(item.SubItems(6).Text)
                                lvi.SubItems.Add(item.SubItems(7).Text)
                                lvi.SubItems.Add(item.SubItems(8).Text)
                                lvi.SubItems.Add(item.SubItems(8).Text)
                                lvi.SubItems.Add(nupitemqty.Value)
                                Dim unitprice As Decimal = item.SubItems(8).Text.Replace("Php ", "")
                                Dim totalprice As Decimal = unitprice * nupitemqty.Value
                                If totalprice > 999 Then
                                    lvi.SubItems.Add("Php " & Format((totalprice), "0,00.00"))
                                ElseIf totalprice < 1000 Then
                                    lvi.SubItems.Add("Php " & Format((totalprice), "0.00"))
                                End If
                                lvi.SubItems.Add(item.SubItems(11).Text)
                                lviitemstosell.Items.Add(lvi)
                            ElseIf counter = 1 Then
                                lviitemstosell.Items.Item(itemtoremove).Remove()
                                Dim lvi As New ListViewItem(item.SubItems(0).Text)
                                lvi.SubItems.Add(item.SubItems(1).Text)
                                lvi.SubItems.Add(item.SubItems(2).Text)
                                lvi.SubItems.Add(item.SubItems(3).Text)
                                lvi.SubItems.Add(item.SubItems(4).Text)
                                lvi.SubItems.Add(item.SubItems(5).Text)
                                lvi.SubItems.Add(item.SubItems(6).Text)
                                lvi.SubItems.Add(item.SubItems(7).Text)
                                lvi.SubItems.Add(item.SubItems(8).Text)
                                lvi.SubItems.Add(item.SubItems(8).Text)
                                lvi.SubItems.Add(quantity + nupitemqty.Value)
                                Dim unitprice As Decimal = item.SubItems(8).Text.Replace("Php ", "")
                                Dim totalprice As Decimal = unitprice * (quantity + nupitemqty.Value)
                                If totalprice > 999 Then
                                    lvi.SubItems.Add("Php " & Format((totalprice), "0,00.00"))
                                ElseIf totalprice < 1000 Then
                                    lvi.SubItems.Add("Php " & Format((totalprice), "0.00"))
                                End If
                                lvi.SubItems.Add(item.SubItems(11).Text)
                                lviitemstosell.Items.Add(lvi)
                            End If
                        End If

                        If item.SubItems(9).Text = 1 Then
                            item.Remove()
                        ElseIf item.SubItems(9).Text > 1 Then
                            Dim newquantity As Integer
                            Dim lvi2 As New ListViewItem(item.SubItems(0).Text)
                            lvi2.SubItems.Add(item.SubItems(1).Text)
                            lvi2.SubItems.Add(item.SubItems(2).Text)
                            lvi2.SubItems.Add(item.SubItems(3).Text)
                            lvi2.SubItems.Add(item.SubItems(4).Text)
                            lvi2.SubItems.Add(item.SubItems(5).Text)
                            lvi2.SubItems.Add(item.SubItems(6).Text)
                            lvi2.SubItems.Add(item.SubItems(7).Text)
                            lvi2.SubItems.Add(item.SubItems(8).Text)
                            newquantity = item.SubItems(9).Text - nupitemqty.Value
                            lvi2.SubItems.Add(newquantity)
                            Dim unitprice As Decimal = item.SubItems(8).Text.Replace("Php ", "")
                            Dim currenttotalprice As Decimal = item.SubItems(10).Text.Replace("Php ", "")
                            Dim totalprice As Decimal = currenttotalprice - (unitprice * nupitemqty.Value)
                            If totalprice > 999 Then
                                lvi2.SubItems.Add("Php " & Format((totalprice), "0,00.00"))
                            ElseIf totalprice < 1000 Then
                                lvi2.SubItems.Add("Php " & Format((totalprice), "0.00"))
                            End If
                            lvi2.SubItems.Add(item.SubItems(11).Text)
                            If newquantity > 0 Then
                                lvistocks.Items.Add(lvi2)
                            End If
                            item.Remove()
                        End If
                    End If
                Next
                Dim stocksquantity As Integer
                Dim stocksgrandtotal As Decimal
                For Each item As ListViewItem In lvistocks.Items
                    stocksgrandtotal += item.SubItems(10).Text.Replace("Php ", "")
                    stocksquantity += item.SubItems(9).Text
                Next
                If stocksquantity <> 0 Then
                    txtstocksquantity.Text = stocksquantity
                Else
                    txtstocksquantity.Text = ""
                End If
                If stocksgrandtotal > 999 Then
                    txtstocksgrandtotal.Text = "Php " & Format((stocksgrandtotal), "0,00.00")
                ElseIf stocksgrandtotal > 0 And stocksgrandtotal < 1000 Then
                    txtstocksgrandtotal.Text = "Php " & Format((stocksgrandtotal), "0.00")
                ElseIf stocksgrandtotal = 0 Then
                    txtstocksgrandtotal.Text = ""
                End If
                Dim itemstosellquantity As Integer
                Dim itemstosellgrandtotal As Decimal
                For Each selecteditem As ListViewItem In lviitemstosell.Items
                    itemstosellgrandtotal += selecteditem.SubItems(11).Text.Replace("Php", "")
                    itemstosellquantity += selecteditem.SubItems(10).Text
                Next
                If itemstosellquantity <> 0 Then
                    txtitemstosellquantity.Text = itemstosellquantity
                Else
                    txtitemstosellquantity.Text = ""
                End If
                If itemstosellgrandtotal > 999 Then
                    txtitemstosellgrandtotal.Text = "Php " & Format((itemstosellgrandtotal), "0,00.00")
                ElseIf itemstosellgrandtotal > 0 And itemstosellgrandtotal < 1000 Then
                    txtitemstosellgrandtotal.Text = "Php " & Format((itemstosellgrandtotal), "0.00")
                ElseIf itemstosellgrandtotal = 0 Then
                    txtitemstosellgrandtotal.Text = ""
                End If
            End If

            getchange()
        Else
            MessageBox.Show("Quantity cannot be 0.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub lviitemstosell_Click(sender As Object, e As EventArgs) Handles lviitemstosell.Click

        txtsrp.ReadOnly = False
        btnsave.Enabled = True
        rtl0 = lviitemstosell.SelectedItems.Item(0).SubItems(0).Text
        rtl1 = lviitemstosell.SelectedItems.Item(0).SubItems(1).Text
        rtl2 = lviitemstosell.SelectedItems.Item(0).SubItems(2).Text
        rtl3 = lviitemstosell.SelectedItems.Item(0).SubItems(3).Text
        rtl4 = lviitemstosell.SelectedItems.Item(0).SubItems(4).Text
        rtl5 = lviitemstosell.SelectedItems.Item(0).SubItems(5).Text
        rtl6 = lviitemstosell.SelectedItems.Item(0).SubItems(6).Text
        rtl7 = lviitemstosell.SelectedItems.Item(0).SubItems(7).Text
        rtl8 = lviitemstosell.SelectedItems.Item(0).SubItems(8).Text
        txtsrp.Text = lviitemstosell.SelectedItems.Item(0).SubItems(9).Text.Replace("Php", "")
        rtl10 = lviitemstosell.SelectedItems.Item(0).SubItems(10).Text
        rtl11 = lviitemstosell.SelectedItems.Item(0).SubItems(11).Text
        rtl12 = lviitemstosell.SelectedItems.Item(0).SubItems(12).Text

    End Sub

    Private Sub lviitemstosell_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lviitemstosell.SelectedIndexChanged

        For Each item As ListViewItem In lviitemstosell.Items
            If lviitemstosell.SelectedItems.Count = 1 Then
                nuprestock.Enabled = True
                item = lviitemstosell.SelectedItems.Item(0)
                nuprestock.Minimum = 1
                nuprestock.Maximum = item.SubItems(10).Text
                nuprestock.Value = 1
            ElseIf lviitemstosell.SelectedItems.Count > 1 Then
                nuprestock.Maximum = lviitemstosell.SelectedItems.Count
                nuprestock.Value = lviitemstosell.SelectedItems.Count
                nuprestock.Enabled = False
            ElseIf lviitemstosell.SelectedItems.Count = 0 Then
                nuprestock.Enabled = False
                nuprestock.Minimum = 0
                nuprestock.Value = 0
            End If
        Next

    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click

        If txtsrp.Text <> "" Then
            Try
                srp = txtsrp.Text
            Catch ex As Exception
                If txtsrp.Text <> "" Then
                    MessageBox.Show("Retailed price must be a number!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtsrp.Text = ""
                    Exit Sub
                End If
            End Try
        End If

        For Each item As ListViewItem In lviitemstosell.Items
            If item.SubItems(12).Text = rtl12 Then
                item.Remove()
            End If
        Next

        Dim retaileditem As New ListViewItem(rtl0)
        retaileditem.SubItems.Add(rtl1)
        retaileditem.SubItems.Add(rtl2)
        retaileditem.SubItems.Add(rtl3)
        retaileditem.SubItems.Add(rtl4)
        retaileditem.SubItems.Add(rtl5)
        retaileditem.SubItems.Add(rtl6)
        retaileditem.SubItems.Add(rtl7)
        retaileditem.SubItems.Add(rtl8)
        If srp > 999 Then
            retaileditem.SubItems.Add("Php " & Format((srp), "0,00.00"))
        ElseIf srp < 1000 Then
            retaileditem.SubItems.Add("Php " & Format((srp), "0.00"))
        End If
        retaileditem.SubItems.Add(rtl10)
        Dim totalprice As Decimal = srp * rtl10
        If totalprice > 999 Then
            retaileditem.SubItems.Add("Php " & Format((totalprice), "0,00.00"))
        ElseIf totalprice < 1000 Then
            retaileditem.SubItems.Add("Php " & Format((totalprice), "0.00"))
        End If
        retaileditem.SubItems.Add(rtl12)
        lviitemstosell.Items.Add(retaileditem)

        Dim itemstosellgrandtotal As Decimal
        For Each selecteditem As ListViewItem In lviitemstosell.Items
            itemstosellgrandtotal += selecteditem.SubItems(11).Text.Replace("Php", "")
        Next
        If itemstosellgrandtotal > 999 Then
            txtitemstosellgrandtotal.Text = "Php " & Format((itemstosellgrandtotal), "0,00.00")
        ElseIf itemstosellgrandtotal > 0 And itemstosellgrandtotal < 1000 Then
            txtitemstosellgrandtotal.Text = "Php " & Format((itemstosellgrandtotal), "0.00")
        ElseIf itemstosellgrandtotal = 0 Then
            txtitemstosellgrandtotal.Text = ""
        End If

        txtsrp.ReadOnly = True
        txtsrp.Text = ""
        btnsave.Enabled = False
        getchange()

    End Sub

    Private Sub btnsell_Click(sender As Object, e As EventArgs) Handles btnsell.Click

        If txtitemstosellgrandtotal.Text <> "" Then
            If txtcash.Text <> "" Then
                confirm = MessageBox.Show("Do want to sell the selected items?", "Selling Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                If confirm = vbYes Then
                    connecttodb()

                    Dim itemstosellgrandtotal As Decimal = txtitemstosellgrandtotal.Text.Replace("Php", "")
                    Dim cash As Decimal = txtcash.Text
                    Dim change As Decimal = txtchange.Text.Replace("Php", "")
                    cmd = New MySqlCommand("INSERT INTO `tbl_transactions`(`transaction_no`,`transaction_date`,`client`,`address`,`contact_number`,`total_quantity`,`cash`,`change`,`total_payment`) VALUES ('" & txttrnno.Text & "','" & dtpdatesold.Text & "','" & txtclient.Text & "','" & txtaddress.Text & "','" & txtcontactno.Text & "','" & txtitemstosellquantity.Text & "','" & cash & "','" & change & "','" & itemstosellgrandtotal & "')", con)
                    cmd.ExecuteNonQuery()
                    For Each item As ListViewItem In lviitemstosell.Items
                        Dim unitprice As Decimal = item.SubItems(8).Text.Replace("Php ", "")
                        Dim sellingprice As Decimal = item.SubItems(9).Text.Replace("Php ", "")
                        Dim totalprice As Decimal = item.SubItems(11).Text.Replace("Php ", "")

                        cmd = New MySqlCommand("INSERT INTO `tbl_sales`(`transaction_no`,`product_id`,`item`,`brand`,`size`,`byte`,`capacity`,`color`,`supplier`,`arrival_date`,`unit_price`,`selling_price`,`quantity`,`total_price`) VALUES ('" & txttrnno.Text & "','" & item.SubItems(12).Text & "','" & item.SubItems(0).Text & "','" & item.SubItems(1).Text & "','" & item.SubItems(2).Text & "','" & item.SubItems(3).Text & "','" & item.SubItems(4).Text & "','" & item.SubItems(5).Text & "','" & item.SubItems(6).Text & "','" & item.SubItems(7).Text & "','" & unitprice & "','" & sellingprice & "','" & item.SubItems(10).Text & "','" & totalprice & "')", con)
                        cmd.ExecuteNonQuery()
                        'MsgBox("mag minus nata sa stokcs")
                        Dim currentquantity As Integer
                        Dim currenttotalprice As Decimal
                        cmd.CommandText = "Select * from tbl_stocks where product_id = '" & item.SubItems(12).Text & "'"
                        reader = cmd.ExecuteReader
                        If reader.HasRows Then
                            While (reader.Read())
                                currentquantity = reader("quantity").ToString
                                currenttotalprice = reader("total_price").ToString
                            End While
                        End If
                        reader.Close()
                        Dim newquantityinstocks As Integer = currentquantity - item.SubItems(10).Text
                        Dim oldtotalprice As Decimal = item.SubItems(10).Text * item.SubItems(8).Text.Replace("Php ", "")
                        Dim newtotalprice As Decimal = currenttotalprice - oldtotalprice
                        If newquantityinstocks > 0 Then
                            cmd = New MySqlCommand("UPDATE `tbl_stocks` SET `quantity`= '" & newquantityinstocks & "', `total_price`= '" & newtotalprice & "' where product_id='" & item.SubItems(12).Text & "'", con)
                            cmd.ExecuteNonQuery()
                        ElseIf newquantityinstocks = 0 Then
                            cmddelete = "DELETE FROM `tbl_stocks` where product_id='" & item.SubItems(12).Text & "'"
                            sqlda = New MySqlDataAdapter(cmddelete, con)
                            ds = New DataSet()
                            sqlda.Fill(ds)
                        End If
                        item.Remove()
                    Next
                    MessageBox.Show("Items successfully sold.", "Congratulations", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    txttrnno.Text = ""
                    dtpdatesold.Value = Now
                    txtclient.Text = ""
                    txtaddress.Text = ""
                    txtcontactno.Text = ""
                    txtsrp.Text = ""
                    txtitemstosellquantity.Text = ""
                    txtitemstosellgrandtotal.Text = ""
                    txtcash.Text = ""
                    txtchange.Text = ""
                    lviitemstosell.Items.Clear()
                    displaysales()
                    getlasttransactionid()
                    con.Close()
                End If
            Else
                MessageBox.Show("Cash is not enough.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("Select an item to sell first.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub


    Private Sub btnsalesrefresh_Click(sender As Object, e As EventArgs) Handles btnsalesrefresh.Click

        lvisales.Columns.Clear()
        lvisales.Columns.Add("Transaction No.", 110, HorizontalAlignment.Left)
        lvisales.Columns.Add("Date Sold", 90, HorizontalAlignment.Left)
        lvisales.Columns.Add("Client", 100, HorizontalAlignment.Left)
        lvisales.Columns.Add("Address", 100, HorizontalAlignment.Left)
        lvisales.Columns.Add("Contact No.", 0, HorizontalAlignment.Left)
        lvisales.Columns.Add("Item", 0, HorizontalAlignment.Left)
        lvisales.Columns.Add("Brand", 100, HorizontalAlignment.Left)
        lvisales.Columns.Add("Color", 100, HorizontalAlignment.Left)
        lvisales.Columns.Add("Capacity", 100, HorizontalAlignment.Left)
        lvisales.Columns.Add("SRP", 100, HorizontalAlignment.Left)
        lvisales.Columns.Add("Quantity", 80, HorizontalAlignment.Left)
        lvisales.Columns.Add("Cash", 100, HorizontalAlignment.Left)
        lvisales.Columns.Add("Change", 100, HorizontalAlignment.Left)
        lvisales.Columns.Add("Total Payment", 100, HorizontalAlignment.Left)
        cbosalesbrand.Items.Clear()
        cbosalescaapcity.Items.Clear()
        cbosalesbrand.Text = ""
        cbosalescaapcity.Text = ""
        loadbrand2()
        loadcapacity2()
        displaysales()

    End Sub

    Private Sub btnrestock_Click(sender As Object, e As EventArgs) Handles btnrestock.Click

        If lviitemstosell.SelectedItems.Count = 1 Then
            isselecteditemequaltoone = True
        ElseIf lviitemstosell.SelectedItems.Count > 1 Then
            isselecteditemequaltoone = False
        End If

        If isselecteditemequaltoone = True Then
            For Each item As ListViewItem In lviitemstosell.Items
                Dim quantitytominus As Integer = nuprestock.Value
                If lviitemstosell.SelectedItems.Count = 1 Then
                    item = lviitemstosell.SelectedItems.Item(0)
                    col0 = item.SubItems(0).Text
                    col1 = item.SubItems(1).Text
                    col2 = item.SubItems(2).Text
                    col3 = item.SubItems(3).Text
                    col4 = item.SubItems(4).Text
                    col5 = item.SubItems(5).Text
                    col6 = item.SubItems(6).Text
                    col7 = item.SubItems(7).Text
                    col8 = item.SubItems(8).Text
                    col9 = item.SubItems(9).Text
                    col10 = item.SubItems(10).Text
                    col11 = item.SubItems(11).Text
                    col12 = item.SubItems(12).Text

                    item.Remove()
                    Dim newquantity As Long = col10 - quantitytominus
                    If newquantity > 0 Then
                        Dim item2 As New ListViewItem(col0)
                        item2.SubItems.Add(col1)
                        item2.SubItems.Add(col2)
                        item2.SubItems.Add(col3)
                        item2.SubItems.Add(col4)
                        item2.SubItems.Add(col5)
                        item2.SubItems.Add(col6)
                        item2.SubItems.Add(col7)
                        item2.SubItems.Add(col8)
                        item2.SubItems.Add(col9)
                        item2.SubItems.Add(newquantity)
                        Dim totalprice As Decimal = col11.Replace("Php ", "") - (quantitytominus * col9.Replace("Php ", ""))
                        item2.SubItems.Add("Php " & Format((totalprice), "0,00.00"))
                        item2.SubItems.Add(col12)
                        lviitemstosell.Items.Add(item2)
                        item.Selected = False
                        nupitemqty.Value = 1
                        nupitemqty.Enabled = False
                    End If
                End If
            Next
        ElseIf isselecteditemequaltoone = False Then
            'MsgBox("isselecteditemequaltoone: " & isselecteditemequaltoone)
            For Each item As ListViewItem In lviitemstosell.Items
                If lviitemstosell.SelectedItems.Count > 0 Then
                    item = lviitemstosell.SelectedItems.Item(0)
                    If item.SubItems(10).Text > 1 Then
                        col0 = item.SubItems(0).Text
                        col1 = item.SubItems(1).Text
                        col2 = item.SubItems(2).Text
                        col3 = item.SubItems(3).Text
                        col4 = item.SubItems(4).Text
                        col5 = item.SubItems(5).Text
                        col6 = item.SubItems(6).Text
                        col7 = item.SubItems(7).Text
                        col8 = item.SubItems(8).Text
                        col9 = item.SubItems(9).Text
                        col10 = item.SubItems(10).Text
                        col11 = item.SubItems(11).Text
                        col12 = item.SubItems(12).Text

                        item.Remove()
                        Dim item2 As New ListViewItem(col0)
                        item2.SubItems.Add(col1)
                        item2.SubItems.Add(col2)
                        item2.SubItems.Add(col3)
                        item2.SubItems.Add(col4)
                        item2.SubItems.Add(col5)
                        item2.SubItems.Add(col6)
                        item2.SubItems.Add(col7)
                        item2.SubItems.Add(col8)
                        item2.SubItems.Add(col9)
                        item2.SubItems.Add(col10 - 1)
                        Dim totalprice As Decimal = col11.Replace("Php ", "") - col9.Replace("Php ", "")
                        item2.SubItems.Add("Php " & Format((totalprice), "0,00.00"))
                        item2.SubItems.Add(col12)
                        lviitemstosell.Items.Add(item2)
                    ElseIf item.SubItems(10).Text = 1 Then
                        item.Remove()
                    End If
                End If
            Next
        End If
        displaystocks()
        undisplay()
        txtsrp.Text = ""
        txtsrp.ReadOnly = True
        Dim itemstosellquantity As Integer
        Dim itemstosellgrandtotal As Decimal
        For Each selecteditem As ListViewItem In lviitemstosell.Items
            itemstosellgrandtotal += selecteditem.SubItems(11).Text.Replace("Php", "")
            itemstosellquantity += selecteditem.SubItems(10).Text
        Next
        If itemstosellquantity <> 0 Then
            txtitemstosellquantity.Text = itemstosellquantity
        Else
            txtitemstosellquantity.Text = ""
        End If
        If itemstosellgrandtotal > 999 Then
            txtitemstosellgrandtotal.Text = "Php " & Format((itemstosellgrandtotal), "0,00.00")
        ElseIf itemstosellgrandtotal > 0 And itemstosellgrandtotal < 1000 Then
            txtitemstosellgrandtotal.Text = "Php " & Format((itemstosellgrandtotal), "0.00")
        ElseIf itemstosellgrandtotal = 0 Then
            txtitemstosellgrandtotal.Text = ""
        End If

    End Sub

    Private Sub undisplay()

        Dim itemquantity As Integer
        Dim udcol9 As Integer
        Dim udcol10 As Decimal
        Dim totalprice As Decimal
        Dim udcol0 = "", udcol1 = "", udcol2 = "", udcol3 = "", udcol4 = "", udcol5 = "", udcol6 = "", udcol7 = "", udcol8 = "", udcol11 As String = ""
        Dim newqty As Integer
        Dim selecteditemcounter As Integer = lviitemstosell.Items.Count
        For Each selecteditem As ListViewItem In lviitemstosell.Items
            Dim indexofitemtoremove As Integer = -1
            Dim stoper As Boolean = False
            Dim executeremoval As Boolean = False
            If lviitemstosell.Items.Count > 0 Then
                If selecteditemcounter <> 0 Then
                    'MsgBox("Selected item is greater than zero")
                    For Each stocks As ListViewItem In lvistocks.Items
                        If selecteditem.SubItems(12).Text = stocks.SubItems(11).Text Then
                            indexofitemtoremove += 1
                            stoper = True

                            itemquantity = selecteditem.SubItems(10).Text
                            totalprice = selecteditem.SubItems(11).Text.Replace("Php ", "")
                            newqty = stocks.SubItems(9).Text - selecteditem.SubItems(10).Text
                            'MsgBox("New quantity is: " & newqty)
                            If newqty > 0 Then
                                udcol0 = stocks.SubItems(0).Text
                                udcol1 = stocks.SubItems(1).Text
                                udcol2 = stocks.SubItems(2).Text
                                udcol3 = stocks.SubItems(3).Text
                                udcol4 = stocks.SubItems(4).Text
                                udcol5 = stocks.SubItems(5).Text
                                udcol6 = stocks.SubItems(6).Text
                                udcol7 = stocks.SubItems(7).Text
                                udcol8 = stocks.SubItems(8).Text
                                udcol9 = stocks.SubItems(9).Text
                                udcol10 = stocks.SubItems(10).Text.Replace("Php ", "")
                                udcol11 = stocks.SubItems(11).Text
                            End If
                            executeremoval = True
                        Else
                            If stoper = False Then
                                indexofitemtoremove += 1
                            End If
                        End If
                    Next
                    If executeremoval = True Then
                        lvistocks.Items.Item(indexofitemtoremove).Remove()

                        If newqty > 0 Then
                            Dim item As New ListViewItem(udcol0)
                            item.SubItems.Add(udcol1)
                            item.SubItems.Add(udcol2)
                            item.SubItems.Add(udcol3)
                            item.SubItems.Add(udcol4)
                            item.SubItems.Add(udcol5)
                            item.SubItems.Add(udcol6)
                            item.SubItems.Add(udcol7)
                            item.SubItems.Add(udcol8)
                            item.SubItems.Add(udcol9 - itemquantity)
                            Dim newtotalprice As Decimal = udcol10 - totalprice
                            item.SubItems.Add("Php " & newtotalprice)
                            item.SubItems.Add(udcol11)
                            lvistocks.Items.Add(item)
                        End If
                    Else
                        'MsgBox("Execute removeal = " & executeremoval)
                    End If
                    selecteditemcounter = -1
                End If
            End If
        Next

        Dim stocksquantity As Integer
        Dim stocksgrandtotal As Decimal
        For Each item As ListViewItem In lvistocks.Items
            stocksgrandtotal += item.SubItems(10).Text.Replace("Php ", "")
            stocksquantity += item.SubItems(9).Text
        Next
        If stocksquantity <> 0 Then
            txtstocksquantity.Text = stocksquantity
        Else
            txtstocksquantity.Text = ""
        End If
        If stocksgrandtotal > 999 Then
            txtstocksgrandtotal.Text = "Php " & Format((stocksgrandtotal), "0,00.00")
        ElseIf stocksgrandtotal > 0 And stocksgrandtotal < 1000 Then
            txtstocksgrandtotal.Text = "Php " & Format((stocksgrandtotal), "0.00")
        ElseIf stocksgrandtotal = 0 Then
            txtstocksgrandtotal.Text = ""
        End If

    End Sub

    Private Sub cbosalesbrand_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbosalesbrand.SelectedIndexChanged

        filterbrandinsales()

    End Sub


    Private Sub cbosalescaapcity_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbosalescaapcity.SelectedIndexChanged

        filtercapacityinsales()

    End Sub

    Private Sub txtsrp_TextChanged(sender As Object, e As EventArgs) Handles txtsrp.TextChanged

    End Sub

    Private Sub txtcash_TextChanged(sender As Object, e As EventArgs) Handles txtcash.TextChanged

        If txtcash.Text <> "" Then
            Dim cash As Decimal
            Try
                cash = txtcash.Text
            Catch ex As Exception
                MessageBox.Show("Cash must be a number", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtcash.Text = ""
                txtchange.Text = ""
            End Try
        End If
        getchange()

    End Sub

    Private Sub getchange()

        If txtcash.Text <> "" And txtitemstosellgrandtotal.Text <> "" Then
            Dim change As Decimal = txtcash.Text - txtitemstosellgrandtotal.Text.Replace("Php", "")
            If change > 999 Then
                txtchange.Text = "Php " & Format((change), "0,00.00")
            ElseIf change < 1000 Then
                txtchange.Text = "Php " & Format((change), "0.00")
            End If
            If txtchange.Text.Contains("-") Then
                txtchange.Text = ""
            End If
        End If

    End Sub

End Class