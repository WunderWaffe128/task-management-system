create table Organization (
	Id int identity(1,1) Primary key,
	Name nvarchar(100) not null,
	CreateDate datetime default getdate()
);

create table Positions (
	Id int identity(1,1) primary key,
	title nvarchar(100) not null
);

CREATE TABLE Roles (
	Id INT IDENTITY(1,1) PRIMARY KEY,
	Name NVARCHAR(50) NOT NULL UNIQUE
);

create table Users (
	Id int identity(1,1) primary key,
	OrganizationId int 
		foreign key (OrganizationId) references Organization(Id) on delete set null,
	PositionId int
		foreign key (PositionId) references Positions(Id) on delete set null,
	FullName nvarchar(150) not null,
	Email nvarchar(100) not null unique,
	PasswordHash nvarchar(256) not null,
	RoleId INT NOT NULL
		FOREIGN KEY (RoleId) REFERENCES Roles(Id),
	Skills nvarchar(500) null
);

create table Project(
	Id int identity(1,1) primary key,
	OrganizationId int
		foreign key (OrganizationId ) references Organization(Id),
	Title nvarchar(150) not null,
	Description nvarchar(max) not null,
	Status nvarchar(50) default 'Active',
	CONSTRAINT CK_Project_Status CHECK (Status IN ('Planning', 'Active', 'On Hold', 'Completed', 'Cancelled')),
	OwnerId int
		foreign key (OwnerId) references Users(Id),
	CreatedDate datetime not null default getdate()
);

create table Tasks (
	Id int identity(1,1) primary key,
	ProjectId int
		foreign key (ProjectId) references Project(Id) on delete cascade,
	AssigneeId int 
		foreign key (AssigneeId) references Users(Id),
	AuthorId int 
			foreign key (AuthorId) references Users(Id),
	Title nvarchar(150) not null,
	Description nvarchar(max) not null,
	Status nvarchar(50) not null default 'To Do',
	Priority nvarchar(50) not null default 'Medium',
	Deadline datetime not null,
	CONSTRAINT CK_Tasks_Status CHECK (Status IN ('To Do', 'In Progress', 'Done')),
	CONSTRAINT CK_Tasks_Priority CHECK (Priority IN ('Low', 'Medium', 'High', 'Critical'))
);

create table SubTasks (
	Id int identity(1,1) primary key,
	TaskId int 
		foreign key(TaskId) references Tasks(Id) on delete cascade,
	IsCompleted bit not null default 0,
	Title nvarchar(255) not null
);

create table Comments (
	Id int identity(1,1) primary key,
	TaskId int
		foreign key (TaskId) references Tasks(Id) on delete cascade,
	UserId int 
		foreign key (UserId) references Users(Id),
	Text nvarchar(max) not null,
	CreatedAt datetime not null default getdate()
);
create table TaskHistory (
	Id int identity(1,1) primary key,
	TaskId int
		foreign key (TaskId) references Tasks(Id) on delete cascade,
	UserId int
		foreign key (UserId) references Users(Id),
	ActionText nvarchar(500) not null,
	ChangedAt datetime not null default getdate()
);