Public Class Table

    Public Property Name As String
    Public Property Description As String
    Public Property Fields As List(Of Field)

    Public Sub New(ByVal name As String, ByVal description As String)
        Me.Name = name
        Me.Description = description

        Fields = New List(Of Field)
    End Sub

    ''' <summary>
    ''' Transforms one table to HTML
    ''' </summary>
    ''' <remarks>
    ''' The "class" attribute is used in the .css styling. See styles.css
    ''' </remarks>
    Public Function ToHTML() As String

        Dim sql As String = ""

        sql = "<table class=""table"" border=""1""><caption><span class=""tName"">" & Name & "</span> - <span class=""tDescription"">" & Description & "</span></caption>"
        sql = sql & "<tr class=""tHeaderStyle"">" &
            "<td>Field Name</td>" &
            "<td class=""tDescriptionStyle"">Description</td>" &
            "<td>Allow NULL</td>" &
            "<td>Data Type</td>" &
            "<td>Length</td>" &
            "<td>Precision</td>" &
            "<td>Is Key</td>" &
            "<td>Linked Table</td>" &
            "</tr>"

        Dim alternativeColor = False
        For Each veld In Fields
            alternativeColor = Not alternativeColor
            sql = sql & veld.ToHTML(Name, alternativeColor)
        Next
        sql = sql & "</table><p></p>"

        Return sql

    End Function
End Class
