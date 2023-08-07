﻿CREATE PROC Add_New_User
@FIRST    NVARCHAR (50) NULL,
@LAST     NVARCHAR (50) NULL,
@SEX      NVARCHAR (50) NULL,
@AGE      INT NULL,
@STATE    NVARCHAR (50) NULL,
@EMAIL    NVARCHAR (50) NULL,
@USERNAME NVARCHAR (50) NULL,
@PASSWORD NVARCHAR (50) NULL
AS
BEGIN
INSERT INTO dbo.Users
(
	FIRST,
	LAST,
	SEX,
	AGE,
	STATE,
	EMAIL,
	USERNAME,
	PASSWORD
)
VALUES
(
@FIRST,
@LAST,
@SEX,
@AGE,
@STATE,    
@EMAIL,    
@USERNAME, 
@PASSWORD 
)
END