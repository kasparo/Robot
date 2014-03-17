USE [RobotHand]
GO

/****** Object:  Table [dbo].[Robot]    Script Date: 03/17/2014 06:59:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Robot](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Place] [nchar](10) NOT NULL,
	[Identification] [nchar](20) NOT NULL,
 CONSTRAINT [PK_Robot] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Robot] ADD  CONSTRAINT [DF_Robot_Place]  DEFAULT ('') FOR [Place]
GO

ALTER TABLE [dbo].[Robot] ADD  CONSTRAINT [DF_Robot_Identification]  DEFAULT ('') FOR [Identification]
GO


