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
-- Description:	Stored Procedures for Employee Table dbo.Employee
-- =============================================
CREATE PROCEDURE [AddEmployee]
@EmployeeName varchar(50),
@EmployeeMobile varchar(50),
@EmployeeEmail varchar(50),
@Department varchar(50),
@ImageURL varchar(50),
@EmployeeRegisteredDate date
AS
BEGIN
	
	SET NOCOUNT ON;
	INSERT INTO [dbo].[Employee](EmployeeName, EmployeeMobile, EmployeeEmail, Department, ImageURL, EmployeeRegisteredDate) VALUES(@EmployeeName, @EmployeeMobile, @EmployeeEmail, @Department, @ImageURL, @EmployeeRegisteredDate)  
END

-- SP_DeleteEmployee Script Date: 08/10/2020 **********/ --
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [DeleteEmployee]
@EmployeeId int

AS
BEGIN
SET NOCOUNT ON;
DELETE FROM [dbo].[Employee] WHERE EmployeeId=@EmployeeId
END

-- SP_GetAllEmployees Script Date: 08/10/2020 **********/ ----
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [GetAllEmployees]

AS
BEGIN
SET NOCOUNT ON;
SELECT * FROM [dbo].[Employee] 
END

-- GetEmployeeById Script Date: 08/10/2020 **********/ -- --
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [GetEmployeeById]
@EmployeeId int

AS
BEGIN
SET NOCOUNT ON;
SELECT * FROM [dbo].[Employee] WHERE EmployeeId=@EmployeeId
END

-- UpdateEmployee Script Date: 08/10/2020 **********/ --
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [UpdateEmployee]
@EmployeeId int,
@EmployeeName varchar(50),
@EmployeeMobile varchar(50),
@EmployeeEmail varchar(50),
@Department varchar(50),
@ImageURL varchar(50),
@EmployeeRegisteredDate date

AS
BEGIN
SET NOCOUNT ON;
UPDATE [dbo].[Employee] SET EmployeeName=@EmployeeName, EmployeeMobile=@EmployeeMobile, EmployeeEmail=@Department, ImageURL=@ImageURL, EmployeeRegisteredDate=@EmployeeRegisteredDate
END

