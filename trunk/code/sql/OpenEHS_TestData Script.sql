/***********************************************
~~~~~~~This Script is only for test data~~~~~~~
***********************************************/

USE OpenEHS_database;

#--------------------------------------------------------------------------------------------------------------
#-------------------------------------------------Stored Procs-------------------------------------------------
#--------------------------------------------------------------------------------------------------------------


#--------------Delete Patient Table--------------
/************************************
* sp_deletePatient updates
* Patient IsActive to 0. Must pass 
* patientID.
************************************/

DELIMITER |
CREATE PROCEDURE sp_deletePatient
(
IN i_Patient        int
)

BEGIN

UPDATE Patient SET
IsActive = 0
WHERE i_PatientID = PatientID;

END ||
DELIMITER ;

#--------------Insert Staff Table--------------
/************************************
* sp_insertStaff inserts into 
* Staff table.
************************************/

DELIMITER | 
CREATE PROCEDURE sp_insertStaff
(
IN i_Street1                varchar(30),
IN i_Street2                varchar(30),
IN i_City                   varchar(30),
IN i_Region                 varchar(30),
IN i_Country                varchar(30),
IN i_UserName               varchar(30),
IN i_Password               varchar(30),
IN i_LIP                    char(1),
IN i_FirstName              varchar(30),
IN i_MiddleName             varchar(30),
IN i_LastName               varchar(30),
IN i_PhoneNumber            varchar(20),
IN i_StaffType              tinyint(1),
IN i_LN                     varchar(20)
)

BEGIN

DECLARE _returnAddID int;
DECLARE _returnUserID int;

INSERT INTO Address
(
Street1,
Street2,
City,
Region,
Country
)
VALUES
(
i_Street1,
i_Street2,
i_City,
i_Region,
i_Country
);

SELECT LAST_INSERT_ID() INTO _returnAddID;

INSERT INTO User
(
UserName,
`Password`
)
VALUES
(
i_UserName,
i_Password
);

SELECT LAST_INSERT_ID() INTO _returnUserID;

INSERT INTO Staff
(
FirstName,
MiddleName,
LastName,
PhoneNumber,
StaffType,
LicenseNumber,
AddressID,
UserID
)
VALUES
(
i_FirstName,
i_MiddleName,
i_LastName,
i_PhoneNumber,
i_StaffType,
i_LN,
_returnAddID,
_returnUserID
);

END ||
DELIMITER ;

#--------------Update Staff Table--------------
/************************************
* sp_updateStaff updates into 
* Staff table.
************************************/

DELIMITER | 
CREATE PROCEDURE sp_updateStaff
(
IN i_StaffID                int,
IN i_Street1                varchar(30),
IN i_Street2                varchar(30),
IN i_City                   varchar(30),
IN i_Region                 varchar(30),
IN i_Country                varchar(30),
IN i_UserName               varchar(30),
IN i_Password               varchar(30),
IN i_FirstName              varchar(30),
IN i_MiddleName             varchar(30),
IN i_LastName               varchar(30),
IN i_PhoneNumber            varchar(20),
IN i_StaffType              tinyint(1),
IN i_LN                     varchar(20)
)

BEGIN

DECLARE _AddressID  int;
DECLARE _UserID    int;

SELECT AddressID FROM Staff WHERE StaffID = i_StaffID INTO _AddressID;

SELECT UserID FROM Staff WHERE StaffID = i_StaffID INTO _UserID;

UPDATE Address SET
Street1 = i_Street1,
Street2 = i_Street2,
City = i_City,
Region = i_Region,
Country = i_Country
WHERE _AddressID = AddressID;

UPDATE User SET
UserName = i_UserName,
Password = i_Password
WHERE _UserID = UserID;

UPDATE Staff SET
FirstName = i_Firstname,
MiddleName = i_MiddleName,
LastName = i_LastName,
PhoneNumber = i_PhoneNumber,
StaffType = i_StaffType,
LicenseNumber = i_LN
WHERE i_StaffID = StaffID;

END ||
DELIMITER ;

#--------------Delete(update) Staff Table--------------
/************************************
* sp_deleteStaff deletes(update) into 
* Staff table changing IsActive to 0.
************************************/

DELIMITER | 
CREATE PROCEDURE sp_deleteStaff
(
IN i_StaffID    int
)

BEGIN

UPDATE Staff SET
IsActive = 0
WHERE i_StaffID = StaffID;

END ||
DELIMITER ;

#--------------Update EmergencyContact Table--------------
/************************************
* sp_updateEmergencyContact updates
* EmergencyContact table. Must pass 
* patientID.
************************************/

DELIMITER |
CREATE PROCEDURE sp_updateEmergencyContact
(
IN i_Street1        varchar(30),
IN i_Street2        varchar(30),
IN i_City           varchar(30),
IN i_Region         varchar(30),
IN i_Country        varchar(30),
IN i_PatientID      int,
IN i_FirstName      varchar(30),
IN i_LastName       varchar(30),
IN i_PhoneNumber    varchar(20),
IN i_Relationship   bit(3)
)

BEGIN

DECLARE _AddressID      int;

SELECT AddressID FROM EmergencyContact WHERE PatientID = i_PatientID INTO _AddressID;

UPDATE Address SET
Street1 = i_Street1,
Street2 = i_Street2,
City = i_City,
Region = i_Region,
Country = i_Country
WHERE _AddressID = AddressID;

UPDATE EmergencyContact SET
FirstName = i_FirstName,
LastName = i_LastName,
PhoneNumber = i_PhoneNumber,
Relationship = i_Relationship
WHERE i_PatientID = PatientID;

END ||
DELIMITER ;


#--------------Update Invoice Table--------------
/************************************
* sp_updateInvoice updates into 
* Service table after invoice amount
* has been calculated.
************************************/

DELIMITER |
CREATE PROCEDURE sp_updateInvoice
(
IN i_InvoiceID      int,
IN i_Total          decimal(6,2)
)

BEGIN

UPDATE Invoice SET
Total = i_Total
WHERE i_InvoiceID = InvoiceID;

END ||
DELIMITER ;

#--------------insert Service Table--------------
/************************************
* sp_insertService inserts into the
* Service table.
************************************/

DELIMITER | 
CREATE PROCEDURE sp_insertService
(
IN i_Name           varchar(30),
IN i_ServiceCost    decimal(6, 2)
)

BEGIN

INSERT INTO Service
(
Name,
ServiceCost
)
VALUES
(
i_Name,
i_ServiceCost
);

END ||
DELIMITER ;

#--------------update Service Table--------------
/************************************
* sp_updateService updates the
* Service table.
************************************/

DELIMITER | 
CREATE PROCEDURE sp_updateService
(
IN i_ServiceID      int,
IN i_Name           varchar(30),
IN i_ServiceCost    decimal(6, 2)
)

BEGIN

UPDATE Service SET
Name = i_Name,
ServiceCost = i_ServiceCost
WHERE ServiceID = i_ServiceID;

END ||
DELIMITER ;

#--------------delete Service Table--------------
/************************************
* sp_deleteService deletes(updates)
* Service table IsActice to 0.
************************************/

DELIMITER | 
CREATE PROCEDURE sp_deleteService
(
IN i_ServiceID      int
)

BEGIN

UPDATE Service SET
IsActice = 0
WHERE ServiceID = i_ServiceID;

END ||
DELIMITER ;

#--------------insert Products Table--------------
/************************************
* sp_insertProducts inserts into the
* Products table.
************************************/

DELIMITER | 
CREATE PROCEDURE sp_insertProduct
(
IN i_Name               varchar(30),
IN i_Unit               varchar(10),
IN i_CategoryID         int,
IN i_ProductCost        decimal(6, 2),
IN i_QuantityOnHand     int
)

BEGIN

INSERT INTO Product
(
Name,
Unit,
CategoryID,
ProductCost,
QuantityOnHand
)
VALUES
(
i_Name,
i_Unit,
i_CategoryID,
i_ProductCost,
i_QuantityOnHand
);

END ||
DELIMITER ;

#--------------update Products Table--------------
/************************************
* sp_updateProducts updates the
* Service table.
************************************/

DELIMITER | 
CREATE PROCEDURE sp_updateProduct
(
IN i_ProductID          int,
IN i_Name               varchar(30),
IN i_Unit               varchar(10),
IN i_CategoryID         int,
IN i_ProductCost        decimal(6, 2),
IN i_QuantityOnHand     int
)

BEGIN

UPDATE Product SET
Name = i_Name,
Unit = i_Unit,
CategoryID = i_CategoryID,
ProductCost = i_ProductCost,
QuantityOnHand = i_QuantityOnHand
WHERE ProductID = i_ProductID;

END ||
DELIMITER ;

#--------------delete Product Table--------------
/************************************
* sp_deleteService deletes(updates)
* Service table IsActice to 0.
************************************/

DELIMITER | 
CREATE PROCEDURE sp_deleteProduct
(
IN i_ProductID      int
)

BEGIN

UPDATE Product SET
IsActice = 0
WHERE ProductID = i_ProductID;

END ||
DELIMITER ;

#--------------insert Payment/Updates Invoice Table--------------
/************************************
* sp_insertPayment inserts into the
* Payment table and updates invoice.
************************************/

DELIMITER | 
CREATE PROCEDURE sp_insertPayment
(
IN i_InvoiceID      int,
IN i_CashAmount     decimal(6,2),
IN i_PaymentDate    timestamp
)

BEGIN

DECLARE _Itotal decimal(6,2);

SELECT Total FROM Invoice WHERE InvoiceID = i_InvoiceID INTO _Itotal;

INSERT INTO Payment
(
CashAmount,
PaymentDate,
InvoiceID
)
VALUES
(
i_CashAmount,
i_PaymentDate,
i_InvoiceID
);

UPDATE Invoice SET
Total = (_Itotal - i_CashAmount)
WHERE InvoiceID = i_InvoiceID;

END ||
DELIMITER ;


#--------------insert into Surgery Table--------------
/******************************************
* sp_insertSurgery inserts into the
* Surgery table.
******************************************/

DELIMITER |
CREATE PROCEDURE sp_insertSurgery
(
IN i_SurgeryType        text,
IN i_StartTime          datetime,
IN i_EndTime            datetime,
IN i_RoomNumber         int,
IN i_Comments           text,
IN i_PatientCheckInID int
)

BEGIN

INSERT INTO Surgery
(
SurgeryType,
StartTime,
EndTime,
RoomNumber,
Comments,
PatientCheckInID
)
VALUES
(
i_SurgeryType,
i_StartTime,
i_EndTime,
i_RoomNumber,
i_Comments,
i_PatientCheckInID
);

END ||
DELIMITER ;

#--------------update Surgery Table--------------
/******************************************
* sp_updateSurgery updates the
* Surgery table.
******************************************/

DELIMITER |
CREATE PROCEDURE sp_updateSurgery
(
IN i_SurgeryID          int,
IN i_EndTime            time,
IN i_RoomNumber         int,
IN i_Comments           text
)

BEGIN

UPDATE Surgery SET
EndTime = i_EndTime,
RoomNumber = i_RoomNumber,
Comments = i_Comments
WHERE SurgeryID = i_SurgeryID;

END ||
DELIMITER ;

#--------------insert SurgeryStaff Table--------------
/******************************************
* sp_insertSurgeryStaff inserts into the
* SurgeryStaff table.
******************************************/

DELIMITER |
CREATE PROCEDURE sp_insertSurgeryStaff
(
IN i_staffFN        varchar(30),
IN i_staffLN        varchar(30),
IN i_SurgeryID      int
)

BEGIN

DECLARE _staffID int;

SELECT StaffID FROM Staff WHERE FirstName LIKE i_staffFN && LastName LIKE i_staffLN INTO _staffID;

INSERT INTO SurgeryStaff
(
StaffID,
SurgeryID
)
VALUES
(
_staffID,
i_SurgeryID
);

END ||
DELIMITER ;

#--------------insert Problem/PatientProblem Table--------------
/******************************************
* sp_insertProblem inserts into the
* Problem table.
******************************************/

DELIMITER |
CREATE PROCEDURE sp_insertProblem
(
IN i_ProblemName        varchar(30),
IN i_PatientID          int
)

BEGIN

DECLARE _problemID  int;

INSERT INTO Problem
(
ProblemName
)
VALUES
(
i_ProblemName
);

SELECT LAST_INSERT_ID() INTO _problemID;

INSERT INTO PatientProblem
(
PatientID,
ProblemID
)
VALUES
(
i_PatientID,
_problemID
);

END ||
DELIMITER ;

#--------------insert InvoiceItem Table--------------
/******************************************
* sp_insertInvoiceItem inserts into the
* InvoiceItem table.
******************************************/

DELIMITER |
CREATE PROCEDURE sp_insertInvoiceItem
(
IN i_InvoiceID      int,
IN i_ProductID      int,
IN i_ServiceID      int,
IN i_Quantity       float
)

BEGIN

INSERT INTO InvoiceItem
(
InvoiceID,
ProductID,
ServiceID,
Quantity
)
VALUES
(
i_InvoiceID,
i_ProductID,
i_ServiceID,
i_Quantity
);

END ||
DELIMITER ;

#--------------insert Category Table--------------
/******************************************
* sp_insertCategory inserts into the
* Category table.
******************************************/

DELIMITER |
CREATE PROCEDURE sp_insertCategory
(
IN i_Name          varchar(30),
IN i_Description   text
)

BEGIN

INSERT INTO Category
(
Name,
Description
)
VALUES
(
i_Name,
i_Description
);

END ||
DELIMITER ;

#--------------update Product Count Table--------------
/******************************************
* sp_updateProductCount inserts into the
* Category table.
******************************************/

DELIMITER |
CREATE PROCEDURE sp_updateProductCount
(
IN i_ProductID      int
)

BEGIN

UPDATE Product SET
Counter = Counter + 1
WHERE ProductID = i_ProductID;

END ||
DELIMITER ;

#-----------------------------------------------------------------------------------------------------------
#-------------------------------------------------TEST DATA-------------------------------------------------
#-----------------------------------------------------------------------------------------------------------

INSERT INTO Address
(
Street1,
Street2,
City,
Region,
Country
)
VALUES
(
'12667 W. 85th Cir',
'',
'Arvada',
'Co',
'USA'
);

INSERT INTO Address
(
Street1,
Street2,
City,
Region,
Country
)
VALUES
(
'2558 S 1687 W',
'',
'Layton',
'Ut',
'USA'
);

INSERT INTO EmergencyContact
(
FirstName,
LastName,
PhoneNumber,
Relationship,
AddressID
)
VALUES
(
'Daniel',
'Agyei',
'3034213837',
4,
1
);

INSERT INTO Patient
(
FirstName,
MiddleName,
LastName,
DateOfBirth,
Gender,
PhoneNumber,
AddressID,
BloodType,
Religion,
PatientNote,
OldPhysicalRecordNumb,
EmergencyContactID
)
VALUES
(
'Hans',
'',
'Sarpei',
'1940-02-10',
0,
'3032768557',
2,
0,
'0',
'This is a test note for a patient',
null,
1
);

#--------

INSERT INTO Address
(
Street1,
Street2,
City,
Region,
Country
)
VALUES
(
'1965 S. 1275 E.',
'',
'Ogden',
'Ut',
'USA'
);

INSERT INTO Address
(
Street1,
Street2,
City,
Region,
Country
)
VALUES
(
'1234 N. 5678 S.',
'',
'Midvill',
'Ut',
'USA'
);

INSERT INTO EmergencyContact
(
FirstName,
LastName,
PhoneNumber,
Relationship,
AddressID
)
VALUES
(
'Samuel',
'Inkoom',
'8018957452',
2,
3
);

INSERT INTO Patient
(
FirstName,
MiddleName,
LastName,
DateOfBirth,
Gender,
PhoneNumber,
AddressID,
BloodType,
Religion,
PatientNote,
OldPhysicalRecordNumb,
EmergencyContactID
)
VALUES
(
'Jaide',
'',
'Boateng',
'1970-10-15',
1,
'8014587895',
4,
0,
0,
'Another test note comes here',
null,
2
);

#--------

INSERT INTO Address
(
Street1,
Street2,
City,
Region,
Country
)
VALUES
(
'5698 W. 12th Dr.',
'',
'Littleton',
'Co',
'USA'
);

INSERT INTO Address
(
Street1,
Street2,
City,
Region,
Country
)
VALUES
(
'12478 S Riverdale Rd.',
'',
'Ogden',
'Ut',
'USA'
);

INSERT INTO EmergencyContact
(
FirstName,
LastName,
PhoneNumber,
Relationship,
AddressID
)
VALUES
(
'Prince',
'Tagoe',
'4586547878',
3,
5
);

INSERT INTO Patient
(
FirstName,
MiddleName,
LastName,
DateOfBirth,
Gender,
PhoneNumber,
AddressID,
BloodType,
Religion,
PatientNote,
OldPhysicalRecordNumb,
EmergencyContactID
)
VALUES
(
'Kwadwo',
'',
'Asamoah',
'1986-10-07',
0,
'8013208896',
6,
0,
0,
'Is addicted to pain meds',
null,
3
);


#--------

INSERT INTO Address
(
Street1,
Street2,
City,
Region,
Country
)
VALUES
(
'1111 W. 10th Dr.',
'',
'Riverdale',
'Ut',
'USA'
);

INSERT INTO Address
(
Street1,
Street2,
City,
Region,
Country
)
VALUES
(
'12478 S Place Rd.',
'',
'Ogden',
'Ut',
'USA'
);

INSERT INTO EmergencyContact
(
FirstName,
LastName,
PhoneNumber,
Relationship,
AddressID
)
VALUES
(
'Katie',
'Perry',
'4586547878',
3,
7
);

INSERT INTO Patient
(
FirstName,
MiddleName,
LastName,
DateOfBirth,
Gender,
PhoneNumber,
AddressID,
BloodType,
Religion,
PatientNote,
OldPhysicalRecordNumb,
EmergencyContactID
)
VALUES
(
'Hans',
'',
'Kirkibe',
'1999-02-10',
0,
'8019995265',
8,
0,
0,
null,
null,
4
);


#--------


CALL sp_insertProblem
(
'Aids',
100000
);

CALL sp_insertProblem
(
'Sickle Cell',
100000
);

#CALL sp_insertProblem
#(
#'STDs',
#100002
#);

CALL sp_insertProblem
(
'Diabetes',
100000
);

#CALL sp_insertProblem
#(
#'Diabetes',
#100003
#);

INSERT INTO Allergy
(
Name
)
VALUES
(
'Pollen'
);

INSERT INTO Allergy
(
Name
)
VALUES
(
'Neosporn'
);

INSERT INTO Allergy
(
Name
)
VALUES
(
'Bees'
);

INSERT INTO Allergy
(
Name
)
VALUES
(
'Chocolate'
);

INSERT INTO Allergy
(
Name
)
VALUES
(
'Fruit'
);

INSERT INTO Allergy
(
Name
)
VALUES
(
'Advil'
);

INSERT INTO Allergy
(
Name
)
VALUES
(
'Morphine'
);

/*

INSERT INTO PatientAllergy
(
PatientID,
AllergyID
)
VALUES
(
100000,
1
);

INSERT INTO PatientAllergy
(
PatientID,
AllergyID
)
VALUES
(
100000,
2
);

INSERT INTO PatientAllergy
(
PatientID,
AllergyID
)
VALUES
(
100000,
3
);

INSERT INTO PatientAllergy
(
PatientID,
AllergyID
)
VALUES
(
100001,
1
);

INSERT INTO PatientAllergy
(
PatientID,
AllergyID
)
VALUES
(
100001,
4
);

INSERT INTO PatientAllergy
(
PatientID,
AllergyID
)
VALUES
(
100001,
5
);
*/

CALL sp_insertStaff
(
    "",
    "",
    "Accra",
    "Accra",
    "Ghana",
    "admin",
    "iForget",
    "A",
    "Korle Bu",
    "",
    "Administrator",
    "222-1234567",
    4,
    null
);

CALL sp_insertStaff
(
'6666 N 8888 E',
'',
'Ogden',
'Ut',
'USA',
'JJimmy',
'Password',
'A',
'Jimmy',
'',
'John',
'801-895-7885',
4,
null
);

CALL sp_insertStaff
(
'6666 N 8888 E',
'',
'Ogden',
'Ut',
'USA',
'TJimmy',
'Password',
'A',
'Jimmy',
'',
'Tom',
'801-895-7885',
0,
null
);

CALL sp_insertStaff
(
'1965 S 1275 E',
'',
'Ogden',
'Ut',
'USA',
'charp',
'Password',
'A',
'Cameron',
'',
'Harp',
'801-458-7687',
4,
null
);

CALL sp_updateInvoice
(
1000,
800.25
);

CALL sp_updateInvoice
(
1001,
80.25
);

CALL sp_insertCategory
(
'Medical Equipment',
'This includes anything that monitors a bodily function and is used in patient care.'
);

CALL sp_insertCategory
(
'Pharmaceuticals',
'Drugs provided to a patient for care.'
);

CALL sp_insertCategory
(
'Miscellaneous',
'General products and supplies that do not fit under a specific category.'
);

CALL sp_insertCategory
(
'Diabetic Supplies',
'Anything used in the treatment of diabetes.'
);

CALL sp_insertCategory
(
'Catheters',
'You do not even want to know this one.'
);

CALL sp_insertProduct
(
'Large Catheter',
'each',
5,
12.25,
50
);

CALL sp_insertProduct
(
'Medium Catheter',
'each',
5,
9.98,
34
);

CALL sp_insertProduct
(
'Small Catheter',
'each',
5,
6.00,
101
);

CALL sp_insertProduct
(
'Aspirin',
'250mg',
2,
2.35,
2340
);

CALL sp_insertProduct
(
'Tylenol',
'500mg',
2,
4.43,
1920
);

CALL sp_insertProduct
(
'Paxil',
'50mg',
2,
6.34,
344
);

CALL sp_insertProduct
(
'Augmentin',
'750mg',
2,
10.54,
67
);

CALL sp_insertProduct
(
'Blood Pressure Cuff',
'each',
1,
45.00,
3
);

CALL sp_insertProduct
(
'Pulse Oximeters',
'each',
1,
2335.43,
3
);

CALL sp_insertService
(
'test service',
22.50
);

INSERT INTO Immunization
(
VaccineType
)
VALUES
(
'DTP - Diphtheria, tetanus toxoids, and whole cell pertussis'
);

INSERT INTO Immunization
(
VaccineType
)
VALUES
(
'IPV - Poliovirus vaccine, inactivated'
);

INSERT INTO Immunization
(
VaccineType
)
VALUES
(
'Hep B - 3 dose schedule'
);

INSERT INTO Immunization
(
VaccineType
)
VALUES
(
'YellowFevor'
);

INSERT INTO Immunization
(
VaccineType
)
VALUES
(
'TwinRix'
);

INSERT INTO Immunization
(
VaccineType
)
VALUES
(
'YellowFevor'
);

INSERT INTO Immunization
(
VaccineType
)
VALUES
(
'Flu Shot'
);

INSERT INTO PatientImmunization
(
PatientID,
ImmunizationID,
DateAdministered
)
VALUES
(
100000,
1,
NOW()
);

INSERT INTO PatientImmunization
(
PatientID,
ImmunizationID,
DateAdministered
)
VALUES
(
100000,
3,
NOW()
);

INSERT INTO PatientImmunization
(
PatientID,
ImmunizationID,
DateAdministered
)
VALUES
(
100001,
2,
'2011-01-14 00:00:00'
);

INSERT INTO PatientImmunization
(
PatientID,
ImmunizationID,
DateAdministered
)
VALUES
(
100000,
4,
'2000-01-14 00:00:00'
);

INSERT INTO PatientImmunization
(
PatientID,
ImmunizationID,
DateAdministered
)
VALUES
(
100000,
5,
'2005-01-14 00:00:00'
);

INSERT INTO PatientImmunization
(
PatientID,
ImmunizationID,
DateAdministered
)
VALUES
(
100001,
6,
'2009-01-14 00:00:00'
);

INSERT INTO PatientImmunization
(
PatientID,
ImmunizationID,
DateAdministered
)
VALUES
(
100000,
7,
'2011-01-14 00:00:00'
);

INSERT INTO Location
(
Department,
RoomNumber
)
VALUE
(
'WARD 1',
1
);

INSERT INTO Location
(
Department,
RoomNumber
)
VALUE
(
'WARD 2',
1
);

INSERT INTO Location
(
Department,
RoomNumber
)
VALUE
(
'WARD 3',
1
);

INSERT INTO Location
(
Department,
RoomNumber
)
VALUE
(
'WARD 4',
2
);

INSERT INTO Location
(
Department,
RoomNumber
)
VALUE
(
'WARD 5',
3
);

INSERT INTO Location
(
Department,
RoomNumber
)
VALUE
(
'WARD 6',
4
);

INSERT INTO Location
(
Department,
RoomNumber
)
VALUE
(
'WARD 7',
5
);



INSERT INTO PatientCheckIn
(
    CheckinTime,
    PatientType,
    PatientID,
    InvoiceID,
    CheckOutTime,
    Diagnosis,
    LocationID,
    StaffID,
    IsActive
)
VALUE
(
    NOW(),
    1,
    100000,
    1,
    NOW(),
    'Smelly Feet',
    1,
    1,
    1
);

INSERT INTO PatientCheckIn
(
    CheckinTime,
    PatientType,
    PatientID,
    InvoiceID,
    CheckOutTime,
    Diagnosis,
    LocationID,
    StaffID,
    IsActive
)
VALUE
(
    '2011-01-05 12:45:10',
    0,
    100000,
    2,
    NOW(),
    'Hyperlipidemia',
    2,
    2,
    1
);

INSERT INTO PatientCheckIn
(
    CheckinTime,
    PatientType,
    PatientID,
    InvoiceID,
    CheckOutTime,
    Diagnosis,
    LocationID,
    StaffID,
    IsActive
)
VALUE
(
    NOW(),
    1,
    100001,
    3,
    NOW(),
    'Finger Fungus',
    2,
    2,
    1
);

INSERT INTO PatientCheckIn
(
    CheckinTime,
    PatientType,
    PatientID,
    InvoiceID,
    CheckOutTime,
    Diagnosis,
    LocationID,
    StaffID,
    IsActive
)
VALUE
(
    NOW(),
    0,
    100002,
    4,
    NOW(),
    'GOHNAHIFASURFALAIDS',
    2,
    2,
    1
);

INSERT INTO Vitals
(
Time,
Type,
Height,
Weight,
HeartRate,
Temperature,
BPSystolic,
BPDiastolic,
RespiratoryRate,
PatientCheckInID,
IsActive
)
VALUES
(
'2010-12-05 12:59:40',
2,
76,
78,
76,
37,
140,
70,
12,
2,
1
);

INSERT INTO Vitals
(
Time,
Type,
Height,
Weight,
HeartRate,
Temperature,
BPSystolic,
BPDiastolic,
RespiratoryRate,
PatientCheckInID,
IsActive
)
VALUES
(
'2010-12-05 01:10:30',
2,
76,
78,
60,
40,
112,
79,
16,
2,
1
);

INSERT INTO Vitals
(
Time,
Type,
Height,
Weight,
HeartRate,
Temperature,
BPSystolic,
BPDiastolic,
RespiratoryRate,
PatientCheckInID,
IsActive
)
VALUES
(
'20100510103842',
1,
76,
78,
76,
37,
140,
70,
12,
1,
1
);

INSERT INTO Invoice
(
    Total,
    `Date`,
    IsActive
)
VALUES
(
    0.00,
    '2010-12-05 01:10:30',
    1
);

INSERT INTO Invoice
(
    Total,
    `Date`,
    IsActive
)
VALUES
(
   0.00,
   '2010-02-02 03:12:10',
   1
);

INSERT INTO Invoice
(
    Total,
    `Date`,
    IsActive
)
VALUES
(
   0.00,
   '2011-01-02 12:12:10',
   1
);

INSERT INTO Invoice
(
    Total,
    `Date`,
    IsActive
)
VALUES
(
   0.00,
   '2011-02-22 19:11:45',
   1
);

/*****************************************************
    Role Test Data
*****************************************************/
INSERT INTO Role
(
    `Name`,
    Description,
    DateCreated
)
VALUES
(
    "Sysop",
    "The system administrator. An individual in the I.T. department.",
    "2011-02-21 00:00:00"
);

INSERT INTO Role
(
    `Name`,
    Description,
    DateCreated
)
VALUES
(
    "Physician",
    "A person who is legally qualified to practice medicine; doctor of medicine.",
    "2011-02-21 00:00:00"
);

INSERT INTO Role
(
    `Name`,
    Description,
    DateCreated
)
VALUES
(
    "Medical Assistant",
    "Otherwise known as a nurse, is the person trained to care for the sick or infirm.",
    "2011-02-21 00:00:00"
);

INSERT INTO Role
(
    `Name`,
    Description,
    DateCreated
)
VALUES
(
    "Cashier",
    "An employee who collects payment for products and services provided by the hospital.",
    "2011-02-21 00:00:00"
);

INSERT INTO Role
(
    `Name`,
    Description,
    DateCreated
)
VALUES
(
    "Administrator",
    "A person who fulfills the hopsital's business needs. Files paperwork, deals with billing issues, and manages the overall operation of the hospital.",
    "2011-02-21 00:00:00"
);

INSERT INTO Role
(
    `Name`,
    Description,
    DateCreated
)
VALUES
(
    "Surgeon",
    "A physician who specializes in surgery.",
    "2011-02-21 00:00:00"
);

/*****************************************************
    Surgery Test Data
*****************************************************/
INSERT INTO Surgery
(
StartTime,
EndTime,
LocationID,
PatientCheckInID,
CaseType
)
VALUES
(
NOW(),
NOW(),
2,
1,
0
);

INSERT INTO Surgery
(
StartTime,
EndTime,
LocationID,
PatientCheckInID,
CaseType
)
VALUES
(
NOW(),
NOW(),
1,
2,
1
);

INSERT INTO SurgeryStaff
(
StaffID,
SurgeryID,
Role
)
VALUES
(
1,
1,
0
);

INSERT INTO SurgeryStaff
(
StaffID,
SurgeryID,
Role
)
VALUES
(
2,
1,
1
);

INSERT INTO SurgeryStaff
(
StaffID,
SurgeryID,
Role
)
VALUES
(
3,
1,
2
);

INSERT INTO SurgeryStaff
(
StaffID,
SurgeryID,
Role
)
VALUES
(
3,
2,
0
);

INSERT INTO SurgeryStaff
(
StaffID,
SurgeryID,
Role
)
VALUES
(
1,
2,
4
);

INSERT INTO FeedChart
(
PatientCheckInID,
FeedTime,
FeedType,
AmountOffered,
AmountTaken,
Vomit,
Urine,
Stool,
Comments
)
VALUES
(
1,
NOW(),
'Dinner',
'6 oz. Steak',
'4 oz.',
'No Idea',
'No Idea',
'No Idea',
'I really have no idea what they put in these charts'
);

INSERT INTO FeedChart
(
PatientCheckInID,
FeedTime,
FeedType,
AmountOffered,
AmountTaken,
Vomit,
Urine,
Stool,
Comments
)
VALUES
(
1,
NOW(),
'Breakfast',
'Hash Browns',
'1 lb.',
'All over',
'On the plant',
'In his pants',
'I really have no idea what they put in these charts'
);

INSERT INTO InvoiceItem
(
    InvoiceID,
    ProductID,
    ServiceID,
    Quantity
)
VALUES
(
    1,
    2,
    null,
    2
);

INSERT INTO InvoiceItem
(
    InvoiceID,
    ProductID,
    ServiceID,
    Quantity
)
VALUES
(
    1,
    null,
    1,
    1
);

INSERT INTO InvoiceItem
(
    InvoiceID,
    ProductID,
    ServiceID,
    Quantity
)
VALUES
(
    1,
    4,
    null,
    42
);

INSERT INTO InvoiceItem
(
    InvoiceID,
    ProductID,
    ServiceID,
    Quantity
)
VALUES
(
    2,
    5,
    null,
    12
);

INSERT INTO InvoiceItem
(
    InvoiceID,
    ProductID,
    ServiceID,
    Quantity
)
VALUES
(
    2,
    6,
    null,
    13
);

INSERT INTO InvoiceItem
(
    InvoiceID,
    ProductID,
    ServiceID,
    Quantity
)
VALUES
(
    2,
    null,
    1,
    1
);

INSERT INTO InvoiceItem
(
    InvoiceID,
    ProductID,
    ServiceID,
    Quantity
)
VALUES
(
    3,
    null,
    1,
    1
);

INSERT INTO InvoiceItem
(
    InvoiceID,
    ProductID,
    ServiceID,
    Quantity
)
VALUES
(
    4,
    2,
    null,
    1
);

INSERT INTO Payment
(
CashAmount,
PaymentDate,
InvoiceID
)
VALUES
(
5.20,
'2011-02-23 01:15:12',
1
);

INSERT INTO Payment
(
CashAmount,
PaymentDate,
InvoiceID
)
VALUES
(
42.85,
'2011-02-23 01:16:12',
1
);

INSERT INTO Payment
(
CashAmount,
PaymentDate,
InvoiceID
)
VALUES
(
15.00,
'2011-02-23 01:15:13',
2
);

INSERT INTO FeedChart
(
PatientCheckInID,
FeedTime,
FeedType,
AmountOffered,
AmountTaken,
Vomit,
Urine,
Stool,
Comments   
)
VALUES
(
1,
NOW(),
'Blah',
'Blah',
'Blah',
'Blah',
'Blah',
'Blah',
'Blah'
);

INSERT INTO FeedChart
(
PatientCheckInID,
FeedTime,
FeedType,
AmountOffered,
AmountTaken,
Vomit,
Urine,
Stool,
Comments   
)
VALUES
(
2,
NOW(),
'Boaring',
'Boaring',
'Boaring',
'Boaring',
'Boaring',
'Boaring',
'Boaring'
);

INSERT INTO OutputChart
(
ChartTime,
NGSuctionAmount,
NGSuctionColor,
UrineAmount,
StoolAmount,
StoolColor,
PatientCheckInID
)
VALUES
(
NOW(),
'20 cc.',
'Brown',
'2 oz.',
'1 lb.',
'Red',
1
);

INSERT INTO OutputChart
(
ChartTime,
NGSuctionAmount,
NGSuctionColor,
UrineAmount,
StoolAmount,
StoolColor,
PatientCheckInID
)
VALUES
(
NOW(),
'2 cc.',
'Green',
'2 oz.',
'2 lb.',
'Yellow and brown',
2
);

INSERT INTO IntakeChart
(
ChartTime,
KindOfFluid,
Amount,
PatientCheckInID
)
VALUES
(
NOW(),
'Dr. Pepper',
'32 oz.',
1
);

INSERT INTO IntakeChart
(
ChartTime,
KindOfFluid,
Amount,
PatientCheckInID
)
VALUES
(
NOW(),
'Apple Juice',
'32 oz.',
1
);

INSERT INTO IntakeChart
(
ChartTime,
KindOfFluid,
Amount,
PatientCheckInID
)
VALUES
(
NOW(),
'Pepto',
'2 oz.',
2
);

INSERT INTO IntakeChart
(
ChartTime,
KindOfFluid,
Amount,
PatientCheckInID
)
VALUES
(
NOW(),
'Orange Juice',
'32 oz.',
2
);

INSERT INTO Note
(
Title,
Type,
Body,
DateCreated,
StaffID,
NoteTemplateCategoryID,
PatientCheckInID
)
VALUES
(
null,
0,
'This is a test note for PMH testing. If your reading this that means you didnt get commit 800 or 900',
NOW(),
1,
1,
1
);

INSERT INTO Note
(
Title,
Type,
Body,
DateCreated,
StaffID,
NoteTemplateCategoryID,
PatientCheckInID
)
VALUES
(
null,
0,
'I know Matt is crying inside about not getting these numbers but it was good comedy for me and JD.',
NOW(),
1,
1,
1
);

INSERT INTO Note
(
Title,
Type,
Body,
DateCreated,
StaffID,
NoteTemplateCategoryID,
PatientCheckInID
)
VALUES
(
null,
0,
'P.S. Cameron and JD think Matt plays soccer like a little girl!!!',
NOW(),
1,
1,
1
);

INSERT INTO Note
(
Title,
Type,
Body,
DateCreated,
StaffID,
NoteTemplateCategoryID,
PatientCheckInID
)
VALUES
(
null,
1,
'This surgery went very very bad. We were supposed to do a mole removal and we accidently amputated a leg! Oops',
NOW(),
1,
1,
1
);