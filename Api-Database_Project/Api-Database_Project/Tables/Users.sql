CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY Identity,
	[Username] VARCHAR(50),
    [UserPassword] VARCHAR(50),
    [UserRole] VARCHAR(500),
    [UserEmail] VARCHAR(100),
)
