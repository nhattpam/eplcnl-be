USE [EPLCNL]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 1/23/2024 3:14:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[id] [uniqueidentifier] NOT NULL,
	[email] [varchar](255) NULL,
	[password] [varchar](255) NULL,
	[full_name] [varchar](255) NULL,
	[phone_number] [varchar](10) NULL,
	[image_url] [varchar](2000) NULL,
	[date_of_birth] [date] NULL,
	[gender] [bit] NULL,
	[address] [varchar](255) NULL,
	[is_active] [bit] NULL,
	[is_deleted] [bit] NULL,
	[role_id] [uniqueidentifier] NULL,
	[created_date] [datetime] NULL,
	[created_by] [uniqueidentifier] NULL,
	[updated_date] [datetime] NULL,
	[updated_by] [uniqueidentifier] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AccountForum]    Script Date: 1/23/2024 3:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountForum](
	[id] [uniqueidentifier] NOT NULL,
	[learner_id] [uniqueidentifier] NULL,
	[tutor_id] [uniqueidentifier] NULL,
	[forum_id] [uniqueidentifier] NULL,
	[message] [varchar](max) NULL,
	[messaged_date] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AccountSurvey]    Script Date: 1/23/2024 3:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountSurvey](
	[id] [uniqueidentifier] NOT NULL,
	[survey_id] [uniqueidentifier] NULL,
	[learner_id] [uniqueidentifier] NULL,
	[answer] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Assignment]    Script Date: 1/23/2024 3:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Assignment](
	[id] [uniqueidentifier] NOT NULL,
	[question_text] [varchar](255) NULL,
	[open_time] [time](7) NULL,
	[close_time] [time](7) NULL,
	[module_id] [uniqueidentifier] NULL,
	[deadline] [time](7) NULL,
	[created_date] [datetime] NULL,
	[updated_date] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AssignmentAttempt]    Script Date: 1/23/2024 3:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssignmentAttempt](
	[id] [uniqueidentifier] NOT NULL,
	[assignment_id] [uniqueidentifier] NULL,
	[learner_id] [uniqueidentifier] NULL,
	[answer_text] [varchar](max) NULL,
	[attempted_date] [datetime] NULL,
	[total_grade] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 1/23/2024 3:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[id] [uniqueidentifier] NOT NULL,
	[name] [varchar](255) NULL,
	[description] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Center]    Script Date: 1/23/2024 3:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Center](
	[id] [uniqueidentifier] NOT NULL,
	[account_id] [uniqueidentifier] NULL,
	[name] [varchar](255) NULL,
	[description] [varchar](255) NULL,
	[address] [varchar](1000) NULL,
	[email] [varchar](255) NULL,
	[is_active] [bit] NULL,
	[staff_id] [uniqueidentifier] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Certificate]    Script Date: 1/23/2024 3:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Certificate](
	[id] [uniqueidentifier] NOT NULL,
	[name] [varchar](255) NULL,
	[created_date] [datetime] NULL,
	[updated_date] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CertificateCourse]    Script Date: 1/23/2024 3:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CertificateCourse](
	[id] [uniqueidentifier] NOT NULL,
	[certificate_id] [uniqueidentifier] NULL,
	[course_id] [uniqueidentifier] NULL,
	[description] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClassLesson]    Script Date: 1/23/2024 3:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClassLesson](
	[id] [uniqueidentifier] NOT NULL,
	[class_hours] [varchar](255) NULL,
	[class_url] [varchar](max) NULL,
	[class_module_id] [uniqueidentifier] NULL,
	[created_date] [datetime] NULL,
	[updated_date] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClassMaterial]    Script Date: 1/23/2024 3:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClassMaterial](
	[id] [uniqueidentifier] NOT NULL,
	[name] [varchar](100) NULL,
	[material_url] [varchar](max) NULL,
	[class_topic_id] [uniqueidentifier] NULL,
	[created_date] [datetime] NULL,
	[updated_date] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClassModule]    Script Date: 1/23/2024 3:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClassModule](
	[id] [uniqueidentifier] NOT NULL,
	[start_date] [datetime] NULL,
	[class_type_id] [uniqueidentifier] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClassPractice]    Script Date: 1/23/2024 3:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClassPractice](
	[id] [uniqueidentifier] NOT NULL,
	[name] [varchar](255) NULL,
	[class_topic_id] [uniqueidentifier] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClassTopic]    Script Date: 1/23/2024 3:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClassTopic](
	[id] [uniqueidentifier] NOT NULL,
	[name] [varchar](255) NULL,
	[description] [varchar](255) NULL,
	[material_url] [varchar](max) NULL,
	[created_date] [datetime] NULL,
	[updated_date] [datetime] NULL,
	[class_lesson_id] [uniqueidentifier] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClassType]    Script Date: 1/23/2024 3:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClassType](
	[id] [uniqueidentifier] NOT NULL,
	[name] [varchar](255) NULL,
	[course_id] [uniqueidentifier] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 1/23/2024 3:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[id] [uniqueidentifier] NOT NULL,
	[name] [varchar](255) NULL,
	[description] [varchar](255) NULL,
	[code] [varchar](100) NULL,
	[image_url] [varchar](2000) NULL,
	[tutor_id] [uniqueidentifier] NULL,
	[stock_price] [decimal](18, 0) NULL,
	[is_active] [bit] NULL,
	[is_online_class] [bit] NULL,
	[rating] [float] NULL,
	[category_id] [uniqueidentifier] NULL,
	[tags] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CourseType]    Script Date: 1/23/2024 3:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseType](
	[id] [uniqueidentifier] NOT NULL,
	[name] [varchar](255) NULL,
	[category_id] [uniqueidentifier] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Enrollment]    Script Date: 1/23/2024 3:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enrollment](
	[id] [uniqueidentifier] NOT NULL,
	[learner_id] [uniqueidentifier] NULL,
	[course_id] [uniqueidentifier] NULL,
	[enrolled_date] [datetime] NULL,
	[status] [varchar](255) NULL,
	[total_grade] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Feedback]    Script Date: 1/23/2024 3:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedback](
	[id] [uniqueidentifier] NOT NULL,
	[feedback_content] [varchar](max) NULL,
	[image_url] [varchar](max) NULL,
	[created_date] [datetime] NULL,
	[learner_id] [uniqueidentifier] NULL,
	[course_id] [uniqueidentifier] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Forum]    Script Date: 1/23/2024 3:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Forum](
	[id] [uniqueidentifier] NOT NULL,
	[course_id] [uniqueidentifier] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Learner]    Script Date: 1/23/2024 3:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Learner](
	[id] [uniqueidentifier] NOT NULL,
	[account_id] [uniqueidentifier] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lesson]    Script Date: 1/23/2024 3:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lesson](
	[id] [uniqueidentifier] NOT NULL,
	[name] [varchar](255) NULL,
	[video_url] [varchar](max) NULL,
	[reading] [varchar](max) NULL,
	[module_id] [uniqueidentifier] NULL,
	[created_date] [datetime] NULL,
	[updated_date] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LessonMaterial]    Script Date: 1/23/2024 3:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LessonMaterial](
	[id] [uniqueidentifier] NOT NULL,
	[name] [varchar](100) NULL,
	[material_url] [varchar](max) NULL,
	[lesson_id] [uniqueidentifier] NULL,
	[created_date] [datetime] NULL,
	[updated_date] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Module]    Script Date: 1/23/2024 3:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Module](
	[id] [uniqueidentifier] NOT NULL,
	[course_id] [uniqueidentifier] NULL,
	[name] [varchar](255) NULL,
	[created_date] [datetime] NULL,
	[updated_date] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PaperWork]    Script Date: 1/23/2024 3:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaperWork](
	[id] [uniqueidentifier] NOT NULL,
	[name] [varchar](255) NULL,
	[description] [varchar](255) NULL,
	[paper_work_url] [varchar](max) NULL,
	[paper_work_type_id] [uniqueidentifier] NULL,
	[tutor_id] [uniqueidentifier] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PaperWorkType]    Script Date: 1/23/2024 3:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaperWorkType](
	[id] [uniqueidentifier] NOT NULL,
	[name] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PaymentMethod]    Script Date: 1/23/2024 3:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentMethod](
	[id] [uniqueidentifier] NOT NULL,
	[name] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProfileCertificate]    Script Date: 1/23/2024 3:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProfileCertificate](
	[id] [uniqueidentifier] NOT NULL,
	[learner_id] [uniqueidentifier] NULL,
	[certificate_id] [uniqueidentifier] NULL,
	[status] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Question]    Script Date: 1/23/2024 3:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Question](
	[id] [uniqueidentifier] NOT NULL,
	[question_text] [varchar](max) NULL,
	[question_image_url] [varchar](max) NULL,
	[question_audio_url] [varchar](max) NULL,
	[default_grade] [float] NULL,
	[created_date] [datetime] NULL,
	[updated_date] [datetime] NULL,
	[quiz_id] [uniqueidentifier] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuestionAnswer]    Script Date: 1/23/2024 3:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuestionAnswer](
	[id] [uniqueidentifier] NOT NULL,
	[question_id] [uniqueidentifier] NULL,
	[answer_text] [varchar](100) NULL,
	[position] [int] NULL,
	[is_answer] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Quiz]    Script Date: 1/23/2024 3:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quiz](
	[id] [uniqueidentifier] NOT NULL,
	[module_id] [uniqueidentifier] NULL,
	[class_practice_id] [uniqueidentifier] NULL,
	[name] [varchar](255) NULL,
	[grade_to_pass] [float] NULL,
	[deadline] [time](7) NULL,
	[created_date] [datetime] NULL,
	[updated_date] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuizAttempt]    Script Date: 1/23/2024 3:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuizAttempt](
	[id] [uniqueidentifier] NOT NULL,
	[quiz_id] [uniqueidentifier] NULL,
	[learner_id] [uniqueidentifier] NULL,
	[attempted_date] [datetime] NULL,
	[open_time] [time](7) NULL,
	[close_time] [time](7) NULL,
	[total_grade] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RefundRequest]    Script Date: 1/23/2024 3:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RefundRequest](
	[id] [uniqueidentifier] NOT NULL,
	[transaction_id] [uniqueidentifier] NULL,
	[requested_date] [datetime] NULL,
	[approved_date] [datetime] NULL,
	[status] [varchar](50) NULL,
	[reason] [varchar](1000) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 1/23/2024 3:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[id] [uniqueidentifier] NOT NULL,
	[name] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Staff]    Script Date: 1/23/2024 3:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staff](
	[id] [uniqueidentifier] NOT NULL,
	[account_id] [uniqueidentifier] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Survey]    Script Date: 1/23/2024 3:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Survey](
	[id] [uniqueidentifier] NOT NULL,
	[survey_question] [varchar](255) NULL,
	[survey_answer] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transaction]    Script Date: 1/23/2024 3:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transaction](
	[id] [uniqueidentifier] NOT NULL,
	[payment_method_id] [uniqueidentifier] NULL,
	[amount] [decimal](18, 0) NULL,
	[status] [varchar](50) NULL,
	[transaction_date] [datetime] NULL,
	[learner_id] [uniqueidentifier] NULL,
	[course_id] [uniqueidentifier] NULL,
	[refund_status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tutor]    Script Date: 1/23/2024 3:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tutor](
	[id] [uniqueidentifier] NOT NULL,
	[account_id] [uniqueidentifier] NULL,
	[is_freelancer] [bit] NULL,
	[center_id] [uniqueidentifier] NULL,
	[staff_id] [uniqueidentifier] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Wallet]    Script Date: 1/23/2024 3:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wallet](
	[id] [uniqueidentifier] NOT NULL,
	[balance] [decimal](18, 0) NULL,
	[transaction_date] [datetime] NULL,
	[account_id] [uniqueidentifier] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD FOREIGN KEY([role_id])
REFERENCES [dbo].[Role] ([id])
GO
ALTER TABLE [dbo].[AccountForum]  WITH CHECK ADD FOREIGN KEY([forum_id])
REFERENCES [dbo].[Forum] ([id])
GO
ALTER TABLE [dbo].[AccountForum]  WITH CHECK ADD FOREIGN KEY([learner_id])
REFERENCES [dbo].[Learner] ([id])
GO
ALTER TABLE [dbo].[AccountForum]  WITH CHECK ADD FOREIGN KEY([tutor_id])
REFERENCES [dbo].[Tutor] ([id])
GO
ALTER TABLE [dbo].[AccountSurvey]  WITH CHECK ADD FOREIGN KEY([learner_id])
REFERENCES [dbo].[Learner] ([id])
GO
ALTER TABLE [dbo].[AccountSurvey]  WITH CHECK ADD FOREIGN KEY([survey_id])
REFERENCES [dbo].[Survey] ([id])
GO
ALTER TABLE [dbo].[Assignment]  WITH CHECK ADD FOREIGN KEY([module_id])
REFERENCES [dbo].[Module] ([id])
GO
ALTER TABLE [dbo].[AssignmentAttempt]  WITH CHECK ADD FOREIGN KEY([assignment_id])
REFERENCES [dbo].[Assignment] ([id])
GO
ALTER TABLE [dbo].[AssignmentAttempt]  WITH CHECK ADD FOREIGN KEY([learner_id])
REFERENCES [dbo].[Learner] ([id])
GO
ALTER TABLE [dbo].[Center]  WITH CHECK ADD FOREIGN KEY([account_id])
REFERENCES [dbo].[Account] ([id])
GO
ALTER TABLE [dbo].[Center]  WITH CHECK ADD FOREIGN KEY([staff_id])
REFERENCES [dbo].[Staff] ([id])
GO
ALTER TABLE [dbo].[CertificateCourse]  WITH CHECK ADD FOREIGN KEY([certificate_id])
REFERENCES [dbo].[Certificate] ([id])
GO
ALTER TABLE [dbo].[CertificateCourse]  WITH CHECK ADD FOREIGN KEY([course_id])
REFERENCES [dbo].[Course] ([id])
GO
ALTER TABLE [dbo].[ClassLesson]  WITH CHECK ADD FOREIGN KEY([class_module_id])
REFERENCES [dbo].[ClassModule] ([id])
GO
ALTER TABLE [dbo].[ClassMaterial]  WITH CHECK ADD FOREIGN KEY([class_topic_id])
REFERENCES [dbo].[ClassTopic] ([id])
GO
ALTER TABLE [dbo].[ClassModule]  WITH CHECK ADD FOREIGN KEY([class_type_id])
REFERENCES [dbo].[ClassType] ([id])
GO
ALTER TABLE [dbo].[ClassPractice]  WITH CHECK ADD FOREIGN KEY([class_topic_id])
REFERENCES [dbo].[ClassTopic] ([id])
GO
ALTER TABLE [dbo].[ClassTopic]  WITH CHECK ADD FOREIGN KEY([class_lesson_id])
REFERENCES [dbo].[ClassLesson] ([id])
GO
ALTER TABLE [dbo].[ClassType]  WITH CHECK ADD FOREIGN KEY([course_id])
REFERENCES [dbo].[Course] ([id])
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD FOREIGN KEY([category_id])
REFERENCES [dbo].[Category] ([id])
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD FOREIGN KEY([tutor_id])
REFERENCES [dbo].[Tutor] ([id])
GO
ALTER TABLE [dbo].[CourseType]  WITH CHECK ADD FOREIGN KEY([category_id])
REFERENCES [dbo].[Category] ([id])
GO
ALTER TABLE [dbo].[Enrollment]  WITH CHECK ADD FOREIGN KEY([course_id])
REFERENCES [dbo].[Course] ([id])
GO
ALTER TABLE [dbo].[Enrollment]  WITH CHECK ADD FOREIGN KEY([learner_id])
REFERENCES [dbo].[Learner] ([id])
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD FOREIGN KEY([course_id])
REFERENCES [dbo].[Course] ([id])
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD FOREIGN KEY([learner_id])
REFERENCES [dbo].[Account] ([id])
GO
ALTER TABLE [dbo].[Forum]  WITH CHECK ADD FOREIGN KEY([course_id])
REFERENCES [dbo].[Course] ([id])
GO
ALTER TABLE [dbo].[Learner]  WITH CHECK ADD FOREIGN KEY([account_id])
REFERENCES [dbo].[Account] ([id])
GO
ALTER TABLE [dbo].[Lesson]  WITH CHECK ADD FOREIGN KEY([module_id])
REFERENCES [dbo].[Module] ([id])
GO
ALTER TABLE [dbo].[LessonMaterial]  WITH CHECK ADD FOREIGN KEY([lesson_id])
REFERENCES [dbo].[Lesson] ([id])
GO
ALTER TABLE [dbo].[Module]  WITH CHECK ADD FOREIGN KEY([course_id])
REFERENCES [dbo].[Course] ([id])
GO
ALTER TABLE [dbo].[PaperWork]  WITH CHECK ADD FOREIGN KEY([paper_work_type_id])
REFERENCES [dbo].[PaperWorkType] ([id])
GO
ALTER TABLE [dbo].[PaperWork]  WITH CHECK ADD FOREIGN KEY([tutor_id])
REFERENCES [dbo].[Tutor] ([id])
GO
ALTER TABLE [dbo].[ProfileCertificate]  WITH CHECK ADD FOREIGN KEY([certificate_id])
REFERENCES [dbo].[Certificate] ([id])
GO
ALTER TABLE [dbo].[ProfileCertificate]  WITH CHECK ADD FOREIGN KEY([learner_id])
REFERENCES [dbo].[Learner] ([id])
GO
ALTER TABLE [dbo].[Question]  WITH CHECK ADD FOREIGN KEY([quiz_id])
REFERENCES [dbo].[Quiz] ([id])
GO
ALTER TABLE [dbo].[QuestionAnswer]  WITH CHECK ADD FOREIGN KEY([question_id])
REFERENCES [dbo].[Question] ([id])
GO
ALTER TABLE [dbo].[Quiz]  WITH CHECK ADD FOREIGN KEY([class_practice_id])
REFERENCES [dbo].[ClassPractice] ([id])
GO
ALTER TABLE [dbo].[Quiz]  WITH CHECK ADD FOREIGN KEY([module_id])
REFERENCES [dbo].[Module] ([id])
GO
ALTER TABLE [dbo].[QuizAttempt]  WITH CHECK ADD FOREIGN KEY([learner_id])
REFERENCES [dbo].[Learner] ([id])
GO
ALTER TABLE [dbo].[QuizAttempt]  WITH CHECK ADD FOREIGN KEY([quiz_id])
REFERENCES [dbo].[Quiz] ([id])
GO
ALTER TABLE [dbo].[RefundRequest]  WITH CHECK ADD FOREIGN KEY([transaction_id])
REFERENCES [dbo].[Transaction] ([id])
GO
ALTER TABLE [dbo].[Staff]  WITH CHECK ADD FOREIGN KEY([account_id])
REFERENCES [dbo].[Account] ([id])
GO
ALTER TABLE [dbo].[Transaction]  WITH CHECK ADD FOREIGN KEY([course_id])
REFERENCES [dbo].[Course] ([id])
GO
ALTER TABLE [dbo].[Transaction]  WITH CHECK ADD FOREIGN KEY([learner_id])
REFERENCES [dbo].[Learner] ([id])
GO
ALTER TABLE [dbo].[Transaction]  WITH CHECK ADD FOREIGN KEY([payment_method_id])
REFERENCES [dbo].[PaymentMethod] ([id])
GO
ALTER TABLE [dbo].[Tutor]  WITH CHECK ADD FOREIGN KEY([account_id])
REFERENCES [dbo].[Account] ([id])
GO
ALTER TABLE [dbo].[Tutor]  WITH CHECK ADD FOREIGN KEY([center_id])
REFERENCES [dbo].[Center] ([id])
GO
ALTER TABLE [dbo].[Tutor]  WITH CHECK ADD FOREIGN KEY([staff_id])
REFERENCES [dbo].[Staff] ([id])
GO
ALTER TABLE [dbo].[Wallet]  WITH CHECK ADD FOREIGN KEY([account_id])
REFERENCES [dbo].[Account] ([id])
GO
