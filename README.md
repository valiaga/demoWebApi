Demo de arquitectura sistema de ciruclacion CRAI upeu-lima

//FRAMEWORKS
webApi
EntityFramework
AngularMaterial

//Comandos para hacer la migracion de las base de datos

Enable-Migrations -ProjectName:Crai.Icrai.Data -MigrationsDirectory:CraiIcraiDataContextMigrations
Add-Migration Initial -ProjectName:Crai.Icrai.Data -verbose
update-database -ProjectName:Crai.Icrai.Data -verbose

una vez descargado solo se usara el ultimo:

update-database -ProjectName:Crai.Icrai.Data -verbose
