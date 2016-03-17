# Requirements:
- .NET, version 4.5.2 or above
- NuGet Package Manager, version 2.8.60 or above
- localdb instance with name "mssqllocaldb" (default with Visual Studio 2015)

Running from **Visual Studio 2015 is recommended** and should require no additional steps.
Running from Visual Studio 2013 is officially not supported, but should be possible after dealing with some errors described in FAQ.


# FAQ:
1. My .NET Framework version is older than required.
In such case, Visual Studio will offer downgrading project target version. If chosen, langversion change is required and can be done in Web.config, in copmpilerOptions parameter:
```
<compiler language="c#;cs;csharp" extension=".cs" type="Microsoft.CSharp.CSharpCodeProvider, System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" warningLevel="4" compilerOptions="/langversion:5 /nowarn:1659;1699;1701">
          <providerOption name="CompilerVersion" value="v4.0" />
</compiler>
```

2. My localdb instance has different name.
You can change localdb instance name in Web.config and App.config files, in the parameters section:
```
  <entityFramework>
    <defaultConnectionFactory type="System.Data.Entity.Infrastructure.LocalDbConnectionFactory, EntityFramework">
      <parameters>
        <parameter value="v11.0" />
      </parameters>
    </defaultConnectionFactory>
    <providers>
      <provider invariantName="System.Data.SqlClient" type="System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer" />
    </providers>
  </entityFramework>
```
3. "The type 'System.Data.Entity.DbContext' is defined in an assembly that is not referenced."
This may happen for the "Domain" assembly when using Visual Sutdio 2013. To solve it use NuGet Package Manager to install latest version of EntityFramework in that assembly.
