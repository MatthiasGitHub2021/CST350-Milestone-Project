CREATE TABLE [dbo].[Users] (
    [Id]       INT      IDENTITY(1,1)     NOT NULL,
    [FIRST]    NVARCHAR (50) NULL,
    [LAST]     NVARCHAR (50) NULL,
    [SEX]      NVARCHAR (50) NULL,
    [AGE]      INT NULL,
    [STATE]    NVARCHAR (50) NULL,
    [EMAIL]    NVARCHAR (50) NULL,
    [USERNAME] NVARCHAR (50) NULL,
    [PASSWORD] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

