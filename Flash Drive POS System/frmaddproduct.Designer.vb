<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmaddproduct
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtsize = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtprice = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtquantity = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txttotalprice = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btndelete = New System.Windows.Forms.Button()
        Me.btnedit = New System.Windows.Forms.Button()
        Me.btnadd = New System.Windows.Forms.Button()
        Me.cboitem = New System.Windows.Forms.ComboBox()
        Me.dtparrival = New System.Windows.Forms.DateTimePicker()
        Me.txtprodid = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cbobrand = New System.Windows.Forms.ComboBox()
        Me.cbobyte = New System.Windows.Forms.ComboBox()
        Me.cbosupplier = New System.Windows.Forms.ComboBox()
        Me.cbocolor = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Teal
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(-1, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(422, 54)
        Me.Label8.TabIndex = 168
        Me.Label8.Text = "Add Product"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(12, 124)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(45, 24)
        Me.Label25.TabIndex = 170
        Me.Label25.Text = "Item"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 161)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 24)
        Me.Label1.TabIndex = 172
        Me.Label1.Text = "Brand"
        '
        'txtsize
        '
        Me.txtsize.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsize.Location = New System.Drawing.Point(135, 191)
        Me.txtsize.Name = "txtsize"
        Me.txtsize.Size = New System.Drawing.Size(191, 31)
        Me.txtsize.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 198)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 24)
        Me.Label2.TabIndex = 174
        Me.Label2.Text = "Capacity"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 235)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 24)
        Me.Label3.TabIndex = 176
        Me.Label3.Text = "Color"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 272)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 24)
        Me.Label4.TabIndex = 178
        Me.Label4.Text = "Supplier"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 309)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(105, 24)
        Me.Label5.TabIndex = 180
        Me.Label5.Text = "Arrival Date"
        '
        'txtprice
        '
        Me.txtprice.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtprice.Location = New System.Drawing.Point(135, 339)
        Me.txtprice.Name = "txtprice"
        Me.txtprice.Size = New System.Drawing.Size(273, 31)
        Me.txtprice.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 346)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 24)
        Me.Label6.TabIndex = 182
        Me.Label6.Text = "Price"
        '
        'txtquantity
        '
        Me.txtquantity.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtquantity.Location = New System.Drawing.Point(135, 376)
        Me.txtquantity.Name = "txtquantity"
        Me.txtquantity.Size = New System.Drawing.Size(273, 31)
        Me.txtquantity.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(12, 383)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(78, 24)
        Me.Label7.TabIndex = 184
        Me.Label7.Text = "Quantity"
        '
        'txttotalprice
        '
        Me.txttotalprice.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttotalprice.ForeColor = System.Drawing.Color.Red
        Me.txttotalprice.Location = New System.Drawing.Point(133, 420)
        Me.txttotalprice.Name = "txttotalprice"
        Me.txttotalprice.ReadOnly = True
        Me.txttotalprice.Size = New System.Drawing.Size(273, 31)
        Me.txttotalprice.TabIndex = 10
        Me.txttotalprice.Text = "Php"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(11, 426)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(115, 25)
        Me.Label9.TabIndex = 186
        Me.Label9.Text = "Total Price"
        '
        'btndelete
        '
        Me.btndelete.Location = New System.Drawing.Point(335, 474)
        Me.btndelete.Name = "btndelete"
        Me.btndelete.Size = New System.Drawing.Size(73, 30)
        Me.btndelete.TabIndex = 13
        Me.btndelete.Text = "Delete"
        Me.btndelete.UseVisualStyleBackColor = True
        '
        'btnedit
        '
        Me.btnedit.Location = New System.Drawing.Point(256, 474)
        Me.btnedit.Name = "btnedit"
        Me.btnedit.Size = New System.Drawing.Size(73, 30)
        Me.btnedit.TabIndex = 12
        Me.btnedit.Text = "Edit"
        Me.btnedit.UseVisualStyleBackColor = True
        '
        'btnadd
        '
        Me.btnadd.Location = New System.Drawing.Point(177, 474)
        Me.btnadd.Name = "btnadd"
        Me.btnadd.Size = New System.Drawing.Size(73, 30)
        Me.btnadd.TabIndex = 11
        Me.btnadd.Text = "Add"
        Me.btnadd.UseVisualStyleBackColor = True
        '
        'cboitem
        '
        Me.cboitem.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboitem.FormattingEnabled = True
        Me.cboitem.Items.AddRange(New Object() {"Flash Drive"})
        Me.cboitem.Location = New System.Drawing.Point(135, 116)
        Me.cboitem.Name = "cboitem"
        Me.cboitem.Size = New System.Drawing.Size(273, 31)
        Me.cboitem.TabIndex = 1
        Me.cboitem.Text = "Flash Drive"
        '
        'dtparrival
        '
        Me.dtparrival.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtparrival.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtparrival.Location = New System.Drawing.Point(135, 304)
        Me.dtparrival.Name = "dtparrival"
        Me.dtparrival.Size = New System.Drawing.Size(273, 31)
        Me.dtparrival.TabIndex = 7
        '
        'txtprodid
        '
        Me.txtprodid.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtprodid.Location = New System.Drawing.Point(135, 79)
        Me.txtprodid.Name = "txtprodid"
        Me.txtprodid.ReadOnly = True
        Me.txtprodid.Size = New System.Drawing.Size(273, 31)
        Me.txtprodid.TabIndex = 0
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(12, 86)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(97, 24)
        Me.Label10.TabIndex = 188
        Me.Label10.Text = "Product ID"
        '
        'cbobrand
        '
        Me.cbobrand.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbobrand.FormattingEnabled = True
        Me.cbobrand.Location = New System.Drawing.Point(135, 153)
        Me.cbobrand.Name = "cbobrand"
        Me.cbobrand.Size = New System.Drawing.Size(273, 31)
        Me.cbobrand.TabIndex = 2
        '
        'cbobyte
        '
        Me.cbobyte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbobyte.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbobyte.FormattingEnabled = True
        Me.cbobyte.Items.AddRange(New Object() {"MB", "GB", "TB"})
        Me.cbobyte.Location = New System.Drawing.Point(327, 191)
        Me.cbobyte.Name = "cbobyte"
        Me.cbobyte.Size = New System.Drawing.Size(81, 31)
        Me.cbobyte.TabIndex = 4
        '
        'cbosupplier
        '
        Me.cbosupplier.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbosupplier.FormattingEnabled = True
        Me.cbosupplier.Location = New System.Drawing.Point(135, 264)
        Me.cbosupplier.Name = "cbosupplier"
        Me.cbosupplier.Size = New System.Drawing.Size(273, 31)
        Me.cbosupplier.TabIndex = 6
        '
        'cbocolor
        '
        Me.cbocolor.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbocolor.FormattingEnabled = True
        Me.cbocolor.Location = New System.Drawing.Point(135, 228)
        Me.cbocolor.Name = "cbocolor"
        Me.cbocolor.Size = New System.Drawing.Size(273, 31)
        Me.cbocolor.TabIndex = 5
        '
        'frmaddproduct
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(420, 516)
        Me.Controls.Add(Me.cbocolor)
        Me.Controls.Add(Me.cbosupplier)
        Me.Controls.Add(Me.cbobyte)
        Me.Controls.Add(Me.cbobrand)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtprodid)
        Me.Controls.Add(Me.dtparrival)
        Me.Controls.Add(Me.cboitem)
        Me.Controls.Add(Me.btnadd)
        Me.Controls.Add(Me.btnedit)
        Me.Controls.Add(Me.btndelete)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txttotalprice)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtquantity)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtprice)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtsize)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label8)
        Me.MaximumSize = New System.Drawing.Size(436, 554)
        Me.MinimumSize = New System.Drawing.Size(436, 554)
        Me.Name = "frmaddproduct"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "x"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtsize As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtprice As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtquantity As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txttotalprice As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btndelete As System.Windows.Forms.Button
    Friend WithEvents btnedit As System.Windows.Forms.Button
    Friend WithEvents btnadd As System.Windows.Forms.Button
    Friend WithEvents cboitem As System.Windows.Forms.ComboBox
    Friend WithEvents dtparrival As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtprodid As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cbobrand As System.Windows.Forms.ComboBox
    Friend WithEvents cbobyte As System.Windows.Forms.ComboBox
    Friend WithEvents cbosupplier As System.Windows.Forms.ComboBox
    Friend WithEvents cbocolor As System.Windows.Forms.ComboBox
End Class
