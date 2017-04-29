use master
go
if exists(select * from sys.databases where name='ManagerDB')
begin
	drop database ManagerDB
end
go 
--建立数据库---------start
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
--建立数据库---------end

Go

use ManagerDB
 --打开ManagerDB数据库
go
---------------------建表-----------------start
--用户基础表
if exists(select * from sys.objects where name='T_User')
	drop table T_User
go


create table T_User
(
	UserID varchar(50) primary key not null, 
	SystemID varchar(50) not null,
	LoginName varchar(50) not null,
	PwssWord varchar(50) not null,
	NiceName nvarchar(50),--昵称 
	Level int not null,	--等级
	Integral int not null,	--积分	
	RegisterDate datetime not null,
	UpudateDate datetime not null,
	LastLoginDate datetime not null,
	LastOpreateDate datetime not null,	--最后活动时间
	IsOnLin bit not null,--是否在线
	UserType int not null,--用户类型
	UserStatus smallint not null,		--状态 0 注册 1正常 2禁用 																					UserIP varchar(50)  not null
) 
 EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'UserID'
 EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录账号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'LoginName'
 EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'PwssWord'
 EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'昵称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'NiceName'
 EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'等级' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'Level'
 EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'积分' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'Integral'
 EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'注册时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'RegisterDate'
 EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'UpudateDate'
 EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后登录时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'LastLoginDate'
 EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后活动时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'LastOpreateDate'
 EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否在线 0离线 1在线' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'IsOnLin'
 EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户类型 0系统账号 1 普通用户 2 广告商用户 3 推广员' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'UserType'
 EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态 0正常 1锁定 2删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'UserStatus'
go


if exists(select * from sys.objects where name='T_UserExtend')
	drop table T_UserExtend
go

--用户信息扩展表
create table T_UserExtend
(
	UserExtendID varchar(50) primary key not null, 
	UserID varchar(50) not null, 
	SystemID varchar(50) not null,
	UserName varchar(50),
	UserIDCard varchar(50),--身份证
	Phone varchar(50),-- 
	Email varchar(50), 
	Fax varchar(50), --传真
	[Address] nvarchar(200), 
	Gender bit,
	Birthday datetime, 
	Photo varchar(50),
	UserIP nvarchar(50), --用户IP
)
 EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户扩展编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_UserExtend', @level2type=N'COLUMN',@level2name=N'UserExtendID'
 EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_UserExtend', @level2type=N'COLUMN',@level2name=N'UserID'
 EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'真实姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_UserExtend', @level2type=N'COLUMN',@level2name=N'UserName'
 EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'身份证' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_UserExtend', @level2type=N'COLUMN',@level2name=N'UserIDCard'
 EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'手机号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_UserExtend', @level2type=N'COLUMN',@level2name=N'Phone'
 EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'邮箱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_UserExtend', @level2type=N'COLUMN',@level2name=N'Email'
 EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'传真' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_UserExtend', @level2type=N'COLUMN',@level2name=N'Fax'
 EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联系地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_UserExtend', @level2type=N'COLUMN',@level2name=N'Address'
 EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'性别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_UserExtend', @level2type=N'COLUMN',@level2name=N'Gender'
 EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生日' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_UserExtend', @level2type=N'COLUMN',@level2name=N'Birthday'
 EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'头像照片' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_UserExtend', @level2type=N'COLUMN',@level2name=N'Photo'
 EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_UserExtend', @level2type=N'COLUMN',@level2name=N'UserIP'
 go
  
-------------------------------------------------------------------------------------
--角色表
if exists(select * from sys.objects where name='T_Role')
	drop table T_Role
go

--角色信息表
create table T_Role
(
	RoleID varchar(50) primary key not null, 
	SystemID varchar(50) not null,
	RoleName varchar(50) not null, 
	CreateUser varchar(50) not null, 
	CreateDate varchar(50) not null, 
	UpdateUser varchar(50) not null, 
	UpdateDate varchar(50) not null, 
	Status bit not null,  --0 启用 1 禁用
	[Index] smallint  not null,  --0 排序
)
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Role', @level2type=N'COLUMN',@level2name=N'RoleID'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Role', @level2type=N'COLUMN',@level2name=N'RoleName'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Role', @level2type=N'COLUMN',@level2name=N'CreateUser'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Role', @level2type=N'COLUMN',@level2name=N'CreateDate'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Role', @level2type=N'COLUMN',@level2name=N'UpdateUser'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Role', @level2type=N'COLUMN',@level2name=N'UpdateDate'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态：启用 1 禁用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Role', @level2type=N'COLUMN',@level2name=N'Status'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Role', @level2type=N'COLUMN',@level2name=N'Index'
 
go
---------
--模块信息表
if exists(select * from sys.objects where name='T_Module')
	drop table T_Module
go

--模块信息表
create table T_Module
(
	ModuleID varchar(50) primary key not null, 
	SystemID varchar(50) not null,
	ModuleName varchar(50) not null, 
	ModuleParentID varchar(50),
	Type bit not null,-- 权限类型： 0页面导航 1功能按钮
	URL varchar(50),-- 
	ModuleCode varchar(50) not null,  
	[Index] smallint  not null,  --0 排序
	Status bit  not null,  --0 启用 1 禁用
	CreateUser varchar(50)  not null,  
	CreateDate varchar(50)  not null, 
	UpdateUser varchar(50) not null, 
	UpdateDate varchar(50) not null, 
)
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'模块编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Module', @level2type=N'COLUMN',@level2name=N'ModuleID'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'模块名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Module', @level2type=N'COLUMN',@level2name=N'ModuleName'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'父模块' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Module', @level2type=N'COLUMN',@level2name=N'ModuleParentID'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'模块类型 0页面导航 1功能按钮' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Module', @level2type=N'COLUMN',@level2name=N'Type'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'页面地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Module', @level2type=N'COLUMN',@level2name=N'URL'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'模块代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Module', @level2type=N'COLUMN',@level2name=N'ModuleCode'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Module', @level2type=N'COLUMN',@level2name=N'CreateUser'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Module', @level2type=N'COLUMN',@level2name=N'CreateDate'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Module', @level2type=N'COLUMN',@level2name=N'UpdateUser'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Module', @level2type=N'COLUMN',@level2name=N'UpdateDate'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态 0 启用1禁用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Module', @level2type=N'COLUMN',@level2name=N'Status'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Module', @level2type=N'COLUMN',@level2name=N'Index'
 
go
--------------
--用户角色表
if exists(select * from sys.objects where name='T_UserRole')
	drop table T_UserRole
go

--用户角色表
create table T_UserRole
(
	UserRoleID varchar(50) primary key not null, 
	SystemID varchar(50) not null,
	UserID varchar(50) not null,
	RoleID varchar(50) not null
)
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_UserRole', @level2type=N'COLUMN',@level2name=N'UserRoleID'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_UserRole', @level2type=N'COLUMN',@level2name=N'UserID'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_UserRole', @level2type=N'COLUMN',@level2name=N'RoleID'
 
go
--------------
--角色模块表
if exists(select * from sys.objects where name='T_Permission')
	drop table T_Permission
go

--角色模块表
create table T_Permission
(
	PermissionID varchar(50) primary key not null,  
	SystemID varchar(50) not null,
	RoleID varchar(50) not null,
	ModuleID varchar(50) not null
)
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Permission', @level2type=N'COLUMN',@level2name=N'PermissionID'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'模块编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Permission', @level2type=N'COLUMN',@level2name=N'ModuleID'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Permission', @level2type=N'COLUMN',@level2name=N'RoleID'
go
----------------

--角色模块表
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
