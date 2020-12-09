-- Created by Vertabelo (http://vertabelo.com)
-- Last modification date: 2020-12-07 08:27:05.806

-- tables
-- Table: Attendees
CREATE TABLE Attendees (
    attendeesID int  NOT NULL,
    meetingID int  NOT NULL,
    userID int  NOT NULL,
    CONSTRAINT Attendees_pk PRIMARY KEY  (attendeesID)
);

-- Table: Authentication
CREATE TABLE Authentication (
    authID int  NOT NULL,
    authProvider nvarchar(128)  NOT NULL,
    email nvarchar(320)  NOT NULL,
    token nvarchar(255)  NOT NULL,
    userID int  NOT NULL,
    CONSTRAINT Authentication_pk PRIMARY KEY  (authID)
);

-- Table: Meeting
CREATE TABLE Meeting (
    meetingID int  NOT NULL,
    meetingTitle nvarchar(128)  NOT NULL,
    startTime smalldatetime  NOT NULL,
    endTime smalldatetime  NOT NULL,
    creatorID int  NOT NULL,
    meetingStatusID int  NOT NULL,
    roomID int  NOT NULL,
    CONSTRAINT Meeting_pk PRIMARY KEY  (meetingID)
);

-- Table: Meeting_Status
CREATE TABLE Meeting_Status (
    meetingStatusID int  NOT NULL,
    name nvarchar(128)  NOT NULL,
    CONSTRAINT Meeting_Status_pk PRIMARY KEY  (meetingStatusID)
);

-- Table: Room
CREATE TABLE Room (
    roomID int  NOT NULL,
    roomName nvarchar(128)  NOT NULL,
    roomStatusID int  NOT NULL,
    CONSTRAINT Room_pk PRIMARY KEY  (roomID)
);

-- Table: Room_Status
CREATE TABLE Room_Status (
    roomStatusID int  NOT NULL,
    name nvarchar(128)  NOT NULL,
    CONSTRAINT Room_Status_pk PRIMARY KEY  (roomStatusID)
);

-- Table: User
CREATE TABLE "User" (
    userID int  NOT NULL,
    name nvarchar(128)  NOT NULL,
    isAdmin bit  NOT NULL,
    company nvarchar(128)  NOT NULL,
    CONSTRAINT User_pk PRIMARY KEY  (userID)
);

-- foreign keys
-- Reference: Attendees_Meeting (table: Attendees)
ALTER TABLE Attendees ADD CONSTRAINT Attendees_Meeting
    FOREIGN KEY (meetingID)
    REFERENCES Meeting (meetingID);

-- Reference: Attendees_User (table: Attendees)
ALTER TABLE Attendees ADD CONSTRAINT Attendees_User
    FOREIGN KEY (userID)
    REFERENCES "User" (userID);

-- Reference: Authentication_User (table: Authentication)
ALTER TABLE Authentication ADD CONSTRAINT Authentication_User
    FOREIGN KEY (userID)
    REFERENCES "User" (userID);

-- Reference: Meeting_Meeting_Status (table: Meeting)
ALTER TABLE Meeting ADD CONSTRAINT Meeting_Meeting_Status
    FOREIGN KEY (meetingStatusID)
    REFERENCES Meeting_Status (meetingStatusID);

-- Reference: Meeting_Room (table: Meeting)
ALTER TABLE Meeting ADD CONSTRAINT Meeting_Room
    FOREIGN KEY (roomID)
    REFERENCES Room (roomID);

-- Reference: Meeting_User (table: Meeting)
ALTER TABLE Meeting ADD CONSTRAINT Meeting_User
    FOREIGN KEY (creatorID)
    REFERENCES "User" (userID);

-- Reference: Room_Room_Status (table: Room)
ALTER TABLE Room ADD CONSTRAINT Room_Room_Status
    FOREIGN KEY (roomStatusID)
    REFERENCES Room_Status (roomStatusID);

-- End of file.

