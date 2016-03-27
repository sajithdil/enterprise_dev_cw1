
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/20/2016 09:17:20
-- Generated from EDMX file: E:\IIT MSC\Enterprise Development\CW1\dev\enterprise_dev_cw1\Enterprise_Development_CW1\Enterprise_Development_CW1.DB\ConverterGameDbContext.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ConverterGameDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UsernamesGame]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Games] DROP CONSTRAINT [FK_UsernamesGame];
GO
IF OBJECT_ID(N'[dbo].[FK_GameGameData]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GameDatas] DROP CONSTRAINT [FK_GameGameData];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Usernames]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Usernames];
GO
IF OBJECT_ID(N'[dbo].[Games]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Games];
GO
IF OBJECT_ID(N'[dbo].[GameDatas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GameDatas];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Usernames'
CREATE TABLE [dbo].[Usernames] (
    [Username] varchar(50)  NOT NULL
);
GO

-- Creating table 'Games'
CREATE TABLE [dbo].[Games] (
    [Id] int  NOT NULL,
    [UserN] varchar(50)  NOT NULL
);
GO

-- Creating table 'GameDatas'
CREATE TABLE [dbo].[GameDatas] (
    [Id] int  NOT NULL,
    [GameId] int  NOT NULL,
    [FromType] nvarchar(max)  NULL,
    [ToType] nvarchar(max)  NULL,
    [FromValue] nvarchar(max)  NULL,
    [ToValue] nvarchar(max)  NULL,
    [GameString] nvarchar(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Username] in table 'Usernames'
ALTER TABLE [dbo].[Usernames]
ADD CONSTRAINT [PK_Usernames]
    PRIMARY KEY CLUSTERED ([Username] ASC);
GO

-- Creating primary key on [Id] in table 'Games'
ALTER TABLE [dbo].[Games]
ADD CONSTRAINT [PK_Games]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'GameDatas'
ALTER TABLE [dbo].[GameDatas]
ADD CONSTRAINT [PK_GameDatas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserN] in table 'Games'
ALTER TABLE [dbo].[Games]
ADD CONSTRAINT [FK_UsernamesGame]
    FOREIGN KEY ([UserN])
    REFERENCES [dbo].[Usernames]
        ([Username])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsernamesGame'
CREATE INDEX [IX_FK_UsernamesGame]
ON [dbo].[Games]
    ([UserN]);
GO

-- Creating foreign key on [GameId] in table 'GameDatas'
ALTER TABLE [dbo].[GameDatas]
ADD CONSTRAINT [FK_GameGameData]
    FOREIGN KEY ([GameId])
    REFERENCES [dbo].[Games]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GameGameData'
CREATE INDEX [IX_FK_GameGameData]
ON [dbo].[GameDatas]
    ([GameId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------