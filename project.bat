@echo off
:menu
echo 1. Modelo 3 Capas
echo 2. Modelo 4 Capas
echo 0. Salir
choice /c 120 /n /m "Selecciona una opcion: "
if errorlevel 3 goto :salir
if errorlevel 2 goto :opcion2
if errorlevel 1 goto :opcion1

:opcion1
echo Has seleccionado la opcion 1.
goto :three
:three
REM Resto del código para la opción 1


REM Verificar si .NET Core SDK está instalado
dotnet --version > nul 2>&1
if %errorlevel% neq 0 (
    echo Error: .NET Core SDK no está instalado.
    exit /b 1
)

REM Solicitar el nombre de la carpeta del proyecto
set /p nombreCarpeta="Nombre de la carpeta del proyecto: "

REM Verificar si la carpeta ya existe
if exist %nombreCarpeta% (
    echo Error: La carpeta %nombreCarpeta% ya existe.
    exit /b 1
)

REM Crear la carpeta del proyecto
mkdir %nombreCarpeta%
cd %nombreCarpeta%

REM Crear gitignore
dotnet new gitignore

REM Crear la solución
dotnet new sln

REM 3 CAPAS 

REM Crear el proyecto API
dotnet new webapi -o API

REM Agregar el proyecto API a la solución
dotnet sln add ./API/

REM Crear el proyecto Core
dotnet new classlib -o Core

REM Agregar el proyecto Core a la solución
dotnet sln add ./Core/

REM Crear el proyecto Infrastructure
dotnet new classlib -o Infrastructure

REM Agregar el proyecto Infrastructure a la solución
dotnet sln add ./Infrastructure/

REM Cambiar al directorio del proyecto API
cd ./API/
REM Crea las carpetas en API
mkdir Extensions
mkdir Profiles
mkdir Dtos

REM Instala dependencias
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer --version 7.0.10
dotnet add package Microsoft.EntityFrameworkcore --version 7.0.10
dotnet add package Microsoft.EntityFrameworkCore.Design --version 7.0.10
dotnet add package Microsoft.Extensions.DependencyInjection --version 7.0.0
dotnet add package System.IdentityModel.Tokens.Jwt --version 6.32.3
dotnet add package Serilog.AspNetcore --version 7.0.0
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection --version 12.0.1
dotnet add package AspNetCoreRateLimit --version 5.0.0

REM Conectar el proyecto Infrastructure con el proyecto API
dotnet add reference ../Infrastructure/

REM Volver al directorio principal
cd ..

REM Cambiar al directorio del proyecto Infrastructure
cd ./Infrastructure/

REM Crea las carpetas en Infrastructure

mkdir Data
mkdir Repositories
mkdir UnitOfWork

cd ./Data/
mkdir Configuration
cd ..

REM Instala dependencias

dotnet add package Pomelo.EntityFrameworkCore.MySql --version 7.0.0
dotnet add package Microsoft.EntityFrameworkCore --version 7.0.10
dotnet add package CsvHelper --version 30.0.1

REM Conectar el proyecto Core con el proyecto Infrastructure
dotnet add reference ../Core/

REM Instalar la herramienta dotnet-ef
dotnet tool install --global dotnet-ef

REM Volver al directorio principal
cd ..

REM CORE

cd ./Core/
mkdir Entities
mkdir Interfaces
cd ..

REM Crear el archivo de migración
echo @echo off > migration.bat
echo. >> migration.bat
echo REM Solicitar el nombre de la migración >> migration.bat
echo set /p nombreMigracion="Nombre de la migracion: " >> migration.bat
echo. >> migration.bat
echo REM Generar la migración >> migration.bat
echo dotnet ef migrations add !nombreMigracion! --project ./Infrastructure/ --startup-project ./API/ --output-dir ./Data/Migrations >> migration.bat
echo. >> migration.bat
echo REM Actualizar la base de datos >> migration.bat
echo dotnet ef database update --project ./Infrastructure/ --startup-project ./API/ >> migration.bat


echo "Se generó el archivo de migración migration.bat"

echo "Se creó el proyecto webApi de %nombreCarpeta%"

@echo off
setlocal enabledelayedexpansion

:: Define la URL del archivo y el token de autorización
set "url=https://raw.githubusercontent.com/Lenin2611/snippets-vsc/main/snippets-threelayers.txt"
set "token=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"

:: Define la ruta del archivo de salida
set "rutaArchivo=snippets.txt"

:: Ejecuta la solicitud HTTP utilizando curl y guarda la respuesta en un archivo
curl -H "Authorization: Bearer %token%" -o "%rutaArchivo%" -L "%url%"

:: Comprueba si la descarga se realizó correctamente
if %errorlevel% equ 0 (
    echo Descarga exitosa. El archivo se guardó en %rutaArchivo%.
) else (
    echo Error en la descarga.
)

endlocal

REM Abrir el proyecto en Visual Studio Code
code .

exit /b 0


:opcion2
echo Has seleccionado la opcion 2.

echo 1. NET 7
echo 2. NET 8
echo 0. Salir
choice /c 120 /n /m "Selecciona una opcion: "
if errorlevel 3 goto :salir
if errorlevel 2 goto :eight
if errorlevel 1 goto :seven

:seven
goto :four
:four

REM Resto del código para la opción 2


REM Verificar si .NET Core SDK está instalado
dotnet --version > nul 2>&1
if %errorlevel% neq 0 (
    echo Error: .NET Core SDK no está instalado.
    exit /b 1
)

REM Solicitar el nombre de la carpeta del proyecto
set /p nombreCarpeta="Nombre de la carpeta del proyecto: "

REM Verificar si la carpeta ya existe
if exist %nombreCarpeta% (
    echo Error: La carpeta %nombreCarpeta% ya existe.
    exit /b 1
)

REM Crear la carpeta del proyecto
mkdir %nombreCarpeta%
cd %nombreCarpeta%

REM Crear gitignore
dotnet new gitignore

REM Crear la solución
dotnet new sln

REM Crear el proyecto API
dotnet new webapi -o API

REM Agregar el proyecto API a la solución
dotnet sln add ./API/

REM Crear el proyecto Application
dotnet new classlib -o Application

REM Agregar el proyecto Application a la solución
dotnet sln add ./Application/

REM Crear el proyecto Domain
dotnet new classlib -o Domain

REM Agregar el proyecto Domain a la solución
dotnet sln add ./Domain/

REM Crear el proyecto Persistence
dotnet new classlib -o Persistence

REM Agregar el proyecto Persistence a la solución
dotnet sln add ./Persistence/

REM Cambiar al directorio del proyecto API
cd ./API/
REM Crea las carpetas en API
mkdir Controllers
mkdir Dtos
mkdir Extensions
mkdir Helpers
mkdir Profiles
mkdir Services

REM Instala dependencias
dotnet add package AspNetCoreRateLimit --version 5.0.0
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection --version 12.0.1
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer --version 7.0.0
dotnet add package Microsoft.AspNetCore.Mvc.Versioning --version 7.0.0
dotnet add package Microsoft.AspNetCore.OpenApi --version 7.0.0
dotnet add package Microsoft.EntityFrameworkCore.Design --version 7.0.0
dotnet add package System.IdentityModel.Tokens.Jwt --version 7.0.0
dotnet add package Serilog.AspNetCore --version 7.0.0
dotnet add package Microsoft.Extensions.DependencyInjection --version 7.0.0
dotnet add package Microsoft.EntityFrameworkCore --version 7.0.0
dotnet add package Swashbuckle.AspNetCore.Filters --version 7.0.12

REM Conectar el proyecto Infrastructure con el proyecto API
dotnet add reference ../Application/

REM Volver al directorio principal
cd ..

REM Cambiar al directorio del proyecto Application
cd ./Application/
dotnet add reference ../Domain/
dotnet add reference ../Persistence/

REM Crea las carpetas en Application

mkdir Repositories
mkdir UnitOfWork

REM Volver al directorio principal
cd ..

REM Cambiar el directorio a Domain
cd ./Domain/

REM Instala dependencias
dotnet add package FluentValidation.AspNetCore --version 11.7.0
dotnet add package itext7.pdfhtml --version 7.2.0
dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 7.0.0

mkdir Entities
mkdir Interfaces

REM Volver al directorio principal
cd ..

REM Cambiar el directorio a Persistence
cd ./Persistence/

REM Instala dependecias
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 7.0.0
dotnet add package Pomelo.EntityFrameworkCore.MySql --version 5.1.1

REM Conectar el proyecto Persistence con Domain
dotnet add reference ../Domain/

REM Crea el directirio Data
mkdir Data
cd ./Data/
mkdir Configuration
cd ..

REM Volver al directorio principal
cd ..

REM Instalar la herramienta dotnet-ef
dotnet tool install --global dotnet-ef

REM Crear el archivo de migración
echo @echo off > migration.bat
echo. >> migration.bat
echo REM Solicitar el nombre de la migración >> migration.bat
echo set /p nombreMigracion="Nombre de la migracion: " >> migration.bat
echo. >> migration.bat
echo REM Generar la migración >> migration.bat
echo dotnet ef migrations add !nombreMigracion! --project ./Persistence/ --startup-project ./API/ --output-dir ./Data/Migrations >> migration.bat
echo. >> migration.bat
echo REM Actualizar la base de datos >> migration.bat
echo dotnet ef database update --project ./Persistence/ --startup-project ./API/ >> migration.bat


echo "Se generó el archivo de migración migration.bat"

echo "Se creó el proyecto webApi de %nombreCarpeta%"

@echo off
setlocal enabledelayedexpansion

:: Define la URL del archivo y el token de autorización
set "url=https://raw.githubusercontent.com/Lenin2611/snippets-vsc/main/snippets-fourlayers.txt"
set "token=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"

:: Define la ruta del archivo de salida
set "rutaArchivo=snippets.txt"

:: Ejecuta la solicitud HTTP utilizando curl y guarda la respuesta en un archivo
curl -H "Authorization: token %token%" -o "%rutaArchivo%" -L "%url%"

:: Comprueba si la descarga se realizó correctamente
if %errorlevel% equ 0 (
    echo Descarga exitosa. El archivo se guardó en %rutaArchivo%.
) else (
    echo Error en la descarga.
)

endlocal



REM Abrir el proyecto en Visual Studio Code
code .

exit /b 0

:eight
goto :five
:five

REM Resto del código para la opción 2


REM Verificar si .NET Core SDK está instalado
dotnet --version > nul 2>&1
if %errorlevel% neq 0 (
    echo Error: .NET Core SDK no está instalado.
    exit /b 1
)

REM Solicitar el nombre de la carpeta del proyecto
set /p nombreCarpeta="Nombre de la carpeta del proyecto: "

REM Verificar si la carpeta ya existe
if exist %nombreCarpeta% (
    echo Error: La carpeta %nombreCarpeta% ya existe.
    exit /b 1
)

REM Crear la carpeta del proyecto
mkdir %nombreCarpeta%
cd %nombreCarpeta%

REM Crear gitignore
dotnet new gitignore

REM Crear la solución
dotnet new sln

REM Crear el proyecto API
dotnet new webapi -o API

REM Agregar el proyecto API a la solución
dotnet sln add ./API/

REM Crear el proyecto Application
dotnet new classlib -o Application

REM Agregar el proyecto Application a la solución
dotnet sln add ./Application/

REM Crear el proyecto Domain
dotnet new classlib -o Domain

REM Agregar el proyecto Domain a la solución
dotnet sln add ./Domain/

REM Crear el proyecto Persistence
dotnet new classlib -o Persistence

REM Agregar el proyecto Persistence a la solución
dotnet sln add ./Persistence/

REM Cambiar al directorio del proyecto API
cd ./API/
REM Crea las carpetas en API
mkdir Controllers
mkdir Dtos
mkdir Extensions
mkdir Helpers
mkdir Profiles
mkdir Services

REM Instala dependencias
dotnet add package AspNetCoreRateLimit
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
dotnet add package Microsoft.AspNetCore.Mvc.Versioning
dotnet add package Microsoft.AspNetCore.OpenApi
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package System.IdentityModel.Tokens.Jwt
dotnet add package Serilog.AspNetCore
dotnet add package Microsoft.Extensions.DependencyInjection
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Swashbuckle.AspNetCore.Filters

REM Conectar el proyecto Infrastructure con el proyecto API
dotnet add reference ../Application/

REM Volver al directorio principal
cd ..

REM Cambiar al directorio del proyecto Application
cd ./Application/
dotnet add reference ../Domain/
dotnet add reference ../Persistence/

REM Crea las carpetas en Application

mkdir Repositories
mkdir UnitOfWork

REM Volver al directorio principal
cd ..

REM Cambiar el directorio a Domain
cd ./Domain/

REM Instala dependencias
dotnet add package FluentValidation.AspNetCore
dotnet add package itext7.pdfhtml
dotnet add package Microsoft.EntityFrameworkCore

mkdir Entities
mkdir Interfaces

REM Volver al directorio principal
cd ..

REM Cambiar el directorio a Persistence
cd ./Persistence/

REM Instala dependecias
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Pomelo.EntityFrameworkCore.MySql --version 8.0.0-beta.2

REM Conectar el proyecto Persistence con Domain
dotnet add reference ../Domain/

REM Crea el directirio Data
mkdir Data
cd ./Data/
mkdir Configuration
cd ..

REM Volver al directorio principal
cd ..

REM Instalar la herramienta dotnet-ef
dotnet tool install --global dotnet-ef

REM Crear el archivo de migración
echo @echo off > migration.bat
echo. >> migration.bat
echo REM Solicitar el nombre de la migración >> migration.bat
echo set /p nombreMigracion="Nombre de la migracion: " >> migration.bat
echo. >> migration.bat
echo REM Generar la migración >> migration.bat
echo dotnet ef migrations add !nombreMigracion! --project ./Persistence/ --startup-project ./API/ --output-dir ./Data/Migrations >> migration.bat
echo. >> migration.bat
echo REM Actualizar la base de datos >> migration.bat
echo dotnet ef database update --project ./Persistence/ --startup-project ./API/ >> migration.bat


echo "Se generó el archivo de migración migration.bat"

echo "Se creó el proyecto webApi de %nombreCarpeta%"

@echo off
setlocal enabledelayedexpansion

:: Define la URL del archivo y el token de autorización
set "url=https://raw.githubusercontent.com/Lenin2611/snippets-vsc/main/snippets-fourlayers.txt"
set "token=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"

:: Define la ruta del archivo de salida
set "rutaArchivo=snippets.txt"

:: Ejecuta la solicitud HTTP utilizando curl y guarda la respuesta en un archivo
curl -H "Authorization: Bearer %token%" -o "%rutaArchivo%" -L "%url%"

:: Comprueba si la descarga se realizó correctamente
if %errorlevel% equ 0 (
    echo Descarga exitosa. El archivo se guardó en %rutaArchivo%.
) else (
    echo Error en la descarga.
)

endlocal



REM Abrir el proyecto en Visual Studio Code
code .

exit /b 0

:salir
echo Saliendo del programa.
pause
