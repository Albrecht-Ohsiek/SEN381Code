IF DB_ID('SEN381_DATABASE') IS NOT NULL
    print 'Database Exists';
ELSE
    CREATE DATABASE SEN381_DATABASE;

GO
USE SEN381_DATABASE;

GO
DECLARE @dropTables BIT = 0; --set to 1 to drop all tables

BEGIN

-- EmployeeLogin
IF EXISTS (SELECT 1 FROM sys.tables WHERE name = 'EmployeeLogin')
    IF @dropTables = 1
        DROP TABLE EmployeeLogin
    ELSE
        PRINT 'EmployeeLogin Table already exists';
ELSE
    CREATE TABLE EmployeeLogin (
        employeeId Uniqueidentifier PRIMARY KEY,
        username NVARCHAR(50) NOT NULL,
        password NVARCHAR(50) NOT NULL
    );

-- Employees
IF EXISTS (SELECT 1 FROM sys.tables WHERE name = 'Employees')
    IF @dropTables = 1
        DROP TABLE Employees
    ELSE
        PRINT 'Employees Table already exists';
ELSE
CREATE TABLE Employees(
    employeeId Uniqueidentifier PRIMARY KEY DEfault NEWID(),
    employeeName NVARCHAR(50),
    department NVARCHAR(50),
    emailAddress NVARCHAR(255),
    phoneNumber NVARCHAR(15)
);

-- ServiceTypes
IF EXISTS (SELECT 1 FROM sys.tables WHERE name = 'ServiceTypes')
    IF @dropTables = 1
        DROP TABLE ServiceTypes
    ELSE
        PRINT 'ServiceTypes Table already exists';
ELSE
    CREATE TABLE ServiceTypes(
        serviceTypeId Uniqueidentifier PRIMARY KEY DEfault NEWID(),
        serviceType NVARCHAR(50),
        serviceDetails NVARCHAR(MAX)
    );

-- Technicians
IF EXISTS (SELECT 1 FROM sys.tables WHERE name = 'Technicians')
    IF @dropTables = 1
        DROP TABLE Technicians
    ELSE
        PRINT 'Technicians Table already exists';
ELSE
    CREATE TABLE Technicians(
        technicianId Uniqueidentifier PRIMARY KEY DEfault NEWID(),
        employeeId Uniqueidentifier FOREIGN KEY REFERENCES Employees(employeeId),
        skillLevel int,
		availability BIT,
		serviceArea NVARCHAR(255),
		certificationLevel NVARCHAR(50)
    );

-- Clients
IF EXISTS (SELECT 1 FROM sys.tables WHERE name = 'Clients')
    IF @dropTables = 1
        DROP TABLE Clients
    ELSE
        PRINT 'Clients Table already exists';
ELSE
    CREATE TABLE Clients(
        clientId Uniqueidentifier PRIMARY KEY DEfault NEWID(),
        clientName NVARCHAR(50),
        phoneNumber NVARCHAR(15),
        clientType NVARCHAR(50),
		contracts NVARCHAR(MAX),
		address NVARCHAR(255),
        lastCallDate DATETIME,    
        clientNotes NVARCHAR(MAX),
    );

-- WorkRequests
IF EXISTS (SELECT 1 FROM sys.tables WHERE name = 'WorkRequests')
    IF @dropTables = 1
        DROP TABLE WorkRequests
    ELSE
        PRINT 'WorkRequests Table already exists';
ELSE
    CREATE TABLE WorkRequests(
        requestId Uniqueidentifier PRIMARY KEY DEfault NEWID(),
        clientId Uniqueidentifier FOREIGN KEY REFERENCES Clients(clientId),
        serviceType NVARCHAR(50),
        priority NVARCHAR(50),
        status NVARCHAR(50)
    );

-- Work
IF EXISTS (SELECT 1 FROM sys.tables WHERE name = 'Work')
    IF @dropTables = 1
        DROP TABLE Work
    ELSE
        PRINT 'Work Table already exists';
ELSE
    CREATE TABLE Work(
        workId Uniqueidentifier PRIMARY KEY DEfault NEWID(),
        technicianId Uniqueidentifier FOREIGN KEY REFERENCES Technicians(technicianId),
        workDate DATETIME
    );

-- Calls
IF EXISTS (SELECT 1 FROM sys.tables WHERE name = 'Calls')
    IF @dropTables = 1
        DROP TABLE Calls
    ELSE
        PRINT 'Calls Table already exists';
ELSE
    CREATE TABLE Calls(
        callId Uniqueidentifier PRIMARY KEY DEfault NEWID(),
        clientId Uniqueidentifier FOREIGN KEY REFERENCES Clients(clientId),
        employeeId Uniqueidentifier FOREIGN KEY REFERENCES Employees(employeeId),
        workId Uniqueidentifier FOREIGN KEY REFERENCES Work(workId),
        startTime DATETIME,
        endTime DATETIME
    );

-- CallReports
IF EXISTS (SELECT 1 FROM sys.tables WHERE name = 'CallReports')
    IF @dropTables = 1
        DROP TABLE CallReports
    ELSE
        PRINT 'CallReports Table already exists';
ELSE
    CREATE TABLE CallReports(
        callReportId Uniqueidentifier PRIMARY KEY DEfault NEWID(),
        workId Uniqueidentifier FOREIGN KEY REFERENCES Work(workId),
        calls NVARCHAR(MAX)
    );

-- ClientRequests
IF EXISTS (SELECT 1 FROM sys.tables WHERE name = 'RequestLog')
    IF @dropTables = 1
        DROP TABLE RequestLog
    ELSE
        PRINT 'RequestLog Table already exists';
ELSE
    CREATE TABLE RequestLog(
        requestId Uniqueidentifier PRIMARY KEY DEfault NEWID(),
        clientId Uniqueidentifier FOREIGN KEY REFERENCES Clients(clientId),
        technicianId Uniqueidentifier FOREIGN KEY REFERENCES Technicians(technicianId),
		lastCallDate DATETIME,
		callDuration FLOAT,
		priorityLevel NVARCHAR(50),
		requestStatus NVARCHAR(50)
    );

-- Contracts
IF EXISTS (SELECT 1 FROM sys.tables WHERE name = 'Contracts')
    IF @dropTables = 1
        DROP TABLE Contracts
    ELSE
        PRINT 'Contracts Table already exists';
ELSE
    CREATE TABLE Contracts(
        contractId Uniqueidentifier PRIMARY KEY DEfault NEWID(),
        clientId Uniqueidentifier FOREIGN KEY REFERENCES Clients(clientId),
        contractType NVARCHAR(50),
        contractDetails NVARCHAR(MAX),
        serviceLevel NVARCHAR(50),
        contractStatus NVARCHAR(50)
    );

END
