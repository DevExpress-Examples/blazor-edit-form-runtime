Imports System
Imports System.ComponentModel.DataAnnotations
Imports System.Text.RegularExpressions

Namespace DxBlazorApplication1.Data

    Public Class UserData

        <Required(ErrorMessage:="The Username value should be specified.")>
        <DataType(DataType.Text)>
        <Display(Name:="User Name")>
        Public Property Username As String

        <Required(ErrorMessage:="The Password value should be specified.")>
        <MinPasswordLength(6, "The Password must be at least 6 characters long.")>
        <Display(Name:="Password")>
        <DataType(DataType.Password)>
        Public Property Password As String

        <Required(ErrorMessage:="The Email value should be specified.")>
        <Email(ErrorMessage:="The Email value is invalid.")>
        <Display(Name:="Email Address")>
        <DataType(DataType.Text)>
        Public Property Email As String

        <Required(ErrorMessage:="The Phone value should be specified.")>
        <Display(Name:="Phone Number")>
        <DataType(DataType.PhoneNumber)>
        Public Property Phone As String

        <Display(Name:="Birth Date")>
        <DataType(DataType.Date)>
        Public Property BirthDate As DateTime = New DateTime(1970, 1, 1)

        <DataType("ComboBox")>
        <Display(Name:="Occupation")>
        Public Property Occupation As String

        <DataType(DataType.MultilineText)>
        <Display(Name:="Notes")>
        Public Property Notes As String
    End Class

    Public Class AdditionalData

        Public Shared Property Occupations As IEnumerable(Of String) = New List(Of String)() From {"Academic", "Administrative", "Art/Entertainment", "College Student", "Community & Social", "Computers", "Education", "Engineering", "Financial Services", "Government", "High School Student", "Law", "Managerial", "Manufacturing", "Medical/Health", "Military", "Non-government Organization", "Other Services", "Professional", "Retail", "Science & Research", "Sports", "Technical", "University Student", "Web Building"}
    End Class

    <AttributeUsage(AttributeTargets.Property Or AttributeTargets.Field Or AttributeTargets.Parameter, AllowMultiple:=False)>
    Public Class MinPasswordLengthAttribute
        Inherits ValidationAttribute

        Private ReadOnly Property MinLength As Integer

        Public Sub New(ByVal minLength As Integer, ByVal errorMsg As String)
            MyBase.New(errorMsg)
            Me.MinLength = minLength
        End Sub

        Public Overrides Function IsValid(ByVal value As Object) As Boolean
            Return(CStr(value)).Length >= MinLength
        End Function
    End Class

    <AttributeUsage(AttributeTargets.Property Or AttributeTargets.Field Or AttributeTargets.Parameter, AllowMultiple:=False)>
    Public Class EmailAttribute
        Inherits ValidationAttribute

        Public Overrides Function IsValid(ByVal value As Object) As Boolean
            Return Regex.IsMatch(CStr(value), "^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" & "@" & "((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$")
        End Function
    End Class
End Namespace
