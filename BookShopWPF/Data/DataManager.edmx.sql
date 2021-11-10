
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/10/2021 23:35:21
-- Generated from EDMX file: C:\Users\vsh15\source\repos\BookShopWPF\BookShopWPF\Data\DataManager.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BooksDatabase];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_BookPublisher]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Books] DROP CONSTRAINT [FK_BookPublisher];
GO
IF OBJECT_ID(N'[dbo].[FK_BookGenre]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Books] DROP CONSTRAINT [FK_BookGenre];
GO
IF OBJECT_ID(N'[dbo].[FK_AuthorBook]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Books] DROP CONSTRAINT [FK_AuthorBook];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Books]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Books];
GO
IF OBJECT_ID(N'[dbo].[Publishers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Publishers];
GO
IF OBJECT_ID(N'[dbo].[GenreSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GenreSet];
GO
IF OBJECT_ID(N'[dbo].[Authors]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Authors];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Books'
CREATE TABLE [dbo].[Books] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [About] nvarchar(max)  NOT NULL,
    [Year] int  NOT NULL,
    [Pages] int  NOT NULL,
    [PublisherId] int  NOT NULL,
    [GenreId] int  NOT NULL,
    [AuthorId] int  NOT NULL,
    [Price] float  NOT NULL
);
GO

-- Creating table 'Publishers'
CREATE TABLE [dbo].[Publishers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'GenreSet'
CREATE TABLE [dbo].[GenreSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Authors'
CREATE TABLE [dbo].[Authors] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FIO] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Sales'
CREATE TABLE [dbo].[Sales] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [BookId] int  NOT NULL,
    [SaleDate] datetime  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Books'
ALTER TABLE [dbo].[Books]
ADD CONSTRAINT [PK_Books]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Publishers'
ALTER TABLE [dbo].[Publishers]
ADD CONSTRAINT [PK_Publishers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'GenreSet'
ALTER TABLE [dbo].[GenreSet]
ADD CONSTRAINT [PK_GenreSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Authors'
ALTER TABLE [dbo].[Authors]
ADD CONSTRAINT [PK_Authors]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Sales'
ALTER TABLE [dbo].[Sales]
ADD CONSTRAINT [PK_Sales]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [PublisherId] in table 'Books'
ALTER TABLE [dbo].[Books]
ADD CONSTRAINT [FK_BookPublisher]
    FOREIGN KEY ([PublisherId])
    REFERENCES [dbo].[Publishers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BookPublisher'
CREATE INDEX [IX_FK_BookPublisher]
ON [dbo].[Books]
    ([PublisherId]);
GO

-- Creating foreign key on [GenreId] in table 'Books'
ALTER TABLE [dbo].[Books]
ADD CONSTRAINT [FK_BookGenre]
    FOREIGN KEY ([GenreId])
    REFERENCES [dbo].[GenreSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BookGenre'
CREATE INDEX [IX_FK_BookGenre]
ON [dbo].[Books]
    ([GenreId]);
GO

-- Creating foreign key on [AuthorId] in table 'Books'
ALTER TABLE [dbo].[Books]
ADD CONSTRAINT [FK_AuthorBook]
    FOREIGN KEY ([AuthorId])
    REFERENCES [dbo].[Authors]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AuthorBook'
CREATE INDEX [IX_FK_AuthorBook]
ON [dbo].[Books]
    ([AuthorId]);
GO

-- Creating foreign key on [BookId] in table 'Sales'
ALTER TABLE [dbo].[Sales]
ADD CONSTRAINT [FK_SalesBook]
    FOREIGN KEY ([BookId])
    REFERENCES [dbo].[Books]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SalesBook'
CREATE INDEX [IX_FK_SalesBook]
ON [dbo].[Sales]
    ([BookId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------