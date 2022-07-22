create table Employee(
EmployeeId int identity (1,1)primary key,
FirstName varchar(255),
LastName varchar(255),
Email varchar(255),
Password varchar(255),
EmpAddress varchar(255),
Gender varchar(255),
DateOfBirth varchar(255),
Position varchar(255),
Salary Decimal,
PhoneNumber varchar(50)
);

select *from Employee
----Add Procedure  for AddEmployee----
create procedure AddEmployee
(
@FirstName varchar(255),
@LastName varchar(255),
@Email varchar(255),
@Password varchar(255),
@EmpAddress varchar(100),
@Gender varchar(255),
@DateOfBirth varchar(255),
@Position varchar(255),
@Salary Decimal,
@PhoneNumber varchar(50)
)
as
BEGIN
Insert into Employee(FirstName, LastName,Email,Password, EmpAddress, Gender, DateOfBirth, 
Position, Salary, PhoneNumber)
values (@FirstName, @LastName,@Email,@Password, @EmpAddress, @Gender ,@DateOfBirth, @Position,
@Salary, @PhoneNumber);
End;

-------Procedure for delete----
create procedure DeleteEmployee
(
@EmployeeId int
)
as
BEGIN
Delete Employee
where EmployeeId = @EmployeeId;
End;


----Store procedure for update Employee--

create procedure UpdateEmployee
(
@EmployeeId int,
@FirstName varchar(255),
@LastName varchar(255),
@Email varchar(100),
@Password varchar(255),
@EmpAddress varchar(255),
@Gender varchar(255),
@DateOfBirth varchar(255),
@Position varchar(255),
@Salary Decimal,
@PhoneNumber varchar(50)
)
as
BEGIN
Update Employee set FirstName = @FirstName, 
LastName = @LastName,
Email = @Email,
Password =@Password,
EmpAddress= @EmpAddress,
Gender = @Gender,
DateOfBirth = @DateOfBirth,
Position =@Position,
Salary = @Salary,
PhoneNumber=@PhoneNumber
where EmployeeId = @EmployeeId;
End;

----Procedure for getAllEmployee----

create procedure GetAllEmployee
as
BEGIN
	select * from Employee;
End;

