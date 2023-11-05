
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



