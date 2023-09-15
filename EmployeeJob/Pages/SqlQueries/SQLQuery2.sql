ALTER TABLE EmployeeJobs drop CONSTRAINT PK_EmployeeJobs;
ALTER TABLE EmployeeJobs ADD CONSTRAINT PK_EmployeeJobs PRIMARY KEY (Eid,Jid);
SET IDENTITY_INSERT EmployeeJobs OFF;

drop database EmployeesJobs
delete from EmployeeJobs where Eid=3;
select * from EmployeeJobs;


//not important just notes