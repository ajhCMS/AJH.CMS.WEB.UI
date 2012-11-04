﻿ALTER TABLE [SETUP].[PORTAL_LANGUAGE]
    ADD CONSTRAINT [PK_PORTAL_LANGUAGE] PRIMARY KEY CLUSTERED ([PORTAL_ID] ASC, [LANGUAGE_ID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);
