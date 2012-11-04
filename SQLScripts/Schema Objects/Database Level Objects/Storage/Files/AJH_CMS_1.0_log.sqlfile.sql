ALTER DATABASE [$(DatabaseName)]
    ADD LOG FILE (NAME = [AJH_CMS_1.0_log], FILENAME = '$(Path1)$(DatabaseName).ldf', MAXSIZE = 2097152 MB, FILEGROWTH = 10 %);

