
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/29/2018 16:07:10
-- Generated from EDMX file: C:\Users\admin\Desktop\.NET\Lab 5\Capstone_Project\DBModel\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [patel631_Capstone];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_studentlinkedinAccount]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[students] DROP CONSTRAINT [FK_studentlinkedinAccount];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[students]', 'U') IS NOT NULL
    DROP TABLE [dbo].[students];
GO
IF OBJECT_ID(N'[dbo].[admins]', 'U') IS NOT NULL
    DROP TABLE [dbo].[admins];
GO
IF OBJECT_ID(N'[dbo].[linkedinAccounts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[linkedinAccounts];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'students'
CREATE TABLE [dbo].[students] (
    [record_id] int IDENTITY(1,1) NOT NULL,
    [alumni_id] int  NOT NULL,
    [secondaryemail] nvarchar(max)  NULL,
    [Campus] nvarchar(max)  NULL,
    [skill_1] nvarchar(max)  NOT NULL,
    [skill_2] nvarchar(max)  NOT NULL,
    [skill_3] nvarchar(max)  NOT NULL,
    [programfast] nvarchar(max)  NULL,
    [graduationdate] datetime  NULL,
    [password] nvarchar(max)  NOT NULL,
    [comment] nvarchar(max)  NULL,
    [linkedinAccount_linkedinAccount_Id] int  NOT NULL
);
GO

-- Creating table 'admins'
CREATE TABLE [dbo].[admins] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [username] nvarchar(max)  NOT NULL,
    [password] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'linkedinAccounts'
CREATE TABLE [dbo].[linkedinAccounts] (
    [linkedinAccount_Id] int IDENTITY(1,1) NOT NULL,
    [firstname] nvarchar(max)  NOT NULL,
    [lastname] nvarchar(max)  NOT NULL,
    [email] nvarchar(max)  NOT NULL,
    [url] nvarchar(max)  NOT NULL,
    [positions] nvarchar(max)  NOT NULL,
    [imgurl] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [record_id] in table 'students'
ALTER TABLE [dbo].[students]
ADD CONSTRAINT [PK_students]
    PRIMARY KEY CLUSTERED ([record_id] ASC);
GO

-- Creating primary key on [Id] in table 'admins'
ALTER TABLE [dbo].[admins]
ADD CONSTRAINT [PK_admins]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [linkedinAccount_Id] in table 'linkedinAccounts'
ALTER TABLE [dbo].[linkedinAccounts]
ADD CONSTRAINT [PK_linkedinAccounts]
    PRIMARY KEY CLUSTERED ([linkedinAccount_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [linkedinAccount_linkedinAccount_Id] in table 'students'
ALTER TABLE [dbo].[students]
ADD CONSTRAINT [FK_studentlinkedinAccount]
    FOREIGN KEY ([linkedinAccount_linkedinAccount_Id])
    REFERENCES [dbo].[linkedinAccounts]
        ([linkedinAccount_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_studentlinkedinAccount'
CREATE INDEX [IX_FK_studentlinkedinAccount]
ON [dbo].[students]
    ([linkedinAccount_linkedinAccount_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------