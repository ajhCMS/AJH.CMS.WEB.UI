﻿ALTER DATABASE [$(DatabaseName)]
    ADD FILE (NAME = [AJH_CMS_1.0], FILENAME = '$(Path2)$(DatabaseName).mdf', FILEGROWTH = 1024 KB) TO FILEGROUP [PRIMARY];
