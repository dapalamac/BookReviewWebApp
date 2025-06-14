<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title>@ViewBag.Title - David Palacio </title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
        <div class="container">
            <a class="navbar-brand" href="@Url.Action("Index", "Books")">📚 David Palacio - Reseña de Libros</a>
            <div class="collapse navbar-collapse">
                <ul class="navbar-nav ms-auto">
                    <li class="nav-item">
                        @Html.ActionLink("Inicio", "Index", "Home", Nothing, New With {.class = "nav-link"})
                    </li>
                    <li class="nav-item">
                        @Html.ActionLink("Libros", "Index", "Books", Nothing, New With {.class = "nav-link"})
                    </li>
                    <li class="nav-item">
                        @Html.ActionLink("Contacto", "Contact", "Home", Nothing, New With {.class = "nav-link"})
                    </li>
                </ul>
            </div>
        </div>
    </nav>

    <div class="container mt-4">
        @RenderBody()
    </div>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>

