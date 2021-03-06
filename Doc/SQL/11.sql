USE [Bill]
GO
/****** Object:  Table [dbo].[Bills]    Script Date: 2019/3/8 16:55:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bills](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BillsTypeId] [int] NOT NULL,
	[Money] [money] NOT NULL,
	[UserId] [int] NOT NULL,
	[UpdateTime] [datetime] NULL,
	[CreationTime] [datetime] NOT NULL,
	[Describe] [nvarchar](128) NULL,
 CONSTRAINT [PK_BILLS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BillsType]    Script Date: 2019/3/8 16:55:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillsType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](32) NOT NULL,
	[Logo] [nvarchar](64) NOT NULL,
	[UserId] [int] NOT NULL,
	[CreationTime] [datetime] NOT NULL,
	[Describe] [nvarchar](128) NULL,
	[IsDefault] [bit] NULL,
	[IsSystem] [bit] NULL,
 CONSTRAINT [PK_BILLSTYPE] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 2019/3/8 16:55:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](32) NOT NULL,
	[Pwd] [varchar](32) NOT NULL,
	[RandomCode] [char](6) NOT NULL,
	[NickName] [nvarchar](16) NOT NULL,
	[Logo] [nvarchar](64) NULL,
	[CreationTime] [datetime] NOT NULL,
	[Describe] [nvarchar](128) NULL,
	[IsSystem] [bit] NULL,
 CONSTRAINT [PK_USERS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Bills] ON 

INSERT [dbo].[Bills] ([Id], [BillsTypeId], [Money], [UserId], [UpdateTime], [CreationTime], [Describe]) VALUES (6, 7, 1.0000, 1, CAST(0x0000AA0900351768 AS DateTime), CAST(0x0000AA0A00FAE48F AS DateTime), N'单车')
INSERT [dbo].[Bills] ([Id], [BillsTypeId], [Money], [UserId], [UpdateTime], [CreationTime], [Describe]) VALUES (7, 3, 50.0000, 1, CAST(0x0000AA0900352ED8 AS DateTime), CAST(0x0000AA0A00FB18C0 AS DateTime), N'话费')
INSERT [dbo].[Bills] ([Id], [BillsTypeId], [Money], [UserId], [UpdateTime], [CreationTime], [Describe]) VALUES (8, 6, 66.5000, 1, CAST(0x0000AA0700355908 AS DateTime), CAST(0x0000AA0A00FB4326 AS DateTime), NULL)
INSERT [dbo].[Bills] ([Id], [BillsTypeId], [Money], [UserId], [UpdateTime], [CreationTime], [Describe]) VALUES (9, 7, 1.0000, 1, CAST(0x0000AA0700358590 AS DateTime), CAST(0x0000AA0A00FB5416 AS DateTime), N'单车')
INSERT [dbo].[Bills] ([Id], [BillsTypeId], [Money], [UserId], [UpdateTime], [CreationTime], [Describe]) VALUES (10, 7, 1.0000, 1, CAST(0x0000AA07003594CC AS DateTime), CAST(0x0000AA0A00FB642F AS DateTime), N'单车')
INSERT [dbo].[Bills] ([Id], [BillsTypeId], [Money], [UserId], [UpdateTime], [CreationTime], [Describe]) VALUES (11, 1, 21.9000, 1, CAST(0x0000AA070035A534 AS DateTime), CAST(0x0000AA0A00FB818E AS DateTime), N'美团')
INSERT [dbo].[Bills] ([Id], [BillsTypeId], [Money], [UserId], [UpdateTime], [CreationTime], [Describe]) VALUES (12, 8, 30.0000, 1, CAST(0x0000AA0600362F7C AS DateTime), CAST(0x0000AA0A00FC1601 AS DateTime), N'飞卢充值')
INSERT [dbo].[Bills] ([Id], [BillsTypeId], [Money], [UserId], [UpdateTime], [CreationTime], [Describe]) VALUES (13, 2, 95.0000, 1, CAST(0x0000AA0600365628 AS DateTime), CAST(0x0000AA0A00FC2E7A AS DateTime), N'哑铃')
INSERT [dbo].[Bills] ([Id], [BillsTypeId], [Money], [UserId], [UpdateTime], [CreationTime], [Describe]) VALUES (14, 1, 6.0000, 1, CAST(0x0000AA0400366EC4 AS DateTime), CAST(0x0000AA0A00FC593B AS DateTime), N'调料')
INSERT [dbo].[Bills] ([Id], [BillsTypeId], [Money], [UserId], [UpdateTime], [CreationTime], [Describe]) VALUES (15, 1, 18.9000, 1, CAST(0x0000AA03003698F4 AS DateTime), CAST(0x0000AA0A00FC7BA0 AS DateTime), N'美团')
INSERT [dbo].[Bills] ([Id], [BillsTypeId], [Money], [UserId], [UpdateTime], [CreationTime], [Describe]) VALUES (16, 7, 1.0000, 1, CAST(0x0000AA030036BAF0 AS DateTime), CAST(0x0000AA0A00FC8861 AS DateTime), N'单车')
INSERT [dbo].[Bills] ([Id], [BillsTypeId], [Money], [UserId], [UpdateTime], [CreationTime], [Describe]) VALUES (17, 1, 148.0000, 1, CAST(0x0000AA040036D38C AS DateTime), CAST(0x0000AA0A00FCD759 AS DateTime), N'烤鱼')
INSERT [dbo].[Bills] ([Id], [BillsTypeId], [Money], [UserId], [UpdateTime], [CreationTime], [Describe]) VALUES (18, 1, 2.5000, 1, CAST(0x0000AA0300380568 AS DateTime), CAST(0x0000AA0A00FDD36B AS DateTime), NULL)
INSERT [dbo].[Bills] ([Id], [BillsTypeId], [Money], [UserId], [UpdateTime], [CreationTime], [Describe]) VALUES (19, 1, 11.5000, 1, CAST(0x0000AA0300383448 AS DateTime), CAST(0x0000AA0A00FE04E7 AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Bills] OFF
SET IDENTITY_INSERT [dbo].[BillsType] ON 

INSERT [dbo].[BillsType] ([Id], [Name], [Logo], [UserId], [CreationTime], [Describe], [IsDefault], [IsSystem]) VALUES (1, N'餐饮', N'/Images/BillsTypeImg/canyin.png', 4, CAST(0x0000AA0900E7716F AS DateTime), N'餐饮', 1, 1)
INSERT [dbo].[BillsType] ([Id], [Name], [Logo], [UserId], [CreationTime], [Describe], [IsDefault], [IsSystem]) VALUES (2, N'购物', N'/Images/BillsTypeImg/gouwu.png', 4, CAST(0x0000AA0900E77170 AS DateTime), N'购物', 0, 1)
INSERT [dbo].[BillsType] ([Id], [Name], [Logo], [UserId], [CreationTime], [Describe], [IsDefault], [IsSystem]) VALUES (3, N'通讯', N'/Images/BillsTypeImg/tongxun.png', 4, CAST(0x0000AA0900E77170 AS DateTime), N'通讯', 0, 1)
INSERT [dbo].[BillsType] ([Id], [Name], [Logo], [UserId], [CreationTime], [Describe], [IsDefault], [IsSystem]) VALUES (4, N'零食', N'/Images/BillsTypeImg/lingshi.png', 4, CAST(0x0000AA0900E77170 AS DateTime), N'餐饮', 0, 1)
INSERT [dbo].[BillsType] ([Id], [Name], [Logo], [UserId], [CreationTime], [Describe], [IsDefault], [IsSystem]) VALUES (5, N'一般', N'/Images/BillsTypeImg/yiban.png', 4, CAST(0x0000AA0900E77170 AS DateTime), N'一般', 0, 1)
INSERT [dbo].[BillsType] ([Id], [Name], [Logo], [UserId], [CreationTime], [Describe], [IsDefault], [IsSystem]) VALUES (6, N'水果', N'http://t.cn/RCzsdCq', 1, CAST(0x0000AA0900EBD3B3 AS DateTime), NULL, 0, 0)
INSERT [dbo].[BillsType] ([Id], [Name], [Logo], [UserId], [CreationTime], [Describe], [IsDefault], [IsSystem]) VALUES (7, N'交通', N'/Images/BillsTypeImg/jiaotong.png', 4, CAST(0x0000AA0A00FAC3B2 AS DateTime), N'一般', 0, 1)
INSERT [dbo].[BillsType] ([Id], [Name], [Logo], [UserId], [CreationTime], [Describe], [IsDefault], [IsSystem]) VALUES (8, N'小说', N'\Files\BillsType\1552029428790.png', 1, CAST(0x0000AA0A00FBE876 AS DateTime), N'小说相关消费', 0, 0)
SET IDENTITY_INSERT [dbo].[BillsType] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Name], [Pwd], [RandomCode], [NickName], [Logo], [CreationTime], [Describe], [IsSystem]) VALUES (1, N'zx', N'67be35738cd0571aa9df3dc4a3e7b35', N'485261', N'zx', NULL, CAST(0x0000AA0300A8FEC0 AS DateTime), NULL, NULL)
INSERT [dbo].[Users] ([Id], [Name], [Pwd], [RandomCode], [NickName], [Logo], [CreationTime], [Describe], [IsSystem]) VALUES (2, N'11', N'63d546fba3508c5134b7a4854df634', N'195697', N'11', NULL, CAST(0x0000AA0300A95305 AS DateTime), NULL, NULL)
INSERT [dbo].[Users] ([Id], [Name], [Pwd], [RandomCode], [NickName], [Logo], [CreationTime], [Describe], [IsSystem]) VALUES (4, N'admin', N'88a4db38a595b217a933a5acd5ed2d1', N'714294', N'默认账户', N'/', CAST(0x0000AA0900E57699 AS DateTime), N'默认账户', 1)
SET IDENTITY_INSERT [dbo].[Users] OFF
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_IsSystem]  DEFAULT ((0)) FOR [IsSystem]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'Pwd'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'随机加密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'RandomCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'昵称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'NickName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'头像' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'Logo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'CreationTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'Describe'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users'
GO
