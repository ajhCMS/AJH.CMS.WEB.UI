CREATE TABLE [SETUP].[MENU] (
    [MENU_ID]            INT             IDENTITY (1, 1) NOT NULL,
    [MENU_NAME]          NVARCHAR (500)  NOT NULL,
    [MENU_DESCRIPTION]   NVARCHAR (1000) NOT NULL,
    [MENU_KEYWORDS]      NVARCHAR (1000) NOT NULL,
    [MENU_SEO_NAME]      NVARCHAR (1000) NOT NULL,
    [MENU_DETAILS]       NTEXT           NOT NULL,
    [MENU_URL]           NVARCHAR (1000) NOT NULL,
    [MENU_IMAGE]         NVARCHAR (500)  NOT NULL,
    [MENU_PAGE_ID]       INT             NOT NULL,
    [MENU_CATEGORY_ID]   INT             NOT NULL,
    [MENU_PARENT_ID]     INT             NOT NULL,
    [MENU_CREATION_DAY]  INT             NOT NULL,
    [MENU_CREATION_SEC]  INT             NOT NULL,
    [MENU_IS_DELETED]    BIT             NOT NULL,
    [MENU_PORTAL_ID]     INT             NOT NULL,
    [MENU_LANGUAGE_ID]   INT             NOT NULL,
    [MENU_TYPE]          INT             NOT NULL,
    [MENU_ORDER]         INT             NOT NULL,
    [MENU_CREATED_BY]    INT             NOT NULL,
    [MENU_PARENT_OBJ_ID] INT             NOT NULL
);

