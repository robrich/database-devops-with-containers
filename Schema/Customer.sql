USE [WebApp]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Customer](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](20) NOT NULL,
	[Email] [nvarchar](200) NOT NULL,
	[Title] [nvarchar](10) NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](100) NULL,
	[Address1] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[State] [nvarchar](50) NULL,
	[Zip] [nvarchar](20) NULL,
	[Country] [nvarchar](2) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[Gender] [nvarchar](10) NULL,
	[Phone] [varchar](50) NULL,
	[Cell] [varchar](50) NULL,
	[ProfileLargeUrl] [nvarchar](120) NULL,
	[ProfileMediumUrl] [nvarchar](120) NULL,
	[ProfileThumbUrl] [nvarchar](120) NULL,
 CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

