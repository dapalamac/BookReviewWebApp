Imports System.Web.Mvc
Imports MySql.Data.MySqlClient

Public Class BooksController

    Inherits Controller
    Function Index() As ActionResult
        Dim books As New List(Of Book)()

        Using con As New MySqlConnection(ConfigurationManager.ConnectionStrings("MySqlConnection").ConnectionString)
            con.Open()
            Dim cmd As New MySqlCommand("SELECT * FROM Books", con)
            Dim reader = cmd.ExecuteReader()
            While reader.Read()
                books.Add(New Book With {
                    .Id = reader("Id"),
                    .Title = reader("Title"),
                    .Author = reader("Author"),
                    .Category = reader("Category"),
                    .Summary = reader("Summary")
                })
            End While
        End Using

        Return View(books)
    End Function

    Function Details(id As Integer) As ActionResult
        Dim book As New Book()

        Using con As New MySqlConnection(ConfigurationManager.ConnectionStrings("MySqlConnection").ConnectionString)
            con.Open()
            Dim cmd As New MySqlCommand("SELECT * FROM books WHERE Id=@Id", con)
            cmd.Parameters.AddWithValue("@Id", id)
            Dim reader = cmd.ExecuteReader()
            If reader.Read() Then
                book.Id = reader("Id")
                book.Title = reader("Title")
                book.Author = reader("Author")
                book.Category = reader("Category")
                book.Summary = reader("Summary")
            End If
            reader.Close()

            ' Cargar reseñas del libro
            Dim reviews As New List(Of Review)()
            cmd = New MySqlCommand("SELECT * FROM Reviews WHERE BookId = @BookId ORDER BY CreatedAt DESC", con)
            cmd.Parameters.AddWithValue("@BookId", id)
            reader = cmd.ExecuteReader()
            While reader.Read()
                reviews.Add(New Review With {
                    .Id = reader("Id"),
                    .BookId = reader("BookId"),
                    .Username = reader("Username"),
                    .Rating = reader("Rating"),
                    .Comment = reader("Comment"),
                    .CreatedAt = If(IsDBNull(reader("CreatedAt")), DateTime.MinValue, Convert.ToDateTime(reader("CreatedAt")))
                })
            End While

            ViewBag.Reviews = reviews
        End Using

        Return View(book)
    End Function

    <HttpPost>
    Function AddReview(BookId As Integer, Rating As Integer, Comment As String) As ActionResult
        If Session("Username") Is Nothing Then
            Return RedirectToAction("Login", "Account")
        End If

        Using con As New MySqlConnection(ConfigurationManager.ConnectionStrings("MySqlConnection").ConnectionString)
            con.Open()
            Dim cmd As New MySqlCommand("INSERT INTO Reviews (BookId, Username, Rating, Comment) VALUES (@BookId, @Username, @Rating, @Comment)", con)
            cmd.Parameters.AddWithValue("@BookId", BookId)
            cmd.Parameters.AddWithValue("@Username", Session("Username").ToString())
            cmd.Parameters.AddWithValue("@Rating", Rating)
            cmd.Parameters.AddWithValue("@Comment", Comment)
            cmd.ExecuteNonQuery()
        End Using

        Return RedirectToAction("Details", New With {.id = BookId})
    End Function



End Class

