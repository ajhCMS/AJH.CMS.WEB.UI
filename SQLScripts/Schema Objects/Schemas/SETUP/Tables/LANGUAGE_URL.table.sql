﻿CREATE TABLE [SETUP].[LANGUAGE_URL] (
    [LANGUAGE_URL_ID]          INT            IDENTITY (1, 1) NOT NULL,
    [LANGUAGE_URL_LANGUAGE_ID] INT            NOT NULL,
    [LANGUAGE_URL_NAME]        NVARCHAR (500) NOT NULL,
    [LANGUAGE_URL_PORTAL_ID]   INT            NOT NULL
);
