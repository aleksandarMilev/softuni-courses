--1
create trigger trg_Accounts_SumChange
on Accounts
after update
as
begin
    insert into Logs (AccountId, OldSum, NewSum)
    select
        i.Id,          
        d.Balance as OldSum, 
        i.Balance as NewSum  
    from inserted i inner join deleted d on i.Id = d.Id; 
end;

--2
create or alter trg_Logs_TableInserted
on Logs
after insert
as
begin
	insert into NotificationEmails (Recipient, Subject, Body)
		select 
			i.AccountId
			,'Balance change for account: ' +  cast(i.AccountId as nvarchar(10))
			,'On ' + cast(getdate() as nvarchar(20)) + ' your balance was changed from ' + cast(i.OldSum as nvarchar(30))+ ' to ' + cast(i.NewSum as nvarchar(30)) + '.'
		from inserted i
end

--3
create or alter proc usp_DepositMoney
@AccountId int
,@MoneyAmount decimal(18, 4)
as
begin	
	if @MoneyAmount > 0
		begin
			update Accounts 
			set Balance = Balance + @MoneyAmount
			where @AccountId = Id
		end
end

--4
create or alter proc usp_WithdrawMoney 
@AccountId int
,@MoneyAmount decimal(18,4)
as
begin
	if @MoneyAmount > 0
		begin
			update Accounts
			set Balance = Balance - @MoneyAmount 
			where @AccountId = Id
		end
end

--5
create or alter proc usp_TransferMoney
@SenderId int
,@ReceiverId int
,@Amount decimal(18,4)
as
begin 
	if @Amount > 0 and @SenderId <> @ReceiverId
		begin 
			begin try
				begin transaction
				exec usp_WithdrawMoney @SenderId, @Amount;

				exec usp_DepositMoney @ReceiverId, @Amount;

				commit transaction;
			end try
			begin catch
				rollback transaction;
				throw;
			end catch
		end
end

