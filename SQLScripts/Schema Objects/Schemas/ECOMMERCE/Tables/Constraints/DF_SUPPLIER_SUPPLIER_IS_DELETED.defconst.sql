﻿ALTER TABLE [ECOMMERCE].[SUPPLIER]
    ADD CONSTRAINT [DF_SUPPLIER_SUPPLIER_IS_DELETED] DEFAULT ((0)) FOR [SUPPLIER_IS_DELETED];
