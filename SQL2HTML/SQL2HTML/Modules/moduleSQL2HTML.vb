Module moduleSQL2HTML

    ''' <summary>
    ''' Transforms a database value to a String
    ''' </summary>
    ''' <param name="obj">Object</param>
    ''' <returns>String represantation of the object</returns>
    ''' <remarks>Returns "" if the object is Nothing or DBNULL</remarks>
    Public Function ObjectToString(ByVal obj As Object) As String
        If (obj Is Nothing Or IsDBNull(obj)) Then
            Return ""
        Else
            Return CStr(obj)
        End If
    End Function

    ''' <summary>
    ''' Transforms True | False to Yes | No
    ''' </summary>
    ''' <param name="bool">Boolean value</param>
    ''' <returns>More readable for non-users</returns>
    ''' <remarks></remarks>
    Public Function BooleanToEnglish(ByVal bool As Boolean) As String
        If (bool) Then
            Return "Yes"
        Else
            Return "No"
        End If
    End Function
End Module
