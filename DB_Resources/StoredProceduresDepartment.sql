-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Faith Olusegun - propenster
-- Create date: Oct 8th 2020
-- Description:	Stored Procedures for Department Table dbo.Department
-- =============================================
CREATE PROCEDURE [AddDepartment]
@DepartmentName varchar(50),
@DepartmentEmail varchar(50)
AS
BEGIN
	
	SET NOCOUNT ON;
	INSERT INTO [dbo].[Department](DepartmentName, DepartmentEmail) VALUES(@DepartmentName, @DepartmentEmail)  
END

-- SP_DeleteDepartment Script Date: 08/10/2020 **********/ --
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [DeleteDepartment]
@DepartmentId int

AS
BEGIN
SET NOCOUNT ON;
DELETE FROM [dbo].[Department] WHERE DepartmentId=@DepartmentId
END

-- SP_GetAllDepartments Script Date: 08/10/2020 **********/ ----
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [GetAllDepartments]

AS
BEGIN
SET NOCOUNT ON;
SELECT * FROM [dbo].[Department] 
END

-- GetDepartmentById Script Date: 08/10/2020 **********/ -- --
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [GetDepartmentById]
@DepartmentId int

AS
BEGIN
SET NOCOUNT ON;
SELECT * FROM [dbo].[Department] WHERE DepartmentId=@DepartmentId
END

-- UpdateDepartment Script Date: 08/10/2020 **********/ --
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [UpdateDepartment]
@DepartmentId int,
@DepartmentName varchar(50),
@DepartmentEmail varchar(50)

AS
BEGIN
SET NOCOUNT ON;
UPDATE [dbo].[Department] SET DepartmentName=@DepartmentName, DepartmentEmail=@DepartmentEmail
END

