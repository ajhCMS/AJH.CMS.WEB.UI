﻿ALTER TABLE [ECOMMERCE].[TAX]
    ADD CONSTRAINT [PK_TAX] PRIMARY KEY CLUSTERED ([TAX_ID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);
