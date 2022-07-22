create database EmployeeManagement

create Table Admin
(
	AdminId int Identity(1,1) primary key not null,
	FullName varchar(255) not null,
	Email varchar(255) not null,
	Password varchar(255) not null,
	MobileNumber varchar(50) not null,
);

select * from Admin


INSERT INTO Admin VALUES ('Admin Admin','Admin@admin.com', 'Admin@123', '+91 8805713251');

--------Admin Login
Create Procedure LoginAdmin
(
	@Email varchar(max),
	@Password varchar(max)
)
as
BEGIN
	If(Exists(select * from Admin where Email= @Email and Password = @Password))
		Begin
			select * from Admin where Email= @Email and Password = @Password;
		end
	Else
		Begin
			select 2;
			End
End;