# Gestión de Presupuestos de Campos Clínicos

Este proyecto consiste en una aplicación web para gestionar presupuestos de campos clínicos, incluyendo usuarios, roles, y funcionalidades como registro de estudiantes, convenios, devengados, y facturación.

---

## **Requisitos previos**
Antes de iniciar, asegúrate de tener instalado lo siguiente en tu sistema:
<Project Sdk="Microsoft.NET.Sdk.Web">

  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>
    <RootNamespace>Gestion_Del_Presupuesto</RootNamespace>
  </PropertyGroup>

  <ItemGroup>
	 
    <Compile Remove="Views\Cambio_Moneda\**" />
    <Content Remove="Views\Cambio_Moneda\**" />
    <EmbeddedResource Remove="Views\Cambio_Moneda\**" />
    <None Remove="Views\Cambio_Moneda\**" />
  </ItemGroup>

  <ItemGroup>
    <PackageReference Include="CsvHelper" Version="33.0.1" />
    <PackageReference Include="EPPlus" Version="7.4.1" />
    <PackageReference Include="HtmlAgilityPack" Version="1.11.67" />
    <PackageReference Include="Microsoft.AspNetCore.Identity.EntityFrameworkCore" Version="8.0.10" />
    <PackageReference Include="Microsoft.AspNetCore.Mvc.TagHelpers" Version="2.2.0" />
    <PackageReference Include="Microsoft.EntityFrameworkCore" Version="8.0.10" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Relational" Version="8.0.10" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="8.0.10">
      <PrivateAssets>all</PrivateAssets>
      <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
    </PackageReference>
    <PackageReference Include="Microsoft.VisualStudio.Web.CodeGeneration.Design" Version="8.0.6" />
    <PackageReference Include="Npgsql.EntityFrameworkCore.PostgreSQL" Version="8.0.8" />
    <PackageReference Include="StyleCop.Analyzers" Version="1.1.118">
      <PrivateAssets>all</PrivateAssets>
      <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
    </PackageReference>
	

  </ItemGroup>

  <ItemGroup>
    <Folder Include="Migrations\" />
    <Folder Include="Documentos_Termino\" />
  </ItemGroup>

</Project>


---

## **Pasos para iniciar el proyecto**

### **1. Clonar el repositorio**
```bash
git clone https://github.com/tu-usuario/tu-repositorio.git
cd tu-repositorio



