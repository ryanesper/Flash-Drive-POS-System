Imports MySql.Data.MySqlClient

Module globalvariablesandfunctions

    Public con As New MySqlConnection
    Public cmd As New MySqlCommand
    Public reader As MySqlDataReader
    Public sqlda As New MySqlDataAdapter
    Public ds As New DataSet

    Public confirm, cmddelete As String
    Public username, password As String
    Public productmode As String

    Public Sub connecttodb()

        If con.State = ConnectionState.Closed Then
            con.ConnectionString = "Server = localhost; User ID = esper; Password = ryan; Database = computershop;"
            con.Open()
            cmd.Connection = con
        End If

    End Sub

    Public Sub displaystocks()

        frmmain.lvistocks.Items.Clear()
        connecttodb()
        Dim grandtotal As Decimal
        Dim qty As Integer = 0
        cmd = New MySqlCommand("select * from tbl_stocks", con)
        reader = cmd.ExecuteReader
        While (reader.Read())
            Dim lvi As New ListViewItem(reader("item").ToString())
            lvi.SubItems.Add(reader("brand").ToString())
            lvi.SubItems.Add(reader("size").ToString())
            lvi.SubItems.Add(reader("byte").ToString())
            lvi.SubItems.Add(reader("size").ToString() & " " & reader("byte").ToString())
            lvi.SubItems.Add(reader("color").ToString())
            lvi.SubItems.Add(reader("supplier").ToString())
            lvi.SubItems.Add(reader("arrival_date").ToString())
            Dim unitprice As Decimal = reader("unit_price").ToString()
            If unitprice > 999 Then
                lvi.SubItems.Add("Php " & Format((unitprice), "0,00.00"))
            ElseIf unitprice < 1000 Then
                lvi.SubItems.Add("Php " & Format((unitprice), "0.00"))
            End If
            lvi.SubItems.Add(reader("quantity").ToString())
            qty += reader("quantity").ToString()
            Dim totalprice As Decimal = reader("total_price").ToString()
            If totalprice > 999 Then
                lvi.SubItems.Add("Php " & Format((totalprice), "0,00.00"))
            ElseIf totalprice < 1000 Then
                lvi.SubItems.Add("Php " & Format((totalprice), "0.00"))
            End If
            grandtotal += totalprice
            lvi.SubItems.Add(reader("product_id").ToString())
            frmmain.lvistocks.Items.Add(lvi)
        End While
        reader.Close()
        con.Close()
        If qty = 0 Then
            frmmain.txtstocksquantity.Text = ""
        ElseIf qty > 0 Then
            frmmain.txtstocksquantity.Text = qty
        End If
        If grandtotal > 999 Then
            frmmain.txtstocksgrandtotal.Text = "Php " & Format((grandtotal), "0,00.00")
        ElseIf grandtotal > 0 And grandtotal < 1000 Then
            frmmain.txtstocksgrandtotal.Text = "Php " & Format((grandtotal), "0.00")
        ElseIf grandtotal = 0 Then
            frmmain.txtstocksgrandtotal.Text = ""
        End If

    End Sub

    Public Sub filterbrandinstocks()

        frmmain.lvistocks.Items.Clear()
        connecttodb()
        Dim grandtotal As Decimal
        Dim qty As Integer = 0
        If frmmain.cbocapacity.Text = "" Then
            cmd = New MySqlCommand("select * from tbl_stocks where brand = '" & frmmain.cbobrand.Text & "'", con)
        Else
            cmd = New MySqlCommand("select * from tbl_stocks where brand = '" & frmmain.cbobrand.Text & "' and capacity = '" & frmmain.cbocapacity.Text & "'", con)
        End If
        reader = cmd.ExecuteReader
        While (reader.Read())
            Dim lvi As New ListViewItem(reader("item").ToString())
            lvi.SubItems.Add(reader("brand").ToString())
            lvi.SubItems.Add(reader("size").ToString())
            lvi.SubItems.Add(reader("byte").ToString())
            lvi.SubItems.Add(reader("size").ToString() & " " & reader("byte").ToString())
            lvi.SubItems.Add(reader("color").ToString())
            lvi.SubItems.Add(reader("supplier").ToString())
            lvi.SubItems.Add(reader("arrival_date").ToString())
            Dim unitprice As Decimal = reader("unit_price").ToString()
            If unitprice > 999 Then
                lvi.SubItems.Add("Php " & Format((unitprice), "0,00.00"))
            ElseIf unitprice < 1000 Then
                lvi.SubItems.Add("Php " & Format((unitprice), "0.00"))
            End If
            lvi.SubItems.Add(reader("quantity").ToString())
            qty += reader("quantity").ToString()
            Dim totalprice As Decimal = reader("total_price").ToString()
            If totalprice > 999 Then
                lvi.SubItems.Add("Php " & Format((totalprice), "0,00.00"))
            ElseIf totalprice < 1000 Then
                lvi.SubItems.Add("Php " & Format((totalprice), "0.00"))
            End If
            grandtotal += totalprice
            lvi.SubItems.Add(reader("product_id").ToString())
            frmmain.lvistocks.Items.Add(lvi)
        End While
        reader.Close()
        con.Close()
        If qty = 0 Then
            frmmain.txtstocksquantity.Text = ""
        ElseIf qty > 0 Then
            frmmain.txtstocksquantity.Text = qty
        End If
        If grandtotal <> 0 Then
            If grandtotal > 999 Then
                frmmain.txtstocksgrandtotal.Text = "Php " & Format((grandtotal), "0,00.00")
            ElseIf grandtotal < 1000 Then
                frmmain.txtstocksgrandtotal.Text = "Php " & Format((grandtotal), "0.00")
            End If
        Else
            frmmain.txtstocksgrandtotal.Text = ""
        End If

    End Sub

    Public Sub filtercapacityinstocks()

        frmmain.lvistocks.Items.Clear()
        connecttodb()
        Dim grandtotal As Decimal
        Dim qty As Integer = 0
        If frmmain.cbobrand.Text = "" Then
            cmd = New MySqlCommand("select * from tbl_stocks where capacity = '" & frmmain.cbocapacity.Text & "'", con)
        Else
            cmd = New MySqlCommand("select * from tbl_stocks where capacity = '" & frmmain.cbocapacity.Text & "' and brand = '" & frmmain.cbobrand.Text & "'", con)
        End If
        reader = cmd.ExecuteReader
        While (reader.Read())
            Dim lvi As New ListViewItem(reader("item").ToString())
            lvi.SubItems.Add(reader("brand").ToString())
            lvi.SubItems.Add(reader("size").ToString())
            lvi.SubItems.Add(reader("byte").ToString())
            lvi.SubItems.Add(reader("size").ToString() & " " & reader("byte").ToString())
            lvi.SubItems.Add(reader("color").ToString())
            lvi.SubItems.Add(reader("supplier").ToString())
            lvi.SubItems.Add(reader("arrival_date").ToString())
            Dim unitprice As Decimal = reader("unit_price").ToString()
            If unitprice > 999 Then
                lvi.SubItems.Add("Php " & Format((unitprice), "0,00.00"))
            ElseIf unitprice < 1000 Then
                lvi.SubItems.Add("Php " & Format((unitprice), "0.00"))
            End If
            lvi.SubItems.Add(reader("quantity").ToString())
            qty += reader("quantity").ToString()
            Dim totalprice As Decimal = reader("total_price").ToString()
            If totalprice > 999 Then
                lvi.SubItems.Add("Php " & Format((totalprice), "0,00.00"))
            ElseIf totalprice < 1000 Then
                lvi.SubItems.Add("Php " & Format((totalprice), "0.00"))
            End If
            grandtotal += totalprice
            lvi.SubItems.Add(reader("product_id").ToString())
            frmmain.lvistocks.Items.Add(lvi)
        End While
        reader.Close()
        con.Close()
        If qty = 0 Then
            frmmain.txtstocksquantity.Text = ""
        ElseIf qty > 0 Then
            frmmain.txtstocksquantity.Text = qty
        End If
        If grandtotal <> 0 Then
            If grandtotal > 999 Then
                frmmain.txtstocksgrandtotal.Text = "Php " & Format((grandtotal), "0,00.00")
            ElseIf grandtotal < 1000 Then
                frmmain.txtstocksgrandtotal.Text = "Php " & Format((grandtotal), "0.00")
            End If
        Else
            frmmain.txtstocksgrandtotal.Text = ""
        End If

    End Sub

    Public Sub displaysales()

        frmmain.lvisales.Items.Clear()
        connecttodb()
        cmd = New MySqlCommand("select tbl_transactions.transaction_no, tbl_transactions.transaction_date, tbl_transactions.client, tbl_transactions.address, tbl_transactions.contact_number, tbl_transactions.cash, tbl_transactions.change, tbl_sales.item, tbl_sales.brand, tbl_sales.color, tbl_sales.capacity, tbl_sales.selling_price, tbl_sales.quantity, tbl_sales.total_price from tbl_sales inner join tbl_transactions on tbl_sales.transaction_no = tbl_transactions.transaction_no", con)
        reader = cmd.ExecuteReader
        While (reader.Read())
            Dim item As New ListViewItem(reader("transaction_no").ToString())
            item.SubItems.Add(reader("transaction_date").ToString())
            item.SubItems.Add(reader("client").ToString())
            item.SubItems.Add(reader("address").ToString())
            item.SubItems.Add(reader("contact_number").ToString())
            item.SubItems.Add(reader("item").ToString())
            item.SubItems.Add(reader("brand").ToString())
            item.SubItems.Add(reader("color").ToString())
            item.SubItems.Add(reader("capacity").ToString())
            Dim sellingprice As Decimal = reader("selling_price").ToString()
            If sellingprice > 999 Then
                item.SubItems.Add("Php " & Format((sellingprice), "0,00.00"))
            ElseIf sellingprice < 1000 Then
                item.SubItems.Add("Php " & Format((sellingprice), "0.00"))
            End If
            item.SubItems.Add(reader("quantity").ToString())
            Dim cash As Decimal = reader("cash").ToString()
            If cash > 999 Then
                item.SubItems.Add("Php " & Format((cash), "0,00.00"))
            ElseIf cash < 1000 Then
                item.SubItems.Add("Php " & Format((cash), "0.00"))
            End If
            Dim change As Decimal = reader("change").ToString()
            If change > 999 Then
                item.SubItems.Add("Php " & Format((change), "0,00.00"))
            ElseIf change < 1000 Then
                item.SubItems.Add("Php " & Format((change), "0.00"))
            End If
            Dim totalprice As Decimal = reader("total_price").ToString()
            If totalprice > 999 Then
                item.SubItems.Add("Php " & Format((totalprice), "0,00.00"))
            ElseIf totalprice < 1000 Then
                item.SubItems.Add("Php " & Format((totalprice), "0.00"))
            End If
            frmmain.lvisales.Items.Add(item)
        End While
        reader.Close()
        con.Close()

        Dim salestotalquantity As Long
        Dim salestotalsales As Decimal
        For Each item As ListViewItem In frmmain.lvisales.Items
            salestotalquantity += item.SubItems(10).Text
            salestotalsales += item.SubItems(13).Text.Replace("Php", "")
        Next
        frmmain.txtsalestotalquantity.Text = salestotalquantity
        If salestotalsales > 999 Then
            frmmain.txtsalestotalsales.Text = "Php " & Format((salestotalsales), "0,00.00")
        ElseIf salestotalsales > 0 And salestotalsales < 1000 Then
            frmmain.txtsalestotalsales.Text = "Php " & Format((salestotalsales), "0.00")
        ElseIf salestotalsales = 0 Then
            frmmain.txtsalestotalsales.Text = ""
        End If

    End Sub

    Public Sub filterbrandinsales()

        frmmain.lvisales.Items.Clear()
        connecttodb()
        If frmmain.cbosalescaapcity.Text = "" Then
            cmd = New MySqlCommand("select tbl_transactions.transaction_no, tbl_transactions.transaction_date, tbl_transactions.client, tbl_transactions.address, tbl_transactions.contact_number, tbl_transactions.cash, tbl_transactions.change, tbl_sales.item, tbl_sales.brand, tbl_sales.color, tbl_sales.capacity, tbl_sales.selling_price, tbl_sales.quantity, tbl_sales.total_price from tbl_sales inner join tbl_transactions on tbl_sales.transaction_no = tbl_transactions.transaction_no where brand = '" & frmmain.cbosalesbrand.Text & "'", con)
        Else
            cmd = New MySqlCommand("select tbl_transactions.transaction_no, tbl_transactions.transaction_date, tbl_transactions.client, tbl_transactions.address, tbl_transactions.contact_number, tbl_transactions.cash, tbl_transactions.change, tbl_sales.item, tbl_sales.brand, tbl_sales.color, tbl_sales.capacity, tbl_sales.selling_price, tbl_sales.quantity, tbl_sales.total_price from tbl_sales inner join tbl_transactions on tbl_sales.transaction_no = tbl_transactions.transaction_no where brand = '" & frmmain.cbosalesbrand.Text & "' and capacity = '" & frmmain.cbosalescaapcity.Text & "'", con)
        End If
        reader = cmd.ExecuteReader
        While (reader.Read())
            Dim item As New ListViewItem(reader("transaction_no").ToString())
            item.SubItems.Add(reader("transaction_date").ToString())
            item.SubItems.Add(reader("client").ToString())
            item.SubItems.Add(reader("address").ToString())
            item.SubItems.Add(reader("contact_number").ToString())
            item.SubItems.Add(reader("item").ToString())
            item.SubItems.Add(reader("brand").ToString())
            item.SubItems.Add(reader("color").ToString())
            item.SubItems.Add(reader("capacity").ToString())
            Dim sellingprice As Decimal = reader("selling_price").ToString()
            If sellingprice > 999 Then
                item.SubItems.Add("Php " & Format((sellingprice), "0,00.00"))
            ElseIf sellingprice < 1000 Then
                item.SubItems.Add("Php " & Format((sellingprice), "0.00"))
            End If
            item.SubItems.Add(reader("quantity").ToString())
            Dim cash As Decimal = reader("cash").ToString()
            If cash > 999 Then
                item.SubItems.Add("Php " & Format((cash), "0,00.00"))
            ElseIf cash < 1000 Then
                item.SubItems.Add("Php " & Format((cash), "0.00"))
            End If
            Dim change As Decimal = reader("change").ToString()
            If change > 999 Then
                item.SubItems.Add("Php " & Format((change), "0,00.00"))
            ElseIf change < 1000 Then
                item.SubItems.Add("Php " & Format((change), "0.00"))
            End If
            Dim totalprice As Decimal = reader("total_price").ToString()
            If totalprice > 999 Then
                item.SubItems.Add("Php " & Format((totalprice), "0,00.00"))
            ElseIf totalprice < 1000 Then
                item.SubItems.Add("Php " & Format((totalprice), "0,00.00"))
            End If
            frmmain.lvisales.Items.Add(item)
        End While
        reader.Close()
        con.Close()

        Dim salestotalquantity As Long
        Dim salestotalsales As Decimal
        For Each item As ListViewItem In frmmain.lvisales.Items
            salestotalquantity += item.SubItems(10).Text
            salestotalsales += item.SubItems(13).Text.Replace("Php", "")
        Next
        frmmain.txtsalestotalquantity.Text = salestotalquantity
        If salestotalsales > 999 Then
            frmmain.txtsalestotalsales.Text = "Php " & Format((salestotalsales), "0,00.00")
        ElseIf salestotalsales > 0 And salestotalsales < 1000 Then
            frmmain.txtsalestotalsales.Text = "Php " & Format((salestotalsales), "0.00")
        ElseIf salestotalsales = 0 Then
            frmmain.txtsalestotalsales.Text = ""
        End If

    End Sub

    Public Sub filtercapacityinsales()

        frmmain.lvisales.Items.Clear()
        connecttodb()
        If frmmain.cbosalesbrand.Text = "" Then
            cmd = New MySqlCommand("select tbl_transactions.transaction_no, tbl_transactions.transaction_date, tbl_transactions.client, tbl_transactions.address, tbl_transactions.contact_number, tbl_transactions.cash, tbl_transactions.change, tbl_sales.item, tbl_sales.brand, tbl_sales.color, tbl_sales.capacity, tbl_sales.selling_price, tbl_sales.quantity, tbl_sales.total_price from tbl_sales inner join tbl_transactions on tbl_sales.transaction_no = tbl_transactions.transaction_no where capacity = '" & frmmain.cbosalescaapcity.Text & "'", con)
        Else
            cmd = New MySqlCommand("select tbl_transactions.transaction_no, tbl_transactions.transaction_date, tbl_transactions.client, tbl_transactions.address, tbl_transactions.contact_number, tbl_transactions.cash, tbl_transactions.change, tbl_sales.item, tbl_sales.brand, tbl_sales.color, tbl_sales.capacity, tbl_sales.selling_price, tbl_sales.quantity, tbl_sales.total_price from tbl_sales inner join tbl_transactions on tbl_sales.transaction_no = tbl_transactions.transaction_no where capacity = '" & frmmain.cbosalescaapcity.Text & "' and brand = '" & frmmain.cbosalesbrand.Text & "'", con)
        End If
        reader = cmd.ExecuteReader
        While (reader.Read())
            Dim item As New ListViewItem(reader("transaction_no").ToString())
            item.SubItems.Add(reader("transaction_date").ToString())
            item.SubItems.Add(reader("client").ToString())
            item.SubItems.Add(reader("address").ToString())
            item.SubItems.Add(reader("contact_number").ToString())
            item.SubItems.Add(reader("item").ToString())
            item.SubItems.Add(reader("brand").ToString())
            item.SubItems.Add(reader("color").ToString())
            item.SubItems.Add(reader("capacity").ToString())
            Dim sellingprice As Decimal = reader("selling_price").ToString()
            If sellingprice > 999 Then
                item.SubItems.Add("Php " & Format((sellingprice), "0,00.00"))
            ElseIf sellingprice < 1000 Then
                item.SubItems.Add("Php " & Format((sellingprice), "0.00"))
            End If
            item.SubItems.Add(reader("quantity").ToString())
            Dim cash As Decimal = reader("cash").ToString()
            If cash > 999 Then
                item.SubItems.Add("Php " & Format((cash), "0,00.00"))
            ElseIf cash < 1000 Then
                item.SubItems.Add("Php " & Format((cash), "0.00"))
            End If
            Dim change As Decimal = reader("change").ToString()
            If change > 999 Then
                item.SubItems.Add("Php " & Format((change), "0,00.00"))
            ElseIf change < 1000 Then
                item.SubItems.Add("Php " & Format((change), "0.00"))
            End If
            Dim totalprice As Decimal = reader("total_price").ToString()
            If totalprice > 999 Then
                item.SubItems.Add("Php " & Format((totalprice), "0,00.00"))
            ElseIf totalprice < 1000 Then
                item.SubItems.Add("Php " & Format((totalprice), "0,00.00"))
            End If
            frmmain.lvisales.Items.Add(item)
        End While
        reader.Close()
        con.Close()

        Dim salestotalquantity As Long
        Dim salestotalsales As Decimal
        For Each item As ListViewItem In frmmain.lvisales.Items
            salestotalquantity += item.SubItems(10).Text
            salestotalsales += item.SubItems(13).Text.Replace("Php", "")
        Next
        frmmain.txtsalestotalquantity.Text = salestotalquantity
        If salestotalsales > 999 Then
            frmmain.txtsalestotalsales.Text = "Php " & Format((salestotalsales), "0,00.00")
        ElseIf salestotalsales > 0 And salestotalsales < 1000 Then
            frmmain.txtsalestotalsales.Text = "Php " & Format((salestotalsales), "0.00")
        ElseIf salestotalsales = 0 Then
            frmmain.txtsalestotalsales.Text = ""
        End If

    End Sub

End Module
