
USE [ProjectManager];
GO

-- Creating table 'ParentTasks'
CREATE TABLE [dbo].[ParentTasks] (
    [Parent_ID] int IDENTITY(1,1) NOT NULL,
    [Parent_Task] varchar(100)  NOT NULL
);
GO

-- Creating table 'Projects'
CREATE TABLE [dbo].[Projects] (
    [Project_ID] int IDENTITY(1,1) NOT NULL,
    [ProjectName] varchar(50)  NOT NULL,
    [StartDate] datetime  NULL,
    [EndDate] datetime  NULL,
    [Priority] int  NOT NULL,
    [ManagerId] int  NULL,
    [ManagerName] nvarchar(100)  NULL
);
GO

-- Creating table 'Tasks'
CREATE TABLE [dbo].[Tasks] (
    [Task_ID] int IDENTITY(1,1) NOT NULL,
    [Parent_ID] int  NOT NULL,
    [Project_ID] int  NOT NULL,
    [Task1] varchar(50)  NOT NULL,
    [Start_Date] datetime  NULL,
    [End_Date] datetime  NULL,
    [Priority] int  NOT NULL,
    [STATUS] varchar(50)  NULL,
    [UserId] int  NULL,
    [UserName] nvarchar(50)  NULL,
    [ParentTaskName] nvarchar(50)  NULL,
    [ProjectName] nvarchar(50)  NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [User_ID] int IDENTITY(1,1) NOT NULL,
    [FirstName] varchar(50)  NOT NULL,
    [LastName] varchar(50)  NOT NULL,
    [Employee_Id] int  NOT NULL,
    [Project_ID] int  NULL,
    [Task_ID] int  NULL
);
GO

-- Creating primary key on [Parent_ID] in table 'ParentTasks'
ALTER TABLE [dbo].[ParentTasks]
ADD CONSTRAINT [PK_ParentTasks]
    PRIMARY KEY CLUSTERED ([Parent_ID] ASC);
GO

-- Creating primary key on [Project_ID] in table 'Projects'
ALTER TABLE [dbo].[Projects]
ADD CONSTRAINT [PK_Projects]
    PRIMARY KEY CLUSTERED ([Project_ID] ASC);
GO

-- Creating primary key on [Task_ID] in table 'Tasks'
ALTER TABLE [dbo].[Tasks]
ADD CONSTRAINT [PK_Tasks]
    PRIMARY KEY CLUSTERED ([Task_ID] ASC);
GO

-- Creating primary key on [User_ID] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([User_ID] ASC);
GO

-- Creating foreign key on [Parent_ID] in table 'Tasks'
ALTER TABLE [dbo].[Tasks]
ADD CONSTRAINT [fk_Parent_ID]
    FOREIGN KEY ([Parent_ID])
    REFERENCES [dbo].[ParentTasks]
        ([Parent_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_Parent_ID'
CREATE INDEX [IX_fk_Parent_ID]
ON [dbo].[Tasks]
    ([Parent_ID]);
GO

-- Creating foreign key on [ManagerId] in table 'Projects'
ALTER TABLE [dbo].[Projects]
ADD CONSTRAINT [FK_Manager_UserId]
    FOREIGN KEY ([ManagerId])
    REFERENCES [dbo].[Users]
        ([User_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Manager_UserId'
CREATE INDEX [IX_FK_Manager_UserId]
ON [dbo].[Projects]
    ([ManagerId]);
GO

-- Creating foreign key on [Project_ID] in table 'Tasks'
ALTER TABLE [dbo].[Tasks]
ADD CONSTRAINT [fk_Project_ID]
    FOREIGN KEY ([Project_ID])
    REFERENCES [dbo].[Projects]
        ([Project_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_Project_ID'
CREATE INDEX [IX_fk_Project_ID]
ON [dbo].[Tasks]
    ([Project_ID]);
GO

-- Creating foreign key on [Project_ID] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [fk_Users_Project_ID]
    FOREIGN KEY ([Project_ID])
    REFERENCES [dbo].[Projects]
        ([Project_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_Users_Project_ID'
CREATE INDEX [IX_fk_Users_Project_ID]
ON [dbo].[Users]
    ([Project_ID]);
GO

-- Creating foreign key on [Task_ID] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [fk_Task_ID]
    FOREIGN KEY ([Task_ID])
    REFERENCES [dbo].[Tasks]
        ([Task_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_Task_ID'
CREATE INDEX [IX_fk_Task_ID]
ON [dbo].[Users]
    ([Task_ID]);
GO