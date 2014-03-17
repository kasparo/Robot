USE [RobotHand]
GO

/****** Object:  Table [dbo].[Instruction]    Script Date: 03/17/2014 06:58:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Instruction](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Id_Part] [int] NOT NULL,
	[Value] [int] NOT NULL,
 CONSTRAINT [PK_Instruction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Instruction]  WITH CHECK ADD  CONSTRAINT [FK_Instruction_Part] FOREIGN KEY([Id_Part])
REFERENCES [dbo].[Part] ([Id])
GO

ALTER TABLE [dbo].[Instruction] CHECK CONSTRAINT [FK_Instruction_Part]
GO

ALTER TABLE [dbo].[Instruction] ADD  CONSTRAINT [DF_Instruction_Value]  DEFAULT ((0)) FOR [Value]
GO


