/*****************************************************************************
 * Project: Open Electronic Healthcare System
 * Group: Ghana Team
 * Date: Jan-3-2011
 * 
 * Author: Cameron Harp (charp5257@gmail.com)
 *****************************************************************************/
 
 /*************************************************************************************
 * Database Notes:
 *
 * Download:
 *
 * Run Script:
 *
 *
 * IsActive:
 *      In every table there is a field 'IsActive', this field is used to determin
 *      if the table is active or inactive aka 'DELETED'. This field is automatically
 *      defaulted to 1 which is set to active. When deleting a table from the database
 *      you are really only doing an update to change the bit field to 0 which means
 *      inactive.
 * 
 *************************************************************************************/

GRANT USAGE ON *.* TO "OpenEHS_admin"@"localhost";
DROP USER "OpenEHS_admin"@"localhost";

DROP DATABASE IF EXISTS OpenEHS_database;

CREATE DATABASE OpenEHS_database;

USE OpenEHS_database;

CREATE USER "OpenEHS_admin"@"localhost" IDENTIFIED BY "password";
GRANT ALL ON OpenEHS_database.* TO "OpenEHS_admin"@"localhost";

#----------------------------------------------------------------------------------------------------------
#--------------------------------------------------Tables--------------------------------------------------
#----------------------------------------------------------------------------------------------------------

CREATE TABLE Location
(
LocationID          int                 AUTO_INCREMENT          PRIMARY KEY         NOT NULL,
Building            varchar(30)         NOT NULL
);

/*******************
*Notes on Record:
*
*CheckedIn:
*   0 = No
*   1 = Yes
*******************/

CREATE TABLE Record
(
RecordID            int                 AUTO_INCREMENT          PRIMARY KEY         NOT NULL,
PatientID           int                 NULL,
CheckedIn           bit(1)              NULL,
TimeStamp           timestamp           NULL                    DEFAULT CURRENT_TIMESTAMP,
Comments            longtext            NULL,
LocationID          int                 NULL,
IsActive            bit(1)              NOT NULL                DEFAULT 1
);

CREATE TABLE Address
(
AddressID           int                 AUTO_INCREMENT          PRIMARY KEY         NOT NULL,
Street1             varchar(50)         NOT NULL,
Street2             varchar(50)         NULL,
City                varchar(30)         NOT NULL,
Region              varchar(30)         NOT NULL,
Country             varchar(30)         NOT NULL                DEFAULT 'Ghana',
IsActive            bit(1)              NOT NULL                DEFAULT 1
);

CREATE TABLE EmergencyContact
(
EmergencyContactID          int              AUTO_INCREMENT          PRIMARY KEY         NOT NULL,
FirstName                   varchar(30)      NOT NULL,
LastName                    varchar(30)      NOT NULL,
PhoneNumber                 varchar(20)      NOT NULL,
Relationship                bit(3)           NOT NULL,
AddressID                   int              NOT NULL,
PatientID                   int              NOT NULL,
IsActive                    bit(1)           NOT NULL                DEFAULT 1
);

/**************************************
*Notes on Patient:
*
*DOB:
* The DOB will be stored in the DB as a
* date, but the UI for KorleBu will be
* entered as a age and needs to be 
* converted into a date. MLKMC will be
* entered in as a normal date.
**************************************/

CREATE TABLE Patient
(
PatientID           int                 AUTO_INCREMENT          PRIMARY KEY         NOT NULL,
FirstName           varchar(30)         NOT NULL,
MiddleName          varchar(30)         NULL,
LastName            varchar(30)         NOT NULL,
DateOfBirth         Date                NOT NULL,
Gender              char(10)            NOT NULL,
PhoneNumber         varchar(20)         NULL,
AddressID           int                 NOT NULL,
BloodType           varchar(10)         NULL,
TribeRace           varchar(30)         NULL,
Religion            varchar(30)         NULL,
IsActive            bit(1)              NOT NULL                DEFAULT 1
) AUTO_INCREMENT= 100000;

/*******************
*Notes on Vitals:
*
*Type(No default):
*   ?????????
*******************/

CREATE TABLE Vitals
(
VitalsID            int                 AUTO_INCREMENT          PRIMARY KEY         NOT NULL,
Type                bit(5)              NOT NULL,
Height              varchar(5)          NOT NULL,
Weight              varchar(5)          NOT NULL,
HeartRate           tinyint             NOT NULL,
Temperature         decimal(4,1)        NOT NULL,
BPSystolic          varchar(3)          NOT NULL,
BPDiastolic         varchar(3)          NOT NULL,
RespirtoryRate      tinyint             NOT NULL,
IsActive            bit(1)              NOT NULL                DEFAULT 1
);

CREATE TABLE LogIn
(
LogInID             int                 AUTO_INCREMENT          PRIMARY KEY         NOT NULL,
UserName            varchar(30)         NOT NULL,
Password            varchar(30)         NOT NULL,
LogInPermissions    Char(1)             NOT NULL,
IsActive            bit(1)              NOT NULL                DEFAULT 1
);

/*******************
*Notes on Staff:
*
* StaffType:
*   0 = Doctor
*   1 = Surgeon
*   2 = Nurse
*   3 = Rep
*   4 = Admin
*******************/

CREATE TABLE Staff
(
StaffID             int                 AUTO_INCREMENT          PRIMARY KEY         NOT NULL,
FirstName           varchar(30)         NOT NULL,
MiddleName          varchar(30)         NULL,
LastName            varchar(30)         NOT NULL,
PhoneNumber         varchar(20)         NOT NULL,
StaffType           tinyint(1)          NOT NULL,
LicenseNumber       varchar(20)         NULL                    Default NULL,
AddressID           int                 NOT NULL,
LogInID             int                 NOT NULL,
IsActive            bit(1)              NOT NULL                DEFAULT 1
);

CREATE TABLE Allergy
(
AllergyID               int             AUTO_INCREMENT              PRIMARY KEY         NOT NULL,
Name                    varchar(30)     NULL,
Medication              varchar(30)     NULL,
PatientID               int             NOT NULL,
IsActive                bit(1)          NOT NULL                    DEFAULT 1
);

/***************************
*Notes on PatientCheckIn:
* 
* Type:
*   0 = OutPatient 
*   1 = InPatient
*
* Status:
*   0 = InProgress 
*   1 = CheckedIn 
***************************/

CREATE TABLE PatientCheckIn
(
PatientCheckInID            int             AUTO_INCREMENT              PRIMARY KEY         NOT NULL,
DateTime                    timestamp       NOT NULL                    DEFAULT NOW(),
Type                        bit(1)          NOT NULL,
PatientID                   int             NOT NULL,
Status                      bit             NOT NULL                    DEFAULT 1,
IsActive                    bit(1)          NOT NULL                    DEFAULT 1
);

CREATE TABLE Invoice
(
InvoiceID               int             AUTO_INCREMENT          PRIMARY KEY         NOT NULL,
Total                   decimal(6,2)    NOT NULL                DEFAULT 0.00,
Date                    timestamp       NOT NULL                DEFAULT CURRENT_TIMESTAMP,
PatientID               int             NOT NULL,
PatientCheckInID        int             NOT NULL,
IsActive                bit(1)          NOT NULL                DEFAULT 1
) AUTO_INCREMENT= 1000;

CREATE TABLE Products
(
ProductsID              int             AUTO_INCREMENT          PRIMARY KEY         NOT NULL,
Name                    varchar(50)     NOT NULL,
Unit                    varchar(10)     NOT NULL,
Catagory                varchar(20)     NOT NULL,
ProductCost             decimal(4,2)    NOT NULL,
QuantityOnHand          int             NOT NULL,
IsActive                bit(1)          NOT NULL                DEFAULT 1
);

CREATE TABLE Service
(
ServiceID               int             AUTO_INCREMENT          PRIMARY KEY         NOT NULL,
Name                    varchar(30)     NOT NULL,
ServiceCost             decimal(6, 2)   NOT NULL,
IsActive                bit(1)          NOT NULL                DEFAULT 1
);

CREATE TABLE InvoiceItem
(
InvoiceItemID           int             AUTO_INCREMENT             PRIMARY KEY         NOT NULL,
InvoiceID               int             NOT NULL,
ProductsID              int             NULL,
ServiceID               int             NULL,
Quantity                float           NULL,
IsActive                bit(1)          NOT NULL                DEFAULT 1
);

CREATE TABLE Payment
(
PaymentID               int               AUTO_INCREMENT          PRIMARY KEY         NOT NULL,
CashAmount              decimal(6,2)      NOT NULL,
PaymentDate             timestamp         NOT NULL                DEFAULT CURRENT_TIMESTAMP,
InvoiceID               int               NOT NULL,
IsActive                bit(1)            NOT NULL                DEFAULT 1
);

CREATE TABLE InPatient
(
InPatientID             int               AUTO_INCREMENT          PRIMARY KEY         NOT NULL,
PatientCheckInID        int               NOT NULL,
AdmitReason             text              NOT NULL,
Comments                text              NULL,
AdmitDate               timestamp         NOT NULL                DEFAULT NOW(),
StaffID                 int               NOT NULL,
WardNumber              int               NOT NULL,
IsActive                bit(1)            NOT NULL                DEFAULT 1
);

CREATE TABLE InPatientEncounter
(
InPatientEncounterID                int                 AUTO_INCREMENT          PRIMARY KEY       NOT NULL,
Time                                timestamp           NOT NULL,
InPatientID                         int                 NOT NULL,
Diagnosis                           text                NOT NULL,
StaffID                             int                 NOT NULL
);

CREATE TABLE Note
(
NoteID              int             AUTO_INCREMENT          PRIMARY KEY                      NOT NULL,
Title               varchar(30)     NOT NULL,
Body                longtext        NOT NULL,
DateCreated         timestamp       NOT NULL                DEFAULT CURRENT_TIMESTAMP,
StaffID             int             NOT NULL,
IsActive            bit(1)          NOT NULL                DEFAULT 1
);

CREATE TABLE InPatientEncounterNote
(
InPatientEncounterNoteID            int             AUTO_INCREMENT          PRIMARY KEY         NOT NULL,
InPatientEncounterID                int             NULL,
NoteID                              int             NOT NULL,
SurgeryID                           int             NULL,
IsActive                            bit(1)          NOT NULL                DEFAULT 1
);

CREATE TABLE OutPatientEncounter
(
OutPatientEncounterID               int             AUTO_INCREMENT          PRIMARY KEY                     NOT NULL,
PatientCheckInID                    int             NOT NULL,
Time                                timestamp       NOT NULL                DEFAULT CURRENT_TIMESTAMP,
Comments                            longtext        NULL,
RoomNumber                          int             NOT NULL,
Diagnosis                           text            NOT NULL,
StaffID                             int             NOT NULL,
IsActive                            bit(1)          NOT NULL                DEFAULT 1
);

CREATE TABLE OutPatientEncounterNote
(
OutPatientEncounterNoteID           int             AUTO_INCREMENT          PRIMARY KEY         NOT NULL,
OutPatientEncounterID               int             NOT NULL,
NoteID                              int             NOT NULL,
IsActive                            bit(1)          NOT NULL                DEFAULT 1
);

CREATE TABLE InPatientVitals
(
InPatientVitalsID         int             AUTO_INCREMENT          PRIMARY KEY         NOT NULL,
VitalsID                  int             NOT NULL,
InPatientEncounterID      int             NOT NULL
);

CREATE TABLE OutPatientVitals
(
OutPatientVitalsID          int         AUTO_INCREMENT              PRIMARY KEY         NOT NULL,
VitalsID                    int         NOT NULL,
OutPatientEncounterID       int         NOT NULL
);

CREATE TABLE LabResult
(
LabResultID             int             AUTO_INCREMENT          PRIMARY KEY         NOT NULL,
Results                 text            NOT NULL,
Attachments             blob            NULL,
OutPatientEncounterID   int             NOT NULL,
IsActive                bit(1)          NOT NULL                DEFAULT 1
);

CREATE TABLE PreWrittenNote
(
PreWrittenNoteID            int         AUTO_INCREMENT          PRIMARY KEY         NOT NULL,
Body                        longtext    NOT NULL,
IsActive                    bit(1)      NOT NULL                DEFAULT 1
);

CREATE TABLE PreWrittenDiagnosis
(
PreWrittenNoteID            int         AUTO_INCREMENT          PRIMARY KEY         NOT NULL,
Diagnosis                   longtext    NOT NULL,
IsActive                    bit(1)      NOT NULL                DEFAULT 1
);

CREATE TABLE PreWrittenSurgeryType
(
PreWrittenSurgeryTypeID     int         AUTO_INCREMENT          PRIMARY KEY         NOT NULL,
SurgeryType                 text        NOT NULL,
IsActive                    bit(1)      NOT NULL                DEFAULT 1
);

CREATE TABLE PreWrittenReason
(
PreWrittenReason            int         AUTO_INCREMENT          PRIMARY KEY         NOT NULL,
Reason                      text        NOT NULL,
IsActive                    bit(1)      NOT NULL                DEFAULT 1
);

CREATE TABLE Surgery
(
SurgeryID           int             AUTO_INCREMENT              PRIMARY KEY         NOT NULL,
SurgeryType         longtext        NOT NULL,
RoomNumber          int             NOT NULL,
StartTime           time            NOT NULL,
EndTime             time            NULL,
Comments            longtext        NULL,
InPatientID         int             NOT NULL,
IsActive            bit(1)          NOT NULL                    DEFAULT 1
);

CREATE TABLE SurgeryVitals
(
SurgeyVitalsID              int         AUTO_INCREMENT              PRIMARY KEY         NOT NULL,
VitalsID                    int         NOT NULL,
SurgeryID                   int         NOT NULL
);

CREATE TABLE SurgeryStaff
(
SurgeryStaffID          int             AUTO_INCREMENT          PRIMARY KEY         NOT NULL,
StaffID                 int             NOT NULL,
SurgeryID               int             NOT NULL
);


#----------------------------------------------------------------------------------------------------------
#---------------------------------------------------FK's---------------------------------------------------
#----------------------------------------------------------------------------------------------------------

ALTER TABLE Record
ADD CONSTRAINT FK_RecordMustHavePatientID
FOREIGN KEY (PatientID) REFERENCES Patient(PatientID);

ALTER TABLE Record
ADD CONSTRAINT FK_RecordMustHaveLoactionID
FOREIGN KEY (LocationID) REFERENCES Location(LocationID);

ALTER TABLE EmergencyContact
ADD CONSTRAINT FK_EmergencyContactMustHaveAddressID
FOREIGN KEY (AddressID) REFERENCES Address(AddressID);

ALTER TABLE EmergencyContact
ADD CONSTRAINT FK_EmergencyContactMustHavePatientID
FOREIGN KEY (PatientID) REFERENCES Patient(PatientID);

ALTER TABLE Patient
ADD CONSTRAINT FK_PatientMustHaveAddressID
FOREIGN KEY (AddressID) REFERENCES Address(AddressID);

ALTER TABLE Staff
ADD CONSTRAINT FK_StaffMustHaveAddressID
FOREIGN KEY (AddressID) REFERENCES Address(AddressID);

ALTER TABLE Staff
ADD CONSTRAINT FK_StaffMustHaveLogInID
FOREIGN KEY (LogInID) REFERENCES LogIn(LogInID);

ALTER TABLE Allergy
ADD CONSTRAINT FK_AllergyMustHavePatientID
FOREIGN KEY (PatientID) REFERENCES Patient(PatientID);

ALTER TABLE PatientCheckIn
ADD CONSTRAINT FK_PatientCheckInMustHavePatientID
FOREIGN KEY (PatientID) REFERENCES Patient(PatientID);

ALTER TABLE Invoice
ADD CONSTRAINT FK_InvoiceMustHavePatientID
FOREIGN KEY (PatientID) REFERENCES Patient(PatientID);

ALTER TABLE Invoice
ADD CONSTRAINT FK_InvoiceMustHavePatientCheckInID
FOREIGN KEY (PatientCheckInID) REFERENCES PatientCheckIn(PatientCheckInID);

ALTER TABLE InvoiceItem
ADD CONSTRAINT FK_InvoiceItemMustHaveInvoiceID
FOREIGN KEY (InvoiceID) REFERENCES Invoice(InvoiceID);

ALTER TABLE InvoiceItem
ADD CONSTRAINT FK_InvoiceItemMustHaveProductID
FOREIGN KEY (ProductsID) REFERENCES Products(ProductsID);

ALTER TABLE InvoiceItem
ADD CONSTRAINT FK_InvoiceItemMustHaveServiceID
FOREIGN KEY (ServiceID) REFERENCES Service(ServiceID);

ALTER TABLE Payment
ADD CONSTRAINT FK_PaymentMustHaveInvoiceID
FOREIGN KEY (InvoiceID) REFERENCES Invoice(InvoiceID);

ALTER TABLE InPatient
ADD CONSTRAINT FK_InPatientMustHavePatientCheckInID
FOREIGN KEY (PatientCheckInID) REFERENCES PatientCheckIn(PatientCheckInID);

ALTER TABLE InPatient
ADD CONSTRAINT FK_InPatientMustHavePatientStaffID
FOREIGN KEY (StaffID) REFERENCES Staff(StaffID);

ALTER TABLE InPatientEncounter
ADD CONSTRAINT FK_InPatientEncounterMustHaveInPatientID
FOREIGN KEY (InPatientID) REFERENCES InPatient(InPatientID);

ALTER TABLE InPatientEncounter
ADD CONSTRAINT FK_InPatientEncounterMustHaveStaffID
FOREIGN KEY (StaffID) REFERENCES Staff(StaffID);

ALTER TABLE Note
ADD CONSTRAINT FK_NoteMustHaveStaffID
FOREIGN KEY (StaffID) REFERENCES Staff(StaffID);

ALTER TABLE InPatientEncounterNote
ADD CONSTRAINT FK_InPatientEncounterNoteMustHaveInPatientEncounterID
FOREIGN KEY (InPatientEncounterID) REFERENCES InPatientEncounter(InPatientEncounterID);

ALTER TABLE InPatientEncounterNote
ADD CONSTRAINT FK_InPatientEncounterNoteMustHaveNoteID
FOREIGN KEY (NoteID) REFERENCES Note(NoteID);

ALTER TABLE OutPatientEncounter
ADD CONSTRAINT FK_InPatientEncounterNoteMustHaveStaffID
FOREIGN KEY (StaffID) REFERENCES Staff(StaffID);

ALTER TABLE OutPatientEncounter
ADD CONSTRAINT FK_InPatientEncounterNoteMustHavePatientCheckInID
FOREIGN KEY (PatientCheckInID) REFERENCES PatientCheckIn(PatientCheckInID);

ALTER TABLE OutPatientEncounterNote
ADD CONSTRAINT FK_OutPatientEncounterNoteMustHaveOutPatientEncounterID
FOREIGN KEY (OutPatientEncounterID) REFERENCES OutPatientEncounter(OutPatientEncounterID);

ALTER TABLE OutPatientEncounterNote
ADD CONSTRAINT FK_OutPatientEncounterNoteMustHaveNoteID
FOREIGN KEY (NoteID) REFERENCES Note(NoteID);

ALTER TABLE InPatientVitals
ADD CONSTRAINT FK_InPatientVitalsMustHaveVitalsID
FOREIGN KEY (VitalsID) REFERENCES Vitals(VitalsID);

ALTER TABLE InPatientVitals
ADD CONSTRAINT FK_InPatientVitalsMustHaveInPatientEncounterID
FOREIGN KEY (InPatientEncounterID) REFERENCES InPatientEncounter(InPatientEncounterID);

ALTER TABLE OutPatientVitals
ADD CONSTRAINT FK_OutPatientVitalsMustHaveVitalsID
FOREIGN KEY (VitalsID) REFERENCES Vitals(VitalsID);

ALTER TABLE OutPatientVitals
ADD CONSTRAINT FK_OutPatientVitalsMustHaveOutPatientEncounterID
FOREIGN KEY (OutPatientEncounterID) REFERENCES OutPatientEncounter(OutPatientEncounterID);

ALTER TABLE LabResult
ADD CONSTRAINT FK_LabResultMustHaveOutPatientEncounterID
FOREIGN KEY (OutPatientEncounterID) REFERENCES OutPatientEncounter(OutPatientEncounterID);

ALTER TABLE Surgery
ADD CONSTRAINT FK_SurgeryMustHaveInPatientID
FOREIGN KEY (InPatientID) REFERENCES InPatient(InPatientID);

ALTER TABLE SurgeryStaff
ADD CONSTRAINT FK_SurgeryStaffMustHaveStaffID
FOREIGN KEY (StaffID) REFERENCES Staff(StaffID);

ALTER TABLE SurgeryStaff
ADD CONSTRAINT FK_SurgeryStaffMustHaveSurgeryID
FOREIGN KEY (SurgeryID) REFERENCES Surgery(SurgeryID);


#----------------------------------------------------------------------------------------------------------
#-------------------------------------------------TRIGGERS-------------------------------------------------
#----------------------------------------------------------------------------------------------------------

#----------Auto Correct Patient Name----------

DELIMITER $$
CREATE TRIGGER tr_AutoCorrectFormatPatientName
BEFORE INSERT ON Patient

FOR EACH ROW

BEGIN
    SET NEW.FirstName = CONCAT(UCASE(substr(NEW.FirstName,1,1)), substr(NEW.FirstName,2));
    SET NEW.MiddleName = CONCAT(UCASE(substr(NEW.MiddleName,1,1)), substr(NEW.MiddleName,2));
    SET NEW.LastName = CONCAT(UCASE(substr(NEW.LastName,1,1)), substr(NEW.LastName,2));
END;
$$
DELIMITER ;

#----------Auto Correct Emergency Contact Name----------

DELIMITER $$
CREATE TRIGGER tr_AutoCorrectFormatEmergencyContactName
BEFORE INSERT ON EmergencyContact

FOR EACH ROW

BEGIN
    SET NEW.FirstName = CONCAT(UCASE(substr(NEW.FirstName,1,1)), substr(NEW.FirstName,2));
    SET NEW.LastName = CONCAT(UCASE(substr(NEW.LastName,1,1)), substr(NEW.LastName,2));
END;
$$
DELIMITER ;

#----------Auto Correct Staff Name----------

DELIMITER $$
CREATE TRIGGER tr_AutoCorrectFormatStaffName
BEFORE INSERT ON Staff

FOR EACH ROW

BEGIN
    SET NEW.FirstName = CONCAT(UCASE(substr(NEW.FirstName,1,1)), substr(NEW.FirstName,2));
    SET NEW.MiddleName = CONCAT(UCASE(substr(NEW.MiddleName,1,1)), substr(NEW.MiddleName,2));
    SET NEW.LastName = CONCAT(UCASE(substr(NEW.LastName,1,1)), substr(NEW.LastName,2));
END;
$$
DELIMITER ;

#----------Auto Correct City and Region and Country In Address----------

DELIMITER $$
CREATE TRIGGER tr_AutoCorrectFormatCityRegionCountryInAddress
BEFORE INSERT ON Address

FOR EACH ROW

BEGIN
    SET NEW.City = CONCAT(UCASE(substr(NEW.City,1,1)), substr(NEW.City,2));
    SET NEW.Region = CONCAT(UCASE(substr(NEW.Region,1,1)), substr(NEW.Region,2));
    SET NEW.Country = CONCAT(UCASE(substr(NEW.Country,1,1)), substr(NEW.Country,2));
END;
$$
DELIMITER ;

#--------------------------------------------------------------------------------------------------------------
#-------------------------------------------------Stored Procs-------------------------------------------------
#--------------------------------------------------------------------------------------------------------------



#--------------Insert Patient Table--------------
/************************************
* sp_insertPatient inserts into 
* Address and EmergencyContact
* tables.
************************************/

DELIMITER | 
CREATE PROCEDURE sp_insertPatient
(
IN i_Street1                varchar(30),
IN i_Street2                varchar(30),
IN i_City                   varchar(30),
IN i_Region                 varchar(30),
IN i_Country                varchar(30),
IN i_ECStreet1              varchar(30),
IN i_ECStreet2              varchar(30),
IN i_ECCity                 varchar(30),
IN i_ECRegion               varchar(30),
IN i_ECCountry              varchar(30),
IN i_CFN                    varchar(30),
IN i_CLN                    varchar(30),
IN i_CPN                    varchar(30),
IN i_Relationship           bit(3),
IN i_FirstName              varchar(30),
IN i_MiddleName             varchar(30),
IN i_LastName               varchar(30),
IN i_DateOfBirth            date,
IN i_Gender                 char(10),
IN i_PhoneNumber            varchar(20),
IN i_BloodType              varchar(10),
IN i_TribeRace              varchar(30),
IN i_Religion               varchar(30)
)

BEGIN

DECLARE _AddressID              int;
DECLARE _ECAddressID            int;
DECLARE _PatientID              int;

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

SELECT LAST_INSERT_ID() INTO _AddressID;

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
TribeRace,
Religion
)
VALUES
(
i_FirstName,
i_MiddleName,
i_LastName,
i_DateOfBirth,
i_Gender,
i_PhoneNumber,
_AddressID,
i_BloodType,
i_TribeRace,
i_Religion
);

SELECT LAST_INSERT_ID() INTO _PatientID;

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
i_ECStreet1,
i_ECStreet2,
i_ECCity,
i_ECRegion,
i_ECCountry
);

SELECT LAST_INSERT_ID() INTO _ECAddressID;

INSERT INTO EmergencyContact
(
FirstName,
LastName,
PhoneNumber,
RelationShip,
AddressID,
PatientID
)
VALUES
(
i_CFN,
i_CLN,
i_CPN,
i_RelationShip,
_ECAddressID,
_PatientID
);

END ||
DELIMITER ;

#--------------Update Patient Table--------------
/************************************
* sp_updatePatient updates into 
* Address. Must pass PatientID
************************************/

DELIMITER |
CREATE PROCEDURE sp_updatePatient
(
IN i_PatientID              int,
IN i_Street1                varchar(30),
IN i_Street2                varchar(30),
IN i_City                   varchar(30),
IN i_Region                 varchar(30),
IN i_Country                varchar(30),
IN i_FirstName              varchar(30),
IN i_MiddleName             varchar(30),
IN i_LastName               varchar(30),
IN i_DateOfBirth            date,
IN i_Gender                 char(10),
IN i_PhoneNumber            varchar(20),
IN i_BloodType              varchar(10),
IN i_TribeRace              varchar(30),
IN i_Religion               varchar(30)
)

BEGIN

DECLARE _AddressID  int;

SELECT AddressID FROM Patient WHERE PatientID = i_PatientID INTO _AddressID;

UPDATE Address SET
Street1 = i_Street1,
Street2 = i_Street2,
City = i_City,
Region = i_Region,
Country = i_Country
WHERE _AddressID = AddressID;

UPDATE Patient SET
FirstName = i_FirstName,
MiddleName = i_MiddleName,
LastName = LastName,
DateOfBirth = i_DateOfBirth,
Gender = i_Gender,
PhoneNumber = i_PhoneNumber,
BloodType = i_BloodType,
TribeRace = i_TribeRace,
Religion = i_Religion
WHERE i_PatientID = PatientID;

END ||
DELIMITER ;

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


#--------------Insert Allergy Table--------------
/************************************
* sp_insertAllergy inserts into 
* Allergy tables. Must pass patientID.
************************************/

DELIMITER |
CREATE PROCEDURE sp_insertAllergy
(
IN i_Name          varchar(50),
IN i_Medication    varchar(50),
IN i_PatientID     int
)

BEGIN

INSERT INTO Allergy
(
Name,
Medication,
PatientID
)
VALUES
(
i_Name,
i_Medication,
i_PatientID
);

END ||
DELIMITER ;

#--------------Insert Invoice & PatientCheckIn Table--------------
/**************************************
* sp_insertPatientCheckIn inserts into 
* PatientCheckIn table and creates the
* blank Invoice table.
**************************************/

DELIMITER |
CREATE PROCEDURE sp_insertPatientCheckIn
(
IN i_DateTime        timestamp,
IN i_Type            bit(1),
IN i_Status          bit(1),
IN i_PatientID       int
)

BEGIN

DECLARE _PCIID  int;

INSERT INTO PatientCheckIn
(
DateTime,
Type,
Status,
PatientID
)
VALUES
(
i_DateTime,
i_Type,
i_Status,
i_PatientID
);

SELECT LAST_INSERT_ID() INTO _PCIID;

INSERT INTO Invoice
(
PatientID,
PatientCheckInID
)
VALUES
(
i_PatientID,
_PCIID
);

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
IN i_PatientID      int,
IN i_Total          decimal(6,2)
)

BEGIN

UPDATE Invoice SET
Total = i_Total
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
DECLARE _returnLogID int;

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

INSERT INTO LogIn
(
UserName,
Password,
LogInPermissions
)
VALUES
(
i_UserName,
i_Password,
i_LIP
);

SELECT LAST_INSERT_ID() INTO _returnLogID;

INSERT INTO Staff
(
FirstName,
MiddleName,
LastName,
PhoneNumber,
StaffType,
LicenseNumber,
AddressID,
LogInID
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
_returnLogID
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
IN i_LIP                    char(1),
IN i_FirstName              varchar(30),
IN i_MiddleName             varchar(30),
IN i_LastName               varchar(30),
IN i_PhoneNumber            varchar(20),
IN i_StaffType              tinyint(1),
IN i_LN                     varchar(20)
)

BEGIN

DECLARE _AddressID  int;
DECLARE _LogInID    int;

SELECT AddressID FROM Staff WHERE StaffID = i_StaffID INTO _AddressID;

SELECT LogInID FROM Staff WHERE StaffID = i_StaffID INTO _LogInID;

UPDATE Address SET
Street1 = i_Street1,
Street2 = i_Street2,
City = i_City,
Region = i_Region,
Country = i_Country
WHERE _AddressID = AddressID;

UPDATE LogIn SET
UserName = i_UserName,
Password = i_Password,
LogInPermissions = i_LIP
WHERE _LogInID = LogInID;

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
CREATE PROCEDURE sp_insertProducts
(
IN i_Name               varchar(30),
IN i_Unit               varchar(10),
IN i_Catagory           varchar(20),
IN i_UnitCost           decimal(6, 2),
IN i_QuantityOnHand     int
)

BEGIN

INSERT INTO Products
(
Name,
Unit,
Catagory,
UnitCost,
QuantityOnHand
)
VALUES
(
i_Name,
i_Unit,
i_Catagory,
i_UnitCost,
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
CREATE PROCEDURE sp_updateProducts
(
IN i_ProductsID         int,
IN i_Name               varchar(30),
IN i_Unit               varchar(10),
IN i_Catagory           varchar(20),
IN i_UnitCost           decimal(6, 2),
IN i_QuantityOnHand     int
)

BEGIN

UPDATE Products SET
Name = i_Name,
Unit = i_Unit,
Catagory = i_Catagory,
UnitCost = i_UnitCost,
QuantityOnHand = i_QuantityOnHand
WHERE ProductsID = i_ProductsID;

END ||
DELIMITER ;

#--------------delete Service Table--------------
/************************************
* sp_deleteService deletes(updates)
* Service table IsActice to 0.
************************************/

DELIMITER | 
CREATE PROCEDURE sp_deleteProducts
(
IN i_ProductsID      int
)

BEGIN

UPDATE Products SET
IsActice = 0
WHERE ProductsID = i_ProductsID;

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

#--------------insert InPatient Vitals Table--------------
/************************************
* sp_insertInPatientVitals inserts into
* both InPatientVitals and vitals table.
************************************/

DELIMITER | 
CREATE PROCEDURE sp_insertInPatientVitals
(
IN i_InPatientEncounterID    int,
IN i_Type                    bit(5),
IN i_Height                  varchar(5),
IN i_Weight                  varchar(5),
IN i_HeartRate               int,
IN i_Temperature             decimal(4,1),
IN i_BPSystolic              int,
IN i_BPDiastolic             int,
IN i_RespirtoryRate          int
)

BEGIN

DECLARE _VitalsID int;

INSERT INTO Vitals
(
Type,
Height,
Weight,
HeartRate,
Temperature,
BPSystolic,
BPDiastolic,
RespirtoryRate
)
VALUES
(
i_Type,
i_Height,
i_Weight,
i_HeartRate,
i_Temperature,
i_BPSystolic,
i_BPDiastolic,
i_RespirtoryRate
);

SELECT LAST_INSERT_ID() INTO _VitalsID;

INSERT INTO InPatientVitals
(
VitalsID,
InPatientEncounterID
)
VALUES
(
_VitalsID,
i_InPatientEncounterID
);

END ||
DELIMITER ;

#--------------insert OutPatient Vitals Table--------------
/************************************
* sp_insertOutPatientVitals inserts into
* both OutPatientVitals and vitals table.
************************************/

DELIMITER | 
CREATE PROCEDURE sp_insertOutPatientVitals
(
IN i_OutPatientEncounterID   int,
IN i_Type                    bit(5),
IN i_Height                  varchar(5),
IN i_Weight                  varchar(5),
IN i_HeartRate               int,
IN i_Temperature             decimal(4,1),
IN i_BPSystolic              int,
IN i_BPDiastolic             int,
IN i_RespirtoryRate          int
)

BEGIN

DECLARE _VitalsID int;

INSERT INTO Vitals
(
Type,
Height,
Weight,
HeartRate,
Temperature,
BPSystolic,
BPDiastolic,
RespirtoryRate
)
VALUES
(
i_Type,
i_Height,
i_Weight,
i_HeartRate,
i_Temperature,
i_BPSystolic,
i_BPDiastolic,
i_RespirtoryRate
);

SELECT LAST_INSERT_ID() INTO _VitalsID;

INSERT INTO OutPatientVitals
(
VitalsID,
OutPatientEncounterID
)
VALUES
(
_VitalsID,
i_OutPatientEncounterID
);

END ||
DELIMITER ;

#--------------insert Surgery Vitals Table--------------
/************************************
* sp_insertSurgeryVitals inserts into
* both SurgeryVitals and vitals table.
************************************/

DELIMITER | 
CREATE PROCEDURE sp_insertSurgeryVitals
(
IN i_SurgeryID               int,
IN i_Type                    bit(5),
IN i_Height                  varchar(5),
IN i_Weight                  varchar(5),
IN i_HeartRate               int,
IN i_Temperature             decimal(4,1),
IN i_BPSystolic              int,
IN i_BPDiastolic             int,
IN i_RespirtoryRate          int
)

BEGIN

DECLARE _VitalsID int;

INSERT INTO Vitals
(
Type,
Height,
Weight,
HeartRate,
Temperature,
BPSystolic,
BPDiastolic,
RespirtoryRate
)
VALUES
(
i_Type,
i_Height,
i_Weight,
i_HeartRate,
i_Temperature,
i_BPSystolic,
i_BPDiastolic,
i_RespirtoryRate
);

SELECT LAST_INSERT_ID() INTO _VitalsID;

INSERT INTO SurgeryVitals
(
VitalsID,
SurgeryID
)
VALUES
(
_VitalsID,
i_SurgeryID
);

END ||
DELIMITER ;


#--------------insert InPatient Table--------------
/************************************
* sp_insertInPatient inserts
* InPatient table.
************************************/

DELIMITER | 
CREATE PROCEDURE sp_insertInPatient
(
IN i_PatientCheckInID       int,
IN i_AdmitReason            varchar(30),
IN i_Comments               varchar(255),
IN i_AdmitDate              timestamp,
IN i_staffFname             varchar(30),
IN i_staffLname             varchar(30),
IN i_WardNumber             int
)

BEGIN

DECLARE _staffID int;

SELECT StaffID FROM Staff WHERE FirstName LIKE i_staffFname && LastName LIKE i_staffLname INTO _staffID;

INSERT INTO InPatient
(
PatientCheckInID,
AdmitReason,
Comments,
AdmitDate,
StaffID,
WardNumber
)
VALUES
(
i_PatientCheckInID,
i_AdmitReason,
i_Comments,
i_AdmitDate,
_StaffID,
i_WardNumber
);

END ||
DELIMITER ;

#--------------insert InPatientEncounter Table--------------
/************************************
* sp_insertInPatientEncounter inserts
* InPatientEncounter table.
************************************/

DELIMITER | 
CREATE PROCEDURE sp_insertInPatientEncounter
(
IN i_Time           timestamp,
IN i_InPatientID    int,
IN i_Diagnosis      text,
IN i_staffFname     varchar(30),
IN i_staffLname     varchar(30)
)

BEGIN

DECLARE _staffID int;

SELECT StaffID FROM Staff WHERE FirstName LIKE i_staffFname && LastName LIKE i_staffLname INTO _staffID;

INSERT INTO InPatientEncounter
(
Time,
InPatientID,
Diagnosis,
StaffID
)
VALUES
(
i_Time,
i_InPatientID,
i_Diagnosis,
_staffID
);

END ||
DELIMITER ;

#--------------insert OutPatientEncounter Table--------------
/************************************
* sp_insertOutPatientEncounter inserts
* OutPatientEncounter table.
************************************/

DELIMITER |
CREATE PROCEDURE sp_insertOutPatientEncounter
(
IN i_PatientCheckInID     int,
IN i_Time                   timestamp,
IN i_Comments               varchar(255),
IN i_RoomNumber             int,
IN i_Diagnosis              text,
IN i_staffFname             varchar(30),
IN i_staffLname             varchar(30)
)

BEGIN

DECLARE _staffID int;

SELECT StaffID FROM Staff WHERE FirstName LIKE i_staffFname && LastName LIKE i_staffLname INTO _staffID;

INSERT INTO OutPatientEncounter
(
PatientCheckInID,
Time,
Comments,
RoomNumber,
Diagnosis,
StaffID
)
VALUES
(
i_PatientCheckInID,
i_Time,
i_Comments,
i_RoomNumber,
i_Diagnosis,
_staffID
);


END ||
DELIMITER ;

#--------------insert Surgery Table--------------
/************************************
* sp_insertSurgery inserts
* Surgery table.
************************************/

DELIMITER |
CREATE PROCEDURE sp_insertSurgery
(
IN i_SurgeryType        text,
IN i_RoomNumber         int,
IN i_StartTime          timestamp,
IN i_EndTime            timestamp,
IN i_Comments           varchar(255),
IN I_InPatientID        int
)

BEGIN

INSERT INTO Surgery
(
SurgeryType,
RoomNumber,
StartTime,
EndTime,
Comments,
InPatientID
)
VALUES
(
I_SurgeryType,
I_RoomNumber,
I_StartTime,
I_EndTime,
I_Comments,
I_InPatientID
);

END ||
DELIMITER ;

#--------------insert SurgeryStaff Table--------------
/************************************
* sp_insertSurgeryStaff inserts
* SurgeryStaff table.
************************************/

DELIMITER |
CREATE PROCEDURE sp_insertSurgeryStaff
(
IN i_staffFname     varchar(30),
IN i_staffLname     varchar(30),
IN i_InPatientID    int
)

BEGIN

DECLARE _staffID int;
DECLARE _SurgeryID int;

SELECT StaffID FROM Staff WHERE FirstName LIKE i_staffFname && LastName LIKE i_staffLname INTO _staffID;
SELECT SurgeryID FROM Surgery WHERE InPatientID = i_InPatientID INTO _SurgeryID;

INSERT INTO SurgeryStaff
(
StaffID,
SurgeryID
)
VALUES
(
_staffID,
_SurgeryID
);


END ||
DELIMITER ;


#-----------------------------------------------------------------------------------------------------------
#-------------------------------------------------TEST DATA-------------------------------------------------
#-----------------------------------------------------------------------------------------------------------

CALL sp_insertPatient
(
'12667 W. 85th Cir',
'',
'Arvada',
'Co',
'USA',
'2558 S 1687 W',
'',
'Layton',
'Ut',
'USA',
'Lila',
'Harp',
'303-421-3837',
4,
'Ed',
'',
'Harp',
'1940-02-10',
'Male',
'303-276-8557',
'AB+',
'White',
'LDS'
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

CALL sp_insertPatientCheckIn
(
NOW(),
1,
1,
100000
);

CALL sp_updateInvoice
(
100000,
800.25
);

CALL sp_insertInPatient
(
1,
'Pancreatitis',
'They feels bad',
NOW(),
'Cameron',
'Harp',
1
);

CALL sp_insertInPatientEncounter
(
NOW(),
1,
'Something',
'Jimmy',
'John'
);

CALL sp_insertOutPatientEncounter
(
1,
NOW(),
'Patient has a sore throat',
11,
'Common Cold',
'Cameron',
'Harp'
);

CALL sp_insertInPatientVitals
(
1,
1,
'5''10''',
202,
65,
98.5,
120,
80,
88
);

CALL sp_insertOutPatientVitals
(
1,
2,
'4''9''',
100,
60,
105.5,
110,
70,
79
);

CALL sp_insertSurgery
(
'SAD',
1,
NOW(),
NOW(),
null,
1
);

CALL sp_insertSurgeryVitals
(
1,
3,
'7''1''',
390,
100,
98.5,
140,
90,
92
);

CALL sp_insertSurgeryStaff
(
'Cameron',
'Harp',
1
);

CALL sp_insertSurgeryStaff
(
'Jimmy',
'John',
1
);