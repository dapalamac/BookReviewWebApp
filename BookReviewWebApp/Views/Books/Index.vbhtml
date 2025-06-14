@ModelType List(Of Book)

@Code ViewBag.Title = "Libros disponibles" End Code

<h2 class="mb-4">Libros disponibles</h2>

<div class="row">
    @For Each book In Model
        @<div class="col-md-4 mb-3">
            <div class="card h-100 shadow">
                <div class="card-body">
                    <h5 class="card-title">@book.Title</h5>
                    <p class="card-text"><strong>Autor:</strong> @book.Author</p>
                    <p class="card-text"><strong>Categoría:</strong> @book.Category</p>
                    @Html.ActionLink("Ver detalles", "Details", New With {.id = book.Id}, New With {.class = "btn btn-primary"})
                </div>
            </div>
        </div>
    Next
</div>

