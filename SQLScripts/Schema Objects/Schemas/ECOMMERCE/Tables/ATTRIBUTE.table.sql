﻿CREATE TABLE [ECOMMERCE].[ATTRIBUTE] (
    [ATTRIBUTE_ID]         INT IDENTITY (1, 1) NOT NULL,
    [ATTRIBUTE_GROUP_ID]   INT NOT NULL,
    [ATTRIBUTE_PORTAL_ID]  INT NOT NULL,
    [ATTRIBUTE_IS_DELETED] BIT NOT NULL
);
