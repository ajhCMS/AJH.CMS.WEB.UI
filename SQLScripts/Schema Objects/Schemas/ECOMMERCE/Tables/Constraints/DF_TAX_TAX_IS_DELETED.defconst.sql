﻿ALTER TABLE [ECOMMERCE].[TAX]
    ADD CONSTRAINT [DF_TAX_TAX_IS_DELETED] DEFAULT ((0)) FOR [TAX_IS_DELETED];

