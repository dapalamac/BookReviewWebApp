Imports System.Web.Mvc
Imports MySql.Data.MySqlClient
Imports System.Configuration
Imports System.Security.Cryptography
Imports System.Text

Public Class AccountController
    Inherits Controller

    Private Function HashPassword(password As String) As String
        Using sha = SHA256.Create()
            Dim bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password))
            Return BitConverter.ToString(bytes).Replace("-", "").ToLower()
        End Using
    End Function

    Function Register() As ActionResult
        Return View()
    End Function

    <HttpPost>
    Function Register(username As String, email As String, password As String) As ActionResult
        Dim hash = HashPassword(password)
        Using con As New MySqlConnection(ConfigurationManager.ConnectionStrings("MySqlConnection").ConnectionString)
            con.Open()
            Dim cmd As New MySqlCommand("INSERT INTO Users (Username, Email, PasswordHash) VALUES (@Username, @Email, @PasswordHash)", con)
            cmd.Parameters.AddWithValue("@Username", username)
            cmd.Parameters.AddWithValue("@Email", email)
            cmd.Parameters.AddWithValue("@PasswordHash", hash)
            Try
                cmd.ExecuteNonQuery()
                Return RedirectToAction("Login")
            Catch ex As MySqlException
                ViewBag.Error = "Error: " & ex.Message
                Return View()
            End Try
        End Using
    End Function

    Function Login() As ActionResult
        Return View()
    End Function

    <HttpPost>
    Function Login(username As String, password As String) As ActionResult
        Dim hash = HashPassword(password)
        Using con As New MySqlConnection(ConfigurationManager.ConnectionStrings("MySqlConnection").ConnectionString)
            con.Open()
            Dim cmd As New MySqlCommand("SELECT * FROM Users WHERE Username=@Username AND PasswordHash=@Password", con)
            cmd.Parameters.AddWithValue("@Username", username)
            cmd.Parameters.AddWithValue("@Password", hash)
            Dim reader = cmd.ExecuteReader()
            If reader.Read() Then
                Session("Username") = username
                Session("UserId") = reader("Id")
                Return RedirectToAction("Index", "Books")
            End If
        End Using
        ViewBag.Error = "Credenciales incorrectas."
        Return View()
    End Function

    Function Logout() As ActionResult
        Session.Clear()
        Return RedirectToAction("Login")
    End Function
End Class


