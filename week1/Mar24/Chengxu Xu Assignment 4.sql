-- Use Northwind database. All questions are based on assumptions described by the Database Diagram sent to you yesterday. 
-- When inserting, make up info if necessary. Write query for each step. Do not use IDE. BE CAREFUL WHEN DELETING DATA OR DROPPING TABLE.
USE Northwind
GO


-- 1.      Create a view named “view_product_order_[your_last_name]”, 
-- list all products and total ordered quantity for that product.
CREATE VIEW view_product_order_Xu
AS
    (
    SELECT p.ProductName, SUM(od.Quantity) AS [Total Order Quentity]
    FROM Products p
        JOIN [Order Details] od ON od.ProductId = p. ProductId
    GROUP BY p.ProductName
    )
GO

-- Test code
SELECT *
FROM dbo.view_product_order_Xu
GO

-- 2.      Create a stored procedure “sp_product_order_quantity_[your_last_name]” 
-- that accept product id as an input and total quantities of order as output parameter.
CREATE PROC sp_product_order_quantity_Xu
    @Pid INT,
    @TotalQuantities INT OUT
AS
BEGIN
    SELECT @TotalQuantities = SUM(od.OrderID)
    FROM [Order Details] od
    WHERE od.ProductID = @Pid
END

-- Test code
DECLARE @resultQuantity INT
EXEC sp_product_order_quantity_Xu 10, @resultQuantity OUT
PRINT @resultQuantity
-- DROP PROC sp_product_order_quantity_Xu  
GO

-- 3.      Create a stored procedure “sp_product_order_city_[your_last_name]” 
-- that accept product name as an input and top 5 cities that ordered most that product 
-- combined with the total quantity of that product ordered from that city as output.
CREATE PROC sp_product_order_city_Xu
    @product_name NVARCHAR(40)
AS
BEGIN
    SELECT TOP 5 o.ShipCity, SUM(od.Quantity) AS [Total Order Quantities]
    FROM Orders o
        JOIN [Order Details] od ON od.OrderID = o.OrderID
        JOIN Products p  ON p.ProductID = od.ProductID
    WHERE p.ProductName = @product_name
    GROUP BY o.ShipCity
    ORDER BY [Total Order Quantities] DESC
END

--Test code
EXEC sp_product_order_city_Xu "Chef Anton's Cajun Seasoning"


-- 4.      Create 2 new tables “people_your_last_name” “city_your_last_name”. 
-- City table has two records: {Id:1, City: Seattle}, {Id:2, City: Green Bay}. 
-- People has three records:
-- {id:1, Name: Aaron Rodgers, City: 2}, {id:2, Name: Russell Wilson, City:1}, {Id: 3, Name: Jody Nelson, City:2}. 

-- Remove city of Seattle. If there was anyone from Seattle, put them into a new city “Madison”. 
-- Create a view “Packers_your_name” lists all people from Green Bay. 
-- If any error occurred, no changes should be made to DB. (after test) Drop both tables and view.

-- Create Tables and Insert Values
CREATE TABLE city_Xu
(   
    Id INT PRIMARY KEY,
    City NVARCHAR(30)
) 
CREATE TABLE people_Xu
(   
    Id INT PRIMARY KEY,
    Name VARCHAR(30),
    CityId INT
    -- CONSTRAINT FK_people_Xu FOREIGN KEY (CityId) REFERENCES city_xu(Id)
) 
INSERT INTO city_Xu (Id, City) VALUES (1, 'Seattle'), (2, 'Green Bay')
INSERT INTO people_Xu (Id, Name, CityId) VALUES (1, 'Aaron Rodgers', 2), (2, 'Russell Wilson', 1), (3, 'Jody Nelson', 2);


-- Test Table Creation
SELECT * FROM city_Xu
SELECT * FROM people_Xu


-- Use TRY and CACHE to make sure if any error occurs no changes should be made to DB
BEGIN TRY
    BEGIN TRANSACTION 

    DELETE FROM city_Xu WHERE City = 'Seattle'

    IF @@ROWCOUNT > 0
    BEGIN
        UPDATE people_Xu SET CityId = 3 WHERE CityId = 1
        INSERT INTO city_Xu VALUES (3, 'Madison')
    END

    COMMIT TRANSACTION
END TRY

BEGIN CATCH
    ROLLBACK TRANSACTION
END CATCH
GO


-- Create VIEW Packers_Chengxu_Xu 
CREATE VIEW Packers_Chengxu_Xu 
AS 
(
    SELECT px.Id, px.Name
    FROM people_Xu px
    JOIN city_Xu cx ON cx.Id = px.CityId
    WHERE City = 'Green Bay'
)
GO


-- test dbo.Packers_Chengxu_Xu
SELECT *
FROM dbo.Packers_Chengxu_Xu
GO


-- Drop tables and view
DROP TABLE dbo.people_Xu;
DROP TABLE dbo.city_Xu;
DROP VIEW dbo.Packers_Chengxu_Xu;
GO


-- 5.       Create a stored procedure “sp_birthday_employees_[you_last_name]” 
-- that creates a new table “birthday_employees_your_last_name” and fill it with all employees that have a birthday on Feb. 
-- (Make a screen shot) drop the table. Employee table should not be affected.

--Create SP 
CREATE PROC sp_birthday_employees_Xu
    @inputMonth INT
    AS
    BEGIN
        CREATE TABLE birthday_employees_Xu(
            Id INT PRIMARY KEY,
            FirstName NVARCHAR(50) NOT NULL,
            LastName NVARCHAR(50) NOT NULL,
            BirthDate DATE NOT NULL
        )

        INSERT INTO birthday_employees_Xu (Id, FirstName, LastName, BirthDate)
        SELECT EmployeeID, FirstName, LastName, BirthDate
        FROM Employees
        WHERE MONTH(BirthDate) = @inputMonth;

    END

-- Execute SP with Febrary
EXEC sp_birthday_employees_Xu 2;

-- Test and drop birthday_employees_Xu table 
SELECT * FROM birthday_employees_Xu
DROP TABLE birthday_employees_Xu



-- 6.      How do you make sure two tables have the same data?
-- Use a UNION to combine the rows from both tables, and then GROUP BY all columns and use the COUNT(*) function to check if the number of rows for each combination of columns is the same.