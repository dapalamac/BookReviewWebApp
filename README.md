# 📚 Aplicación de Reseñas de Libros - David Palacio

Esta es una aplicación web desarrollada en ASP.NET (.NET Framework) con una base de datos MySQL para gestionar reseñas de libros. Permite registrar libros, mostrar reseñas y consultar detalles.

---

## 🚀 Tecnologías utilizadas

* ASP.NET MVC (.NET Framework 4.7.2)
* MySQL
* Entity Framework 6
* HTML + Bootstrap
* Hospedaje en [SmartASP.NET](https://www.smartasp.net/)

---

## 🖥️ Cómo ejecutar la aplicación localmente

### 1. Requisitos

* Visual Studio 2019 o superior
* .NET Framework 4.7.2 instalado
* MySQL instalado localmente o acceso a un servidor remoto
* Conexión a internet

### 2. Clonar el repositorio

```bash
git clone https://github.com/tuusuario/tu-repositorio.git
```

### 3. Abrir el proyecto

Abre el archivo `TuProyecto.sln` en Visual Studio.

### 4. Configurar cadena de conexión

Edita `Web.config` y reemplaza los datos de conexión a la base de datos si vas a usar un servidor local:

```xml
<connectionStrings>
  <add name="MySqlConnection"
       connectionString="server=localhost;user id=root;password=tu_clave;database=nombre_bd"
       providerName="MySql.Data.MySqlClient" />
</connectionStrings>
```

### 5. Restaurar paquetes NuGet

En Visual Studio:

```
Tools > NuGet Package Manager > Package Manager Console
```

Y ejecuta:

```powershell
Update-Package -reinstall
```

### 6. Ejecutar

Presiona `F5` o haz clic en "Iniciar depuración".

---

## ☁️ Cómo implementarla en SmartASP.NET

### Opcion 1: Publicar desde Visual Studio (Web Deploy)

1. Haz clic derecho en el proyecto > `Publicar`
2. Configura:

   * Servidor: `https://win1044.site4now.net:8172/MsDeploy.axd?site=dapalma-001-site1`
   * Sitio: `dapalma-001-site1`
   * Usuario: `dapalma-001`
   * Contraseña: `[tu contraseña SmartASP.NET]`
3. Publicar

### Opcion 2: Usar FTP

1. Genera los archivos desde Visual Studio:

   * `Publicar > Carpeta > bin\Release\`
2. Sube por FTP (usa FileZilla o Visual Studio) al servidor:

   * FTP host: `win1044.site4now.net`
   * Usuario: `dapalma-001`
   * Carpeta destino: `site1` o `wwwroot`

---

## 🌐 Demo en Vivo

Puedes ver la aplicación desplegada aquí:

🔗 [https://dapalma-001-site1.ktempurl.com](https://dapalma-001-site1.ktempurl.com)

---

## 📬 Contacto

Cualquier duda o sugerencia, contáctame a: [dapalma94@gmail.com]
