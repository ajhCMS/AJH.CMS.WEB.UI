﻿ALTER TABLE [ECOMMERCE].[CATALOG]
    ADD CONSTRAINT [DF_CATALOG_CATALOG_IS_PUBLISHED] DEFAULT ((0)) FOR [CATALOG_IS_PUBLISHED];

