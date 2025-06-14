@ModelType Book
@Code ViewBag.Title = "Detalles del Libro" End Code

<h2>@Model.Title</h2>

<div class="card shadow p-4 mb-3">
    <h5 class="card-title">Autor: @Model.Author</h5>
    <h6 class="card-subtitle mb-2 text-muted">Categoría: @Model.Category</h6>
    <p class="card-text">@Model.Summary</p>
</div>

@Html.ActionLink("← Volver a la lista", "Index", "Books", Nothing, New With {.class = "btn btn-secondary"})

<hr />
<h4>Reseñas</h4>

@If ViewBag.Reviews IsNot Nothing Then
    Dim reviews = CType(ViewBag.Reviews, List(Of Review))
    If reviews.Any() Then
        For Each r In reviews
            @<div class="border p-3 mb-2">
                <strong>@r.Username</strong> - @r.Rating estrellas<br />
                <small>@r.CreatedAt.ToString("yyyy-MM-dd HH:mm")</small>
                <p>@r.Comment</p>
            </div> Next
    Else
        @<p>No hay reseñas aún.</p>
    End If
End If

@If Session("Username") IsNot Nothing Then
    @Code
        Dim form = Html.BeginForm("AddReview", "Books", FormMethod.Post)
    End Code

    @<div class="mb-3">
        @Html.Hidden("BookId", Model.Id)
        <label for="Rating">Calificación (1 a 5)</label>
        <input type="number" name="Rating" class="form-control" min="1" max="5" required />
    </div>

    @<div class="mb-3">
        <label for="Comment">Comentario</label>
        <textarea name="Comment" class="form-control" required></textarea>
    </div>

    @<button type="submit" class="btn btn-success">Enviar reseña</button>

    @Code
        form.EndForm()
    End Code
Else
    @<p><em>Debes iniciar sesión para dejar una reseña.</em></p>
End If








