using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Domain.DBModels
{
    public partial class DiriWebPortalContext : DbContext
    {
        public DiriWebPortalContext()
        {
        }

        public DiriWebPortalContext(DbContextOptions<DiriWebPortalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AboutU> AboutUs { get; set; } = null!;
        public virtual DbSet<AboutUsDetail> AboutUsDetails { get; set; } = null!;
        public virtual DbSet<AcademicCourse> AcademicCourses { get; set; } = null!;
        public virtual DbSet<AlbumMaster> AlbumMasters { get; set; } = null!;
        public virtual DbSet<AlbumPhoto> AlbumPhotos { get; set; } = null!;
        public virtual DbSet<ArchivesAndDocumentation> ArchivesAndDocumentations { get; set; } = null!;
        public virtual DbSet<Article> Articles { get; set; } = null!;
        public virtual DbSet<ArticleAttachment> ArticleAttachments { get; set; } = null!;
        public virtual DbSet<ArticleAuthor> ArticleAuthors { get; set; } = null!;
        public virtual DbSet<ArticleDetail> ArticleDetails { get; set; } = null!;
        public virtual DbSet<ArticleTypeMaster> ArticleTypeMasters { get; set; } = null!;
        public virtual DbSet<ArticleWritter> ArticleWritters { get; set; } = null!;
        public virtual DbSet<ArticleWritterMaster> ArticleWritterMasters { get; set; } = null!;
        public virtual DbSet<BannerText> BannerTexts { get; set; } = null!;
        public virtual DbSet<BookAttachment> BookAttachments { get; set; } = null!;
        public virtual DbSet<BookMaster> BookMasters { get; set; } = null!;
        public virtual DbSet<Citation> Citations { get; set; } = null!;
        public virtual DbSet<ConfCommitteeDesignation> ConfCommitteeDesignations { get; set; } = null!;
        public virtual DbSet<ConfCommitteeMaster> ConfCommitteeMasters { get; set; } = null!;
        public virtual DbSet<ConfCommitteeMember> ConfCommitteeMembers { get; set; } = null!;
        public virtual DbSet<ConferenceDayDetail> ConferenceDayDetails { get; set; } = null!;
        public virtual DbSet<ConferenceInstruction> ConferenceInstructions { get; set; } = null!;
        public virtual DbSet<ConferenceInstructionDetail> ConferenceInstructionDetails { get; set; } = null!;
        public virtual DbSet<ConferenceMaster> ConferenceMasters { get; set; } = null!;
        public virtual DbSet<ConferenceParticipant> ConferenceParticipants { get; set; } = null!;
        public virtual DbSet<ConferenceParticipantsMap> ConferenceParticipantsMaps { get; set; } = null!;
        public virtual DbSet<ConferenceSessionDetail> ConferenceSessionDetails { get; set; } = null!;
        public virtual DbSet<ContactU> ContactUs { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<DocumentTypeMaster> DocumentTypeMasters { get; set; } = null!;
        public virtual DbSet<ExecutiveCommitteeDesignation> ExecutiveCommitteeDesignations { get; set; } = null!;
        public virtual DbSet<ExecutiveCommitteeMember> ExecutiveCommitteeMembers { get; set; } = null!;
        public virtual DbSet<FounderInfo> FounderInfos { get; set; } = null!;
        public virtual DbSet<HighlightedEvent> HighlightedEvents { get; set; } = null!;
        public virtual DbSet<ImportantDate> ImportantDates { get; set; } = null!;
        public virtual DbSet<Institute> Institutes { get; set; } = null!;
        public virtual DbSet<InstitutionDepartment> InstitutionDepartments { get; set; } = null!;
        public virtual DbSet<InstitutionMaster> InstitutionMasters { get; set; } = null!;
        public virtual DbSet<InstructionMaster> InstructionMasters { get; set; } = null!;
        public virtual DbSet<Journal> Journals { get; set; } = null!;
        public virtual DbSet<Language> Languages { get; set; } = null!;
        public virtual DbSet<LanguageMaster> LanguageMasters { get; set; } = null!;
        public virtual DbSet<MainThemeMaster> MainThemeMasters { get; set; } = null!;
        public virtual DbSet<ManagingTrusteeArticle> ManagingTrusteeArticles { get; set; } = null!;
        public virtual DbSet<ManagingTrusteeDesignation> ManagingTrusteeDesignations { get; set; } = null!;
        public virtual DbSet<ManagingTrusteeInfo> ManagingTrusteeInfos { get; set; } = null!;
        public virtual DbSet<ManagingTrusteePublication> ManagingTrusteePublications { get; set; } = null!;
        public virtual DbSet<MenuLink> MenuLinks { get; set; } = null!;
        public virtual DbSet<NumericDashboard> NumericDashboards { get; set; } = null!;
        public virtual DbSet<OccupationalDesignation> OccupationalDesignations { get; set; } = null!;
        public virtual DbSet<OrganizingMemberMaster> OrganizingMemberMasters { get; set; } = null!;
        public virtual DbSet<ParticipantsMaster> ParticipantsMasters { get; set; } = null!;
        public virtual DbSet<PlatformMaster> PlatformMasters { get; set; } = null!;
        public virtual DbSet<PublicationTypeMaster> PublicationTypeMasters { get; set; } = null!;
        public virtual DbSet<Reference> References { get; set; } = null!;
        public virtual DbSet<ResearchCategory> ResearchCategories { get; set; } = null!;
        public virtual DbSet<ResearchResource> ResearchResources { get; set; } = null!;
        public virtual DbSet<ResearchSubCategory> ResearchSubCategories { get; set; } = null!;
        public virtual DbSet<ResearchSubject> ResearchSubjects { get; set; } = null!;
        public virtual DbSet<Researcher> Researchers { get; set; } = null!;
        public virtual DbSet<RoleMaster> RoleMasters { get; set; } = null!;
        public virtual DbSet<SubTheme> SubThemes { get; set; } = null!;
        public virtual DbSet<UniversityDepartmentMap> UniversityDepartmentMaps { get; set; } = null!;
        public virtual DbSet<UniversityInstitute> UniversityInstitutes { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserRole> UserRoles { get; set; } = null!;
        public virtual DbSet<VideoMessage> VideoMessages { get; set; } = null!;
        public virtual DbSet<VideoPresenterCategoryMaster> VideoPresenterCategoryMasters { get; set; } = null!;
        public virtual DbSet<Volume> Volumes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=DiriWebPortal;Trusted_Connection=True;User Id=sa;Password=123;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AboutU>(entity =>
            {
                entity.ToTable("AboutUs", "HomePage");

                entity.Property(e => e.AboutUsTitle).HasMaxLength(50);
            });

            modelBuilder.Entity<AboutUsDetail>(entity =>
            {
                entity.ToTable("AboutUsDetails", "AboutUs");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.YearsOfJourney).HasMaxLength(200);
            });

            modelBuilder.Entity<AcademicCourse>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CourseBanner).HasMaxLength(200);

                entity.Property(e => e.CourseDescription).HasMaxLength(200);

                entity.Property(e => e.CourseTittle1).HasMaxLength(50);

                entity.Property(e => e.CourseTittle2).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<AlbumMaster>(entity =>
            {
                entity.ToTable("AlbumMaster", "PhotoGallery");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AlbumName).HasMaxLength(150);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<AlbumPhoto>(entity =>
            {
                entity.ToTable("AlbumPhoto", "PhotoGallery");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ArchivesAndDocumentation>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ArchivesAndDocumentation");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DocumentDescription).HasMaxLength(200);

                entity.Property(e => e.DocumentTittle1).HasMaxLength(50);

                entity.Property(e => e.DocumentTittle2).HasMaxLength(50);

                entity.Property(e => e.DocumentTittle3).HasMaxLength(50);

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Article>(entity =>
            {
                entity.ToTable("Article", "Journal");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Doi)
                    .HasMaxLength(100)
                    .HasColumnName("DOI");

                entity.Property(e => e.Keywords).HasMaxLength(500);

                entity.Property(e => e.Language).HasMaxLength(50);

                entity.Property(e => e.Pages).HasMaxLength(50);

                entity.Property(e => e.Pdfurl)
                    .HasMaxLength(500)
                    .HasColumnName("PDFUrl");

                entity.Property(e => e.PublishedDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('Draft')");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.HasOne(d => d.Volume)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.VolumeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Article_Volume");
            });

            modelBuilder.Entity<ArticleAttachment>(entity =>
            {
                entity.ToTable("ArticleAttachment", "Publication");

                entity.Property(e => e.AttachmentTittle).HasMaxLength(50);
            });

            modelBuilder.Entity<ArticleAuthor>(entity =>
            {
                entity.HasKey(e => new { e.ArticleId, e.ResearcherId });

                entity.ToTable("ArticleAuthors", "Journal");

                entity.Property(e => e.IsCorrespondingAuthor).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Article)
                    .WithMany(p => p.ArticleAuthors)
                    .HasForeignKey(d => d.ArticleId)
                    .HasConstraintName("FK_ArticleAuthors_Article");

                entity.HasOne(d => d.Researcher)
                    .WithMany(p => p.ArticleAuthors)
                    .HasForeignKey(d => d.ResearcherId)
                    .HasConstraintName("FK_ArticleAuthors_Researcher");
            });

            modelBuilder.Entity<ArticleDetail>(entity =>
            {
                entity.ToTable("ArticleDetails", "Publication");

                entity.Property(e => e.ArticleDetails).HasMaxLength(200);

                entity.Property(e => e.ArticleNameEn).HasMaxLength(200);

                entity.Property(e => e.Doi)
                    .HasMaxLength(100)
                    .HasColumnName("DOI");

                entity.Property(e => e.Language).HasMaxLength(50);

                entity.Property(e => e.PublishedDate).HasColumnType("datetime");

                entity.Property(e => e.Publisher).HasMaxLength(150);

                entity.Property(e => e.Remarks).HasMaxLength(200);
            });

            modelBuilder.Entity<ArticleTypeMaster>(entity =>
            {
                entity.ToTable("ArticleTypeMaster", "Publication");

                entity.Property(e => e.ArticleTypeNameAr).HasMaxLength(100);

                entity.Property(e => e.ArticleTypeNameBn).HasMaxLength(100);

                entity.Property(e => e.ArticleTypeNameEn).HasMaxLength(100);
            });

            modelBuilder.Entity<ArticleWritter>(entity =>
            {
                entity.ToTable("ArticleWritter", "Publication");
            });

            modelBuilder.Entity<ArticleWritterMaster>(entity =>
            {
                entity.ToTable("ArticleWritterMaster", "Publication");

                entity.Property(e => e.WritterNameAr).HasMaxLength(50);

                entity.Property(e => e.WritterNameBn).HasMaxLength(50);

                entity.Property(e => e.WritterNameEn).HasMaxLength(50);
            });

            modelBuilder.Entity<BannerText>(entity =>
            {
                entity.ToTable("BannerText", "HomePage");

                entity.Property(e => e.BannerImageLocation).HasMaxLength(350);

                entity.Property(e => e.Subtitle).HasMaxLength(250);

                entity.Property(e => e.TitleText).HasMaxLength(150);
            });

            modelBuilder.Entity<BookAttachment>(entity =>
            {
                entity.ToTable("BookAttachment", "Publication");

                entity.Property(e => e.AttachmentLocation).HasMaxLength(100);

                entity.Property(e => e.AttachmentTittle).HasMaxLength(50);
            });

            modelBuilder.Entity<BookMaster>(entity =>
            {
                entity.ToTable("BookMaster", "Publication");

                entity.Property(e => e.BookNameBn).HasMaxLength(50);

                entity.Property(e => e.BookNameEng).HasMaxLength(50);

                entity.Property(e => e.FirstPublishedYear).HasMaxLength(50);

                entity.Property(e => e.PublisherName).HasMaxLength(50);

                entity.Property(e => e.ShortDescription).HasMaxLength(100);

                entity.Property(e => e.ThumbnailLocation).HasMaxLength(50);

                entity.Property(e => e.WritterName).HasMaxLength(50);
            });

            modelBuilder.Entity<Citation>(entity =>
            {
                entity.ToTable("Citation", "Journal");

                entity.Property(e => e.CitedDoi)
                    .HasMaxLength(100)
                    .HasColumnName("CitedDOI");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<ConfCommitteeDesignation>(entity =>
            {
                entity.ToTable("ConfCommitteeDesignation", "Conference");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CommitteeDesignation).HasMaxLength(50);
            });

            modelBuilder.Entity<ConfCommitteeMaster>(entity =>
            {
                entity.ToTable("ConfCommitteeMaster", "Conference");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CommitteeName).HasMaxLength(50);
            });

            modelBuilder.Entity<ConfCommitteeMember>(entity =>
            {
                entity.ToTable("ConfCommitteeMembers", "Conference");

                entity.Property(e => e.Id).HasColumnName("id");
            });

            modelBuilder.Entity<ConferenceDayDetail>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ConferenceInstruction>(entity =>
            {
                entity.ToTable("ConferenceInstructions", "Conference");
            });

            modelBuilder.Entity<ConferenceInstructionDetail>(entity =>
            {
                entity.ToTable("ConferenceInstructionDetails", "Conference");

                entity.Property(e => e.InstructionText).HasMaxLength(500);
            });

            modelBuilder.Entity<ConferenceMaster>(entity =>
            {
                entity.ToTable("ConferenceMaster", "Conference");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ConferenceCode).HasMaxLength(50);

                entity.Property(e => e.ConferenceTodate).HasColumnType("datetime");

                entity.Property(e => e.ConfrenceFromDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifedDate).HasColumnType("datetime");

                entity.Property(e => e.OrganizedBy1).HasMaxLength(250);

                entity.Property(e => e.OrganizedBy2).HasMaxLength(250);

                entity.Property(e => e.OrganizedBy3).HasMaxLength(250);

                entity.Property(e => e.Venue).HasMaxLength(250);
            });

            modelBuilder.Entity<ConferenceParticipant>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ParticipantDetails).HasMaxLength(50);

                entity.Property(e => e.ParticipantName).HasMaxLength(50);

                entity.Property(e => e.ParticipantsImagePath).HasMaxLength(250);

                entity.Property(e => e.ResearchTittle).HasMaxLength(100);

                entity.Property(e => e.ResourceLocationPath).HasMaxLength(250);
            });

            modelBuilder.Entity<ConferenceParticipantsMap>(entity =>
            {
                entity.ToTable("ConferenceParticipantsMap", "Conference");

                entity.Property(e => e.Id).HasColumnName("id");
            });

            modelBuilder.Entity<ConferenceSessionDetail>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.SessionName).HasMaxLength(50);

                entity.Property(e => e.SessionTiming).HasMaxLength(50);
            });

            modelBuilder.Entity<ContactU>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ContactUs", "HomePage");

                entity.Property(e => e.Address).HasMaxLength(300);

                entity.Property(e => e.District).HasMaxLength(50);

                entity.Property(e => e.Division).HasMaxLength(50);

                entity.Property(e => e.Email1).HasMaxLength(50);

                entity.Property(e => e.Email2).HasMaxLength(50);

                entity.Property(e => e.FacebookLink).HasMaxLength(100);

                entity.Property(e => e.InstagramLink).HasMaxLength(100);

                entity.Property(e => e.LinkedinLink).HasMaxLength(100);

                entity.Property(e => e.LocationMap).HasMaxLength(250);

                entity.Property(e => e.LogoLocation).HasMaxLength(200);

                entity.Property(e => e.Mobile1).HasMaxLength(50);

                entity.Property(e => e.Mobile2).HasMaxLength(50);

                entity.Property(e => e.OrganizationTittle).HasMaxLength(50);

                entity.Property(e => e.PoliceStation).HasMaxLength(50);

                entity.Property(e => e.PostCode).HasMaxLength(10);

                entity.Property(e => e.PostOffice).HasMaxLength(100);

                entity.Property(e => e.TwitterLink).HasMaxLength(100);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country", "master");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CountryCode).HasMaxLength(50);

                entity.Property(e => e.CountryName).HasMaxLength(50);
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department", "master");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DepartmentName).HasMaxLength(50);
            });

            modelBuilder.Entity<DocumentTypeMaster>(entity =>
            {
                entity.ToTable("DocumentTypeMaster");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DocumentType).HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ExecutiveCommitteeDesignation>(entity =>
            {
                entity.ToTable("ExecutiveCommitteeDesignation", "master");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Designation).HasMaxLength(50);
            });

            modelBuilder.Entity<ExecutiveCommitteeMember>(entity =>
            {
                entity.ToTable("ExecutiveCommitteeMembers", "master");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.MemberName).HasMaxLength(50);
            });

            modelBuilder.Entity<FounderInfo>(entity =>
            {
                entity.ToTable("FounderInfo", "HomePage");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.FounderImagePath).HasMaxLength(200);

                entity.Property(e => e.FounderName).HasMaxLength(50);

                entity.Property(e => e.FounderTittle1).HasMaxLength(100);

                entity.Property(e => e.FounderTittle2).HasMaxLength(100);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<HighlightedEvent>(entity =>
            {
                entity.ToTable("HighlightedEvent", "HomePage");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Heading1).HasMaxLength(200);

                entity.Property(e => e.Heading2).HasMaxLength(200);

                entity.Property(e => e.Heading3).HasMaxLength(200);

                entity.Property(e => e.Heading4).HasMaxLength(200);

                entity.Property(e => e.ImageDescription).HasMaxLength(400);

                entity.Property(e => e.ImagePath).HasMaxLength(200);
            });

            modelBuilder.Entity<ImportantDate>(entity =>
            {
                entity.ToTable("ImportantDates", "Conference");

                entity.Property(e => e.ActionDate).HasColumnType("datetime");

                entity.Property(e => e.ActionDescription).HasMaxLength(100);
            });

            modelBuilder.Entity<Institute>(entity =>
            {
                entity.ToTable("Institute", "Journal");

                entity.Property(e => e.Address).HasMaxLength(300);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email).HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.Website).HasMaxLength(300);
            });

            modelBuilder.Entity<InstitutionDepartment>(entity =>
            {
                entity.ToTable("InstitutionDepartment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DepartmentName).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<InstitutionMaster>(entity =>
            {
                entity.ToTable("InstitutionMaster");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.ContactNo).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.InstitutionName).HasMaxLength(100);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<InstructionMaster>(entity =>
            {
                entity.ToTable("InstructionMaster", "Conference");

                entity.Property(e => e.InstructionTitle).HasMaxLength(150);
            });

            modelBuilder.Entity<Journal>(entity =>
            {
                entity.ToTable("Journal", "Journal");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.Issn).HasColumnName("ISSN");

                entity.Property(e => e.JournalName).HasMaxLength(200);

                entity.HasOne(d => d.Institute)
                    .WithMany(p => p.Journals)
                    .HasForeignKey(d => d.InstituteId)
                    .HasConstraintName("FK_Journal_Institute");
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.ToTable("Languages", "Conference");
            });

            modelBuilder.Entity<LanguageMaster>(entity =>
            {
                entity.ToTable("LanguageMaster", "master");

                entity.Property(e => e.LanguageName).HasMaxLength(50);
            });

            modelBuilder.Entity<MainThemeMaster>(entity =>
            {
                entity.ToTable("MainThemeMaster", "Conference");

                entity.Property(e => e.Theme).HasMaxLength(250);
            });

            modelBuilder.Entity<ManagingTrusteeArticle>(entity =>
            {
                entity.ToTable("ManagingTrusteeArticles", "AboutUs");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.PublishedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ManagingTrusteeDesignation>(entity =>
            {
                entity.ToTable("ManagingTrusteeDesignation", "AboutUs");

                entity.Property(e => e.Id).HasColumnName("id");
            });

            modelBuilder.Entity<ManagingTrusteeInfo>(entity =>
            {
                entity.ToTable("ManagingTrusteeInfo", "HomePage");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ManagingTrusteeImagePath).HasMaxLength(200);

                entity.Property(e => e.ManagingTrusteeName).HasMaxLength(50);

                entity.Property(e => e.ManagingTrusteeNameTittle1).HasMaxLength(100);

                entity.Property(e => e.ManagingTrusteeNameTittle2).HasMaxLength(100);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ManagingTrusteePublication>(entity =>
            {
                entity.ToTable("ManagingTrusteePublications", "AboutUs");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.PublishedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MenuLink>(entity =>
            {
                entity.ToTable("MenuLink", "master");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.MenuName).HasMaxLength(50);

                entity.Property(e => e.PageLink).HasMaxLength(50);
            });

            modelBuilder.Entity<NumericDashboard>(entity =>
            {
                entity.ToTable("NumericDashboard", "HomePage");

                entity.Property(e => e.Id).HasColumnName("id");
            });

            modelBuilder.Entity<OccupationalDesignation>(entity =>
            {
                entity.ToTable("OccupationalDesignation", "master");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.OccupationalDesignationName).HasMaxLength(100);
            });

            modelBuilder.Entity<OrganizingMemberMaster>(entity =>
            {
                entity.ToTable("OrganizingMemberMaster", "Conference");

                entity.Property(e => e.DesignationAr).HasMaxLength(200);

                entity.Property(e => e.DesignationBn).HasMaxLength(200);

                entity.Property(e => e.DesignationEn).HasMaxLength(200);

                entity.Property(e => e.MemberNameAr).HasMaxLength(100);

                entity.Property(e => e.MemberNameBn).HasMaxLength(100);

                entity.Property(e => e.MemberNameEng).HasMaxLength(100);
            });

            modelBuilder.Entity<ParticipantsMaster>(entity =>
            {
                entity.ToTable("ParticipantsMaster", "Conference");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Active).ValueGeneratedOnAdd();

                entity.Property(e => e.ContactNumber).HasMaxLength(50);

                entity.Property(e => e.EducationalQualification).HasMaxLength(150);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Occupation).HasMaxLength(150);

                entity.Property(e => e.ParticipantName).HasMaxLength(100);
            });

            modelBuilder.Entity<PlatformMaster>(entity =>
            {
                entity.ToTable("PlatformMaster", "Conference");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.ConfPlatform).HasMaxLength(50);
            });

            modelBuilder.Entity<PublicationTypeMaster>(entity =>
            {
                entity.ToTable("PublicationTypeMaster", "Publication");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.PublicationTypeDesc).HasMaxLength(50);
            });

            modelBuilder.Entity<Reference>(entity =>
            {
                entity.ToTable("Reference", "Journal");

                entity.Property(e => e.Authors).HasMaxLength(300);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ReferenceDoi)
                    .HasMaxLength(100)
                    .HasColumnName("ReferenceDOI");

                entity.Property(e => e.ReferenceUrl).HasMaxLength(300);

                entity.HasOne(d => d.Article)
                    .WithMany(p => p.References)
                    .HasForeignKey(d => d.ArticleId)
                    .HasConstraintName("FK_Reference_Article");
            });

            modelBuilder.Entity<ResearchCategory>(entity =>
            {
                entity.ToTable("ResearchCategory");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CategoryDescription).HasMaxLength(250);

                entity.Property(e => e.CategoryName).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ResearchResource>(entity =>
            {
                entity.ToTable("ResearchResource", "Conference");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ResearchTitle).HasMaxLength(300);
            });

            modelBuilder.Entity<ResearchSubCategory>(entity =>
            {
                entity.ToTable("ResearchSubCategory");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ResearchSubCategoryDesc).HasMaxLength(250);

                entity.Property(e => e.ResearchSubCategoryName).HasMaxLength(50);
            });

            modelBuilder.Entity<ResearchSubject>(entity =>
            {
                entity.ToTable("ResearchSubject");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.SubjectDescription).HasMaxLength(250);

                entity.Property(e => e.SubjectName).HasMaxLength(50);
            });

            modelBuilder.Entity<Researcher>(entity =>
            {
                entity.ToTable("Researcher", "Journal");

                entity.Property(e => e.Affiliation).HasMaxLength(300);

                entity.Property(e => e.Country).HasMaxLength(100);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email).HasMaxLength(200);

                entity.Property(e => e.FullName).HasMaxLength(200);

                entity.Property(e => e.Orcid)
                    .HasMaxLength(50)
                    .HasColumnName("ORCID");

                entity.Property(e => e.PhotoUrl).HasMaxLength(300);

                entity.Property(e => e.Website).HasMaxLength(300);
            });

            modelBuilder.Entity<RoleMaster>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__RoleMast__8AFACE1A88B12D71");

                entity.ToTable("RoleMaster", "admin");

                entity.HasIndex(e => e.RoleCode, "UQ__RoleMast__D62CB59C9B10C32F")
                    .IsUnique();

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedBy).HasMaxLength(100);

                entity.Property(e => e.RoleCode).HasMaxLength(50);

                entity.Property(e => e.RoleName).HasMaxLength(100);
            });

            modelBuilder.Entity<SubTheme>(entity =>
            {
                entity.ToTable("SubTheme", "Conference");

                entity.Property(e => e.SubTheme1)
                    .HasMaxLength(350)
                    .HasColumnName("SubTheme");
            });

            modelBuilder.Entity<UniversityDepartmentMap>(entity =>
            {
                entity.ToTable("UniversityDepartmentMap", "master");

                entity.Property(e => e.Id).HasColumnName("id");
            });

            modelBuilder.Entity<UniversityInstitute>(entity =>
            {
                entity.ToTable("UniversityInstitute", "master");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address).HasMaxLength(250);

                entity.Property(e => e.ContactNumber).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.UniversityName).HasMaxLength(200);

                entity.Property(e => e.Website).HasMaxLength(150);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users", "admin");

                entity.HasIndex(e => e.LoginId, "UQ__Users__4DDA28193EBD1C3B")
                    .IsUnique();

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email).HasMaxLength(150);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsLocked).HasDefaultValueSql("((0))");

                entity.Property(e => e.LoginId).HasMaxLength(100);

                entity.Property(e => e.MobileNo).HasMaxLength(50);

                entity.Property(e => e.ModifiedBy).HasMaxLength(100);

                entity.Property(e => e.PasswordHash).HasMaxLength(500);

                entity.Property(e => e.UserName).HasMaxLength(100);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("UserRoles", "admin");

                entity.HasIndex(e => new { e.UserId, e.RoleId }, "UQ_UserRole")
                    .IsUnique();

                entity.Property(e => e.AssignedBy).HasMaxLength(100);

                entity.Property(e => e.AssignedDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRoles_Role");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRoles_User");
            });

            modelBuilder.Entity<VideoMessage>(entity =>
            {
                entity.ToTable("VideoMessages", "Archieve");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.PresenterDesignation).HasMaxLength(200);

                entity.Property(e => e.PresenterName).HasMaxLength(50);
            });

            modelBuilder.Entity<VideoPresenterCategoryMaster>(entity =>
            {
                entity.ToTable("VideoPresenterCategoryMaster", "Archieve");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CategoryName).HasMaxLength(100);
            });

            modelBuilder.Entity<Volume>(entity =>
            {
                entity.ToTable("Volume", "Journal");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DoiPrefix)
                    .HasMaxLength(50)
                    .HasColumnName("DOI_Prefix");

                entity.Property(e => e.IsPublished).HasDefaultValueSql("((0))");

                entity.Property(e => e.PublicationMonth).HasMaxLength(20);

                entity.Property(e => e.PublishedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Journal)
                    .WithMany(p => p.Volumes)
                    .HasForeignKey(d => d.JournalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Volume_Journal");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
