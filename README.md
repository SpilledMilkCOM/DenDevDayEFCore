# DenDevDayEFCore
The FULL presentation code for my Entity Framework Core sample. (10-28-2016)

It's OFFICIAL -- I'm only presenting the BASICS, but I will "poll" the audience and see how fast we want to go and possibly incorporate
some of the intermediate and/or advanced topics into the talk as well.

Basics:
-------
  - _Simple_ Entity Framework interaction (Code First using localdb)
  - Have to have a web project since "dotnet ef database update" doesn't work with a class library.
  - XUnit test driven demo (_no GUI_)

Intermediate:
-------------
  - Separate duties with a repository and DbContext
  - More data entity attributes to customize the database.
  - A simple stored procedure call.

Advanced:
---------
  - Calling a stored procedure with a User Defined Table Type (using NReco.Data)
  - Code sharing between .Net Core and .Net Old (no Code First)
  - Repository with ModelBuilder mapping (no attributes on POCOs)
  - Abstracting the ModelBuilder and DbModelBuilder.