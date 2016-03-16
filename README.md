# Requirements:
- .NET, version 4.5.2 or above
- NuGet Package Manager, version 2.8.60 or above
- localdb instance with name "mssqllocaldb" (default with Visual Studio 2015)

Running from **Visual Studio 2015 is recommended** and should require no additional steps.
Running from Visual Studio 2013 is officially not supported, but should be possible after dealing with some errors described in FAQ.


# FAQ:
1. My .NET Framework version is older than required:

- TODO

2. My localdb instance has different name
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
