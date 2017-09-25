# DapperNpgsqlExampleCore
Simple demo for using dapper and npgsql with .NET Core. This is a code 
sample for a blog post at http://www.thespons.net/2015/04/28/dapper-and-npgsql-part-two.html. 

This is just a console application written in C#. It's designed to 
be used with an an already existing (preferably empty) Postgres database, 
but does include table creation and test data population scripts.

The database connection string is configurable with the DAPPER_NPGSQL_CONN_STRING 
environment variable.
