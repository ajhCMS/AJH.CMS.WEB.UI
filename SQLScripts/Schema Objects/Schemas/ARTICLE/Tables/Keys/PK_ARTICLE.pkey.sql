﻿ALTER TABLE [ARTICLE].[ARTICLE]
    ADD CONSTRAINT [PK_ARTICLE] PRIMARY KEY CLUSTERED ([ARTICLE_ID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);
