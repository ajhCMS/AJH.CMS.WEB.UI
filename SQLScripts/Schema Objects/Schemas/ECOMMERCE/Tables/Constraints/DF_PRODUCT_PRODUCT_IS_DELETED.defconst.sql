﻿ALTER TABLE [ECOMMERCE].[PRODUCT]
    ADD CONSTRAINT [DF_PRODUCT_PRODUCT_IS_DELETED] DEFAULT ((0)) FOR [PRODUCT_IS_DELETED];

