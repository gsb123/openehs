/*****************************************************************************
 * Project: Open Electronic Healthcare System
 * Group: Ghana Team
 * Date: Jan-3-2011
 * Version: Final
 * 
 * Author: Cameron Harp (charp5257@gmail.com)
 *****************************************************************************/
 
 /*************************************************************************************
 * Database Notes:
 *
 * Download:
 *      Go to my sql.com and download the 5.2+ community server and workbench
 * 
 * Run Script:
 *      See "First Time Run Instructions.txt" file in SQL folder
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
PatientID                   int                 AUTO_INCREMENT          PRIMARY KEY         NOT NULL,
FirstName                   varchar(30)         NOT NULL,
MiddleName                  varchar(30)         NULL,
LastName                    varchar(30)         NOT NULL,
DateOfBirth                 Date                NOT NULL,
Gender                      char(10)            NOT NULL,
PhoneNumber                 varchar(20)         NULL,
AddressID                   int                 NOT NULL,
BloodType                   varchar(10)         NULL,
TribeRace                   varchar(30)         NULL,
Religion                    varchar(30)         NULL,
PatientNote                 longtext            NULL,
OldPhysicalRecordNumb       int                 Null,
EmergencyContactID          int                 NULL,
DateOfDeath                 datetime            NULL,
IsActive                    bit(1)              NOT NULL                DEFAULT 1
) AUTO_INCREMENT= 100000;

CREATE TABLE Medication
(
MedicationID        int         AUTO_INCREMENT          PRIMARY KEY         NOT NULL,
`Name`              text        NOT NULL,
Instruction         text        NOT NULL,
StartDate           datetime    NOT NULL,
ExpDate             datetime    NOT NULL,
PatientID           int         NOT NULL
);

CREATE TABLE Allergy
(
AllergyID               int             AUTO_INCREMENT              PRIMARY KEY         NOT NULL,
`Name`                    varchar(30)     NULL,
IsActive                bit(1)          NOT NULL                    DEFAULT 1
);

CREATE TABLE PatientAllergy
(
PatientAllergyID            int         AUTO_INCREMENT              PRIMARY KEY         NOT NULL,
PatientID                   int         NOT NULL,
AllergyID                   int         NOT NULL
);

CREATE TABLE Immunization
(
ImmunizationID          int             AUTO_INCREMENT          PRIMARY KEY         NOT NULL,
VaccineType             text            NOT NULL,
DateAdministered        datetime        NOT NULL,
Comments                text            NULL
);

CREATE TABLE PatientImmunization
(
PatientImmunizationID       int             AUTO_INCREMENT          PRIMARY KEY         NOT NULL,
PatientID                   int             NOT NULL,
ImmunizationID              int             NOT NULL
);

CREATE TABLE Problem
(
ProblemID           int             AUTO_INCREMENT          PRIMARY KEY     NOT NULL,
ProblemName         varchar(30)     NOT NULL
);

CREATE TABLE PatientProblem
(
PatientProblemID        int         AUTO_INCREMENT          PRIMARY KEY         NOT NULL,
PatientID               int         NOT NULL,
ProblemID               int         NOT NULL
);

CREATE TABLE Location
(
LocationID          int             AUTO_INCREMENT          PRIMARY KEY         NOT NULL,
Department          varchar(20)     NOT NULL,
RoomNumber          varchar(15)     NOT NULL,
IsActive            bit                 NOT NULL            DEFAULT 1
);

CREATE TABLE PatientCheckIn
(
PatientCheckInID            int             AUTO_INCREMENT              PRIMARY KEY         NOT NULL,
CheckinTime                 datetime       NOT NULL,
PatientType                 tinyint         NOT NULL,
PatientID                   int             NOT NULL,
InvoiceID                   int             NOT NULL,
CheckOutTime                datetime       NULL,
Diagnosis                   text            NULL,
LocationID                  int             NOT NULL,
StaffID                     int             NULL,
TimeOfDeath                 datetime        NULL,
IsActive                    bit             NOT NULL                    DEFAULT 1
);

CREATE TABLE FeedChart
(
FeedChartID             int             AUTO_INCREMENT              PRIMARY KEY         NOT NULL,
PatientCheckInID        int             NOT NULL,
FeedTime                timestamp       NOT NULL                    DEFAULT NOW(),
FeedType                varchar(30)     NULL,
AmountOffered            varchar(20)           NULL,
AmountTaken             varchar(20)           NULL,
Vomit                   varchar(20)     NULL,
Urine                   varchar(20)     NULL,
Stool                   varchar(20)     NULL,
Comments                text            NULL
);

CREATE TABLE OutputChart
(
OutputChartID            int             AUTO_INCREMENT          PRIMARY KEY         NOT NULL,
ChartTime           timestamp       NOT NULL,
NGSuctionAmount     varchar(20)           NULL,
NGSuctionColor      varchar(30)     NULL,
UrineAmount         varchar(20)           NULL,
StoolAmount         varchar(20)           NULL,
StoolColor          varchar(30)     NULL,
PatientCheckInID        int             NOT NULL
);

CREATE TABLE IntakeChart
(
InTakeChartID            int             AUTO_INCREMENT          PRIMARY KEY         NOT NULL,
ChartTime           timestamp       NOT NULL,
KindOfFluid          varchar(30)     NULL,
Amount        varchar(20)           NULL,
PatientCheckInID        int             NOT NULL
);

CREATE TABLE Invoice
(
InvoiceID               int             AUTO_INCREMENT          PRIMARY KEY         NOT NULL,
Total                   decimal(6,2)    NOT NULL                DEFAULT 0.00,
`Date`                  timestamp       NOT NULL                DEFAULT CURRENT_TIMESTAMP,
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

CREATE TABLE InvoiceItem
(
    InvoiceItemID               int                 AUTO_INCREMENT             PRIMARY KEY         NOT NULL,
    InvoiceID                   int                 NOT NULL,
    ProductID                   int                 NULL,
    ServiceID                   int                 NULL,
    Quantity                    float               NULL,
    IsActive                    bit(1)              NOT NULL                DEFAULT 1
);

CREATE TABLE Category
(
    CategoryID                  int                 AUTO_INCREMENT              PRIMARY KEY         NOT NULL,
    `Name`                      varchar(30)         NOT NULL,
    Description                 text                NULL,
    DateCreated                 timestamp           NOT NULL                    DEFAULT NOW(),
    IsActive                    bit                 NOT NULL                    DEFAULT 1
);

CREATE TABLE Product
(
    ProductID                   int                 AUTO_INCREMENT          PRIMARY KEY         NOT NULL,
    `Name`                      varchar(50)         NOT NULL,
    Unit                        varchar(10)         NOT NULL,
    CategoryID                  int                 NOT NULL,
    ProductCost                 decimal(6,2)        NOT NULL,
    QuantityOnHand              int                 NOT NULL,
    Counter                     int                 NOT NULL                DEFAULT 1,
    IsActive                    bit(1)              NOT NULL                DEFAULT 1
);

CREATE TABLE Service
(
    ServiceID                   int                 AUTO_INCREMENT          PRIMARY KEY         NOT NULL,
    `Name`                      varchar(30)         NOT NULL,
    ServiceCost                 decimal(6, 2)       NOT NULL,
    IsActive                    bit(1)              NOT NULL                DEFAULT 1
);

CREATE TABLE `User`
(
    UserID                      int                 AUTO_INCREMENT          PRIMARY KEY         NOT NULL,
    Username                    varchar(30)         NOT NULL,
    EmailAddress                varchar(50)         NULL,
    ApplicationName             varchar(30)         NULL,
    `Password`                  varchar(30)         NOT NULL,
    PasswordQuestion            varchar(50)         NULL,
    PasswordAnswer              varchar(50)         NULL,
    DateCreated                 timestamp           NOT NULL                DEFAULT NOW(),
    LastLogin                   datetime            NULL,
    LastActivity                datetime            NULL,
    IsOnline                    bit(1)              NOT NULL                DEFAULT 0,
    IpAddress                   varchar(20)         NULL,
    IsLockedOut                 bit(1)              NOT NULL                DEFAULT 0,
    FailedPasswordAttemptCount  int                 NOT NULL                DEFAULT 0,
    IsApproved                  bit(1)              NOT NULL                DEFAULT 0,
    IsActive                    bit(1)              NOT NULL                DEFAULT 1
);

CREATE TABLE UserRole
(
    UserRoleID                  int                 NOT NULL                PRIMARY KEY         AUTO_INCREMENT,
    UserID                      int                 NOT NULL,
    RoleID                      int                 NOT NULL
);

CREATE TABLE Staff
(
    StaffID                     int                 AUTO_INCREMENT          PRIMARY KEY         NOT NULL,
    FirstName                   varchar(30)         NOT NULL,
    MiddleName                  varchar(30)         NULL,
    LastName                    varchar(30)         NOT NULL,
    PhoneNumber                 varchar(20)         NOT NULL,
    StaffType                   tinyint(1)          NOT NULL,
    LicenseNumber               varchar(20)         NULL                    Default NULL,
    AddressID                   int                 NOT NULL,
    UserID                      int                 NOT NULL,
    IsActive                    bit(1)              NOT NULL                DEFAULT 1
);

CREATE TABLE Vitals
(
    VitalsID                    int                 AUTO_INCREMENT          PRIMARY KEY         NOT NULL,
    `Time`                      timestamp           NOT NULL,
    `Type`                      bit(5)              NOT NULL,
    Height                      float             NULL,
    Weight                      float             NULL,
    HeartRate                   int             NULL,
    Temperature                 decimal(4,1)        NULL,
    BPSystolic                  int                 NULL,
    BPDiastolic                 int                 NULL,
    RespiratoryRate             int             NULL,
    PatientCheckInID            int                 NULL,
    IsActive                    bit(1)              NOT NULL                DEFAULT 1
);

CREATE TABLE Surgery
(
    SurgeryID                   int                 AUTO_INCREMENT          PRIMARY KEY         NOT NULL,
    StartTime                   datetime                NOT NULL,
    EndTime                     datetime                NULL,
    LocationID                  int                 NULL,
    PatientCheckInID          int                 NOT NULL,
    CaseType                    bit                 NOT NULL
);

CREATE TABLE SurgeryStaff
(
    SurgeryStaffID              int                 AUTO_INCREMENT          PRIMARY KEY         NOT NULL,
    StaffID                     int                 NOT NULL,
    SurgeryID                   int                 NOT NULL,
    Role                        int                 NOT NULL
);

CREATE TABLE NoteTemplateCategory
(
    NoteTemplateCategoryID          int                 AUTO_INCREMENT          PRIMARY KEY      NOT NULL,
    TemplateCategoryName            varchar(30)         NOT NULL
);

CREATE TABLE Note
(
    NoteID                      int                 AUTO_INCREMENT          PRIMARY KEY                      NOT NULL,
    Title                       varchar(30)         NULL,
    Body                        longtext            NOT NULL,
    DateCreated                 timestamp           NOT NULL                DEFAULT CURRENT_TIMESTAMP,
    StaffID                     int                 NOT NULL,
    NoteTemplateCategoryID      int                 NULL,
    PatientCheckInID            int                 NOT NULL,
    IsActive                    bit(1)              NOT NULL                DEFAULT 1
);

CREATE TABLE Template
(
    TemplateID                  int                 AUTO_INCREMENT          PRIMARY KEY         NOT NULL,
    Title                       varchar(150)        NOT NULL,
    TemplateBody                longtext            NOT NULL,
    NoteTemplateCategoryID      int                 NOT NULL,
    StaffID                     int                 NOT NULL,
    IsActive                    bit(1)              NOT NULL                DEFAULT 1
);

CREATE TABLE Role
(
    RoleID                      int                 AUTO_INCREMENT          PRIMARY KEY         NOT NULL,
    `Name`                      varchar(30)         NOT NULL,
    Description                 varchar(255)        NULL,
    DateCreated                 timestamp           NOT NULL                DEFAULT NOW()
);

#----------------------------------------------------------------------------------------------------------
#---------------------------------------------------FK's---------------------------------------------------
#----------------------------------------------------------------------------------------------------------

ALTER TABLE EmergencyContact
ADD CONSTRAINT FK_EmergencyContactMustHaveAddressID
FOREIGN KEY (AddressID) REFERENCES Address(AddressID);

ALTER TABLE Patient
ADD CONSTRAINT FK_PatientMustHaveAddressID
FOREIGN KEY (AddressID) REFERENCES Address(AddressID);

ALTER TABLE Patient
ADD CONSTRAINT FK_PatientMustHaveEmergencyContactID
FOREIGN KEY (EmergencyContactID) REFERENCES EmergencyContact(EmergencyContactID);

ALTER TABLE Staff
ADD CONSTRAINT FK_StaffMustHaveAddressID
FOREIGN KEY (AddressID) REFERENCES Address(AddressID);

ALTER TABLE Staff
ADD CONSTRAINT FK_StaffMustHaveUserID
FOREIGN KEY (UserID) REFERENCES User(UserID);


ALTER TABLE PatientAllergy
ADD CONSTRAINT FK_PatientAllergyMustHavePatientID
FOREIGN KEY (PatientID) REFERENCES Patient(PatientID);

ALTER TABLE PatientAllergy
ADD CONSTRAINT FK_PatientAllergyMustHaveAllergyID
FOREIGN KEY (AllergyID) REFERENCES Allergy(AllergyID);

ALTER TABLE PatientCheckIn
ADD CONSTRAINT FK_PatientCheckInMustHavePatientID
FOREIGN KEY (PatientID) REFERENCES Patient(PatientID);

ALTER TABLE PatientCheckIn
ADD CONSTRAINT FK_PatientCheckInMustHaveLocationID
FOREIGN KEY (LocationID) REFERENCES Location(LocationID);

ALTER TABLE PatientCheckIn
ADD CONSTRAINT FK_PatientCheckInMustHaveStaffID
FOREIGN KEY (StaffID) REFERENCES Staff(StaffID);

ALTER TABLE FeedChart
ADD CONSTRAINT FK_FeedChartMustHavePatientCheckInID
FOREIGN KEY (PatientCheckInID) REFERENCES PatientCheckIn(PatientCheckInID);

ALTER TABLE IntakeChart
ADD CONSTRAINT FK_IntakeChartMustHavePatientCheckInID
FOREIGN KEY (PatientCheckInID) REFERENCES PatientCheckIn(PatientCheckInID);

ALTER TABLE OutputChart
ADD CONSTRAINT FK_OutputChartMustHavePatientCheckInID
FOREIGN KEY (PatientCheckInID) REFERENCES PatientCheckIn(PatientCheckInID);

/*ALTER TABLE Invoice
ADD CONSTRAINT FK_InvoiceMustHavePatientCheckInID
FOREIGN KEY (PatientCheckInID) REFERENCES PatientCheckIn(PatientCheckInID);*/

ALTER TABLE InvoiceItem
ADD CONSTRAINT FK_InvoiceItemMustHaveInvoiceID
FOREIGN KEY (InvoiceID) REFERENCES Invoice(InvoiceID);

ALTER TABLE InvoiceItem
ADD CONSTRAINT FK_InvoiceItemMustHaveProductID
FOREIGN KEY (ProductID) REFERENCES Product(ProductID);

ALTER TABLE InvoiceItem
ADD CONSTRAINT FK_InvoiceItemMustHaveServiceID
FOREIGN KEY (ServiceID) REFERENCES Service(ServiceID);

ALTER TABLE Payment
ADD CONSTRAINT FK_PaymentMustHaveInvoiceID
FOREIGN KEY (InvoiceID) REFERENCES Invoice(InvoiceID);

ALTER TABLE Note
ADD CONSTRAINT FK_NoteMustHaveStaffID
FOREIGN KEY (StaffID) REFERENCES Staff(StaffID);

ALTER TABLE Note
ADD CONSTRAINT FK_NoteMustHavePatientCheckInID
FOREIGN KEY (PatientCheckInID) REFERENCES PatientCheckIn(PatientCheckInID);

ALTER TABLE Surgery
ADD CONSTRAINT FK_SurgeryMustHavePatientCheckInID
FOREIGN KEY (PatientCheckInID) REFERENCES PatientCheckIn(PatientCheckInID);

ALTER TABLE Surgery
ADD CONSTRAINT FK_SurgeryMustHaveLocationID
FOREIGN KEY (LocationID) REFERENCES Location(LocationID);

ALTER TABLE SurgeryStaff
ADD CONSTRAINT FK_SurgeryStaffMustHaveStaffID
FOREIGN KEY (StaffID) REFERENCES Staff(StaffID);

ALTER TABLE SurgeryStaff
ADD CONSTRAINT FK_SurgeryStaffMustHaveSurgeryID
FOREIGN KEY (SurgeryID) REFERENCES Surgery(SurgeryID);

ALTER TABLE Vitals
ADD CONSTRAINT FK_VitalsMustHavePatientCheckInID
FOREIGN KEY (PatientCheckInID) REFERENCES PatientCheckIn(PatientCheckInID);

ALTER TABLE PatientProblem
ADD CONSTRAINT FK_PatientProblemMustHavePatientID
FOREIGN KEY (PatientID) REFERENCES Patient(PatientID);

ALTER TABLE PatientProblem
ADD CONSTRAINT FK_PatientProblemMustHaveProblemID
FOREIGN KEY (ProblemID) REFERENCES Problem(ProblemID);

ALTER TABLE Template
ADD CONSTRAINT TemplateMustHaveStaffID
FOREIGN KEY (StaffID) REFERENCES Staff(StaffID);

ALTER TABLE Template
ADD CONSTRAINT TemplateMustHaveNoteTemplateCategoryID
FOREIGN KEY (NoteTemplateCategoryID) REFERENCES NoteTemplateCategory(NoteTemplateCategoryID);

ALTER TABLE Product
ADD CONSTRAINT ProductMustHaveCategoryID
FOREIGN KEY (CategoryID) REFERENCES Category(CategoryID);

ALTER TABLE PatientImmunization
ADD CONSTRAINT PatientImmunizationMustHavePatientID
FOREIGN KEY (PatientID) REFERENCES Patient(PatientID);

ALTER TABLE PatientImmunization
ADD CONSTRAINT PatientImmunizationMustHaveImmunizationID
FOREIGN KEY (ImmunizationID) REFERENCES Immunization(ImmunizationID);

ALTER TABLE Medication
ADD CONSTRAINT MedicationMustHavePatientID
FOREIGN KEY (PatientID) REFERENCES Patient(PatientID);

#----------------------------------------------------------------------------------------------------------
#-------------------------------------------------TRIGGERS-------------------------------------------------
#----------------------------------------------------------------------------------------------------------

#----------Auto Correct Patient Name----------

DELIMITER $$
CREATE TRIGGER tr_AutoCorrectFormatPatientInfo
BEFORE INSERT ON Patient

FOR EACH ROW

BEGIN
    SET NEW.FirstName = CONCAT(UCASE(substr(NEW.FirstName,1,1)), substr(NEW.FirstName,2));
    SET NEW.MiddleName = CONCAT(UCASE(substr(NEW.MiddleName,1,1)), substr(NEW.MiddleName,2));
    SET NEW.LastName = CONCAT(UCASE(substr(NEW.LastName,1,1)), substr(NEW.LastName,2));
    SET NEW.TribeRace = CONCAT(UCASE(substr(NEW.TribeRace,1,1)), substr(NEW.TribeRace,2));
    SET NEW.Religion = CONCAT(UCASE(substr(NEW.Religion,1,1)), substr(NEW.Religion,2));
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
TribeRace,
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
'Male',
'3032768557',
2,
'AB+',
'white',
'lDS',
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
TribeRace,
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
'Female',
'8014587895',
4,
'AB',
'white',
'N/A',
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
TribeRace,
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
'Male',
'8013208896',
6,
'AB',
'white',
'Catholic',
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
TribeRace,
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
'Male',
'8019995265',
8,
'O-',
'white',
'N/A',
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
VaccineType,
DateAdministered,
Comments
)
VALUES
(
'DTP - Diphtheria, tetanus toxoids, and whole cell pertussis',
NOW(),
null
);

INSERT INTO Immunization
(
VaccineType,
DateAdministered,
Comments
)
VALUES
(
'IPV - Poliovirus vaccine, inactivated',
NOW(),
null
);

INSERT INTO Immunization
(
VaccineType,
DateAdministered,
Comments
)
VALUES
(
'Hep B - 3 dose schedule',
NOW(),
null
);

INSERT INTO Immunization
(
VaccineType,
DateAdministered,
Comments
)
VALUES
(
'YellowFevor',
'2009-08-07 00:00:00',
null
);

INSERT INTO Immunization
(
VaccineType,
DateAdministered,
Comments
)
VALUES
(
'TwinRix',
'2010-10-15 00:00:00',
null
);

INSERT INTO Immunization
(
VaccineType,
DateAdministered,
Comments
)
VALUES
(
'YellowFevor',
'2002-01-16 00:00:00',
null
);

INSERT INTO Immunization
(
VaccineType,
DateAdministered,
Comments
)
VALUES
(
'Flu Shot',
'2000-01-05 00:00:00',
null
);

INSERT INTO PatientImmunization
(
PatientID,
ImmunizationID
)
VALUES
(
100000,
1
);

INSERT INTO PatientImmunization
(
PatientID,
ImmunizationID
)
VALUES
(
100000,
3
);

INSERT INTO PatientImmunization
(
PatientID,
ImmunizationID
)
VALUES
(
100001,
2
);

INSERT INTO PatientImmunization
(
PatientID,
ImmunizationID
)
VALUES
(
100000,
4
);

INSERT INTO PatientImmunization
(
PatientID,
ImmunizationID
)
VALUES
(
100000,
5
);

INSERT INTO PatientImmunization
(
PatientID,
ImmunizationID
)
VALUES
(
100001,
6
);

INSERT INTO PatientImmunization
(
PatientID,
ImmunizationID
)
VALUES
(
100000,
7
);

INSERT INTO Medication
(
`Name`,
Instruction,
StartDate,
ExpDate,
PatientID
)
VALUES
(
'Lisinopril oral tablet 10mg',
'Qty 30 of 10mg, 1 every 4 hours. (6 refills)',
NOW(),
'2011-04-14 00:00:00',
100000
);

INSERT INTO Medication
(
`Name`,
Instruction,
StartDate,
ExpDate,
PatientID
)
VALUES
(
'Metformin Hydrochlorid (metformin) oral tablet 500mg',
'Whatever the directions are',
'2007-10-01 00:00:00',
'2008-05-10 00:00:00',
100000
);

INSERT INTO Medication
(
`Name`,
Instruction,
StartDate,
ExpDate,
PatientID
)
VALUES
(
'Plavix oral tablet 1000mg',
'Take when not feeling well',
'2002-01-01 00:00:00',
'2002-05-02 00:00:00',
100000
);


INSERT INTO Medication
(
`Name`,
Instruction,
StartDate,
ExpDate,
PatientID
)
VALUES
(
'DOXYCYCL HYC oral tablet 100mg',
'Take one tab by mouth twice daily',
'2005-12-10 00:00:00',
'2009-08-07 00:00:00',
100001
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
    2,
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
    2,
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
    3,
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