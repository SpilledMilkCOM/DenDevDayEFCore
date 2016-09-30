# DenDevDayEFCore
The FULL presentation code for my Entity Framework Core sample.

Basics:
-------
  - _Simple_ Entity Framework interaction (Code First using localdb)
  - Have to have a web project since "dotnet ef database update" doesn't work with a class library.
  - XUnit test driven demo (_no GUI_)

Intermediate:
-------------
  - Repository with ModelBuilder mapping (no attributes on POCOs)

Advanced:
---------
  - Calling a stored procedure with a User Defined Table Type (using NReco.Data)
  - Code sharing between .Net Core and .Net Old (no Code First)
  - Abstracting the ModelBuilder and DbModelBuilder.