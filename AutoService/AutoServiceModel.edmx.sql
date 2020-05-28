
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/23/2017 05:10:09
-- Generated from EDMX file: E:\IT\Архив моих работ\Курсовой проект AutoService\AutoService\AutoService\AutoServiceModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [AutoService];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Admin_Status]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Admin] DROP CONSTRAINT [FK_Admin_Status];
GO
IF OBJECT_ID(N'[dbo].[FK_Cars_ModelCars]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cars] DROP CONSTRAINT [FK_Cars_ModelCars];
GO
IF OBJECT_ID(N'[dbo].[FK_Clients_Cars]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Clients] DROP CONSTRAINT [FK_Clients_Cars];
GO
IF OBJECT_ID(N'[dbo].[FK_QueryAutoService_Clients1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[QueryAutoService] DROP CONSTRAINT [FK_QueryAutoService_Clients1];
GO
IF OBJECT_ID(N'[dbo].[FK_QueryAutoService_Masters]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[QueryAutoService] DROP CONSTRAINT [FK_QueryAutoService_Masters];
GO
IF OBJECT_ID(N'[dbo].[FK_QueryAutoService_Services]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[QueryAutoService] DROP CONSTRAINT [FK_QueryAutoService_Services];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Admin]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Admin];
GO
IF OBJECT_ID(N'[dbo].[Cars]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cars];
GO
IF OBJECT_ID(N'[dbo].[Clients]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Clients];
GO
IF OBJECT_ID(N'[dbo].[Masters]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Masters];
GO
IF OBJECT_ID(N'[dbo].[ModelCars]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ModelCars];
GO
IF OBJECT_ID(N'[dbo].[QueryAutoService]', 'U') IS NOT NULL
    DROP TABLE [dbo].[QueryAutoService];
GO
IF OBJECT_ID(N'[dbo].[Services]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Services];
GO
IF OBJECT_ID(N'[dbo].[Status]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Status];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Admin'
CREATE TABLE [dbo].[Admin] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Login] nvarchar(50)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [StatusID] int  NOT NULL
);
GO

-- Creating table 'Cars'
CREATE TABLE [dbo].[Cars] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [ModelCarID] int  NOT NULL,
    [RegisterSign] char(25)  NOT NULL
);
GO

-- Creating table 'Clients'
CREATE TABLE [dbo].[Clients] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [CarID] int  NOT NULL,
    [Name] char(25)  NOT NULL,
    [SurName] char(25)  NOT NULL,
    [Patronymic] char(25)  NULL,
    [Birthday] datetime  NOT NULL,
    [Phone] char(15)  NULL,
    [imagename] nvarchar(50)  NULL
);
GO

-- Creating table 'Masters'
CREATE TABLE [dbo].[Masters] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] char(25)  NOT NULL,
    [SurName] char(25)  NOT NULL,
    [Patronymic] char(25)  NULL,
    [Birthday] datetime  NOT NULL,
    [Phone] char(15)  NULL,
    [imagename] nvarchar(50)  NULL
);
GO

-- Creating table 'ModelCars'
CREATE TABLE [dbo].[ModelCars] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [NameCar] char(50)  NOT NULL,
    [imagename] nvarchar(50)  NULL
);
GO

-- Creating table 'QueryAutoService'
CREATE TABLE [dbo].[QueryAutoService] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [ClientID] int  NOT NULL,
    [MasterID] int  NOT NULL,
    [ServiceID] int  NOT NULL,
    [DateVisit] datetime  NOT NULL,
    [Done] bit  NOT NULL,
    [DateReady] datetime  NULL
);
GO

-- Creating table 'Services'
CREATE TABLE [dbo].[Services] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] char(60)  NOT NULL,
    [Price] decimal(18,0)  NOT NULL,
    [Details] char(1000)  NULL
);
GO

-- Creating table 'Status'
CREATE TABLE [dbo].[Status] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Login] char(12)  NOT NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'Admin'
ALTER TABLE [dbo].[Admin]
ADD CONSTRAINT [PK_Admin]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Cars'
ALTER TABLE [dbo].[Cars]
ADD CONSTRAINT [PK_Cars]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Clients'
ALTER TABLE [dbo].[Clients]
ADD CONSTRAINT [PK_Clients]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Masters'
ALTER TABLE [dbo].[Masters]
ADD CONSTRAINT [PK_Masters]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'ModelCars'
ALTER TABLE [dbo].[ModelCars]
ADD CONSTRAINT [PK_ModelCars]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'QueryAutoService'
ALTER TABLE [dbo].[QueryAutoService]
ADD CONSTRAINT [PK_QueryAutoService]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Services'
ALTER TABLE [dbo].[Services]
ADD CONSTRAINT [PK_Services]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Status'
ALTER TABLE [dbo].[Status]
ADD CONSTRAINT [PK_Status]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ModelCarID] in table 'Cars'
ALTER TABLE [dbo].[Cars]
ADD CONSTRAINT [FK_Cars_ModelCars2]
    FOREIGN KEY ([ModelCarID])
    REFERENCES [dbo].[ModelCars]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Cars_ModelCars2'
CREATE INDEX [IX_FK_Cars_ModelCars2]
ON [dbo].[Cars]
    ([ModelCarID]);
GO

-- Creating foreign key on [CarID] in table 'Clients'
ALTER TABLE [dbo].[Clients]
ADD CONSTRAINT [FK_Clients_Cars1]
    FOREIGN KEY ([CarID])
    REFERENCES [dbo].[Cars]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Clients_Cars1'
CREATE INDEX [IX_FK_Clients_Cars1]
ON [dbo].[Clients]
    ([CarID]);
GO

-- Creating foreign key on [ClientID] in table 'QueryAutoService'
ALTER TABLE [dbo].[QueryAutoService]
ADD CONSTRAINT [FK_QueryAutoService_Clients1]
    FOREIGN KEY ([ClientID])
    REFERENCES [dbo].[Clients]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_QueryAutoService_Clients1'
CREATE INDEX [IX_FK_QueryAutoService_Clients1]
ON [dbo].[QueryAutoService]
    ([ClientID]);
GO

-- Creating foreign key on [MasterID] in table 'QueryAutoService'
ALTER TABLE [dbo].[QueryAutoService]
ADD CONSTRAINT [FK_QueryAutoService_Masters]
    FOREIGN KEY ([MasterID])
    REFERENCES [dbo].[Masters]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_QueryAutoService_Masters'
CREATE INDEX [IX_FK_QueryAutoService_Masters]
ON [dbo].[QueryAutoService]
    ([MasterID]);
GO

-- Creating foreign key on [ServiceID] in table 'QueryAutoService'
ALTER TABLE [dbo].[QueryAutoService]
ADD CONSTRAINT [FK_QueryAutoService_Services]
    FOREIGN KEY ([ServiceID])
    REFERENCES [dbo].[Services]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_QueryAutoService_Services'
CREATE INDEX [IX_FK_QueryAutoService_Services]
ON [dbo].[QueryAutoService]
    ([ServiceID]);
GO

-- Creating foreign key on [StatusID] in table 'Admin'
ALTER TABLE [dbo].[Admin]
ADD CONSTRAINT [FK_Admin_Status]
    FOREIGN KEY ([StatusID])
    REFERENCES [dbo].[Status]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Admin_Status'
CREATE INDEX [IX_FK_Admin_Status]
ON [dbo].[Admin]
    ([StatusID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------