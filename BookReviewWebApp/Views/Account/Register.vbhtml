@Code
    ViewBag.Title = "Registro"
End Code

<h2>Crear cuenta</h2>

@If ViewBag.Error IsNot Nothing Then
    @<div class="alert alert-danger">@ViewBag.Error</div>
End If


@Code
    Dim form = Html.BeginForm("Register", "Account", FormMethod.Post)
End Code

<div class="mb-3">
    <label for="username">Usuario</label>
    <input type="text" name="username" class="form-control" required />
</div>

<div class="mb-3">
    <label for="email">Correo electrónico</label>
    <input type="email" name="email" class="form-control" required />
</div>

<div class="mb-3">
    <label for="password">Contraseña</label>
    <input type="password" name="password" class="form-control" required />
</div>

<button type="submit" class="btn btn-success">Registrarse</button>

@Code
    form.EndForm()
End Code

<p>@Html.ActionLink("¿Ya tienes cuenta? Inicia sesión", "Login", "Account")</p>


