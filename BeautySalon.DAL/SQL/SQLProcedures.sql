----процедуры для админа
-- ✓ Зарегистрировать пользователя по ChatId, заполнив его имя, телефон и почту
create proc AddUserByChatId
    @ChatId int, @UserName nvarchar(50), @Name nvarchar(50), @Phone nvarchar(30), @Mail nvarchar(30), @RoleId int, @Salary decimal, @IsBlocked bit, @IsDeleted bit as
begin
    insert into Users values(@ChatId, @UserName, @Name, @Phone, @Mail, @RoleId, null, 0, 0)
end
go
-- ✓ По Password получить Name
create procedure GetWorkerNameByPassword
    @Password nvarchar(30) as
begin
select Name
from Users
where Password = @Password;
end;
go
-- ✓ По Password обновить ChatId и UserName в таблице Users
create procedure ChangeChatIdAndUserNameByPassword
    @Password nvarchar(30), @ChatId int, @UserName nvarchar(50) as
begin
update Users
set Users.ChatId = @ChatId, Users.UserName = @UserName
where Users.Password = @Password
end;
go
-- ✓ Получить ChatId всех пользователей
create proc GetAllUsersChatId as
begin
    select ChatId from Users
end
go
-- ✓ Найти клиента по имени и id
create proc GetClientByNameAndId
    @Name nvarchar(50), @Id int as
begin
    select Users.Name as Client, Users.Id as ClientId from Users
    where Users.Name = @Name and Users.Id = @Id
end
go
-- ✓ По ChatId получить данные о User
create proc GetUserByChatId
@ChatId int as
begin
    select Id,ChatId, UserName,Name,Phone,Mail,RoleId,Salary,IsBlocked,IsDeleted from Users
    where ChatId = @ChatId
end
go
-- ✓ Найти клиента по имени и телефону
create proc GetClientByNameAndPhone
    @Name nvarchar(50), @Phone nvarchar(30) as
begin
    select Id,ChatId, UserName, Name, Phone,Mail,RoleId,Salary,IsBlocked, IsDeleted from Users
    where Users.Name = @Name and Users.Phone = @Phone and RoleId = 3
end
go
-- ✓ Найти мастера по имени и id
create proc GetMasterByNameAndId
    @Name nvarchar(50), @Id int as
begin
    select Id ,ChatId, UserName, Name , Phone,Mail,RoleId,Salary,IsBlocked, IsDeleted from Users
    where Users.Name = @Name and Users.Id = @Id and RoleId = 2
end
go
-- ✓ Найти мастера по имени и телефону
create proc GetMasterByNameAndPhone
    @Name nvarchar(50), @Phone nvarchar(30) as
begin
    select Id,ChatId, UserName, Name, Phone,Mail,RoleId,Salary,IsBlocked, IsDeleted from Users
    where Users.Name = @Name and Users.Phone = @Phone
end
go
-- ✓ Вывести всех сотрудников по RoleId
create proc GetAllWorkersByRoleId 
as
begin
    select Users.Id, Users.RoleId, Roles.Title as Worker,
    Users.ChatId, Users.UserName, Users.Name, Users.Phone, Users.Mail, Users.Salary, Users.IsBlocked, Users.IsDeleted from Users
    join Roles on Users.RoleId = Roles.Id
    where RoleId = 1 or RoleId = 2
    select Users.Id as WorkerId, Users.RoleId as WorkerRoleId, Roles.Title as Worker, 
           Users.ChatId, Users.UserName, Users.Name, Users.Phone, Users.Mail, Users.Salary, Users.IsBlocked, Users.IsDeleted from Users
    join Roles on Users.RoleId = Roles.Id
    where RoleId = 1 or RoleId = 2
end
go
-- ✓ Вывести всех сотрудников по Id и их контакты
create proc GetAllWorkersWithContactsByUserId
as
begin
    select Users.Id, Users.RoleId,  Users.Name, Users.Phone, Users.Mail ,Roles.Title as Worker from Users
    join Roles on Users.RoleId = Roles.Id
    where RoleId = 1 or RoleId = 2
end
go
-- ✓ Добавить сотрудника в базу через бота по RoleId
create proc AddWorkerByRoleId
    @WorkerRole int, @WorkerName nvarchar(50), @WorkerPhone nvarchar(30), @WorkerMail nvarchar(30) as
begin
    insert into Users (RoleId, Name, Phone, Mail) values(@WorkerRole, @WorkerName, @WorkerPhone, @WorkerMail)
end
go
-- ✓ Удалить пользователя из базы по Id
create proc RemoveUserById
    @Id int
as
begin
    -- Обновляем IsDeleted для пользователя с указанным Id
    update Users
    set IsDeleted = 1
    output deleted.IsDeleted
    where Id = @Id;
end
go
-- ✓ Вывести все смены на сегодня
create proc GetAllShiftsOnToday 
as
begin
    declare @Today datetime
    set @Today = GETDATE()
    select Shifts.Id, Shifts.Title, Shifts.StartTime, Shifts.EndTime from Shifts
    where convert(DATE, StartTime) = convert(DATE, @Today) and Shifts.IsDeleted = 0
end
go
-- ✓ Вывести все смены и работающих в них сотрудников
create proc GetAllShiftsAndEmployeesOnToday 
as
begin
    declare @Today datetime
    set @Today = GETDATE()
    select Users.Name, Shifts.Id, Shifts.Title, Shifts.StartTime, Shifts.EndTime, Shifts.MasterId from Shifts
    join Users on Shifts.MasterId = Users.id
    where convert(DATE, StartTime) = convert(DATE, @Today) and Shifts.IsDeleted = 0
end
go
-- ✓ Назначить на выбранную смену другого мастера
create proc ChangeMasterInShift
    @MasterId int, @ShiftId int as
begin
update Shifts
set Shifts.MasterId = @MasterId
where Shifts.Id = @ShiftId
end
go
-- ✓ Удалить мастера из ВЫБРАННОЙ смены
create proc RemoveMasterFromShift
    @MasterId int, @ShiftId int as
begin
    update Shifts
    set Shifts.MasterId = null
    where Shifts.Id = @ShiftId
end
go
-- ✓ Вывести все интервалы
create proc GetAllIntervals
@Day datetime as
begin
select Shifts.Id, Shifts.Title,
    Intervals.Id, Intervals.Title, Intervals.StartTime, Intervals.IsBusy, Intervals.IsDeleted from Intervals
    join Shifts on Intervals.ShiftId = Shifts.Id
    where convert(DATE, Intervals.StartTime) = convert(DATE, @Day)
end
go
-- ✓ Вывести все интервалы ВЫБРАННОЙ смены
create proc GetAllIntervalsByShiftId
@ShiftID int as
begin
    select Shifts.Id, Shifts.Title, Intervals.Id, Intervals.Title, Intervals.ShiftId, Intervals.StartTime,
           Intervals.IsBusy, Intervals.IsDeleted from Intervals
    join Shifts on Shifts.Id = Intervals.ShiftId
    where @ShiftID = Intervals.ShiftId
end
go
-- ✓ Вывести все типы услуг
create proc GetAllServiceTypes 
as
begin
    select Types.Id, Types.Title, Types.IsDeleted from Types
end
go
-- ✓ Вывести все услуги ВЫБРАННОГО типа
create proc GetAllServicesByIdFromCurrentType
@Id int as
begin
select Services.Id, Services.Title,Services.Price, Services.Duration, Types.Id, Types.Title from Types
                                                                                                     join Services on Services.TypeId = Types.Id
where Types.Id = @Id and Services.IsDeleted = 0
end
go
-- ✓ Вывести все услуги
create proc GetAllServices 
as
begin
    select Services.Id, Services.Title, Services.Duration, Services.Price, Services.IsDeleted, Services.TypeId, Types.Title from Services
    join Types on Services.TypeId = Types.Id
end
go
-- ✓ Добавить услугу
create proc AddServiceById
    @ServiceTitle nvarchar(30), @ServiceType int, @ServiceDuration time, @ServicePrice decimal as
begin
    insert into Services values(@ServiceTitle, @ServiceType, @ServiceDuration, @ServicePrice, 0)
end
go
-- ✓ Изменить название услуги
create proc UpdateServiceTitle
    @ServiceId int, @ServiceTitle nvarchar(50) as
begin
    update Services
    set Services.Title = @ServiceTitle
    where @ServiceId = Services.Id
end
go
-- ✓ Изменить цену услуги
create proc UpdateServicePrice
    @ServiceId int, @ServicePrice decimal as
begin
    update Services
    set Services.Price = @ServicePrice
    where @ServiceId = Services.Id
end
go
-- ✓ Изменить длительность услуги
create proc UpdateServiceDuration
    @ServiceId int, @ServiceDuration nvarchar(20) as
begin
    update Services
    set Services.Duration = @ServiceDuration
    where @ServiceId = Services.Id
end
go
-- ✓ Удалить услугу
create proc RemoveServiceById
    @Id int as
begin
    -- Обновляем IsDeleted для пользователя с указанным Id
    update Services
    set IsDeleted = 1
    output inserted.IsDeleted
    where Id = @Id;
end
go
-- ✓ Записать клиента к СВОБОДНОМУ мастеру
CREATE PROCEDURE AddClientToFreeMaster
    @ClientId INT,
    @ServiceId INT,
    @ShiftId INT,
    @IntervalId INT
AS
BEGIN
    DECLARE @TodayDate DATETIME = GETDATE();
    INSERT INTO Orders (Date, MasterId, ClientId, ServiceId, StartIntervalId, IsDeleted)
    VALUES (@TodayDate, (SELECT MasterId FROM Shifts WHERE Id = @ShiftId), @ClientId, @ServiceId, @IntervalId, 0)
    UPDATE Intervals
    SET IsBusy=1 WHERE @IntervalId=Intervals.Id
END
go
-- ✓ Вывести все заказы на сегодня
create proc GetAllOrdersOnToday
as
begin
    declare @Today datetime
    set @Today = getdate()
    select Orders.Id, Orders.Date, Orders.MasterId, Orders.ClientId, Orders.ServiceId, Orders.StartIntervalId, Orders.IsCompleted, Orders.IsDeleted from Orders
    where convert(date, Orders.Date) = convert(date, @Today) and IsDeleted = 0
end
go
-- ✓ Вывести все заказы на сегодня для всех мастеров
create proc GetAllOrdersOnTodayForMasters
as
begin
    declare @Today datetime
    set @Today = getdate()
    select Orders.Id, Orders.Date, Orders.ServiceId, Orders.StartIntervalId,Orders.IsCompleted, Orders.IsDeleted,
           Orders.MasterId, Orders.ClientId, Master.Id ,Master.Name, Services.Title, Services.Price, Intervals.Title,
           Client.Name from Orders
join Users as Master on Orders.MasterId = Master.Id
join Users as Client on Orders.ClientId = Client.Id
join Services on Services.Id = Orders.ServiceId
join Intervals on Orders.StartIntervalId = Intervals.Id
    where convert(date, Orders.Date) = convert(date, @Today)
end
go
-- Назначить передаваемого мастера на передаваемую смену и создать для неё интервалы
-- (пока оставила StartTime соответствующим времени и дате создания записи в таблице)
create procedure AddMasterToShiftWithCreatedNewIntervals
    @Number int, @MasterId int as
BEGIN
    -- Проверяем, что переданный MasterId существует и является мастером
    if not exists (
        select 1 from Users where Id = @MasterId AND RoleId = 2
    )
    BEGIN
        RAISERROR ('Specified user is not a “Master”.', 16, 1);
        RETURN;
    END
    -- Находим пустые строки для назначения нового мастера
    declare @EmptyShiftId int;
    select top 1 @EmptyShiftId = Id from Shifts where Number = @Number AND MasterId IS NULL;
    -- Проверка, назначен ли на выбранную смену мастер с передаваемым MasterId
    if exists (
        select 1 from Shifts where Number = @Number and MasterId = @MasterId
    )
    BEGIN
        RAISERROR ('Master already assigned to the specified shift.', 16, 1);
        RETURN; -- Завершаем процедуру, так как передаваемый мастер уже назначен на передаваемую смену
    END
    -- Если нет пустых строк, создаем новую строку смены и соответствующие интервалы
    if @EmptyShiftId IS NULL
    BEGIN
        -- Получение названия смены с таким же номером из строки в таблице Shifts
        DECLARE @ShiftTitle nvarchar(30);
        select @ShiftTitle = Title from Shifts where Number = @Number;
        -- Создание новой строки в таблице Shifts, так как на выбранную смену назначен кто-то другой
        insert into Shifts (Number, Title, StartTime, EndTime, MasterId, IsDeleted)
        values (@Number, @ShiftTitle, GETDATE(), GETDATE(), @MasterId, 0);
        -- Получение идентификатора новой смены
        DECLARE @NewShiftId int;
        set @NewShiftId = SCOPE_IDENTITY();
        -- Получение названий интервалов из соответствующих строк в таблице Intervals
        DECLARE @IntervalTitle1 NVARCHAR(30), @IntervalTitle2 NVARCHAR(30), @IntervalTitle3 NVARCHAR(30), @IntervalTitle4 NVARCHAR(30);
        select @IntervalTitle1 = Title from Intervals where ShiftNumber = @Number
        ORDER BY (SELECT NULL) OFFSET 0 ROWS FETCH NEXT 1 ROWS ONLY;
        select @IntervalTitle2 = Title from Intervals where ShiftNumber = @Number
        ORDER BY (SELECT NULL) OFFSET 1 ROWS FETCH NEXT 1 ROWS ONLY;
        select @IntervalTitle3 = Title from Intervals where ShiftNumber = @Number
        ORDER BY (SELECT NULL) OFFSET 2 ROWS FETCH NEXT 1 ROWS ONLY;
        select @IntervalTitle4 = Title from Intervals where ShiftNumber = @Number
        ORDER BY (SELECT NULL) OFFSET 3 ROWS FETCH NEXT 1 ROWS ONLY;
        -- Создание соответствующих строк в таблице Intervals
        insert into Intervals (Title, ShiftId, ShiftNumber, ShiftTitle, MasterId, StartTime, IsBusy, IsDeleted)
        values (@IntervalTitle1, @NewShiftId, @Number, @ShiftTitle, @MasterId, GETDATE(), 0, 0);
        insert into Intervals (Title, ShiftId, ShiftNumber, ShiftTitle, MasterId, StartTime, IsBusy, IsDeleted)
        values (@IntervalTitle2, @NewShiftId, @Number, @ShiftTitle, @MasterId, GETDATE(), 0, 0);
        insert into Intervals (Title, ShiftId, ShiftNumber, ShiftTitle, MasterId, StartTime, IsBusy, IsDeleted)
        values (@IntervalTitle3, @NewShiftId, @Number, @ShiftTitle, @MasterId, GETDATE(), 0, 0);
        insert into Intervals (Title, ShiftId, ShiftNumber, ShiftTitle, MasterId, StartTime, IsBusy, IsDeleted)
        values (@IntervalTitle4, @NewShiftId, @Number, @ShiftTitle, @MasterId, GETDATE(), 0, 0);
        -- Возвращаем результат
        RETURN;
    END
    -- Обновление существующей строки в таблице Shifts, так как на выбранную смену никто не назначен
    update Shifts
    set MasterId = @MasterId
    where Number = @Number;
    -- Обновление MasterId в соответствующих строках в таблице Intervals
    update Intervals
    set MasterId = @MasterId
    where ShiftNumber = @Number;
END
go

----процедуры для мастера
-- ✓ Вывести смены выбранного мастера на сегодня
create proc GetMastersShiftsById
@Id int as
begin
    select Users.Id as MasterId, Users.Name as Master, Shifts.Id, Shifts.Title, Shifts.StartTime, Shifts.EndTime from Users
    join Shifts on Shifts.MasterId = Users.Id
    where Shifts.MasterId = @Id
end
go
-- ✓ Вывести заказы выбранного мастера на сегодня
create proc GetOrdersByMasterId
@Id int as
begin
    select Master.Id, Master.Name,
           Orders.Id,  Orders.Date, Orders.StartIntervalId, Intervals.Id as IntervalId, Intervals.Title as IntervalTitle,
           Services.Id, Services.Title, Services.Duration, Services.Price,
           Client.Id, Client.Name from Orders
                                           join Users as Client on Orders.ClientId = Client.Id
                                           join Users as Master on Orders.MasterId = Master.Id
                                           join Intervals on Orders.StartIntervalId = Intervals.Id
                                           join Services on Orders.ServiceId = Services.Id
    where Master.Id = @Id and Orders.IsDeleted = 0
end
go

----процедуры для клиента
CREATE proc [dbo].[GetOrdersByClientId2]
@Id int as
begin
select Orders.Id,  Orders.Date, Orders.StartIntervalId,
	Client.Id, Client.Name,
	Master.Id, Master.Name,
	Intervals.Id, Intervals.Title,
	Services.Id, Services.Title, Services.Duration, Services.Price
from
	Orders
	join Users as Client on Orders.ClientId = Client.Id
	join Users as Master on Orders.MasterId = Master.Id
	join Intervals on Orders.StartIntervalId = Intervals.Id
	join Services on Orders.ServiceId = Services.Id
where Client.Id = @Id and Orders.IsDeleted = 0
end
-- Получить MasterId по IntervalId если этот интервал ещё не занят в Order
create procedure GetFreeMasterIdByIntervalId
    @IntervalId int as
BEGIN
    select Users.Id as MasterId from Users
    join Shifts on Users.Id = Shifts.MasterId
    join Intervals on Shifts.Id = Intervals.ShiftId
    where Intervals.Id = @IntervalId and Users.IsDeleted = 0 and Shifts.IsDeleted = 0 and Intervals.IsDeleted = 0 and Intervals.IsBusy = 0
END
-- ✓ Вывести свободных мастеров и свободные интервалы для записи
create proc GetFreeMastersAndIntervalsOnToday
    as
begin
    declare @Today datetime
    set @Today = GETDATE()
    select Users.Id as MasterId, Users.Name as Master, Intervals.Id, Intervals.Title, Intervals.StartTime from Users
    join Shifts on Users.Id = Shifts.MasterId
    join Intervals on Shifts.Id = Intervals.ShiftId
    where Users.IsDeleted = 0 and Shifts.IsDeleted = 0 and Intervals.IsDeleted = 0 and Intervals.IsBusy = 0
end
go
-- ✓ Вывести все смены, имеющие СВОБОДНЫЕ интервалы для записи (без дублирования смен)
create proc GetAllShiftsWithFreeIntervalsOnToday
    as
begin
    declare @Today datetime
    set @Today = GETDATE()
    select Shifts.Id, Shifts.Title, Shifts.StartTime from Shifts
    where Shifts.Id in 
        (
        select distinct Intervals.ShiftId from Intervals
        where Intervals.IsBusy = 0 and convert(date, Intervals.StartTime) = convert(date, @Today)
        );
end
go
-- ✓ Для ВЫБРАННОЙ смены вывести все СВОБОДНЫЕ для записи интервалы
create proc GetAllFreeIntervalsByShiftId
@ShiftId int as
begin
    select Intervals.Id, Intervals.Title, Intervals.StartTime from Intervals
    join Shifts on Shifts.Id = Intervals.ShiftId
    where @ShiftId = Shifts.Id and Intervals.IsBusy = 0
end
go
-- ✓ Для ВЫБРАННОЙ услуги вывести все смены, имеющие СВОБОДНЫЕ интервалы для записи
create proc GetAllShiftsWithFreeIntervalsOnCurrentService
@ServiceId int as
begin
    select Services.Id, Services.Title, Shifts.Id, Shifts.Title, Shifts.StartTime from Shifts
    join Services on Services.Id = @ServiceId
    join Intervals on Intervals.ShiftId = Shifts.Id
    where Intervals.IsBusy = 0
end
go
-- ✓ Для ВЫБРАННОЙ услуги в ВЫБРАННУЮ смену вывести все СВОБОДНЫЕ интервалы для записи
create proc GetAllFreeIntervalsInCurrentShiftOnCurrentService
    @ServiceId int, @ShiftId int as
begin
    select Services.Id, Services.Title, Shifts.Id, Shifts.Title, Shifts.StartTime, Intervals.Id, Intervals.Title, Intervals.StartTime from Intervals
    join Services on Services.Id = @ServiceId
    join Shifts on Shifts.Id = @ShiftId
    where Intervals.IsBusy = 0
end
go
-- ✓ Для ВЫБРАННОЙ услуги вывести все СВОБОДНЫЕ интервалы для записи
create proc GetAllFreeIntervalsOnCurrentService
@ServiceId int as
begin
    select Services.Id, Services.Title, Intervals.Id, Intervals.Title, Intervals.StartTime from Intervals
    join Services on Services.Id = @ServiceId
    where Intervals.IsBusy = 0
end
go
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
go
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
go
-- ✓ Изменить время записи клиента
create proc UpdateOrderTimeForClientById
    @OrderId int, @ClientId int, @MasterId int, @IntervalId int as
begin
    update Orders
    set MasterId = @MasterId, StartIntervalId = @IntervalId
    where Orders.Id = @OrderId and Orders.ClientId = @ClientId
end
go
-- ✓ Удалить запись клиента
create proc RemoveOrderForClientByOrderId
@OrderId int as
begin
    update Orders
    set Orders.IsDeleted = 1
    where Orders.Id = @OrderId
end
go