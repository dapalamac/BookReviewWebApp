@Code
    ViewBag.Title = "Iniciar sesión"
End Code

<h2>Iniciar sesión</h2>

@If ViewBag.Error IsNot Nothing Then
    @<div class="alert alert-danger">@ViewBag.Error</div>
End If


@Code
    Dim form = Html.BeginForm("Login", "Account", FormMethod.Post)
End Code

<div class="mb-3">
    <label for="username">Usuario</label>
    <input type="text" name="username" class="form-control" required />
</div>

<div class="mb-3">
    <label for="password">Contraseña</label>
    <input type="password" name="password" class="form-control" required />
</div>

<button type="submit" class="btn btn-primary">Entrar</button>

@Code
    form.EndForm()
End Code

<p>@Html.ActionLink("¿No tienes cuenta? Regístrate", "Register", "Account")</p>


