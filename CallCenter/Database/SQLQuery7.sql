GO
USE SEN381_DATABASE;

go
INSERT INTO ServiceTypes(serviceType, serviceDetails)
VALUES 
('Basic Equipment Inspection', 'A routine check-up service where technicians evaluate the overall health and performance of the client''s equipment. This service ensures that all components are functioning correctly and helps in early detection of potential issues.'),
('Advanced Diagnostic Testing', 'Utilizes specialized tools and software to diagnose deeper issues that might not be apparent in a basic inspection. This service is ideal for clients experiencing specific problems with their equipment or when advanced diagnostic insights are required.'),
('Equipment Calibration', 'Technicians calibrate equipment to ensure optimal performance and accuracy. Regular calibration services are essential for equipment that requires precise measurements or operations.'),
('Emergency Repair Service', 'A priority service catered to clients who experience sudden equipment breakdowns. Technicians are dispatched on an urgent basis to address and resolve the malfunction, minimizing downtime.'),
('Preventive Maintenance Program', 'A comprehensive maintenance plan where technicians perform regular inspections, cleaning, and minor repairs to prevent potential breakdowns and extend the equipment''s lifespan. This service is ideal for clients who want to maintain consistent equipment performance and reduce long-term repair costs.');

Go
-- Step 3: Create some sample Clients
INSERT INTO Clients(clientName, phoneNumber, clientType, lastCallDate, address, clientNotes)
VALUES
('Acme Corp', '1234567891', 'Business', GETDATE(), '123 Acme St, Acme City', 'Good client with regular service needs.'),
('Beton Co.', '1234567892', 'Business', GETDATE(), '456 Beton Rd, Beton City', 'Prefers preventive maintenance.'),
('Charlie Pvt Ltd', '1234567893', 'Business', GETDATE(), '789 Charlie Ave, Charlie Town', 'Regular diagnostics required.'),
('Delta Industries', '1234567894', 'Business', GETDATE(), '012 Delta Blvd, Delta City', 'Frequent equipment calibrations.'),
('Echo Enterprises', '1234567895', 'Business', GETDATE(), '345 Echo Ln, Echo Town', 'New client. Emergency services needed.');


-- Step 12: Add some sample Employees data
INSERT INTO Employees(employeeName, department, emailAddress, phoneNumber)
VALUES
('John Doe', 'Technical Support', 'john.doe@example.com', '123-456-7890'),
('Jane Doe', 'Customer Service', 'jane.doe@example.com', '987-654-3210'),
('Admin User', 'Administration', 'admin.user@example.com', '555-555-5555');