﻿CREATE TABLE [dbo].[Cities] (
    [ID]              INT            IDENTITY (1, 1) NOT NULL,
    [Name]            NVARCHAR (200) NOT NULL,
    CONSTRAINT [PK_Cities] PRIMARY KEY CLUSTERED ([ID] ASC)
);

