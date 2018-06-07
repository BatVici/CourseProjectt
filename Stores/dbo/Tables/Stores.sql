CREATE TABLE [dbo].[Stores] (
    [ID]    INT            IDENTITY (1, 1) NOT NULL,
	[Name] NVARCHAR (200) NOT NULL,
    [City] INT            NOT NULL,
    CONSTRAINT [PK_Stores] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Stores_Cities] FOREIGN KEY ([City]) REFERENCES [dbo].[Cities] ([ID]) ON DELETE CASCADE
);







