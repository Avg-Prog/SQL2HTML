<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtServer = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbDatabase = New System.Windows.Forms.ComboBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.lblErrors = New System.Windows.Forms.Label()
        Me.lbErrors = New System.Windows.Forms.ListBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtIgnorePrefix = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtUserName = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtPaswword = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Server:"
        '
        'txtServer
        '
        Me.txtServer.Location = New System.Drawing.Point(89, 58)
        Me.txtServer.Name = "txtServer"
        Me.txtServer.Size = New System.Drawing.Size(205, 20)
        Me.txtServer.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 87)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Database:"
        '
        'cbDatabase
        '
        Me.cbDatabase.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cbDatabase.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbDatabase.FormattingEnabled = True
        Me.cbDatabase.Location = New System.Drawing.Point(89, 84)
        Me.cbDatabase.Name = "cbDatabase"
        Me.cbDatabase.Size = New System.Drawing.Size(205, 21)
        Me.cbDatabase.TabIndex = 3
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(10, 176)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(103, 23)
        Me.btnSave.TabIndex = 6
        Me.btnSave.Text = "Create HTML..."
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'lblErrors
        '
        Me.lblErrors.AutoSize = True
        Me.lblErrors.Location = New System.Drawing.Point(12, 202)
        Me.lblErrors.Name = "lblErrors"
        Me.lblErrors.Size = New System.Drawing.Size(37, 13)
        Me.lblErrors.TabIndex = 6
        Me.lblErrors.Text = "Errors:"
        '
        'lbErrors
        '
        Me.lbErrors.FormattingEnabled = True
        Me.lbErrors.Location = New System.Drawing.Point(10, 227)
        Me.lbErrors.Name = "lbErrors"
        Me.lbErrors.Size = New System.Drawing.Size(503, 199)
        Me.lbErrors.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 145)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Ignore prefix:"
        '
        'txtIgnorePrefix
        '
        Me.txtIgnorePrefix.Location = New System.Drawing.Point(87, 142)
        Me.txtIgnorePrefix.Name = "txtIgnorePrefix"
        Me.txtIgnorePrefix.Size = New System.Drawing.Size(205, 20)
        Me.txtIgnorePrefix.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "UserName:"
        '
        'txtUserName
        '
        Me.txtUserName.Location = New System.Drawing.Point(89, 6)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(205, 20)
        Me.txtUserName.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Password:"
        '
        'txtPaswword
        '
        Me.txtPaswword.Location = New System.Drawing.Point(89, 32)
        Me.txtPaswword.Name = "txtPaswword"
        Me.txtPaswword.Size = New System.Drawing.Size(205, 20)
        Me.txtPaswword.TabIndex = 1
        Me.txtPaswword.UseSystemPasswordChar = True
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(527, 440)
        Me.Controls.Add(Me.txtPaswword)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtUserName)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtIgnorePrefix)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lbErrors)
        Me.Controls.Add(Me.lblErrors)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.cbDatabase)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtServer)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Main"
        Me.Text = "SQL2HTML"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtServer As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbDatabase As System.Windows.Forms.ComboBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents lblErrors As System.Windows.Forms.Label
    Friend WithEvents lvFouten As System.Windows.Forms.ListView
    Friend WithEvents lbErrors As System.Windows.Forms.ListBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtIgnorePrefix As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtUserName As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtPaswword As System.Windows.Forms.TextBox

End Class
