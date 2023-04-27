USE [SCCRUMDB]
GO

INSERT INTO [dbo].[Product]([Title]
           ,[Image]
           ,[Price]
           ,[Stock]) values ('TV','image',4000,5)
INSERT INTO [dbo].[Product]([Title]
           ,[Image]
           ,[Price]
           ,[Stock]) values ('Mobile','image',2000,3)
INSERT INTO [dbo].[Product]([Title]
           ,[Image]
           ,[Price]
           ,[Stock]) values ('Mixer','image',1500,10)
INSERT INTO [dbo].[Product]([Title]
           ,[Image]
           ,[Price]
           ,[Stock]) values ('Speaker','image',3500,8)
INSERT INTO [dbo].[Product]([Title]
           ,[Image]
           ,[Price]
           ,[Stock]) values ('Tablet','image',4200,15)
INSERT INTO [dbo].[Product]([Title]
           ,[Image]
           ,[Price]
           ,[Stock]) values ('Mouse','image',300,20)
INSERT INTO [dbo].[Product]([Title]
           ,[Image]
           ,[Price]
           ,[Stock]) values (7,'Monitor','image',3800,5)



 select*from Product
