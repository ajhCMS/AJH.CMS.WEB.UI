﻿ALTER TABLE [SECURITY].[FORM_USER]
    ADD CONSTRAINT [PK_FORM_USER] PRIMARY KEY CLUSTERED ([FORM_USER_ID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);
