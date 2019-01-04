-- Installatiescript

-- Create enum namespace
CREATE TABLE [EnumNamespace](
[Id] INT IDENTITY(1, 1),
[Name] NVARCHAR(100) NOT NULL,
CONSTRAINT [PK_EnumNamespace] PRIMARY KEY ([Id]),
CONSTRAINT [IXQ_EnumNamespace_Name] UNIQUE NONCLUSTERED ([Name]));

-- Add enums to namespace
INSERT INTO [EnumNamespace] SELECT 'Roadsigns'
INSERT INTO [EnumNamespace] SELECT 'RouteFlatness'
INSERT INTO [EnumNamespace] SELECT 'HillType'
INSERT INTO [EnumNamespace] SELECT 'ForestDensity';

-- Create enum tables
CREATE TABLE [EnumRoadsigns](
[EnumNamespaceId] INT NOT NULL,
[Value] INT NOT NULL,
[Description] NVARCHAR(100) NOT NULL,
[OrderBy] INT,
CONSTRAINT [PK_EnumRoadsigns] PRIMARY KEY CLUSTERED ([EnumNamespaceId], [Value]),
CONSTRAINT [FK_EnumRoadsigns] FOREIGN KEY ([EnumNamespaceId]) REFERENCES [EnumNamespace] ([Id]))

CREATE TABLE [EnumRouteFlatness](
[EnumNamespaceId] INT NOT NULL,
[Value] INT NOT NULL,
[Description] NVARCHAR(100) NOT NULL,
[OrderBy] INT,
CONSTRAINT [PK_EnumRouteFlatness] PRIMARY KEY CLUSTERED ([EnumNamespaceId], [Value]),
CONSTRAINT [FK_EnumRouteFlatness] FOREIGN KEY ([EnumNamespaceId]) REFERENCES [EnumNamespace] ([Id]))

CREATE TABLE [EnumHillType](
[EnumNamespaceId] INT NOT NULL,
[Value] INT NOT NULL,
[Description] NVARCHAR(100) NOT NULL,
[OrderBy] INT,
CONSTRAINT [PK_EnumHillType] PRIMARY KEY CLUSTERED ([EnumNamespaceId], [Value]),
CONSTRAINT [FK_EnumHillType] FOREIGN KEY ([EnumNamespaceId]) REFERENCES [EnumNamespace] ([Id]))

CREATE TABLE [EnumForestDensity](
[EnumNamespaceId] INT NOT NULL,
[Value] INT NOT NULL,
[Description] NVARCHAR(100) NOT NULL,
[OrderBy] INT,
CONSTRAINT [PK_EnumForestDensity] PRIMARY KEY CLUSTERED ([EnumNamespaceId], [Value]),
CONSTRAINT [FK_EnumForestDensity] FOREIGN KEY ([EnumNamespaceId]) REFERENCES [EnumNamespace] ([Id]));

-- Fill enum tables
INSERT INTO [EnumRoadsigns] SELECT 1, 1, 'None', 1
INSERT INTO [EnumRoadsigns] SELECT 1, 2, 'Some', 2
INSERT INTO [EnumRoadsigns] SELECT 1, 3, 'Many', 3

INSERT INTO [EnumRouteFlatness] SELECT 1, 1, 'Flat', 1
INSERT INTO [EnumRouteFlatness] SELECT 1, 2, 'Bumpy', 2

INSERT INTO [EnumHillType] SELECT 1, 1, 'None', 1
INSERT INTO [EnumHillType] SELECT 1, 2, 'Small', 2
INSERT INTO [EnumHillType] SELECT 1, 3, 'Steep', 3

INSERT INTO [EnumForestDensity] SELECT 1, 1, 'None', 1
INSERT INTO [EnumForestDensity] SELECT 1, 2, 'Thin', 2
INSERT INTO [EnumForestDensity] SELECT 1, 3, 'Thick', 3;

-- Create Preferences table
CREATE TABLE [dbo].[Preferences](
[Id] INT IDENTITY (1, 1),
[Length] INT NOT NULL,
[HillType] INT NOT NULL,
[Marshiness] BIT NOT NULL,
[ForestDensity] INT NOT NULL,
[RouteFlatness] INT NOT NULL,
[RouteAsphalted] BIT NOT NULL,
[RouteHardened] BIT NOT NULL,
[Roadsigns] INT NOT NULL,
CONSTRAINT [PK_Preferences] PRIMARY KEY ([Id]));

-- Fill Preferences table
INSERT INTO [Preferences] SELECT 1, 2, 0, 1, 1, 0, 0, 2
INSERT INTO [Preferences] SELECT 100, 3, 1, 3, 2, 0, 0, 1;

-- Create User table
CREATE TABLE [dbo].[User](
[Id] INT IDENTITY (1, 1),
[Name] NVARCHAR(100) NOT NULL,
[Username] NVARCHAR(100) NOT NULL,
[Password] NVARCHAR(100) NOT NULL,
[Preferences] INT NOT NULL,
CONSTRAINT [PK_User] PRIMARY KEY ([Id]),
CONSTRAINT [FK_User] FOREIGN KEY ([Preferences]) REFERENCES [Preferences] ([Id]));

-- Fill User table
INSERT INTO [User] SELECT 'Justin', 'Justintje', 'abc', 1
INSERT INTO [User] SELECT 'Roy', 'Roytje', 'def', 2;

-- Create Route table
CREATE TABLE [dbo].[Route](
[Id] INT IDENTITY (1, 1),
[Name] NVARCHAR(100) NOT NULL,
[Owner] INT NOT NULL,
[StartLocation] NVARCHAR(100),
[EndLocation] NVARCHAR(100),
[Difficulty] INT NOT NULL,
[Length] INT NOT NULL,
[HillType] INT NOT NULL,
[Marshiness] BIT NOT NULL,
[ForestDensity] INT NOT NULL,
[RouteFlatness] INT NOT NULL,
[RouteAsphalted] BIT NOT NULL,
[RouteHardened] BIT NOT NULL,
[Roadsigns] INT NOT NULL,
CONSTRAINT [PK_Route] PRIMARY KEY ([Id]),
CONSTRAINT [FK_Route] FOREIGN KEY ([Owner]) REFERENCES [User] ([Id]));

-- Fill Route table
INSERT INTO [Route] SELECT 'Ez Route', 1, NULL, NULL, 1, 1, 1, 0, 1, 1, 1, 1, 3
INSERT INTO [Route] SELECT 'FAK Route', 2, NULL, NULL, 10, 100, 3, 1, 3, 2, 0, 0, 1; 
