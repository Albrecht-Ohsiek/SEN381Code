
GO
USE SEN381_DATABASE;

GO
CREATE PROCEDURE createNewCall
    @callId UNIQUEIDENTIFIER,
    @clientId UNIQUEIDENTIFIER,
    @startTime DATETIME,
    @workId UNIQUEIDENTIFIER = NULL,
    @endTime DATETIME = NULL
AS
BEGIN
    INSERT INTO Calls (callId, clientId, startTime, workId, endTime, employeeId)
    VALUES (@callId, @clientId, @startTime, @workId, @endTime, NULL);
END;

GO
CREATE PROCEDURE updateCallsById
    @callId UNIQUEIDENTIFIER,
    @clientId UNIQUEIDENTIFIER,
    @employeeId UNIQUEIDENTIFIER,
    @workId UNIQUEIDENTIFIER,
    @startTime DATETIME,
    @endTime DATETIME
AS
BEGIN
    UPDATE Calls
    SET clientId = @clientId,
        employeeId = @employeeId,
        workId = @workId,
        startTime = @startTime,
        endTime = @endTime
    WHERE callId = @callId;
END;

GO
CREATE PROCEDURE selectAllCalls
AS
BEGIN
    SELECT callId, clientId, employeeId, workId, startTime, endTime
    FROM Calls;
END;

Go
CREATE PROCEDURE selectCallsById
    @callId UNIQUEIDENTIFIER
AS
BEGIN
    SELECT callId, clientId, employeeId, workId, startTime, endTime
    FROM Calls
    WHERE callId = @callId;
END;

Go
CREATE PROCEDURE selectCallsByClientId
    @clientId UNIQUEIDENTIFIER
AS
BEGIN
    SELECT callId, clientId, employeeId, workId, startTime, endTime
    FROM Calls
    WHERE clientId = @clientId;
END;

Go
CREATE PROCEDURE selectCallsByWorkId
    @workId UNIQUEIDENTIFIER
AS
BEGIN
    SELECT callId, clientId, employeeId, workId, startTime, endTime
    FROM Calls
    WHERE workId = @workId;
END;

Go
CREATE PROCEDURE createEmployeeLogin
    @username NVARCHAR(50),
    @password NVARCHAR(50)
AS
BEGIN
    INSERT INTO EmployeeLogin (employeeId, username, password)
    VALUES (NEWID(), @username, @password);
END

Go
CREATE PROCEDURE updateEmployeeLogin
    @employeeId UNIQUEIDENTIFIER,
    @username NVARCHAR(50),
    @password NVARCHAR(50)
AS
BEGIN
    UPDATE EmployeeLogin
    SET
        username = @username,
        password = @password
    WHERE employeeId = @employeeId;
END


CREATE PROCEDURE selectEmployeLoginByName
    @username NVARCHAR(50)
AS
BEGIN
    SELECT TOP 1 *
    FROM EmployeeLogin
    WHERE username = @username;
END
