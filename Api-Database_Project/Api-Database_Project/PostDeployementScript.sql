/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

Merge into Users AS Target 
Using(Values 
    (1, 'Lars', '123456', 'Admin', 'Lars@gmail.com'),
    (2, 'Luuk', 'abcdef', 'User', 'Luuk@gmail.com'),
    (3, 'SocialBrothers', '123pqr', 'SuperAdmin', 'SocialBrothers@gmail.com'),
    (4, 'Avans', 'abc123', 'Admin, User', 'Avans@gmail.com')
) 
AS source(Id, UserName, UserPassword, UserRole, UserEmail)
On Target.Id = Source.Id
WHEN NOT MATCHED BY TARGET THEN
Insert(UserName, UserPassword, UserRole, UserEmail)
Values(UserName, UserPassword, UserRole, UserEmail);

Merge into Products AS Target 
Using(Values 
    (1, 'Website Laravel', 100000),
    (2, 'PHP website', 350),
    (3, 'Website ASP.net', 400),
    (4, 'Google', 200),
    (5, 'Basis website', 300),
    (6, 'Website met Map', 310),
    (7, 'ASP.net API', 50)
) 
AS source(Id, Name, Price)
On Target.Id = Source.Id
WHEN NOT MATCHED BY TARGET THEN
Insert( Name, Price)
Values( Name, Price);

Merge into Clients AS Target 
Using(Values 
    (1, NEWID(), NEWID(), 'My Client1', GETDATE()),
    (2, NEWID(), NEWID(), 'My Client2', GETDATE()),
    (3, NEWID(), NEWID(), 'My Client3', GETDATE()),
    (4, NEWID(), NEWID(), 'My Client4', GETDATE())
) 
AS source(ClientKeyId, ClientId, ClientSecret,ClientName, CreatedOn)
On Target.ClientKeyId = Source.ClientKeyId
WHEN NOT MATCHED BY TARGET THEN
Insert( ClientId, ClientSecret,ClientName, CreatedOn)
Values( ClientId, ClientSecret,ClientName, CreatedOn);
