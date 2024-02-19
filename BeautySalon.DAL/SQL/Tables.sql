create table Users
(
    Id int primary key not null identity(1,1),
    ChatId int,
    UserName nvarchar(50),
    Name nvarchar(50) not null,
    Phone nvarchar(30) not null unique,
    Mail nvarchar(30),
    RoleId int not null,
    Salary decimal,
    IsBlocked bit default 0,
    IsDeleted bit default 0
)

create table Roles
(
    Id int primary key not null identity(1,1),
    Title nvarchar(30) not null unique,
    IsDeleted bit not null default 0
)

create table Shifts
(
    Id int primary key not null identity(1,1),
    Number int,
    Title nvarchar(30) not null,
    StartTime datetime not null,
    EndTime datetime not null,
    MasterId int,
    IsDeleted bit not null default 0
)

create table Intervals
(
    Id int primary key not null identity(1,1),
    Title nvarchar(30) not null,
    ShiftId int not null,
    ShiftNumber int,
    ShiftTitle nvarchar(30) not null,
    MasterId int,
    StartTime datetime not null,
    IsBusy bit not null default 0,
    IsDeleted bit not null default 0
)

create table Services
(
    Id int primary key not null identity(1,1),
    Title nvarchar(50) not null unique,
    TypeId int not null,
    Duration nvarchar(20) not null,
    Price decimal not null,
    IsDeleted bit not null default 0
)

create table Types
(
    Id int primary key not null identity(1,1),
    Title nvarchar(30) not null unique,
    IsDeleted bit not null default 0
)

create table Orders
(
    Id int primary key not null identity(1,1),
    Date datetime not null,
    MasterId int not null,
    ClientId int not null,
    ServiceId int not null,
    StartIntervalId int not null,
    IsCompleted bit not null default 0,
    IsDeleted bit not null default 0
)

alter table Users add foreign key (RoleId) references Roles(Id)
alter table Shifts add foreign key (MasterId) references Users(Id)
alter table Intervals add foreign key (ShiftId) references Shifts(Id)
alter table Services add foreign key (TypeId) references Types(Id)
alter table Orders add foreign key (MasterId) references Users(Id)
alter table Orders add foreign key (ClientId) references Users(Id)
alter table Orders add foreign key (ServiceId) references Services(Id)
alter table Orders add foreign key (StartIntervalId) references Intervals(Id)


insert into Roles (Title) values('Администратор салона'), ('Мастер'), ('Клиент')

insert into Users (ChatId, UserName, Name, Phone, Mail, RoleId, Salary) values(1, '@yhgkli', 'Иван Петрович Веселов', '89663542334', 'gdeakueh@dsejdfek', 1, 50000),
                                                                              (2, '@w;kfop', 'Анна Петровна Брек', '8923467127', 'ewqgtg@fsfgs', 2, 50000), (3, '@;jxiqau', 'Ирина Васильевна Вассильева', '8924350512', 'hseyje@gesdtt', 2, 50000),
                                                                              (4, '@lraikv', 'Оксана Дмитриевна Кек', '877566588690', 'farse@hsdt6rh', 3, null), (5, '@yliivl;i', 'Снежанна Витальевна Соловьева', '892136234', 'gwghw5gh@dsejdfkrutek', 3, null),
                                                                              (6, '@goijrdnr', 'Кристина Валерьевна Заливняк', '642894209', 'fs5g@grq', 3, null),
                                                                              (7, '@sgghhjt', 'Константин Михайлович Пожиняка', '5678966789', 'sfgert@gerg', 2, 50000), (8, '@etgsreh', 'Антон Васильевич Грида', '8436758755', 'sgdsd@sgsh', 2, 50000),
                                                                              (9, '@hdchgz', 'Денис Валерьевич Мдень', '8234043545', 'vdbdfb@oljk', 2, 50000)

insert into Shifts (Number, Title, StartTime, EndTime, MasterId) values(1, 'УТРО (10:00 - 13:45)', '02/19/2024 10:00', '02/19/2024 13:45', 2),
                                                                       (2, 'ДЕНЬ (14:00 - 17:45)', '02/19/2024 14:00', '02/19/2024 17:45', 2),
                                                                       (3, 'ВЕЧЕР (18:00 - 21:45)', '02/19/2024 18:00', '02/19/2024 21:45', 2)

insert into Intervals (Title, ShiftId, ShiftNumber, ShiftTitle, MasterId, StartTime) values('10:00', 1, 1, 'УТРО (10:00 - 13:45)', 2, '02/19/2024 10:00'), ('11:00', 1, 1, 'УТРО (10:00 - 13:45)', 2, '02/19/2024 11:00'), ('12:00', 1, 1, 'УТРО (10:00 - 13:45)', 2, '02/19/2024 12:00'),('13:00', 1, 1, 'УТРО (10:00 - 13:45)', 2, '02/19/2024 13:00'),
                                                                                           ('14:00', 2, 2, 'ДЕНЬ (14:00 - 17:45)', 2, '02/19/2024 14:00'), ('15:00', 2, 2, 'ДЕНЬ (14:00 - 17:45)', 2, '02/19/2024 15:00'), ('16:00', 2, 2, 'ДЕНЬ (14:00 - 17:45)', 2, '02/19/2024 16:00'), ('17:00', 2, 2, 'ДЕНЬ (14:00 - 17:45)', 2, '02/19/2024 17:00'),
                                                                                           ('18:00', 3, 3, 'ВЕЧЕР (18:00 - 21:45)', 2, '02/19/2024 18:00'), ('19:00', 3, 3, 'ВЕЧЕР (18:00 - 21:45)', 2, '02/19/2024 19:00'), ('20:00', 3, 3, 'ВЕЧЕР (18:00 - 21:45)', 2, '02/19/2024 20:00'), ('21:00', 3, 3, 'ВЕЧЕР (18:00 - 21:45)', 2, '02/19/2024 21:00')

insert into Types (Title) values('Визаж'), ('Стрижки'), ('Окрашивание'), ('Моделирование'), ('Маникюр'), ('Педикюр'), ('Эпиляция'),('Пиллинг'), ('Обертывание'),('Массаж')

insert into Services (Title, TypeId, Duration, Price) values('Дневной макияж', 1, '01:00', 2500), ('Вечерний макияж', 1, '01:30', 3500), ('Свадебный макияж', 1, '02:00', 1000), ('Макияж для фотосессий', 1, '02:30', 5900), ('Татуаж', 1, '03:00', 6900), ('Окрашивание бровей и ресниц', 1, '01:00', 8500),('Архитектура бровей', 1, '00:45', 1900), ('Наращивание ресниц', 1, '04:00', 4600),
('Стрижка чёлки', 2, '00:30', 400), ('Подравнивание волос', 2, '01:00', 800), ('Стрижка до 25 см', 2, '00:45', 1000), ('Стрижка от 25 см', 2, '01:00', 1250), ('Стрижка от 50 см', 2, '01:15', 1500), ('Стрижка горячими ножницами', 2, '01:30', 1750),
('Декапирование', 3, '01:00', 2000), ('Окрашивание корней', 3, '01:00', 2100), ('Классическое окрашивание в один тон', 3, '02:00', 3500), ('Мелирование', 3, '00:50', 3500), ('Тонирование', 3, '00:30', 3500), ('Колорирование', 3, '05:00', 5500), ('Окрашивание седых волос', 3, '06:00', 6500),
('Укладка', 4, '00:30', 1300), ('Вечерняя укладка', 4, '01:00', 1700),('Вечерняя причёска', 4, '01:30', 3000), ('Свадебная причёска', 4, '02:00', 4900), ('Химическая завивка', 4, '01:00', 1800), ('Биозавивка', 4, '01:00', 1800), ('Boost UP', 4, '05:00', 5000), ('Флисинг', 4, '01:30', 2500), ('Выпрямление волос', 4, '01:30', 2500),('Наращивание волос', 4, '08:00', 6000)
-- ('Подравнять кончики', 5, '01:00', 700), ('Стрижка машинкой', 5, '00:30', 500), ('Стрижка до 25 см', 5, '00:45', 1000), ('Стрижка от 25 см', 5, '01:00', 1250), ('Стрижка от 50 см', 5, '01:15', 1500),
-- ('Подравнять кончики', 6, '01:00', 700), ('Стрижка машинкой', 6, '00:30', 500), ('Стрижка до 25 см', 6, '00:45', 1000), ('Стрижка от 25 см', 6, '01:00', 1250), ('Стрижка от 50 см', 6, '01:15', 1500),
-- ('Подравнять кончики', 7, '01:00', 700), ('Стрижка машинкой', 7, '00:30', 500), ('Стрижка до 25 см', 7, '00:45', 1000), ('Стрижка от 25 см', 7, '01:00', 1250), ('Стрижка от 50 см', 7, '01:15', 1500),
-- ('Подравнять кончики', 8, '01:00', 700), ('Стрижка машинкой', 8, '00:30', 500), ('Стрижка до 25 см', 8, '00:45', 1000), ('Стрижка от 25 см', 8, '01:00', 1250), ('Стрижка от 50 см', 8, '01:15', 1500),
-- ('Подравнять кончики', 9, '01:00', 700), ('Стрижка машинкой', 9, '00:30', 500), ('Стрижка до 25 см', 9, '00:45', 1000), ('Стрижка от 25 см', 9, '01:00', 1250), ('Стрижка от 50 см', 9, '01:15', 1500),
-- ('Подравнять кончики', 10, '01:00', 700), ('Стрижка машинкой', 10, '00:30', 500), ('Стрижка до 25 см', 10, '00:45', 1000), ('Стрижка от 25 см', 10, '01:00', 1250), ('Стрижка от 50 см', 10, '01:15', 1500)

insert into Orders (Date, MasterId, ClientId, ServiceId, StartIntervalId) values('02/19/2024', 2, 4, 1, 1)