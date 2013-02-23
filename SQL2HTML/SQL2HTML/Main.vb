Imports System.Data.SqlClient
Imports System.IO

Public Enum ReaderCols
    TABLE_NAME = 0
    TABLE_DESCRIPTION
    FIELD_NAME
    FIELD_DESCRIPTION
    FIELD_ISNULL
    FIELD_DATA
    VELD_LEN
    VELD_PREC
    VELD_ISPK
    VELD_ISFK
    FIELD_FKTABLE
    FIELD_FKFIELD
End Enum

Public Class Main

    ''' <summary>
    ''' You can put the name of the server you use the most here
    ''' IgnorePrefix is used to excluse certain prefixes from the convertion
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' TODO: extract it to a config file.
    ''' </remarks>
    Private Sub Main_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Console.WriteLine()
        '  Invoke this sample with an arbitrary set of command line arguments. 
        Dim arguments As String() = Environment.GetCommandLineArgs()

        If (arguments.Count > 4) Then
            Dim server = arguments(1).ToString()
            Dim database = arguments(2).ToString()
            Dim user = arguments(3).ToString()
            Dim pass = arguments(4).ToString()
            SaveSQL(server, database, user, pass, "x")

            Me.Close()
        End If

        txtUserName.Text = "sa"
        txtPaswword.Text = "LightSQL3"
        txtServer.Text = "WIVAN-SYSTEM\LightSQL"
        txtIgnorePrefix.Text = "X."
    End Sub

    ' SQL 2008: Get's all databases on Server
    Private Sub txtServer_LostFocus(sender As Object, e As System.EventArgs) Handles txtServer.LostFocus

        Using connection As New SqlConnection(String.Format("Data Source={0};Initial Catalog=master;User Id={1};Password={2};",
                                                            txtServer.Text,
                                                            txtUserName.Text,
                                                            txtPaswword.Text))
            Dim cmb As New SqlCommand("SELECT name FROM master..sysdatabases", connection)
            connection.Open()
            Dim reader As SqlDataReader = cmb.ExecuteReader
            Try
                While (reader.Read)
                    cbDatabase.Items.Add(reader(0))
                End While
            Catch ex As Exception
            Finally
                reader.Close()
            End Try
        End Using

        If (cbDatabase.Items.Count > 0) Then
            cbDatabase.SelectedIndex = 0
        End If

    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        SaveSQL(txtServer.Text, CStr(cbDatabase.SelectedItem), txtUserName.Text, txtPaswword.Text, txtIgnorePrefix.Text)
    End Sub

    Private Sub SaveSQL(ByVal server As String, ByVal database As String,
                        ByVal userName As String, ByVal password As String,
                        ByVal ignorePrefix As String)

        Dim text = CreateHTMLFile(server, database, userName, password, ignorePrefix)
        If (text <> "") Then

            Dim saveFileDialog As New SaveFileDialog()
            'set for html
            saveFileDialog.Filter = "html files (*.html)|*.html|All files (*.*)|*.*"
            saveFileDialog.FilterIndex = 1
            saveFileDialog.RestoreDirectory = True

            If (saveFileDialog.ShowDialog() = DialogResult.OK) Then
                Dim objWriter As StreamWriter
                Dim fileInfo As New FileInfo(saveFileDialog.FileName)
                Try
                    'write html
                    objWriter = New StreamWriter(saveFileDialog.FileName)
                    objWriter.Write(text)
                    objWriter.Close()

                    'write styles.css
                    objWriter = New StreamWriter(fileInfo.Directory.ToString() & "\styles.css")
                    objWriter.Write(My.Resources.styles)
                    objWriter.Close()

                    'write logo
                    Dim bm As Bitmap = My.Resources.logo
                    bm.Save(fileInfo.Directory.ToString() & "\logo.gif", System.Drawing.Imaging.ImageFormat.Gif)
                Catch ex As Exception
                    Debug.Print(ex.Message)
                End Try
            End If
        End If
    End Sub

    ' SQL Sever 2008 query to get the information
    Private Function GetSql() As String
        Dim sql As String = "SELECT t.name AS [Table], " &
            "td.value AS [Table Description], " &
            "c.name AS [Field], " &
            "cd.value AS [Field Description], " &
            "c.isnullable AS [Allow NULL], " &
            "d.name As [Data Name], " &
            "c.length, c.xprec, " &
            "'Key' = Case " &
            "WHEN IsNull(PrimaryKey.COLUMN_NAME, '') <> '' then 1 " &
            "else 0	end, " &
            "'ForgeinKey' = Case " &
            "WHEN IsNull(ForeignKey.ColumnName, '') <> '' then 1 " &
            "else 0 end, " &
            "ForeignKey.ReferenceTableName as 'ForeignTable', " &
            "ForeignKey.ReferenceColumnName as 'ForeignField' "

        'To get the description for the table/fields you'll have to set the MS_Description in SQL Server 2008
        sql = sql & "FROM sysobjects t " &
            "LEFT OUTER JOIN sys.extended_properties td ON td.major_id = t.id " &
            "AND td.minor_id = 0 " &
            "AND td.name = 'MS_Description' " &
            "INNER JOIN syscolumns c ON c.id = t.id " &
            "LEFT OUTER JOIN sys.extended_properties cd ON cd.major_id = c.id " &
            "AND cd.minor_id = c.colid " &
            "AND cd.name = 'MS_Description'" &
            "LEFT JOIN systypes d ON c.xtype = d.xtype "

        sql = sql & "LEFT JOIN (select c.COLUMN_NAME, c.TABLE_NAME " &
            "from INFORMATION_SCHEMA.TABLE_CONSTRAINTS pk , INFORMATION_SCHEMA.KEY_COLUMN_USAGE c " &
            "where CONSTRAINT_TYPE = 'PRIMARY KEY' " &
            "and c.TABLE_NAME = pk.TABLE_NAME " &
            "and c.CONSTRAINT_NAME = pk.CONSTRAINT_NAME) as PrimaryKey ON PrimaryKey.TABLE_NAME = t.name AND PrimaryKey.COLUMN_NAME = c.name "


        sql = sql & "LEFT JOIN (SELECT OBJECT_NAME(f.parent_object_id) AS TableName, " &
            "COL_NAME(fc.parent_object_id,fc.parent_column_id) AS ColumnName, " &
            "OBJECT_NAME (f.referenced_object_id) AS ReferenceTableName, " &
            "COL_NAME(fc.referenced_object_id,fc.referenced_column_id) AS ReferenceColumnName " &
            "FROM sys.foreign_keys AS f " &
            "INNER JOIN sys.foreign_key_columns AS fc " &
            "ON f.OBJECT_ID = fc.constraint_object_id) as ForeignKey ON ForeignKey.TableName = t.name AND ForeignKey.ColumnName = c.name "

        sql = sql & "WHERE t.type = 'U' " &
            "ORDER BY t.name, c.colorder"

        Return sql
    End Function

    ' generate HTML for selected Server and Database
    ' logs Error if descriptions are missing
    Private Function CreateHTMLFile(server As String,
                                    database As String,
                                    userName As String,
                                    password As String,
                                    ignorePrefix As String) As String

        If (server = "" Or database = "") Then
            MessageBox.Show("Please fill in UserName and Password first.")
            Return ""
        Else
            Dim container As New TableContainer

            Using connection As New SqlConnection(String.Format("Data Source={0};Initial Catalog={1};User Id={2};Password={3};",
                                                                server,
                                                                database,
                                                                userName,
                                                                password))

                Dim sql As String = GetSql()
                Try
                    connection.Open()
                    Dim cmb As New SqlCommand(sql, connection)

                    Dim reader As SqlDataReader = cmb.ExecuteReader
                    Try
                        While (reader.Read)
                            ProcessTable(container, reader, ignorePrefix)
                        End While

                        lblErrors.Text = String.Format("Completed - Errors: ({0})", lbErrors.Items.Count)

                    Catch ex As Exception
                        MessageBox.Show("Error whilst reading Database:" & vbNewLine & ex.Message)
                    Finally
                        reader.Close()
                    End Try
                Catch ex As Exception
                    MessageBox.Show("Connection Error:" & vbNewLine & ex.Message)
                End Try
            End Using

            Return container.ToHTML
        End If
    End Function

    ' Create HTML for table
    ' Ignores 'sysdiagrams' en every table starting with the value entered in lblIngorePrefix
    Private Sub ProcessTable(ByVal container As TableContainer,
                             ByVal reader As SqlDataReader, ByVal ignorePrefix As String)

        Dim tableName = reader(ReaderCols.TABLE_NAME)
        If (CStr(tableName) = "sysdiagrams") Then Exit Sub
        If (CStr(tableName).StartsWith(ignorePrefix)) Then Exit Sub
        Dim table = (From t As Table In container.Tables
                     Where t.Name.Equals(tableName)
                     Select t).FirstOrDefault

        If (table Is Nothing) Then
            table = New Table(CStr(tableName), ObjectToString(reader(ReaderCols.TABLE_DESCRIPTION)))

            If (table.Description = "") Then
                lbErrors.Items.Add(String.Format("Error: Table {0} has no description",
                                                 table.Name))
            End If

            container.Tables.Add(table)
        End If

        ProcessFields(reader, table)

    End Sub

    ' HTML voor veld aanmaken
    Private Sub ProcessFields(ByVal reader As SqlDataReader,
                              ByVal table As Table)

        Dim field As New Field With {
            .Name = CStr(reader(ReaderCols.FIELD_NAME)),
            .Description = ObjectToString(reader(ReaderCols.FIELD_DESCRIPTION)),
            .AllowNULL = CBool(reader(ReaderCols.FIELD_ISNULL)),
            .DataTypeName = CStr(reader(ReaderCols.FIELD_DATA)),
            .Length = CInt(reader(ReaderCols.VELD_LEN)),
            .Precision = CInt(reader(ReaderCols.VELD_PREC)),
            .IsKey = CBool(reader(ReaderCols.VELD_ISPK)),
            .IsForeignKey = CBool(reader(ReaderCols.VELD_ISFK)),
            .FK_TableName = ObjectToString(reader(ReaderCols.FIELD_FKTABLE)),
            .FK_FieldName = ObjectToString(reader(ReaderCols.FIELD_FKFIELD))
        }

        If (field.Description = "") Then
            lbErrors.Items.Add(String.Format("Error: Field {0} in Table {1} has no description",
                                             field.Name,
                                             table.Name))
        End If

        table.Fields.Add(field)

    End Sub

End Class
