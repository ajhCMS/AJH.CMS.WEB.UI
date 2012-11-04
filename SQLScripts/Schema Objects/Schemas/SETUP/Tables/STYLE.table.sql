CREATE TABLE [SETUP].[STYLE] (
    [STYLE_ID]           INT             IDENTITY (1, 1) NOT NULL,
    [STYLE_NAME]         NVARCHAR (500)  NOT NULL,
    [STYLE_FILE_NAME]    NVARCHAR (1000) NOT NULL,
    [STYLE_DETAILS]      NTEXT           NOT NULL,
    [STYLE_IS_DELETED]   BIT             NOT NULL,
    [STYLE_PORTAL_ID]    INT             NOT NULL,
    [STYLE_LANGUAGE_ID]  INT             NOT NULL,
    [STYLE_CREATION_DAY] INT             NOT NULL,
    [STYLE_CREATION_SEC] INT             NOT NULL,
    [STYLE_CREATED_BY]   INT             NOT NULL
);

