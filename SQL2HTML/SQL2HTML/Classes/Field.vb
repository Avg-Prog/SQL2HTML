Public Class Field

    Public Property Name As String
    Public Property Description As String
    Public Property AllowNULL As Boolean
    Public Property DataTypeName As String
    Public Property Length As Integer
    Public Property Precision As Integer
    Public Property IsKey As Boolean
    Public Property IsForeignKey As Boolean
    Public Property FK_TableName As String
    Public Property FK_FieldName As String

    ''' <summary>
    ''' Transforms an SQL field to HTML
    ''' </summary>
    ''' <param name="tableName">Parent table of the field</param>
    ''' <param name="altColor">Default color or alternative color</param>
    ''' <returns>HTML representation of the field</returns>
    ''' <remarks>
    ''' "alternativeColor" is a .css setting. When it isn't set in styles.css, it won't be applied.
    ''' The Primary Key fields will receive a "a name" property used for inpage linking
    ''' The Foreign Key fields will receive a link to said inpage link
    ''' </remarks>
    Function ToHTML(ByVal tableName As String,
                    ByVal altColor As Boolean) As String

        Dim sql = ""

        If (altColor) Then
            sql = "<tr><td>"
        Else
            sql = "<tr class=""alternativeColor""><td>"
        End If


        If (IsKey) Then
            sql = sql & String.Format("<a name=""{0}"">", tableName & Name)
        End If

        sql = sql & Name

        If (IsKey) Then
            sql = sql & "</a>"
        End If

        sql = sql & "</td>" &
            "<td>" & Description & "</td>" &
            "<td>" & BooleanToEnglish(AllowNULL) & "</td>" &
            "<td>" & DataTypeName & "</td><td>"

        'If length equals -1: length is MAX (SQL Server 2008)
        If (Length < 0) Then
            sql = sql & "MAX"
        Else
            sql = sql & Length
        End If

        sql = sql &
            "</td><td>" & Precision & "</td>" &
            "<td>" & BooleanToEnglish(IsKey) & "</td>"

        If (IsForeignKey) Then
            sql = sql & String.Format("<td><a href=""#{0}"">", FK_TableName & FK_FieldName) & String.Format("{0} - {1}", FK_TableName, FK_FieldName) & "</a></td>"
        End If

        sql = sql & "</tr>"

        Return sql
    End Function

End Class
