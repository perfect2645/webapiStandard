#Webapi Messaging Tool

## .net Web API


## Package Overview
### Package - Api Versioning
[ApiVersioning](https://github.com/dotnet/aspnet-api-versioning)

### Package - Log4Net
[Log4Net](https://logging.apache.org/log4net/)

### Package - JWT
Microsoft.AspNetCore.Authentication.JwtBearer

### Openapi
Embedded in .net10 Webapi SDK
``` json
//Properties/launchSettings.json
"https": {
      "launchBrowser": true,
      // "launchUrl": "openapi/v1.json",
      "launchUrl": "swagger",
}
```

### Swagger extension / Annotations
Swashbuckle.AspNetCore

## Entity Framework
### Package - Entity Framework Core
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools

> Run Add-Migration
> Run Update-Database
### Package - Webapi
- Microsoft.EntityFrameworkCore.Design




## HttpContext
- Microsoft.AspNetCore.Http.Abstractions
可以在Service中注入 IHttpContextAccessor

