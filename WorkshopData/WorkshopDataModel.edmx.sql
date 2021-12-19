
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/18/2021 18:58:13
-- Generated from EDMX file: D:\Quaseem Files\Project ASP.NET\MVC Workshop\WorkshopAPI\WorkshopAPI\WorkshopData\WorkshopDataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [WorkShop];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[ARS].[FK_Material_UserDetail]', 'F') IS NOT NULL
    ALTER TABLE [ARS].[Material] DROP CONSTRAINT [FK_Material_UserDetail];
GO
IF OBJECT_ID(N'[ARS].[FK_Material_WorkShop]', 'F') IS NOT NULL
    ALTER TABLE [ARS].[Material] DROP CONSTRAINT [FK_Material_WorkShop];
GO
IF OBJECT_ID(N'[ARS].[FK_Student_WorkShop_Mapping_UserDetail]', 'F') IS NOT NULL
    ALTER TABLE [ARS].[Student_WorkShop_Mapping] DROP CONSTRAINT [FK_Student_WorkShop_Mapping_UserDetail];
GO
IF OBJECT_ID(N'[ARS].[FK_Student_WorkShop_Mapping_WorkShop]', 'F') IS NOT NULL
    ALTER TABLE [ARS].[Student_WorkShop_Mapping] DROP CONSTRAINT [FK_Student_WorkShop_Mapping_WorkShop];
GO
IF OBJECT_ID(N'[ARS].[FK_Trainer_WorkShop_Mapping_UserDetail]', 'F') IS NOT NULL
    ALTER TABLE [ARS].[Trainer_WorkShop_Mapping] DROP CONSTRAINT [FK_Trainer_WorkShop_Mapping_UserDetail];
GO
IF OBJECT_ID(N'[ARS].[FK_Trainer_WorkShop_Mapping_WorkShop]', 'F') IS NOT NULL
    ALTER TABLE [ARS].[Trainer_WorkShop_Mapping] DROP CONSTRAINT [FK_Trainer_WorkShop_Mapping_WorkShop];
GO
IF OBJECT_ID(N'[ARS].[FK_WorkShop_UserDetail1]', 'F') IS NOT NULL
    ALTER TABLE [ARS].[WorkShop] DROP CONSTRAINT [FK_WorkShop_UserDetail1];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[ARS].[Material]', 'U') IS NOT NULL
    DROP TABLE [ARS].[Material];
GO
IF OBJECT_ID(N'[ARS].[Role]', 'U') IS NOT NULL
    DROP TABLE [ARS].[Role];
GO
IF OBJECT_ID(N'[ARS].[Student_WorkShop_Mapping]', 'U') IS NOT NULL
    DROP TABLE [ARS].[Student_WorkShop_Mapping];
GO
IF OBJECT_ID(N'[ARS].[Trainer_WorkShop_Mapping]', 'U') IS NOT NULL
    DROP TABLE [ARS].[Trainer_WorkShop_Mapping];
GO
IF OBJECT_ID(N'[ARS].[UserDetail]', 'U') IS NOT NULL
    DROP TABLE [ARS].[UserDetail];
GO
IF OBJECT_ID(N'[ARS].[WorkShop]', 'U') IS NOT NULL
    DROP TABLE [ARS].[WorkShop];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Materials'
CREATE TABLE [dbo].[Materials] (
    [MaterialId] int IDENTITY(1,1) NOT NULL,
    [MaterialDescription] nvarchar(50)  NULL,
    [MaterialPath] nvarchar(200)  NULL,
    [WorkShopId] int  NULL,
    [CreatedBy] int  NULL,
    [CreatedDate] datetime  NULL,
    [UpdatedBy] nvarchar(100)  NULL,
    [UpdatedDate] datetime  NULL
);
GO

-- Creating table 'Roles'
CREATE TABLE [dbo].[Roles] (
    [RoleId] int IDENTITY(1,1) NOT NULL,
    [RoleName] varchar(50)  NULL,
    [Status] bit  NULL
);
GO

-- Creating table 'Student_WorkShop_Mapping'
CREATE TABLE [dbo].[Student_WorkShop_Mapping] (
    [SerialNo] int IDENTITY(1,1) NOT NULL,
    [StudentId] int  NULL,
    [WorkShopId] int  NULL,
    [ISApproved] bit  NULL
);
GO

-- Creating table 'Trainer_WorkShop_Mapping'
CREATE TABLE [dbo].[Trainer_WorkShop_Mapping] (
    [SerialNo] int IDENTITY(1,1) NOT NULL,
    [TrainerId] int  NULL,
    [WorkShopId] int  NULL,
    [CreatedDate] datetime  NULL,
    [CreatedBy] varchar(100)  NULL,
    [UpdatedDate] datetime  NULL,
    [UpdatedBy] varchar(100)  NULL
);
GO

-- Creating table 'UserDetails'
CREATE TABLE [dbo].[UserDetails] (
    [Userid] int IDENTITY(1,1) NOT NULL,
    [UserName_Email] varchar(100)  NULL,
    [Password] varchar(100)  NULL,
    [FirstName] varchar(100)  NULL,
    [LastName] varchar(100)  NULL,
    [UserGender] varchar(100)  NULL,
    [Mobile] varchar(100)  NULL,
    [IsActive] bit  NULL,
    [UserDob] datetime  NULL,
    [SkillsSet] varchar(500)  NULL,
    [Experience] varchar(100)  NULL,
    [RoleId] int  NULL,
    [CreatedBy] varchar(100)  NULL,
    [CreatedDate] datetime  NULL,
    [UpdatedBy] varchar(100)  NULL,
    [Updateddate] datetime  NULL
);
GO

-- Creating table 'WorkShops'
CREATE TABLE [dbo].[WorkShops] (
    [WorkShopId] int IDENTITY(1,1) NOT NULL,
    [WorkShopTitle] varchar(100)  NULL,
    [WorkShopDate] datetime  NULL,
    [WorkShopDuration] varchar(100)  NULL,
    [WorkShopTopics] varchar(100)  NULL,
    [CreatedBy] int  NULL,
    [CreatedDate] datetime  NULL,
    [UpdatedBy] varchar(100)  NULL,
    [UpdatedDate] datetime  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [MaterialId] in table 'Materials'
ALTER TABLE [dbo].[Materials]
ADD CONSTRAINT [PK_Materials]
    PRIMARY KEY CLUSTERED ([MaterialId] ASC);
GO

-- Creating primary key on [RoleId] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [PK_Roles]
    PRIMARY KEY CLUSTERED ([RoleId] ASC);
GO

-- Creating primary key on [SerialNo] in table 'Student_WorkShop_Mapping'
ALTER TABLE [dbo].[Student_WorkShop_Mapping]
ADD CONSTRAINT [PK_Student_WorkShop_Mapping]
    PRIMARY KEY CLUSTERED ([SerialNo] ASC);
GO

-- Creating primary key on [SerialNo] in table 'Trainer_WorkShop_Mapping'
ALTER TABLE [dbo].[Trainer_WorkShop_Mapping]
ADD CONSTRAINT [PK_Trainer_WorkShop_Mapping]
    PRIMARY KEY CLUSTERED ([SerialNo] ASC);
GO

-- Creating primary key on [Userid] in table 'UserDetails'
ALTER TABLE [dbo].[UserDetails]
ADD CONSTRAINT [PK_UserDetails]
    PRIMARY KEY CLUSTERED ([Userid] ASC);
GO

-- Creating primary key on [WorkShopId] in table 'WorkShops'
ALTER TABLE [dbo].[WorkShops]
ADD CONSTRAINT [PK_WorkShops]
    PRIMARY KEY CLUSTERED ([WorkShopId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CreatedBy] in table 'Materials'
ALTER TABLE [dbo].[Materials]
ADD CONSTRAINT [FK_Material_UserDetail]
    FOREIGN KEY ([CreatedBy])
    REFERENCES [dbo].[UserDetails]
        ([Userid])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Material_UserDetail'
CREATE INDEX [IX_FK_Material_UserDetail]
ON [dbo].[Materials]
    ([CreatedBy]);
GO

-- Creating foreign key on [WorkShopId] in table 'Materials'
ALTER TABLE [dbo].[Materials]
ADD CONSTRAINT [FK_Material_WorkShop]
    FOREIGN KEY ([WorkShopId])
    REFERENCES [dbo].[WorkShops]
        ([WorkShopId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Material_WorkShop'
CREATE INDEX [IX_FK_Material_WorkShop]
ON [dbo].[Materials]
    ([WorkShopId]);
GO

-- Creating foreign key on [StudentId] in table 'Student_WorkShop_Mapping'
ALTER TABLE [dbo].[Student_WorkShop_Mapping]
ADD CONSTRAINT [FK_Student_WorkShop_Mapping_UserDetail]
    FOREIGN KEY ([StudentId])
    REFERENCES [dbo].[UserDetails]
        ([Userid])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Student_WorkShop_Mapping_UserDetail'
CREATE INDEX [IX_FK_Student_WorkShop_Mapping_UserDetail]
ON [dbo].[Student_WorkShop_Mapping]
    ([StudentId]);
GO

-- Creating foreign key on [WorkShopId] in table 'Student_WorkShop_Mapping'
ALTER TABLE [dbo].[Student_WorkShop_Mapping]
ADD CONSTRAINT [FK_Student_WorkShop_Mapping_WorkShop]
    FOREIGN KEY ([WorkShopId])
    REFERENCES [dbo].[WorkShops]
        ([WorkShopId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Student_WorkShop_Mapping_WorkShop'
CREATE INDEX [IX_FK_Student_WorkShop_Mapping_WorkShop]
ON [dbo].[Student_WorkShop_Mapping]
    ([WorkShopId]);
GO

-- Creating foreign key on [TrainerId] in table 'Trainer_WorkShop_Mapping'
ALTER TABLE [dbo].[Trainer_WorkShop_Mapping]
ADD CONSTRAINT [FK_Trainer_WorkShop_Mapping_UserDetail]
    FOREIGN KEY ([TrainerId])
    REFERENCES [dbo].[UserDetails]
        ([Userid])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Trainer_WorkShop_Mapping_UserDetail'
CREATE INDEX [IX_FK_Trainer_WorkShop_Mapping_UserDetail]
ON [dbo].[Trainer_WorkShop_Mapping]
    ([TrainerId]);
GO

-- Creating foreign key on [WorkShopId] in table 'Trainer_WorkShop_Mapping'
ALTER TABLE [dbo].[Trainer_WorkShop_Mapping]
ADD CONSTRAINT [FK_Trainer_WorkShop_Mapping_WorkShop]
    FOREIGN KEY ([WorkShopId])
    REFERENCES [dbo].[WorkShops]
        ([WorkShopId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Trainer_WorkShop_Mapping_WorkShop'
CREATE INDEX [IX_FK_Trainer_WorkShop_Mapping_WorkShop]
ON [dbo].[Trainer_WorkShop_Mapping]
    ([WorkShopId]);
GO

-- Creating foreign key on [CreatedBy] in table 'WorkShops'
ALTER TABLE [dbo].[WorkShops]
ADD CONSTRAINT [FK_WorkShop_UserDetail1]
    FOREIGN KEY ([CreatedBy])
    REFERENCES [dbo].[UserDetails]
        ([Userid])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WorkShop_UserDetail1'
CREATE INDEX [IX_FK_WorkShop_UserDetail1]
ON [dbo].[WorkShops]
    ([CreatedBy]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------