GO
USE SEN381_DATABASE;

INSERT INTO Work(technicianId, workDate)
VALUES
('135C1E18-9EF5-493D-A87C-B4AC2FF9EEDD', GETDATE()),
('9C243AF9-6835-4315-B95F-C60C394641DF', GETDATE()),
('135C1E18-9EF5-493D-A87C-B4AC2FF9EEDD', DATEADD(HOUR, 1, GETDATE())),
('9C243AF9-6835-4315-B95F-C60C394641DF', DATEADD(HOUR, 1, GETDATE()));

INSERT INTO WorkRequests(clientId, serviceType, priority, status)
VALUES
('E5AE2A1B-328D-4BE5-9099-25E1259E2C31', 'Equipment Calibration', 'low', 'open'),
('E5AE2A1B-328D-4BE5-9099-25E1259E2C31', 'Preventive Maintenance Program', 'high', 'pending'),
('7EED4169-A80C-4290-A44D-40152A0B2CCA', 'Equipment Calibration', 'low', 'pending'),
('36F61727-F92D-41C0-A560-4CE6A0E06526', 'Emergency Repair Service', 'medium', 'completed');

INSERT INTO Contracts(clientId, contractType, contractDetails, serviceLevel, contractStatus)
VALUES
('E5AE2A1B-328D-4BE5-9099-25E1259E2C31', 'Basic Maintenance Plan', 'This foundational contract offers routine equipment check-ups...', 'Regular', 'Active'),
('D6CC15A2-56AF-4C8A-8BF4-2BBD211F8757', 'Premium Support Plan', 'Designed for businesses that can''t afford extended downtimes...', 'Priority', 'Active'),
('7EED4169-A80C-4290-A44D-40152A0B2CCA', 'Comprehensive Coverage Plan', 'Our all-inclusive package! Covers routine maintenance...', 'Priority', 'Inactive'),
('36F61727-F92D-41C0-A560-4CE6A0E06526', 'Seasonal Tune-Up Plan', 'This contract is tailored for clients with equipment...', 'Regular', 'Active'),
('061C8226-CE35-45E2-82DE-919676077078', 'Customizable Service Plan', 'For clients with unique needs...', 'Regular', 'Active');

INSERT INTO EmployeeLogin(employeeId, username, password)
VALUES
('FE12742B-984A-4751-B632-4DB9E0DC5F3D', 'john_doe', 'password1'),
('F2C3A199-C2C6-4232-AA46-9C0920E1D50A', 'jane_doe', 'password2'),
('8EF87849-67DF-4FFC-997F-D7C56095473B', 'admin_user', 'admin_password');