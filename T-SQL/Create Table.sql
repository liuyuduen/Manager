use master
go
if exists(select * from sys.databases where name='ManagerDB')
begin
	drop database ManagerDB
end
go 
--�������ݿ�---------start
create database ManagerDB
on(
	filename='F:\project\Manager\DB\ManagerDB.mdf',
	name='ManagerDB',
	size=10MB,
	filegrowth=5MB
)
log on
(
	filename='F:\project\Manager\DB\ManagerDB_log.ldf',
	name='ManagerDB_log',
	size=10MB,
	filegrowth=10%
)
--�������ݿ�---------end

Go

use ManagerDB
 --��ManagerDB���ݿ�
go
---------------------����-----------------start
--�û�������
if exists(select * from sys.objects where name='T_User')
	drop table T_User
go


create table T_User
(
	UserID varchar(50) primary key not null, 
	SystemID varchar(50) not null,
	LoginName varchar(50) not null,
	PwssWord varchar(50) not null,
	NiceName nvarchar(50),--�ǳ� 
	Level int not null,	--�ȼ�
	Integral int not null,	--����	
	RegisterDate datetime not null,
	UpudateDate datetime not null,
	LastLoginDate datetime not null,
	LastOpreateDate datetime not null,	--���ʱ��
	IsOnLin bit not null,--�Ƿ�����
	UserType int not null,--�û�����
	UserStatus smallint not null,		--״̬ 0 ע�� 1���� 2���� 																					UserIP varchar(50)  not null
) 
 EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�û����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'UserID'
 EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��¼�˺�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'LoginName'
 EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��¼����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'PwssWord'
 EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ǳ�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'NiceName'
 EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ȼ�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'Level'
 EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'Integral'
 EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ע��ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'RegisterDate'
 EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'UpudateDate'
 EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����¼ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'LastLoginDate'
 EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'LastOpreateDate'
 EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ƿ����� 0���� 1����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'IsOnLin'
 EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�û����� 0ϵͳ�˺� 1 ��ͨ�û� 2 ������û� 3 �ƹ�Ա' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'UserType'
 EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'״̬ 0���� 1���� 2ɾ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'UserStatus'
go


if exists(select * from sys.objects where name='T_UserExtend')
	drop table T_UserExtend
go

--�û���Ϣ��չ��
create table T_UserExtend
(
	UserExtendID varchar(50) primary key not null, 
	UserID varchar(50) not null, 
	SystemID varchar(50) not null,
	UserName varchar(50),
	UserIDCard varchar(50),--���֤
	Phone varchar(50),-- 
	Email varchar(50), 
	Fax varchar(50), --����
	[Address] nvarchar(200), 
	Gender bit,
	Birthday datetime, 
	Photo varchar(50),
	UserIP nvarchar(50), --�û�IP
)
 EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�û���չ���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_UserExtend', @level2type=N'COLUMN',@level2name=N'UserExtendID'
 EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�û����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_UserExtend', @level2type=N'COLUMN',@level2name=N'UserID'
 EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ʵ����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_UserExtend', @level2type=N'COLUMN',@level2name=N'UserName'
 EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���֤' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_UserExtend', @level2type=N'COLUMN',@level2name=N'UserIDCard'
 EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ֻ���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_UserExtend', @level2type=N'COLUMN',@level2name=N'Phone'
 EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_UserExtend', @level2type=N'COLUMN',@level2name=N'Email'
 EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_UserExtend', @level2type=N'COLUMN',@level2name=N'Fax'
 EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ϵ��ַ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_UserExtend', @level2type=N'COLUMN',@level2name=N'Address'
 EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ա�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_UserExtend', @level2type=N'COLUMN',@level2name=N'Gender'
 EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_UserExtend', @level2type=N'COLUMN',@level2name=N'Birthday'
 EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ͷ����Ƭ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_UserExtend', @level2type=N'COLUMN',@level2name=N'Photo'
 EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��¼IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_UserExtend', @level2type=N'COLUMN',@level2name=N'UserIP'
 go
  
-------------------------------------------------------------------------------------
--��ɫ��
if exists(select * from sys.objects where name='T_Role')
	drop table T_Role
go

--��ɫ��Ϣ��
create table T_Role
(
	RoleID varchar(50) primary key not null, 
	SystemID varchar(50) not null,
	RoleName varchar(50) not null, 
	CreateUser varchar(50) not null, 
	CreateDate varchar(50) not null, 
	UpdateUser varchar(50) not null, 
	UpdateDate varchar(50) not null, 
	Status bit not null,  --0 ���� 1 ����
	[Index] smallint  not null,  --0 ����
)
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ɫ���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Role', @level2type=N'COLUMN',@level2name=N'RoleID'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ɫ����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Role', @level2type=N'COLUMN',@level2name=N'RoleName'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Role', @level2type=N'COLUMN',@level2name=N'CreateUser'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Role', @level2type=N'COLUMN',@level2name=N'CreateDate'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Role', @level2type=N'COLUMN',@level2name=N'UpdateUser'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Role', @level2type=N'COLUMN',@level2name=N'UpdateDate'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'״̬������ 1 ����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Role', @level2type=N'COLUMN',@level2name=N'Status'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Role', @level2type=N'COLUMN',@level2name=N'Index'
 
go
---------
--ģ����Ϣ��
if exists(select * from sys.objects where name='T_Module')
	drop table T_Module
go

--ģ����Ϣ��
create table T_Module
(
	ModuleID varchar(50) primary key not null, 
	SystemID varchar(50) not null,
	ModuleName varchar(50) not null, 
	ModuleParentID varchar(50),
	Type bit not null,-- Ȩ�����ͣ� 0ҳ�浼�� 1���ܰ�ť
	URL varchar(50),-- 
	ModuleCode varchar(50) not null,  
	[Index] smallint  not null,  --0 ����
	Status bit  not null,  --0 ���� 1 ����
	CreateUser varchar(50)  not null,  
	CreateDate varchar(50)  not null, 
	UpdateUser varchar(50) not null, 
	UpdateDate varchar(50) not null, 
)
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ģ����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Module', @level2type=N'COLUMN',@level2name=N'ModuleID'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ģ������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Module', @level2type=N'COLUMN',@level2name=N'ModuleName'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ģ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Module', @level2type=N'COLUMN',@level2name=N'ModuleParentID'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ģ������ 0ҳ�浼�� 1���ܰ�ť' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Module', @level2type=N'COLUMN',@level2name=N'Type'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ҳ���ַ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Module', @level2type=N'COLUMN',@level2name=N'URL'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ģ�����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Module', @level2type=N'COLUMN',@level2name=N'ModuleCode'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Module', @level2type=N'COLUMN',@level2name=N'CreateUser'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Module', @level2type=N'COLUMN',@level2name=N'CreateDate'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Module', @level2type=N'COLUMN',@level2name=N'UpdateUser'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Module', @level2type=N'COLUMN',@level2name=N'UpdateDate'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'״̬ 0 ����1����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Module', @level2type=N'COLUMN',@level2name=N'Status'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Module', @level2type=N'COLUMN',@level2name=N'Index'
 
go
--------------
--�û���ɫ��
if exists(select * from sys.objects where name='T_UserRole')
	drop table T_UserRole
go

--�û���ɫ��
create table T_UserRole
(
	UserRoleID varchar(50) primary key not null, 
	SystemID varchar(50) not null,
	UserID varchar(50) not null,
	RoleID varchar(50) not null
)
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_UserRole', @level2type=N'COLUMN',@level2name=N'UserRoleID'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�û����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_UserRole', @level2type=N'COLUMN',@level2name=N'UserID'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ɫ���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_UserRole', @level2type=N'COLUMN',@level2name=N'RoleID'
 
go
--------------
--��ɫģ���
if exists(select * from sys.objects where name='T_Permission')
	drop table T_Permission
go

--��ɫģ���
create table T_Permission
(
	PermissionID varchar(50) primary key not null,  
	SystemID varchar(50) not null,
	RoleID varchar(50) not null,
	ModuleID varchar(50) not null
)
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Permission', @level2type=N'COLUMN',@level2name=N'PermissionID'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ģ����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Permission', @level2type=N'COLUMN',@level2name=N'ModuleID'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ɫ���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Permission', @level2type=N'COLUMN',@level2name=N'RoleID'
go
----------------

--��ɫģ���
if exists(select * from sys.objects where name='ErrorLog')
	drop table ErrorLog
go
create table ErrorLog
( 
	[ID] int IDENTITY (1,1) NOT NULL ,
	[eDate] datetime,
	[eMachine] nvarchar(100),
	[eLevel] nvarchar(100),
	[eSystemName]  nvarchar(100),
	[eMessage]  nvarchar(2000),
	[eException]  nvarchar(2000),
)
