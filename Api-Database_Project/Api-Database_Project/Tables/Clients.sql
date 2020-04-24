CREATE TABLE [dbo].[Clients]
(
	[ClientKeyId] INT PRIMARY KEY IDENTITY,
    [ClientId] VARCHAR(500),
    [ClientSecret] VARCHAR(500),
    [ClientName] VARCHAR(100),
    [CreatedOn] DateTime
)
