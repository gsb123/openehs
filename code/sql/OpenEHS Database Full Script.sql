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
PhoneNumber                 varchar(20)      NULL,
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
Gender                      int                 NOT NULL,
PhoneNumber                 varchar(20)         NULL,
AddressID                   int                 NOT NULL,
BloodType                   int                 NULL,
Tribe                       int                 NULL,
Race                        int                 NULL,
Religion                    int                 NULL,
Occupation                  varchar(30)         NULL,
Education                   int                 NULL,
PatientNote                 longtext            NULL,
OldPhysicalRecordNumb       varchar(50)         Null,
InsuranceNumber             varchar(20)         NULL,
InsuranceExpiration         datetime            NULL,
EmergencyContactID          int                 NULL,
DateOfDeath                 datetime            NULL,
IsActive                    bit(1)              NOT NULL                DEFAULT 1
) AUTO_INCREMENT= 100000;

CREATE TABLE PatientMedication
(
PatientMedicationID         int             AUTO_INCREMENT          PRIMARY KEY         NOT NULL,
Instruction                 text            NULL,
StartDate                   datetime        NOT NULL,
ExpDate                     datetime        NOT NULL,
Dose                        varchar(15)     NOT NULL,
Frequency                   varchar(20)     NOT NULL,
Administration              int             NOT NULL,
PatientID                   int             NOT NULL,
MedicationID                int             NOT NULL
);

CREATE TABLE Medication
(
MedicationID        int         AUTO_INCREMENT      PRIMARY KEY     NOT NULL,
`Name`              text        NOT NULL,
Description         text        NULL,
IsActive            bit         NOT NULL
);

CREATE TABLE Allergy
(
AllergyID               int             AUTO_INCREMENT              PRIMARY KEY         NOT NULL,
`Name`                  varchar(30)   NULL,
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
IsActive                bit             NOT NULL                DEFAULT 1
);

CREATE TABLE PatientImmunization
(
PatientImmunizationID       int             AUTO_INCREMENT          PRIMARY KEY         NOT NULL,
PatientID                   int             NOT NULL,
DateAdministered            datetime        NOT NULL,
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
LocationID          int                 AUTO_INCREMENT          PRIMARY KEY         NOT NULL,
Department          varchar(20)         NOT NULL,
RoomNumber          varchar(15)         NOT NULL,
IsActive            bit                 NOT NULL            DEFAULT 1
);

CREATE TABLE PatientCheckIn
(
PatientCheckInID            int             AUTO_INCREMENT              PRIMARY KEY         NOT NULL,
CheckinTime                 datetime        NOT NULL,
PatientType                 tinyint         NOT NULL,
PatientID                   int             NOT NULL,
InvoiceID                   int             NOT NULL,
CheckOutTime                datetime        NULL,
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
AmountOffered           varchar(20)    NULL,
AmountTaken             varchar(20)     NULL,
Vomit                   varchar(20)     NULL,
Urine                   varchar(20)     NULL,
Stool                   varchar(20)     NULL,
Comments                text            NULL
);

CREATE TABLE OutputChart
(
OutputChartID            int              AUTO_INCREMENT          PRIMARY KEY         NOT NULL,
ChartTime           timestamp             NOT NULL,
NGSuctionAmount     varchar(20)           NULL,
NGSuctionColor      varchar(30)           NULL,
UrineAmount         varchar(20)           NULL,
StoolAmount         varchar(20)           NULL,
StoolColor          varchar(30)           NULL,
PatientCheckInID        int               NOT NULL
);

CREATE TABLE IntakeChart
(
InTakeChartID            int            AUTO_INCREMENT          PRIMARY KEY         NOT NULL,
ChartTime           timestamp           NOT NULL,
KindOfFluid          varchar(30)        NULL,
Amount        varchar(20)               NULL,
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
    LastPasswordChange          datetime            NULL,
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
    Height                      float               NULL,
    Weight                      float               NULL,
    HeartRate                   int                 NULL,
    Temperature                 decimal(4,1)        NULL,
    BPSystolic                  int                 NULL,
    BPDiastolic                 int                 NULL,
    RespiratoryRate             int                 NULL,
    PatientCheckInID            int                 NULL,
    IsActive                    bit(1)              NOT NULL                DEFAULT 1
);

CREATE TABLE Surgery
(
    SurgeryID                   int                 AUTO_INCREMENT          PRIMARY KEY         NOT NULL,
    StartTime                   datetime                NOT NULL,
    EndTime                     datetime                NULL,
    LocationID                  int                 NULL,
    PatientCheckInID            int                 NOT NULL,
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
    `Type`                      varchar(20)         NOT NULL,
    Body                        longtext            NOT NULL,
    DateCreated                 datetime            NOT NULL,
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

ALTER TABLE PatientMedication
ADD CONSTRAINT PatientMedicationMustHavePatientID
FOREIGN KEY (PatientID) REFERENCES Patient(PatientID);

ALTER TABLE PatientMedication
ADD CONSTRAINT PatientMedicationMustHaveMedicationID
FOREIGN KEY (MedicationID) REFERENCES Medication(MedicationID);

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

/****************************
Do not delete anything below
****************************/

insert into NoteTemplateCategory 
(
TemplateCategoryName
) values 
(
'General'
);

insert into NoteTemplateCategory 
(
TemplateCategoryName
) 
values 
(
'Surgery'
);