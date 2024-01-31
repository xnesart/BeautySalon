create database BeautifulGirl COLLATE Cyrillic_General_CI_AS;
go

use BeautifulGirl

create table Users 
(
	Id int primary key not null identity(1,1),
	ChatId int,
	UserName nvarchar(50) unique,
	Name nvarchar(50) not null,
	Phone nvarchar(30) not null unique,
	Mail nvarchar(30) unique,
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
(6, '@goijrdnr', 'Кристина Валерьевна Заливняк', '642894209', 'fs5g@grq', 3, null)

insert into Shifts (Title, StartTime, EndTime, MasterId) values('УТРО (10:00 - 13:45)', '02/02/2024 10:00', '02/02/2024 13:45', 2),
('ДЕНЬ (14:00 - 17:45)', '02/02/2024 14:00', '02/02/2024 17:45', 2),
('ВЕЧЕР (18:00 - 21:45)', '02/02/2024 18:00', '02/02/2024 21:45', 3)

insert into Intervals (Title, ShiftId, StartTime) values('10:00', 1, '02/02/2024 10:00'), ('11:00', 1, '02/02/2024 11:00'), ('12:00', 1, '02/02/2024 12:00'),
('13:00', 1, '02/02/2024 13:00'), ('14:00', 2, '02/02/2024 14:00'), ('15:00', 2, '02/02/2024 15:00'), ('16:00', 2, '02/02/2024 16:00'), ('17:00', 2, '02/02/2024 17:00'),
('18:00', 3, '02/02/2024 18:00'), ('19:00', 3, '02/02/2024 19:00'), ('20:00', 3, '02/02/2024 20:00'), ('21:00', 3, '02/02/2024 21:00')

insert into Types (Title) values('Стрижка'), ('Покраска'), ('Укладка'), ('Макияж'), ('Маникюр'), ('Педикюр'), ('Эпиляция'),('Пиллинг'), ('Обертывание'),('Массаж')

insert into Services (Title, TypeId, Duration, Price) values('Подравнять кончики', 1, '01:00', 700), ('Стрижка машинкой', 1, '00:30', 500),
('Стрижка до 25 см', 1, '00:45', 1000), ('Стрижка от 25 см', 1, '01:00', 1250), ('Стрижка от 50 см', 1, '01:15', 1500)

insert into Orders (Date, MasterId, ClientId, ServiceId, StartIntervalId) values('02/02/2024', 2, 4, 1, 1)


----процедуры для админа
-- ✓ Зарегистрировать пользователя по ChatId, заполнив его имя, телефон и почту
create proc AddUserByChatId
@ChatId int, @UserName nvarchar(50), @Name nvarchar(50), @Phone nvarchar(30), @Mail nvarchar(30), @RoleId int, @Salary decimal, @IsBlocked bit, @IsDeleted bit as
begin
	insert into Users values(@ChatId, @UserName, @Name, @Phone, @Mail, @RoleId, null, 0, 0)
end

exec AddUserByChatId 7, '@gqrgh8', 'Виктория Сигизмундовна Апраксина', '897464582', 'argrgh@faef', 3, null, 0, 0

drop proc AddUserByChatId

-- ✓ Найти клиента по имени и id
create proc GetClientByNameAndId
@Name nvarchar(50), @Id int as
begin
	select Users.Name as Client, Users.Id as ClientsId from Users
	where Users.Name = @Name and Users.Id = @Id
end

exec GetClientByNameAndId 'Кристина Валерьевна Заливняк', 6

drop proc GetClientByNameAndId

-- ✓ Найти клиента по имени и телефону
create proc GetClientByNameAndPhone
@Name nvarchar(50), @Phone nvarchar(30) as
begin
	select Users.Name as Client, Users.Phone as ClientsPhone from Users
	where Users.Name = @Name and Users.Phone = @Phone
end

exec GetClientByNameAndPhone 'Кристина Валерьевна Заливняк', '642894209'

drop proc GetClientByNameAndPhone

-- ✓ Найти мастера по имени и id
create proc GetMasterByNameAndId
@Name nvarchar(50), @Id int as
begin
	select Users.Name as Master, Users.Id as MasterId from Users
	where Users.Name = @Name and Users.Id = @Id
end

exec GetMasterByNameAndId 'Анна Петровна Брек', 2

drop proc GetMasterByNameAndId

-- ✓ Найти мастера по имени и телефону
create proc GetMasterByNameAndPhone
@Name nvarchar(50), @Phone nvarchar(30) as
begin
	select Users.Name as Master, Users.Phone as MasterPhone from Users
	where Users.Name = @Name and Users.Phone = @Phone
end

exec GetMasterByNameAndPhone 'Анна Петровна Брек', '8923467127'

drop proc GetMasterByNameAndPhone

-- ✓ Вывести всех сотрудников по Id и их контакты
create proc GetAllWorkersWithContactsByUserId
as
begin
	select Users.Id as WorkerId, Users.RoleId as WorkerRoleId, Roles.Title as Worker,  Users.Name, Users.Phone, Users.Mail from Users
	join Roles on Users.RoleId = Roles.Id
	where RoleId = 1 or RoleId = 2
end

exec GetAllWorkersWithContactsByUserId

drop proc GetAllWorkersWithContactsByUserId

-- ✓ Добавить сотрудника в базу через бота по RoleId
create proc AddWorkerByRoleId
@WorkerRole int, @WorkerName nvarchar(50), @WorkerPhone nvarchar(30), @WorkerMail nvarchar(30) as
begin
	insert into Users (RoleId, Name, Phone, Mail) values(@WorkerRole, @WorkerName, @WorkerPhone, @WorkerMail)
end

exec AddWorkerByRoleId 2, 'Климментина Валерьевна Горбачёва', '839875036', '97707@iknlkb'

drop proc AddWorkerByRoleId

-- ✓ Удалить пользователя из базы по Id
create proc RemoveUserById
@Id int as
begin
	update Users
	set IsDeleted = 1
	where Id = @Id
end

exec RemoveUserById 8

drop proc RemoveUserById;

-- ✓ Вывести все смены на сегодня
-- ✓ Вывести все смены и работающих в них сотрудников
-- ✓ Добавить мастера в ВЫБРАННУЮ смену
-- ✓ Удалить мастера из ВЫБРАННОЙ смены
-- ✓ Вывести все интервалы
-- ✓ Вывести все интервалы ВЫБРАННОЙ смены
-- ✓ Вывести все смены, имеющие СВОБОДНЫЕ интервалы для записи
-- ✓ Для ВЫБРАННОЙ смены вывести все СВОБОДНЫЕ для записи интервалы
-- ✓ Вывести все типы услуг

-- ✓ Вывести все услуги ВЫБРАННОГО типа
create proc GetAllServicesByIdFromCurrentType
@Id int as
begin
	select Types.Id, Types.Title, Services.Id, Services.Title, Services.Duration, Services.Price from Types
	join Services on Services.TypeId = Types.Id
	where Types.Id = @Id
end

exec GetAllServicesByIdFromCurrentType 1

drop proc GetAllServicesByIdFromCurrentType

-- ✓ Вывести все услуги

-- ✓ Добавить услугу
create proc AddServiceById
@ServiceTitle nvarchar(30), @ServiceType int, @ServiceDuration time, @ServicePrice decimal as
begin
	insert into Services values(@ServiceTitle, @ServiceType, @ServiceDuration, @ServicePrice, 0)
end

exec AddServiceById 'Стрижка под нуль', 1, '01:00', 500

drop proc AddServiceById;

-- ✓ Изменить название услуги
-- ✓ Изменить цену услуги
-- ✓ Изменить длительность услуги

-- ✓ Удалить услугу
create proc RemoveServiceById
@Id int as
begin
	update Services
	set IsDeleted = 1
	where Id = @Id
end

exec RemoveServiceById 8

drop proc RemoveServiceById

-- ✓ Записать клиента к СВОБОДНОМУ мастеру
-- ✓ Вывести все заказы на сегодня
-- ✓ Вывести все заказы на сегодня для всех мастеров
-- ✓ Вывести все записи на сегодня для всех клиентов


----процедуры для мастера
-- ✓ Вывести смены выбранного мастера на сегодня
create proc GetMastersShiftsById
@Id int as
begin
	select Users.Id as MasterId, Users.Name as Master, Shifts.Id, Shifts.Title, Shifts.StartTime, Shifts.EndTime from Users
	join Shifts on Shifts.MasterId = Users.Id
	where Shifts.MasterId = @Id
end

exec GetMastersShiftsById 2

drop proc GetMastersShiftsById

-- ✓ Вывести заказы выбранного мастера на сегодня
create proc GetMastersOrdersById
@Id int as
begin
	select Master.Id as MasterId, Master.Name as Master, 
	Orders.Id,  Orders.Date, Orders.StartIntervalId, Intervals.Id, Intervals.Title, 
	Services.Id, Services.Title, Services.Duration, Services.Price,
	Client.Id as ClientId, Client.Name as Client from Orders
	join Users as Client on Orders.ClientId = Client.Id
	join Users as Master on Orders.MasterId = Master.Id
	join Intervals on Orders.StartIntervalId = Intervals.Id
	join Services on Orders.ServiceId = Services.Id
	where Master.Id = @Id and Orders.IsDeleted = 0
end

exec GetMastersOrdersById 3

drop proc GetMastersOrdersById


----процедуры для клиента
-- ✓ Для ВЫБРАННОЙ услуги вывести все смены, имеющие СВОБОДНЫЕ интервалы для записи
create proc GetAllShiftsWithFreeIntervalsOnCurrentService
@ServiceId int as
begin
	select Services.Id, Services.Title, Shifts.Id, Shifts.Title, Shifts.StartTime from Shifts
	join Services on Services.Id = @ServiceId
	join Intervals on Intervals.ShiftId = Shifts.Id
	where Intervals.IsBusy = 0
end

exec GetAllShiftsWithFreeIntervalsOnCurrentService 1

drop proc GetAllShiftsWithFreeIntervalsOnCurrentService

-- ✓ Для ВЫБРАННОЙ услуги в ВЫБРАННУЮ смену вывести все СВОБОДНЫЕ интервалы для записи 
create proc GetAllFreeIntervalsInCurrentShiftOnCurrentService
@ServiceId int, @ShiftId int as
begin
    select Services.Id, Services.Title, Shifts.Id, Shifts.Title, Shifts.StartTime, Intervals.Id, Intervals.Title, Intervals.StartTime from Intervals
    join Services on Services.Id = @ServiceId
    join Shifts on Shifts.Id = @ShiftId
	where Intervals.IsBusy = 0
end

exec GetAllFreeIntervalsInCurrentShiftOnCurrentService 1, 1

drop proc GetAllFreeIntervalsInCurrentShiftOnCurrentService

-- ✓ Для ВЫБРАННОЙ услуги вывести все СВОБОДНЫЕ интервалы для записи
create proc GetAllFreeIntervalsOnCurrentService
@ServiceId int as
begin
    select Services.Id, Services.Title, Intervals.Id, Intervals.Title, Intervals.StartTime from Intervals
    join Services on Services.Id = @ServiceId
	where Intervals.IsBusy = 0
end

exec GetAllFreeIntervalsOnCurrentService 1

drop proc GetAllFreeIntervalsOnCurrentService

-- ✓ Создать запись, выбрав услугу, смену и интервал
create proc CreateNewOrder
@ClientId int, @MasterId int, @Date datetime, @ServiceId int, @IntervalId int as
begin
    if exists (select 1 from Intervals where Id = @IntervalId and IsBusy = 0)
    begin
    insert into Orders VALUES (@Date,@MasterId,@ClientId,@ServiceId,@IntervalId,0,0)
    update Intervals
    set Intervals.IsBusy = 1
    where Intervals.Id = @IntervalId
    end
end

exec CreateNewOrder 5,2, '02/02/2024 13:00',1,5

drop proc CreateNewOrder

-- ✓ Вывести  записи клиента на сегодня
create proc GetOrdersForClientById
@Id int as
begin
	select Client.Id as ClientId, Client.Name as Client, Master.Id as MasterId, Master.Name as Master, 
	Orders.Id,  Orders.Date, Orders.StartIntervalId, Intervals.Id, Intervals.Title, 
	Services.Id, Services.Title, Services.Duration, Services.Price from Orders
	join Users as Client on Orders.ClientId = Client.Id
	join Users as Master on Orders.MasterId = Master.Id
	join Intervals on Orders.StartIntervalId = Intervals.Id
	join Services on Orders.ServiceId = Services.Id
	where Client.Id = @Id and Orders.IsDeleted = 0
end

exec GetOrdersForClientById 4

drop proc GetOrdersForClientById

-- ✓ Изменить время записи клиента
create proc UpdateOrderTimeForClientById
@OrderId int, @ClientId int, @MasterId int, @IntervalId int as
begin
    update Orders
    set MasterId = @MasterId, StartIntervalId = @IntervalId
    where Orders.Id = @OrderId and Orders.ClientId = @ClientId
end

exec UpdateOrderTimeForClientById 1,4,2,8

drop proc UpdateOrderTimeForClientById

-- ✓ Удалить запись клиента
create proc RemoveOrderForClientByOrderId
@OrderId int as
begin
    update Orders
    set Orders.IsDeleted = 1
    where Orders.Id = @OrderId
end

exec RemoveOrderForClientByOrderId 1

drop proc RemoveOrderForClientByOrderId