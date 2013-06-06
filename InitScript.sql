IF NOT EXISTS (SELECT 1 FROM [dbo].[ArticleCategories] WHERE [ArticleCategoryID] = '11111111-1111-1111-1111-111111111101')
BEGIN
INSERT INTO [dbo].[ArticleCategories]
           ([ArticleCategoryID]
           ,[ArticleCategoryName]
           ,[Description]
           ,[ImageUrl]
           ,[IsDeleted]
           ,[ForumID])
     VALUES
           ('11111111-1111-1111-1111-111111111101'
           ,N'Tin tức & Sự kiện'
           ,''
           ,''
           ,0
           ,'11111111-1111-1111-1111-111111111100')

END
IF NOT EXISTS (SELECT 1 FROM [dbo].[ArticleCategories] WHERE [ArticleCategoryID] = '11111111-1111-1111-1111-111111111102')
BEGIN
INSERT INTO [dbo].[ArticleCategories]
           ([ArticleCategoryID]
           ,[ArticleCategoryName]
           ,[Description]
           ,[ImageUrl]
           ,[IsDeleted]
           ,[ForumID])
     VALUES
           ('11111111-1111-1111-1111-111111111102'
           ,N'Hỏi - Đáp'
           ,''
           ,''
           ,0
           ,'11111111-1111-1111-1111-111111111102')

END
IF NOT EXISTS (SELECT 1 FROM [dbo].[ArticleCategories] WHERE [ArticleCategoryID] = '11111111-1111-1111-1111-111111111103')
BEGIN
INSERT INTO [dbo].[ArticleCategories]
           ([ArticleCategoryID]
           ,[ArticleCategoryName]
           ,[Description]
           ,[ImageUrl]
           ,[IsDeleted]
           ,[ForumID])
     VALUES
           ('11111111-1111-1111-1111-111111111103'
           ,N'Tư vấn y khoa'
           ,''
           ,''
           ,0
           ,'11111111-1111-1111-1111-111111111101')

END
IF NOT EXISTS (SELECT 1 FROM [dbo].[ArticleCategories] WHERE [ArticleCategoryID] = '11111111-1111-1111-1111-111111111104')
BEGIN
INSERT INTO [dbo].[ArticleCategories]
           ([ArticleCategoryID]
           ,[ArticleCategoryName]
           ,[Description]
           ,[ImageUrl]
           ,[IsDeleted]
           ,[ForumID])
     VALUES
           ('11111111-1111-1111-1111-111111111104'
           ,N'Dịch vụ'
           ,''
           ,'khamvadieutri1.jpg'
           ,0
           ,'11111111-1111-1111-1111-111111111100')

END
IF NOT EXISTS (SELECT 1 FROM [dbo].[ArticleCategories] WHERE [ArticleCategoryID] = '11111111-1111-1111-1111-111111111105')
BEGIN
INSERT INTO [dbo].[ArticleCategories]
           ([ArticleCategoryID]
           ,[ArticleCategoryName]
           ,[Description]
           ,[ImageUrl]
           ,[IsDeleted]
           ,[ForumID])
     VALUES
           ('11111111-1111-1111-1111-111111111105'
           ,N'Khám và điều trị'
           ,N'Với mục tiêu đem đến sự yên tâm, hài lòng cho khách hàng và cộng đồng, cùng với đội ngũ Y bác sĩ giàu chuyên môn cao và giàu kinh nghiệm, bệnh viện chúng tôi luôn mong muốn và sẵn sàng mang lại những giải pháp, phương thức điều trị toàn diện và hiệu quả trong quá trình chăm sóc sức khỏe cho khách hàng'
           ,'khamvadieutri-2.png'
           ,0
           ,'11111111-1111-1111-1111-111111111100')

END
IF NOT EXISTS (SELECT 1 FROM [dbo].[ArticleCategories] WHERE [ArticleCategoryID] = '11111111-1111-1111-1111-111111111106')
BEGIN
INSERT INTO [dbo].[ArticleCategories]
           ([ArticleCategoryID]
           ,[ArticleCategoryName]
           ,[Description]
           ,[ImageUrl]
           ,[IsDeleted]
           ,[ForumID])
     VALUES
           ('11111111-1111-1111-1111-111111111106'
           ,N'Siêu âm xét nghiệm'
           ,''
           ,'khamvadieutri-2.png'
           ,0
           ,'11111111-1111-1111-1111-111111111100')

END
IF NOT EXISTS (SELECT 1 FROM [dbo].[ArticleCategories] WHERE [ArticleCategoryID] = '11111111-1111-1111-1111-111111111107')
BEGIN
INSERT INTO [dbo].[ArticleCategories]
           ([ArticleCategoryID]
           ,[ArticleCategoryName]
           ,[Description]
           ,[ImageUrl]
           ,[IsDeleted]
           ,[ForumID])
     VALUES
           ('11111111-1111-1111-1111-111111111107'
           ,N'Dịch vụ sinh'
           ,''
           ,'khamvadieutri-2.png'
           ,0
           ,'11111111-1111-1111-1111-111111111100')

END
IF NOT EXISTS (SELECT 1 FROM [dbo].[ArticleCategories] WHERE [ArticleCategoryID] = '11111111-1111-1111-1111-111111111108')
BEGIN
INSERT INTO [dbo].[ArticleCategories]
           ([ArticleCategoryID]
           ,[ArticleCategoryName]
           ,[Description]
           ,[ImageUrl]
           ,[IsDeleted]
           ,[ForumID])
     VALUES
           ('11111111-1111-1111-1111-111111111108'
           ,N'Dịch vụ khác'
           ,''
           ,'khamvadieutri-2.png'
           ,0
           ,'11111111-1111-1111-1111-111111111100')

END
IF NOT EXISTS (SELECT 1 FROM [dbo].[ArticleCategories] WHERE [ArticleCategoryID] = '11111111-1111-1111-1111-111111111109')
BEGIN
INSERT INTO [dbo].[ArticleCategories]
           ([ArticleCategoryID]
           ,[ArticleCategoryName]
           ,[Description]
           ,[ImageUrl]
           ,[IsDeleted]
           ,[ForumID])
     VALUES
           ('11111111-1111-1111-1111-111111111109'
           ,N'Đội ngũ chuyên môn'
           ,''
           ,'doingu-bacsi1.png'
           ,0
           ,'11111111-1111-1111-1111-111111111100')

END
IF NOT EXISTS (SELECT 1 FROM [dbo].[ArticleCategories] WHERE [ArticleCategoryID] = '11111111-1111-1111-1111-111111111110')
BEGIN
INSERT INTO [dbo].[ArticleCategories]
           ([ArticleCategoryID]
           ,[ArticleCategoryName]
           ,[Description]
           ,[ImageUrl]
           ,[IsDeleted]
           ,[ForumID])
     VALUES
           ('11111111-1111-1111-1111-111111111110'
           ,N'Bản tin y khoa'
           ,''
           ,'960x142-veauco.png'
           ,0
           ,'11111111-1111-1111-1111-111111111100')

END
IF NOT EXISTS (SELECT 1 FROM [dbo].[ArticleCategories] WHERE [ArticleCategoryID] = '11111111-1111-1111-1111-111111111111')
BEGIN
INSERT INTO [dbo].[ArticleCategories]
           ([ArticleCategoryID]
           ,[ArticleCategoryName]
           ,[Description]
           ,[ImageUrl]
           ,[IsDeleted]
           ,[ForumID])
     VALUES
           ('11111111-1111-1111-1111-111111111111'
           ,N'Tin tức bệnh viện'
           ,''
           ,'960x142-veauco.png'
           ,0
           ,'11111111-1111-1111-1111-111111111100')

END
IF NOT EXISTS (SELECT 1 FROM [dbo].[Menus] WHERE [MenuID] = '11111111-1111-1111-1111-111111111101')
BEGIN
INSERT INTO [dbo].[Menus]
           ([MenuID]
           ,[MenuName]
           ,[Url]
           ,[IsDeleted]
           ,[ParentID]
           ,[OrderID])
     VALUES
           ('11111111-1111-1111-1111-111111111101'
           ,N'Trang chủ'
           ,'#'
           ,0
           ,'00000000-0000-0000-0000-000000000000'
           ,0)
END
IF NOT EXISTS (SELECT 1 FROM [dbo].[Menus] WHERE [MenuID] = '11111111-1111-1111-1111-111111111102')
BEGIN
INSERT INTO [dbo].[Menus]
           ([MenuID]
           ,[MenuName]
           ,[Url]
           ,[IsDeleted]
           ,[ParentID]
           ,[OrderID])
     VALUES
           ('11111111-1111-1111-1111-111111111102'
           ,N'Dịch vụ'
           ,'/home/categorypage?articlecategoryid=11111111-1111-1111-1111-111111111104'
           ,0
           ,'00000000-0000-0000-0000-000000000000'
           ,1)
END
IF NOT EXISTS (SELECT 1 FROM [dbo].[Menus] WHERE [MenuID] = '11111111-1111-1111-1111-111111111103')
BEGIN
INSERT INTO [dbo].[Menus]
           ([MenuID]
           ,[MenuName]
           ,[Url]
           ,[IsDeleted]
           ,[ParentID]
           ,[OrderID])
     VALUES
           ('11111111-1111-1111-1111-111111111103'
           ,N'Đội ngũ chuyên môn'
           ,'/home/categorypage?articlecategoryid=11111111-1111-1111-1111-111111111109'
           ,0
           ,'00000000-0000-0000-0000-000000000000'
           ,2)
END
IF NOT EXISTS (SELECT 1 FROM [dbo].[Menus] WHERE [MenuID] = '11111111-1111-1111-1111-111111111104')
BEGIN
INSERT INTO [dbo].[Menus]
           ([MenuID]
           ,[MenuName]
           ,[Url]
           ,[IsDeleted]
           ,[ParentID]
           ,[OrderID])
     VALUES
           ('11111111-1111-1111-1111-111111111104'
           ,N'Về Âu Cơ'
           ,'/home/detailpage?articleid=11111111-1111-1111-1111-111111111109'
           ,0
           ,'00000000-0000-0000-0000-000000000000'
           ,3)
END
IF NOT EXISTS (SELECT 1 FROM [dbo].[Menus] WHERE [MenuID] = '11111111-1111-1111-1111-111111111105')
BEGIN
INSERT INTO [dbo].[Menus]
           ([MenuID]
           ,[MenuName]
           ,[Url]
           ,[IsDeleted]
           ,[ParentID]
           ,[OrderID])
     VALUES
           ('11111111-1111-1111-1111-111111111105'
           ,N'Quan hệ cộng đồng'
           ,'/home/detailpage?articleid=11111111-1111-1111-1111-111111111110'
           ,0
           ,'00000000-0000-0000-0000-000000000000'
           ,4)
END
IF NOT EXISTS (SELECT 1 FROM [dbo].[Menus] WHERE [MenuID] = '11111111-1111-1111-1111-111111111106')
BEGIN
INSERT INTO [dbo].[Menus]
           ([MenuID]
           ,[MenuName]
           ,[Url]
           ,[IsDeleted]
           ,[ParentID]
           ,[OrderID])
     VALUES
           ('11111111-1111-1111-1111-111111111106'
           ,N'Đặt lịch hẹn'
           ,'/home/booking'
           ,0
           ,'00000000-0000-0000-0000-000000000000'
           ,5)
END
IF NOT EXISTS (SELECT 1 FROM [dbo].[Menus] WHERE [MenuID] = '11111111-1111-1111-1111-111111111107')
BEGIN
INSERT INTO [dbo].[Menus]
           ([MenuID]
           ,[MenuName]
           ,[Url]
           ,[IsDeleted]
           ,[ParentID]
           ,[OrderID])
     VALUES
           ('11111111-1111-1111-1111-111111111107'
           ,N'Liên hệ'
           ,'/home/contact'
           ,0
           ,'00000000-0000-0000-0000-000000000000'
           ,6)
END
IF NOT EXISTS (SELECT 1 FROM [dbo].[Menus] WHERE [MenuID] = '11111111-1111-1111-1111-111111111108')
BEGIN
INSERT INTO [dbo].[Menus]
           ([MenuID]
           ,[MenuName]
           ,[Url]
           ,[IsDeleted]
           ,[ParentID]
           ,[OrderID])
     VALUES
           ('11111111-1111-1111-1111-111111111108'
           ,N'Khám và điều trị'
           ,'/home/detailpage?articleid=11111111-1111-1111-1111-111111111101'
           ,0
           ,'11111111-1111-1111-1111-111111111102'
           ,0)
END
IF NOT EXISTS (SELECT 1 FROM [dbo].[Menus] WHERE [MenuID] = '11111111-1111-1111-1111-111111111109')
BEGIN
INSERT INTO [dbo].[Menus]
           ([MenuID]
           ,[MenuName]
           ,[Url]
           ,[IsDeleted]
           ,[ParentID]
           ,[OrderID])
     VALUES
           ('11111111-1111-1111-1111-111111111109'
           ,N'Siêu âm xét nghiệm'
           ,'/home/detailpage?articleid=11111111-1111-1111-1111-111111111102'
           ,0
           ,'11111111-1111-1111-1111-111111111102'
           ,1)
END
IF NOT EXISTS (SELECT 1 FROM [dbo].[Menus] WHERE [MenuID] = '11111111-1111-1111-1111-111111111110')
BEGIN
INSERT INTO [dbo].[Menus]
           ([MenuID]
           ,[MenuName]
           ,[Url]
           ,[IsDeleted]
           ,[ParentID]
           ,[OrderID])
     VALUES
           ('11111111-1111-1111-1111-111111111110'
           ,N'Dịch vụ sinh'
           ,'/home/detailpage?articleid=11111111-1111-1111-1111-111111111103'
           ,0
           ,'11111111-1111-1111-1111-111111111102'
           ,2)
END
IF NOT EXISTS (SELECT 1 FROM [dbo].[Menus] WHERE [MenuID] = '11111111-1111-1111-1111-111111111111')
BEGIN
INSERT INTO [dbo].[Menus]
           ([MenuID]
           ,[MenuName]
           ,[Url]
           ,[IsDeleted]
           ,[ParentID]
           ,[OrderID])
     VALUES
           ('11111111-1111-1111-1111-111111111111'
           ,N'Dịch vụ khác'
           ,'/home/detailpage?articleid=11111111-1111-1111-1111-111111111104'
           ,0
           ,'11111111-1111-1111-1111-111111111102'
           ,3)
END
IF NOT EXISTS (SELECT 1 FROM [dbo].[Menus] WHERE [MenuID] = '11111111-1111-1111-1111-111111111112')
BEGIN
INSERT INTO [dbo].[Menus]
           ([MenuID]
           ,[MenuName]
           ,[Url]
           ,[IsDeleted]
           ,[ParentID]
           ,[OrderID])
     VALUES
           ('11111111-1111-1111-1111-111111111112'
           ,N'Sứ mệnh'
           ,'/home/detailpage?articleid=11111111-1111-1111-1111-111111111105'
           ,0
           ,'11111111-1111-1111-1111-111111111104'
           ,0)
END
IF NOT EXISTS (SELECT 1 FROM [dbo].[Menus] WHERE [MenuID] = '11111111-1111-1111-1111-111111111113')
BEGIN
INSERT INTO [dbo].[Menus]
           ([MenuID]
           ,[MenuName]
           ,[Url]
           ,[IsDeleted]
           ,[ParentID]
           ,[OrderID])
     VALUES
           ('11111111-1111-1111-1111-111111111113'
           ,N'Cơ sở vật chất'
           ,'/home/detailpage?articleid=11111111-1111-1111-1111-111111111106'
           ,0
           ,'11111111-1111-1111-1111-111111111104'
           ,1)
END
IF NOT EXISTS (SELECT 1 FROM [dbo].[Menus] WHERE [MenuID] = '11111111-1111-1111-1111-111111111114')
BEGIN
INSERT INTO [dbo].[Menus]
           ([MenuID]
           ,[MenuName]
           ,[Url]
           ,[IsDeleted]
           ,[ParentID]
           ,[OrderID])
     VALUES
           ('11111111-1111-1111-1111-111111111114'
           ,N'Thiên thần Âu Cơ'
           ,'/home/detailpage?articleid=11111111-1111-1111-1111-111111111107'
           ,0
           ,'11111111-1111-1111-1111-111111111104'
           ,2)
END
IF NOT EXISTS (SELECT 1 FROM [dbo].[Menus] WHERE [MenuID] = '11111111-1111-1111-1111-111111111115')
BEGIN
INSERT INTO [dbo].[Menus]
           ([MenuID]
           ,[MenuName]
           ,[Url]
           ,[IsDeleted]
           ,[ParentID]
           ,[OrderID])
     VALUES
           ('11111111-1111-1111-1111-111111111115'
           ,N'Tuyển dụng'
           ,'/home/detailpage?articleid=11111111-1111-1111-1111-111111111108'
           ,0
           ,'11111111-1111-1111-1111-111111111104'
           ,3)
END
IF NOT EXISTS (SELECT 1 FROM [dbo].[Menus] WHERE [MenuID] = '11111111-1111-1111-1111-111111111116')
BEGIN
INSERT INTO [dbo].[Menus]
           ([MenuID]
           ,[MenuName]
           ,[Url]
           ,[IsDeleted]
           ,[ParentID]
           ,[OrderID])
     VALUES
           ('11111111-1111-1111-1111-111111111116'
           ,N'Bản tin y khoa'
           ,'/home/categorypage?articlecategoryid=11111111-1111-1111-1111-111111111110'
           ,0
           ,'11111111-1111-1111-1111-111111111105'
           ,0)
END
IF NOT EXISTS (SELECT 1 FROM [dbo].[Menus] WHERE [MenuID] = '11111111-1111-1111-1111-111111111117')
BEGIN
INSERT INTO [dbo].[Menus]
           ([MenuID]
           ,[MenuName]
           ,[Url]
           ,[IsDeleted]
           ,[ParentID]
           ,[OrderID])
     VALUES
           ('11111111-1111-1111-1111-111111111117'
           ,N'Tin tức bệnh viện'
           ,'/home/categorypage?articlecategoryid=11111111-1111-1111-1111-111111111111'
           ,0
           ,'11111111-1111-1111-1111-111111111105'
           ,1)
END
IF NOT EXISTS (SELECT 1 FROM [dbo].[Menus] WHERE [MenuID] = '11111111-1111-1111-1111-111111111118')
BEGIN
INSERT INTO [dbo].[Menus]
           ([MenuID]
           ,[MenuName]
           ,[Url]
           ,[IsDeleted]
           ,[ParentID]
           ,[OrderID])
     VALUES
           ('11111111-1111-1111-1111-111111111118'
           ,N'Hỏi - Đáp'
           ,'/home/categorypage?articlecategoryid=11111111-1111-1111-1111-111111111102'
           ,0
           ,'11111111-1111-1111-1111-111111111105'
           ,2)
END
IF NOT EXISTS (SELECT 1 FROM [dbo].[Menus] WHERE [MenuID] = '11111111-1111-1111-1111-111111111119')
BEGIN
INSERT INTO [dbo].[Menus]
           ([MenuID]
           ,[MenuName]
           ,[Url]
           ,[IsDeleted]
           ,[ParentID]
           ,[OrderID])
     VALUES
           ('11111111-1111-1111-1111-111111111119'
           ,N'Tư vấn y khoa'
           ,'/home/categorypage?articlecategoryid=11111111-1111-1111-1111-111111111103'
           ,0
           ,'11111111-1111-1111-1111-111111111105'
           ,3)
END