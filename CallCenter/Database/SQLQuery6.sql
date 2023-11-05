GO
USE SEN381_DATABASE;

Go
CREATE PROCEDURE createNewCallReport
    @callReportId UNIQUEIDENTIFIER,
    @workId UNIQUEIDENTIFIER,
    @calls NVARCHAR(MAX)
AS
BEGIN
    INSERT INTO CallReports (callReportId, workId, calls)
    VALUES (@callReportId, @workId, @calls);
END;

go
CREATE PROCEDURE updateCallReport
    @callReportId UNIQUEIDENTIFIER,
    @calls NVARCHAR(MAX)
AS
BEGIN
    UPDATE CallReports
    SET calls = @calls
    WHERE callReportId = @callReportId;
END;

go
CREATE PROCEDURE getAllCallReports
AS
BEGIN
    SELECT callReportId, workId, calls
    FROM CallReports;
END;

go
CREATE PROCEDURE getAllCallReportsById
    @callReportId UNIQUEIDENTIFIER
AS
BEGIN
    SELECT callReportId, workId, calls
    FROM CallReports
    WHERE callReportId = @callReportId;
END;

go
CREATE PROCEDURE getAllCallReportsByWorkId
    @workId UNIQUEIDENTIFIER
AS
BEGIN
    SELECT callReportId, workId, calls
    FROM CallReports
    WHERE workId = @workId;
END;

Go
CREATE PROCEDURE createClient
    @clientId UNIQUEIDENTIFIER,
    @clientName NVARCHAR(50),
    @phoneNumber NVARCHAR(15),
    @clientType NVARCHAR(50),
    @address NVARCHAR(255),
    @lastCallDate DATETIME,
    @clientNotes NVARCHAR(MAX)
AS
BEGIN
    INSERT INTO Clients (clientId, clientName, phoneNumber, clientType, address, lastCallDate, clientNotes)
    VALUES (@clientId, @clientName, @phoneNumber, @clientType, @address, @lastCallDate, @clientNotes);
END;

go
CREATE PROCEDURE updateClient
    @clientId UNIQUEIDENTIFIER,
    @clientName NVARCHAR(50),
    @phoneNumber NVARCHAR(15),
    @clientType NVARCHAR(50),
    @address NVARCHAR(255),
    @lastCallDate DATETIME,
    @clientNotes NVARCHAR(MAX)
AS
BEGIN
    UPDATE Clients
    SET clientName = @clientName,
        phoneNumber = @phoneNumber,
        clientType = @clientType,
        address = @address,
        lastCallDate = @lastCallDate,
        clientNotes = @clientNotes
    WHERE clientId = @clientId;
END;

go
CREATE PROCEDURE selectAllClients
AS
BEGIN
    SELECT clientId, clientName, phoneNumber, clientType, address, lastCallDate, clientNotes
    FROM Clients;
END;

go
CREATE PROCEDURE selectClientById
    @clientId UNIQUEIDENTIFIER
AS
BEGIN
    SELECT clientId, clientName, phoneNumber, clientType, address, lastCallDate, clientNotes
    FROM Clients
    WHERE clientId = @clientId;
END;

go
CREATE PROCEDURE selectClientByName
    @clientName NVARCHAR(50)
AS
BEGIN
    SELECT clientId, clientName, phoneNumber, clientType, address, lastCallDate, clientNotes
    FROM Clients
    WHERE clientName = @clientName;
END;

go
CREATE PROCEDURE selectClientByPhone
    @phoneNumber NVARCHAR(15)
AS
BEGIN
    SELECT clientId, clientName, phoneNumber, clientType, address, lastCallDate, clientNotes
    FROM Clients
    WHERE phoneNumber = @phoneNumber;
END;

go
CREATE PROCEDURE createContract
    @contractID UNIQUEIDENTIFIER,
    @clientId UNIQUEIDENTIFIER,
    @contractType NVARCHAR(50),
    @contractDetails NVARCHAR(MAX),
    @serviceLevel NVARCHAR(50),
    @contractStatus NVARCHAR(50)
AS
BEGIN
    INSERT INTO Contracts (contractId, clientId, contractType, contractDetails, serviceLevel, contractStatus)
    VALUES (@contractID, @clientId, @contractType, @contractDetails, @serviceLevel, @contractStatus);
END;

go
CREATE PROCEDURE updateContract
    @contractID UNIQUEIDENTIFIER,
    @clientId UNIQUEIDENTIFIER,
    @contractType NVARCHAR(50),
    @contractDetails NVARCHAR(MAX),
    @serviceLevel NVARCHAR(50),
    @contractStatus NVARCHAR(50)
AS
BEGIN
    UPDATE Contracts
    SET clientId = @clientId,
        contractType = @contractType,
        contractDetails = @contractDetails,
        serviceLevel = @serviceLevel,
        contractStatus = @contractStatus
    WHERE contractId = @contractID;
END;

go
CREATE PROCEDURE selectAllContracts
AS
BEGIN
    SELECT contractId, clientId, contractType, contractDetails, serviceLevel, contractStatus
    FROM Contracts;
END;

go
CREATE PROCEDURE selectContractById
    @contractId UNIQUEIDENTIFIER
AS
BEGIN
    SELECT contractId, clientId, contractType, contractDetails, serviceLevel, contractStatus
    FROM Contracts
    WHERE contractId = @contractId;
END;

go
CREATE PROCEDURE selectContractByClientId
    @clientId UNIQUEIDENTIFIER
AS
BEGIN
    SELECT contractId, clientId, contractType, contractDetails, serviceLevel, contractStatus
    FROM Contracts
    WHERE clientId = @clientId;
END;

go
CREATE PROCEDURE selectContractByServiceLevel
    @serviceLevel NVARCHAR(50)
AS
BEGIN
    SELECT contractId, clientId, contractType, contractDetails, serviceLevel, contractStatus
    FROM Contracts
    WHERE serviceLevel = @serviceLevel;
END;

go
CREATE PROCEDURE selectContractByContractStatus
    @contractStatus NVARCHAR(50)
AS
BEGIN
    SELECT contractId, clientId, contractType, contractDetails, serviceLevel, contractStatus
    FROM Contracts
    WHERE contractStatus = @contractStatus;
END;

go
CREATE PROCEDURE createEmployee
    @employeeId UNIQUEIDENTIFIER,
    @employeeName NVARCHAR(50),
    @department NVARCHAR(50),
    @emailAddress NVARCHAR(255),
    @phoneNumber NVARCHAR(15)
AS
BEGIN
    INSERT INTO Employees (employeeId, employeeName, department, emailAddress, phoneNumber)
    VALUES (@employeeId, @employeeName, @department, @emailAddress, @phoneNumber);
END;

go
CREATE PROCEDURE updateEmployee
    @employeeId UNIQUEIDENTIFIER,
    @employeeName NVARCHAR(50),
    @department NVARCHAR(50),
    @emailAddress NVARCHAR(255),
    @phoneNumber NVARCHAR(15)
AS
BEGIN
    UPDATE Employees
    SET employeeName = @employeeName,
        department = @department,
        emailAddress = @emailAddress,
        phoneNumber = @phoneNumber
    WHERE employeeId = @employeeId;
END;

go
CREATE PROCEDURE selectAllEmployees
AS
BEGIN
    SELECT employeeId, employeeName, department, emailAddress, phoneNumber
    FROM Employees;
END;

go
CREATE PROCEDURE selectEmployeeById
    @employeeId UNIQUEIDENTIFIER
AS
BEGIN
    SELECT employeeId, employeeName, department, emailAddress, phoneNumber
    FROM Employees
    WHERE employeeId = @employeeId;
END;

go
CREATE PROCEDURE selectEmployeeByName
    @employeeName NVARCHAR(50)
AS
BEGIN
    SELECT employeeId, employeeName, department, emailAddress, phoneNumber
    FROM Employees
    WHERE employeeName = @employeeName;
END;

go
CREATE PROCEDURE selectEmployeeByPhoneNumber
    @phoneNumber NVARCHAR(15)
AS
BEGIN
    SELECT employeeId, employeeName, department, emailAddress, phoneNumber
    FROM Employees
    WHERE phoneNumber = @phoneNumber;
END;

go
CREATE PROCEDURE createRequestLog
    @requestId UNIQUEIDENTIFIER,
    @clientId UNIQUEIDENTIFIER,
    @lastCallDate DATETIME,
    @callDuration FLOAT,
    @technicianId UNIQUEIDENTIFIER,
    @priorityLevel NVARCHAR(50),
    @status NVARCHAR(50)
AS
BEGIN
    INSERT INTO RequestLog (requestId, clientId, lastCallDate, callDuration, technicianId, priorityLevel, requestStatus)
    VALUES (@requestId, @clientId, @lastCallDate, @callDuration, @technicianId, @priorityLevel, @status);
END;

go
CREATE PROCEDURE updateRequestLog
    @requestId UNIQUEIDENTIFIER,
    @clientId UNIQUEIDENTIFIER,
    @lastCallDate DATETIME,
    @callDuration FLOAT,
    @technicianId UNIQUEIDENTIFIER,
    @priorityLevel NVARCHAR(50),
    @status NVARCHAR(50)
AS
BEGIN
    UPDATE RequestLog
    SET clientId = @clientId,
        lastCallDate = @lastCallDate,
        callDuration = @callDuration,
        technicianId = @technicianId,
        priorityLevel = @priorityLevel,
        requestStatus = @status
    WHERE requestId = @requestId;
END;

go
CREATE PROCEDURE selectAllRequestLogs
AS
BEGIN
    SELECT requestId, clientId, lastCallDate, callDuration, technicianId, priorityLevel, requestStatus
    FROM RequestLog;
END;

go
CREATE PROCEDURE selectRequestLogById
    @requestId UNIQUEIDENTIFIER
AS
BEGIN
    SELECT requestId, clientId, lastCallDate, callDuration, technicianId, priorityLevel, requestStatus
    FROM RequestLog
    WHERE requestId = @requestId;
END;

go
CREATE PROCEDURE selectRequestLogByClientId
    @clientId UNIQUEIDENTIFIER
AS
BEGIN
    SELECT requestId, clientId, lastCallDate, callDuration, technicianId, priorityLevel, requestStatus
    FROM RequestLog
    WHERE clientId = @clientId;
END;

go
CREATE PROCEDURE selectRequestLogByTechnicianName
    @technicianId UNIQUEIDENTIFIER
AS
BEGIN
    SELECT requestId, clientId, lastCallDate, callDuration, technicianId, priorityLevel, requestStatus
    FROM RequestLog
    WHERE technicianId = @technicianId;
END;

go
CREATE PROCEDURE selecRequestLogByPriority
    @priorityLevel NVARCHAR(50)
AS
BEGIN
    SELECT requestId, clientId, lastCallDate, callDuration, technicianId, priorityLevel, requestStatus
    FROM RequestLog
    WHERE priorityLevel = @priorityLevel;
END;

go
CREATE PROCEDURE selecRequestLogByStatus
    @status NVARCHAR(50)
AS
BEGIN
    SELECT requestId, clientId, lastCallDate, callDuration, technicianId, priorityLevel, requestStatus
    FROM RequestLog
    WHERE requestStatus = @status;
END;

go
CREATE PROCEDURE addTechnician
    @technicianId UNIQUEIDENTIFIER,
    @employeeId UNIQUEIDENTIFIER,
    @skillLevel INT,
    @availability BIT,
    @serviceArea NVARCHAR(255),
    @certificationLevel NVARCHAR(50)
AS
BEGIN
    INSERT INTO Technicians (technicianId, employeeId, skillLevel, availability, serviceArea, certificationLevel)
    VALUES (@technicianId, @employeeId, @skillLevel, @availability, @serviceArea, @certificationLevel);
END;

go
CREATE PROCEDURE updateTechnician
    @technicianId UNIQUEIDENTIFIER,
    @employeeId UNIQUEIDENTIFIER,
    @skillLevel INT,
    @availability BIT,
    @serviceArea NVARCHAR(255),
    @certificationLevel NVARCHAR(50)
AS
BEGIN
    UPDATE Technicians
    SET employeeId = @employeeId,
        skillLevel = @skillLevel,
        availability = @availability,
        serviceArea = @serviceArea,
        certificationLevel = @certificationLevel
    WHERE technicianId = @technicianId;
END;

go
CREATE PROCEDURE selectAllTechnicians
AS
BEGIN
    SELECT technicianId, employeeId, skillLevel, availability, serviceArea, certificationLevel
    FROM Technicians;
END;

go
CREATE PROCEDURE selectTechnicianById
    @technicianId UNIQUEIDENTIFIER
AS
BEGIN
    SELECT technicianId, employeeId, skillLevel, availability, serviceArea, certificationLevel
    FROM Technicians
    WHERE technicianId = @technicianId;
END;

go
CREATE PROCEDURE selectTechnicianByEmployeeId
    @employeeId UNIQUEIDENTIFIER
AS
BEGIN
    SELECT technicianId, employeeId, skillLevel, availability, serviceArea, certificationLevel
    FROM Technicians
    WHERE employeeId = @employeeId;
END;

go
CREATE PROCEDURE selectTechnicianBySkillLevel
    @skillLevel INT
AS
BEGIN
    SELECT technicianId, employeeId, skillLevel, availability, serviceArea, certificationLevel
    FROM Technicians
    WHERE skillLevel = @skillLevel;
END;

go
CREATE PROCEDURE selectTechnicianByServiceArea
    @serviceArea NVARCHAR(255)
AS
BEGIN
    SELECT technicianId, employeeId, skillLevel, availability, serviceArea, certificationLevel
    FROM Technicians
    WHERE serviceArea = @serviceArea;
END;

go
CREATE PROCEDURE selectTechnicianByAvailability
    @availability BIT
AS
BEGIN
    SELECT technicianId, employeeId, skillLevel, availability, serviceArea, certificationLevel
    FROM Technicians
    WHERE availability = @availability;
END;

go
CREATE PROCEDURE selectTechnicianByCertificationLevel
    @certificationLevel NVARCHAR(50)
AS
BEGIN
    SELECT technicianId, employeeId, skillLevel, availability, serviceArea, certificationLevel
    FROM Technicians
    WHERE certificationLevel = @certificationLevel;
END;


go
CREATE PROCEDURE createWork
    @workId UNIQUEIDENTIFIER,
    @technicianId UNIQUEIDENTIFIER,
    @workDate DATETIME
AS
BEGIN
    INSERT INTO Work (workId, technicianId, workDate)
    VALUES (@workId, @technicianId, @workDate);
END;

go
CREATE PROCEDURE updateWork
    @workId UNIQUEIDENTIFIER,
    @technicianId UNIQUEIDENTIFIER,
    @workDate DATETIME
AS
BEGIN
    UPDATE Work
    SET technicianId = @technicianId,
        workDate = @workDate
    WHERE workId = @workId;
END;

go
CREATE PROCEDURE selectAllWorks
AS
BEGIN
    SELECT workId, technicianId, workDate
    FROM Work;
END;

go
CREATE PROCEDURE selectWorkById
    @workId UNIQUEIDENTIFIER
AS
BEGIN
    SELECT workId, technicianId, workDate
    FROM Work
    WHERE workId = @workId;
END;

go
CREATE PROCEDURE selectWorkByTechnicianId
    @technicianId UNIQUEIDENTIFIER
AS
BEGIN
    SELECT workId, technicianId, workDate
    FROM Work
    WHERE technicianId = @technicianId;
END;

go
CREATE PROCEDURE createWorkRequest
    @requestId UNIQUEIDENTIFIER,
    @clientId UNIQUEIDENTIFIER,
    @serviceType NVARCHAR(50),
    @priority NVARCHAR(50),
    @status NVARCHAR(50)
AS
BEGIN
    INSERT INTO WorkRequests (requestId, clientId, serviceType, priority, status)
    VALUES (@requestId, @clientId, @serviceType, @priority, @status);
END;

go
CREATE PROCEDURE updateWorkRequest
    @requestId UNIQUEIDENTIFIER,
    @clientId UNIQUEIDENTIFIER,
    @serviceType NVARCHAR(50),
    @priority NVARCHAR(50),
    @status NVARCHAR(50)
AS
BEGIN
    UPDATE WorkRequests
    SET clientId = @clientId,
        serviceType = @serviceType,
        priority = @priority,
        status = @status
    WHERE requestId = @requestId;
END;

go
CREATE PROCEDURE selectAllWorkRequests
AS
BEGIN
    SELECT requestId, clientId, serviceType, priority, status
    FROM WorkRequests;
END;

go
CREATE PROCEDURE selectWorkRequestById
    @requestId UNIQUEIDENTIFIER
AS
BEGIN
    SELECT requestId, clientId, serviceType, priority, status
    FROM WorkRequests
    WHERE requestId = @requestId;
END;

go
CREATE PROCEDURE selectWorkRequestByClientId
    @clientId UNIQUEIDENTIFIER
AS
BEGIN
    SELECT requestId, clientId, serviceType, priority, status
    FROM WorkRequests
    WHERE clientId = @clientId;
END;

go
CREATE PROCEDURE selectWorkRequestByPriority
    @priority NVARCHAR(50)
AS
BEGIN
    SELECT requestId, clientId, serviceType, priority, status
    FROM WorkRequests
    WHERE priority = @priority;
END;

go
CREATE PROCEDURE selectWorkRequestByServiceType
    @serviceType NVARCHAR(50)
AS
BEGIN
    SELECT requestId, clientId, serviceType, priority, status
    FROM WorkRequests
    WHERE serviceType = @serviceType;
END;

go
CREATE PROCEDURE selectWorkRequestByStatus
    @status NVARCHAR(50)
AS
BEGIN
    SELECT requestId, clientId, serviceType, priority, status
    FROM WorkRequests
    WHERE status = @status;
END;
