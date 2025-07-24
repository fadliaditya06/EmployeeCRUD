IF OBJECT_ID('vw_EmployeeDetails', 'V') IS NOT NULL
    DROP VIEW vw_EmployeeDetails;
GO
IF OBJECT_ID('Employee_dept', 'U') IS NOT NULL
    DROP TABLE Employee_dept;
GO
IF OBJECT_ID('Employee', 'U') IS NOT NULL
    DROP TABLE Employee;
GO
IF OBJECT_ID('Department', 'U') IS NOT NULL
    DROP TABLE Department;
GO
IF OBJECT_ID('Gender', 'U') IS NOT NULL
    DROP TABLE Gender;
GO


GO

CREATE TABLE Gender (
    Gender CHAR(1) PRIMARY KEY,
    Gender_nm VARCHAR(10) NOT NULL
);

CREATE TABLE Department (
    Department_code VARCHAR(10) PRIMARY KEY,
    Department VARCHAR(100) NOT NULL 
);

CREATE TABLE Employee (
    [SESA ID] VARCHAR(10) PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Birth_date DATE NOT NULL,
    Gender CHAR(1) NOT NULL,
    FOREIGN KEY (Gender) REFERENCES Gender(Gender)
);

CREATE TABLE Employee_dept (
    [SESA ID] VARCHAR(10) PRIMARY KEY,
    Department_code VARCHAR(10) NOT NULL,
    FOREIGN KEY ([SESA ID]) REFERENCES Employee([SESA ID]) ON DELETE CASCADE,
    FOREIGN KEY (Department_code) REFERENCES Department(Department_code)
);
GO


GO

INSERT INTO Gender (Gender, Gender_nm) VALUES
('F', 'Female'),
('M', 'Male');

INSERT INTO Department (Department_code, Department) VALUES
('DT', 'Digital Transformation'),
('FIN', 'Finance'),
('HR', 'Human Resources');

INSERT INTO Employee ([SESA ID], Name, Birth_date, Gender) VALUES
('SESA112233', 'ORTEGA, William', '2021-03-23', 'M'),
('SESA112234', 'DIEGO, Mark Anthony', '2020-01-24', 'M'),
('SESA112235', 'MARTINEZ, Rebecca', '2018-10-25', 'F');

INSERT INTO Employee_dept ([SESA ID], Department_code) VALUES
('SESA112233', 'DT'),
('SESA112234', 'FIN'),
('SESA112235', 'HR');
GO

GO

CREATE VIEW vw_EmployeeDetails AS
SELECT
    e.[SESA ID],
    e.Name,
    g.Gender_nm AS Gender,
    d.Department,
    e.Birth_date
FROM
    Employee e
JOIN
    Employee_dept ed ON e.[SESA ID] = ed.[SESA ID]
JOIN
    Department d ON ed.Department_code = d.Department_code
JOIN
    Gender g ON e.Gender = g.Gender;
GO

GO
