using System;
using System.Collections.Generic;
using CurriculumService.Models;
using Microsoft.EntityFrameworkCore;

namespace CurriculumService.Data;

public partial class IuCurriculumContext : DbContext
{
    public IuCurriculumContext()
    {
    }

    public IuCurriculumContext(DbContextOptions<IuCurriculumContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<AsiinAssessmentTool> AsiinAssessmentTools { get; set; }

    public virtual DbSet<AsiinClo> AsiinClos { get; set; }

    public virtual DbSet<AsiinCloslo> AsiinCloslos { get; set; }

    public virtual DbSet<Assessment> Assessments { get; set; }

    public virtual DbSet<AssessmentTool> AssessmentTools { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<ClassAssessment> ClassAssessments { get; set; }

    public virtual DbSet<ClassAssessmentCourse> ClassAssessmentCourses { get; set; }

    public virtual DbSet<ClassSession> ClassSessions { get; set; }

    public virtual DbSet<ClassSloClo> ClassSloClos { get; set; }

    public virtual DbSet<CloAsiin> CloAsiins { get; set; }

    public virtual DbSet<CloSlo> CloSlos { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<CourseAssessment> CourseAssessments { get; set; }

    public virtual DbSet<CourseAssessmentAsiin> CourseAssessmentAsiins { get; set; }

    public virtual DbSet<CourseBook> CourseBooks { get; set; }

    public virtual DbSet<CourseCourseRelationship> CourseCourseRelationships { get; set; }

    public virtual DbSet<CourseDepartment> CourseDepartments { get; set; }

    public virtual DbSet<CourseInstructor> CourseInstructors { get; set; }

    public virtual DbSet<CourseLevel> CourseLevels { get; set; }

    public virtual DbSet<CoursePathway> CoursePathways { get; set; }

    public virtual DbSet<CourseProgram> CoursePrograms { get; set; }

    public virtual DbSet<CourseRelationship> CourseRelationships { get; set; }

    public virtual DbSet<CourseType> CourseTypes { get; set; }

    public virtual DbSet<Curriculum4yearsTemplate> Curriculum4yearsTemplates { get; set; }

    public virtual DbSet<Curriculum8semestersTemplate> Curriculum8semestersTemplates { get; set; }

    public virtual DbSet<CurriculumCs4yearItSubjectOnly> CurriculumCs4yearItSubjectOnlies { get; set; }

    public virtual DbSet<CurriculumCsAe14year> CurriculumCsAe14years { get; set; }

    public virtual DbSet<CurriculumCsAe18semester> CurriculumCsAe18semesters { get; set; }

    public virtual DbSet<CurriculumDsAe14year> CurriculumDsAe14years { get; set; }

    public virtual DbSet<CurriculumDsAe18semester> CurriculumDsAe18semesters { get; set; }

    public virtual DbSet<CurriculumItceAe14year> CurriculumItceAe14years { get; set; }

    public virtual DbSet<CurriculumItceAe18semester> CurriculumItceAe18semesters { get; set; }

    public virtual DbSet<CurriculumItneAe14year> CurriculumItneAe14years { get; set; }

    public virtual DbSet<CurriculumItneAe18semester> CurriculumItneAe18semesters { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<DepartmentInstructor> DepartmentInstructors { get; set; }

    public virtual DbSet<Discipline> Disciplines { get; set; }

    public virtual DbSet<Documentary> Documentaries { get; set; }

    public virtual DbSet<Instructor> Instructors { get; set; }

    public virtual DbSet<LearningOutcome> LearningOutcomes { get; set; }

    public virtual DbSet<Major> Majors { get; set; }

    public virtual DbSet<Migration> Migrations { get; set; }

    public virtual DbSet<Pathway> Pathways { get; set; }

    public virtual DbSet<Models.Program> Programs { get; set; }

    public virtual DbSet<ProgramDocument> ProgramDocuments { get; set; }

    public virtual DbSet<ProgramType> ProgramTypes { get; set; }

    public virtual DbSet<Result> Results { get; set; }

    public virtual DbSet<Slo> Slos { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<SyllabusGenerater> SyllabusGeneraters { get; set; }

    public virtual DbSet<TelescopeEntriesTag> TelescopeEntriesTags { get; set; }

    public virtual DbSet<TelescopeEntry> TelescopeEntries { get; set; }

    public virtual DbSet<TelescopeMonitoring> TelescopeMonitorings { get; set; }

    public virtual DbSet<Topic> Topics { get; set; }

    public virtual DbSet<TopicDetail> TopicDetails { get; set; }

    public virtual DbSet<TopicType> TopicTypes { get; set; }

    public virtual DbSet<TotalCreditsBySemesterC> TotalCreditsBySemesterCs { get; set; }

    public virtual DbSet<TotalCreditsBySemesterD> TotalCreditsBySemesterDs { get; set; }

    public virtual DbSet<TotalCreditsBySemesterItce> TotalCreditsBySemesterItces { get; set; }

    public virtual DbSet<TotalCreditsBySemesterItne> TotalCreditsBySemesterItnes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("account");

            entity.HasIndex(e => e.InstructorId, "FK9nkqtsydmph5nrsd3sn1f4w29");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.InstructorId).HasColumnName("instructor_id");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.UserName)
                .HasMaxLength(255)
                .HasColumnName("user_name");
            entity.Property(e => e.UserRole)
                .HasMaxLength(255)
                .HasColumnName("user_role");
        });

        modelBuilder.Entity<AsiinAssessmentTool>(entity =>
        {
            entity.HasKey(e => new { e.CloId, e.CourseId, e.AssessmentId }).HasName("PRIMARY");

            entity.ToTable("asiin_assessment_tool");

            entity.HasIndex(e => e.CourseId, "FK_asiin_assessmentTool_course_idx");

            entity.HasIndex(e => e.AssessmentId, "FK_assessmentTool_assessment_idx");

            entity.Property(e => e.CloId)
                .HasMaxLength(50)
                .HasColumnName("clo_id");
            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.AssessmentId).HasColumnName("assessment_id");
            entity.Property(e => e.Percentage).HasColumnName("percentage");

            entity.HasOne(d => d.Assessment).WithMany(p => p.AsiinAssessmentTools)
                .HasForeignKey(d => d.AssessmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_asiin_assessmentTool_assessment");

            entity.HasOne(d => d.Clo).WithMany(p => p.AsiinAssessmentTools)
                .HasForeignKey(d => d.CloId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_asiin_assessmentTool_clo");

            entity.HasOne(d => d.Course).WithMany(p => p.AsiinAssessmentTools)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_asiin_assessmentTool_course");
        });

        modelBuilder.Entity<AsiinClo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("asiin_clo");

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
        });

        modelBuilder.Entity<AsiinCloslo>(entity =>
        {
            entity.HasKey(e => new { e.CloId, e.SloId }).HasName("PRIMARY");

            entity.ToTable("asiin_closlo");

            entity.HasIndex(e => e.SloId, "slo_closlo_asiin_idx");

            entity.Property(e => e.CloId)
                .HasMaxLength(50)
                .HasColumnName("clo_id");
            entity.Property(e => e.SloId).HasColumnName("slo_id");
            entity.Property(e => e.Level).HasColumnName("level");
            entity.Property(e => e.Percentage).HasColumnName("percentage");

            entity.HasOne(d => d.Clo).WithMany(p => p.AsiinCloslos)
                .HasForeignKey(d => d.CloId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_closlo_clo");

            entity.HasOne(d => d.Slo).WithMany(p => p.AsiinCloslos)
                .HasForeignKey(d => d.SloId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_closlo_slo");
        });

        modelBuilder.Entity<Assessment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("assessment");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .HasColumnName("type");
            entity.Property(e => e.TypeVn)
                .HasMaxLength(255)
                .HasColumnName("type_vn");
        });

        modelBuilder.Entity<AssessmentTool>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("assessment_tool");

            entity.HasIndex(e => new { e.AssessmentId, e.CourseId }, "FK_AssessmentTool_AssessmentCourse");

            entity.HasIndex(e => e.LoutcomeId, "FK_AssessmentTool_LOutcome");

            entity.HasIndex(e => new { e.CourseId, e.AssessmentId, e.LoutcomeId }, "assessment_tool_id").IsUnique();

            entity.Property(e => e.AssessmentId).HasColumnName("assessment_id");
            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.LoutcomeId).HasColumnName("loutcome_id");
            entity.Property(e => e.Precentage).HasColumnName("precentage");

            entity.HasOne(d => d.Assessment).WithMany()
                .HasForeignKey(d => d.AssessmentId)
                .HasConstraintName("FK_AssessmentTool_Assessment");

            entity.HasOne(d => d.Course).WithMany()
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK_AssessmentTool_Course");

            entity.HasOne(d => d.Loutcome).WithMany()
                .HasForeignKey(d => d.LoutcomeId)
                .HasConstraintName("FK_AssessmentTool_LOutcome");
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("book");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Author)
                .HasMaxLength(255)
                .HasColumnName("author");
            entity.Property(e => e.Isbn)
                .HasMaxLength(255)
                .HasColumnName("ISBN");
            entity.Property(e => e.Publisher)
                .HasMaxLength(255)
                .HasColumnName("publisher");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .HasColumnName("type");
            entity.Property(e => e.Version)
                .HasMaxLength(255)
                .HasColumnName("version");
            entity.Property(e => e.Year).HasColumnName("year");
        });

        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("class");

            entity.HasIndex(e => new { e.CourseId, e.GroupTheory, e.GroupLab, e.Semester, e.AcademicYear }, "course_id_group_theory_group_lab_semester_academic_year");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AcademicYear)
                .HasMaxLength(50)
                .HasDefaultValueSql("'0'")
                .HasColumnName("academic_year");
            entity.Property(e => e.CourseId)
                .HasMaxLength(50)
                .HasDefaultValueSql("'0'")
                .HasColumnName("course_id");
            entity.Property(e => e.GroupLab)
                .HasDefaultValueSql("'0'")
                .HasColumnName("group_lab");
            entity.Property(e => e.GroupTheory)
                .HasDefaultValueSql("'0'")
                .HasColumnName("group_theory");
            entity.Property(e => e.InstructorId)
                .HasMaxLength(50)
                .HasDefaultValueSql("'0'")
                .HasColumnName("instructor_id");
            entity.Property(e => e.NumStudents)
                .HasDefaultValueSql("'0'")
                .HasColumnName("num_students");
            entity.Property(e => e.Semester)
                .HasDefaultValueSql("'0'")
                .HasColumnName("semester");
        });

        modelBuilder.Entity<ClassAssessment>(entity =>
        {
            entity.HasKey(e => new { e.AssessmentId, e.ClassId, e.LearningOutcomeId }).HasName("PRIMARY");

            entity.ToTable("class_assessment");

            entity.HasIndex(e => e.LearningOutcomeId, "FKgvbc7qhba0d7odssq6rtompih");

            entity.HasIndex(e => e.ClassId, "FKmevtb7furfoqcnjqn5wuafdx5");

            entity.Property(e => e.AssessmentId).HasColumnName("assessment_id");
            entity.Property(e => e.ClassId)
                .HasMaxLength(50)
                .HasColumnName("class_id");
            entity.Property(e => e.LearningOutcomeId).HasColumnName("learning_outcome_id");
            entity.Property(e => e.Precentage).HasColumnName("precentage");

            entity.HasOne(d => d.Assessment).WithMany(p => p.ClassAssessments)
                .HasForeignKey(d => d.AssessmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKcdrm0f8q2dbqmsrwi90lcjthx");

            entity.HasOne(d => d.Class).WithMany(p => p.ClassAssessments)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("classAssessmenet_ClassSession");

            entity.HasOne(d => d.LearningOutcome).WithMany(p => p.ClassAssessments)
                .HasForeignKey(d => d.LearningOutcomeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("classAssessement_LearingOutcome");
        });

        modelBuilder.Entity<ClassAssessmentCourse>(entity =>
        {
            entity.HasKey(e => new { e.ClassId, e.AssessmentId }).HasName("PRIMARY");

            entity.ToTable("class_assessment_course");

            entity.HasIndex(e => e.AssessmentId, "fk_class_assessment_course_assessment");

            entity.HasIndex(e => e.ClassId, "fk_class_assessment_course_class");

            entity.Property(e => e.ClassId)
                .HasMaxLength(50)
                .HasColumnName("class_id");
            entity.Property(e => e.AssessmentId).HasColumnName("assessment_id");
            entity.Property(e => e.Percentage).HasColumnName("percentage");

            entity.HasOne(d => d.Assessment).WithMany(p => p.ClassAssessmentCourses)
                .HasForeignKey(d => d.AssessmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("classAssessmentCourse_assessement");

            entity.HasOne(d => d.Class).WithMany(p => p.ClassAssessmentCourses)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("classAssessmentCourse_classSession");
        });

        modelBuilder.Entity<ClassSession>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("class_session");

            entity.HasIndex(e => e.CourseId, "FK_classSession_course");

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .HasColumnName("id");
            entity.Property(e => e.AcademicYear)
                .HasMaxLength(255)
                .HasColumnName("academic_year");
            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.GroupTheory).HasColumnName("group_theory");
            entity.Property(e => e.Semester).HasColumnName("semester");

            entity.HasOne(d => d.Course).WithMany(p => p.ClassSessions)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK_classSession_course");
        });

        modelBuilder.Entity<ClassSloClo>(entity =>
        {
            entity.HasKey(e => new { e.ClassId, e.CloId, e.SloId }).HasName("PRIMARY");

            entity.ToTable("class_slo_clo");

            entity.HasIndex(e => e.CloId, "FKecnfqj0x90g694r9lpkch9v65");

            entity.HasIndex(e => e.SloId, "FKpfxxfwt6crqhsnjdhn8ltf4cu");

            entity.Property(e => e.ClassId)
                .HasMaxLength(50)
                .HasColumnName("class_id");
            entity.Property(e => e.CloId).HasColumnName("clo_id");
            entity.Property(e => e.SloId).HasColumnName("slo_id");
            entity.Property(e => e.Percentage).HasColumnName("percentage");

            entity.HasOne(d => d.Class).WithMany(p => p.ClassSloClos)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("classSLOCLO_classSession");

            entity.HasOne(d => d.Clo).WithMany(p => p.ClassSloClos)
                .HasForeignKey(d => d.CloId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("classSLOCLO_clo");

            entity.HasOne(d => d.Slo).WithMany(p => p.ClassSloClos)
                .HasForeignKey(d => d.SloId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("classSLOCLO_slo");
        });

        modelBuilder.Entity<CloAsiin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("clo_asiin");

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
        });

        modelBuilder.Entity<CloSlo>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("clo_slo");

            entity.HasIndex(e => e.LoId, "fk_clo_slo_learning_outcome");

            entity.HasIndex(e => e.SloId, "fk_clo_slo_slo");

            entity.Property(e => e.Level).HasColumnName("level");
            entity.Property(e => e.LoId).HasColumnName("lo_id");
            entity.Property(e => e.Percentage).HasColumnName("percentage");
            entity.Property(e => e.SloId).HasColumnName("slo_id");

            entity.HasOne(d => d.Lo).WithMany()
                .HasForeignKey(d => d.LoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_clo_slo_learning_outcome");

            entity.HasOne(d => d.Slo).WithMany()
                .HasForeignKey(d => d.SloId)
                .HasConstraintName("fk_clo_slo_slo");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("course");

            entity.HasIndex(e => e.CourseLevelId, "FK_Course_CourseLevel");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CourseLevelId).HasColumnName("course_level_id");
            entity.Property(e => e.CreditLab).HasColumnName("credit_lab");
            entity.Property(e => e.CreditTheory).HasColumnName("credit_theory");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.NameVn)
                .HasMaxLength(255)
                .HasColumnName("name_vn");
        });

        modelBuilder.Entity<CourseAssessment>(entity =>
        {
            entity.HasKey(e => new { e.AssessmentId, e.CourseId }).HasName("PRIMARY");

            entity.ToTable("course_assessment");

            entity.HasIndex(e => e.CourseId, "Fk_AssessmentCourse_Course");

            entity.Property(e => e.AssessmentId).HasColumnName("assessment_id");
            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.Percentage).HasColumnName("percentage");

            entity.HasOne(d => d.Course).WithMany(p => p.CourseAssessments)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("Fk_AssessmentCourse_Course");
        });

        modelBuilder.Entity<CourseAssessmentAsiin>(entity =>
        {
            entity.HasKey(e => new { e.AssessmentId, e.CourseId }).HasName("PRIMARY");

            entity.ToTable("course_assessment_asiin");

            entity.HasIndex(e => e.CourseId, "assessment_course_idx");

            entity.Property(e => e.AssessmentId).HasColumnName("assessment_id");
            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.Percentage).HasColumnName("percentage");
        });

        modelBuilder.Entity<CourseBook>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("course_book");

            entity.HasIndex(e => e.CourseId, "FK_BookCourse_Course");

            entity.HasIndex(e => new { e.BookId, e.CourseId }, "Key").IsUnique();

            entity.Property(e => e.BookId).HasColumnName("book_id");
            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .HasColumnName("type");

            entity.HasOne(d => d.Book).WithMany()
                .HasForeignKey(d => d.BookId)
                .HasConstraintName("FK_BookCourse_Book");

            entity.HasOne(d => d.Course).WithMany()
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK_BookCourse_Course");
        });

        modelBuilder.Entity<CourseCourseRelationship>(entity =>
        {
            entity
                .ToTable("course_course_relationship");
            entity.HasKey(x => new { x.CourseId1, x.CourseId2 });

            entity.HasIndex(e => e.RelationshipId, "CourseCourse_CourseRelationship");

            entity.HasIndex(e => e.CourseId2, "FKCourse_Course2");

            entity.HasIndex(e => new { e.CourseId1, e.CourseId2 }, "Key").IsUnique();

            entity.Property(e => e.CourseId1).HasColumnName("course_id1");
            entity.Property(e => e.CourseId2).HasColumnName("course_id2");
            entity.Property(e => e.RelationshipId).HasColumnName("relationship_id");

            // entity.HasOne(d => d.CourseId1Navigation).WithMany()
            //     .HasForeignKey(d => d.CourseId1)
            //     .HasConstraintName("FKCourse_Course1");
            //
            // entity.HasOne(d => d.CourseId2Navigation).WithMany()
            //     .HasForeignKey(d => d.CourseId2)
            //     .HasConstraintName("FKCourse_Course2");
            //
            // entity.HasOne(d => d.Relationship).WithMany()
            //     .HasForeignKey(d => d.RelationshipId)
            //     .HasConstraintName("CourseCourse_CourseRelationship");
        });

        modelBuilder.Entity<CourseDepartment>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("course_department");

            entity.HasIndex(e => e.DepartmentId, "FK_CourseDepartment_Department");

            entity.HasIndex(e => new { e.CourseId, e.DepartmentId }, "coruse_id").IsUnique();

            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.DepartmentId).HasColumnName("department_id");

            entity.HasOne(d => d.Course).WithMany()
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK_CourseDepartment_Coursre");

            entity.HasOne(d => d.Department).WithMany()
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_CourseDepartment_Department");
        });

        modelBuilder.Entity<CourseInstructor>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("course_instructor");

            entity.HasIndex(e => e.InstructorId, "FK_CourseInstructor_Instructor");

            entity.HasIndex(e => new { e.CourseId, e.InstructorId }, "course_id").IsUnique();

            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.InstructorId).HasColumnName("instructor_id");

            entity.HasOne(d => d.Course).WithMany()
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK_CourseInstructor_Course");
        });

        modelBuilder.Entity<CourseLevel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("course_level");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Level)
                .HasMaxLength(255)
                .HasColumnName("level");
        });

        modelBuilder.Entity<CoursePathway>(entity =>
        {
            entity.HasKey(x => new { x.ProgramId, x.CourseId, x.PathwayId });
            entity
                .ToTable("course_pathway");

            entity.HasIndex(e => e.CourseId, "FK_CoursePathway_Course");

            entity.HasIndex(e => e.PathwayId, "FK_CoursePathway_Pathway");

            entity.HasIndex(e => new { e.ProgramId, e.PathwayId, e.CourseId }, "program_id").IsUnique();

            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.PathwayId).HasColumnName("pathway_id");
            entity.Property(e => e.ProgramId).HasColumnName("program_id");
            entity.Property(e => e.Semester).HasColumnName("semester");
            entity.Property(e => e.Year).HasColumnName("year");

            // entity.HasOne(d => d.Course).WithMany()
            //     .HasForeignKey(d => d.CourseId)
            //     .HasConstraintName("FK_CoursePathway_Course");
            //
            // entity.HasOne(d => d.Pathway).WithMany()
            //     .HasForeignKey(d => d.PathwayId)
            //     .HasConstraintName("FK_CoursePathway_Pathway");
            //
            // entity.HasOne(d => d.Program).WithMany()
            //     .HasForeignKey(d => d.ProgramId)
            //     .OnDelete(DeleteBehavior.ClientSetNull)
            //     .HasConstraintName("FK_CoursePathway_Program");
        });

        modelBuilder.Entity<CourseProgram>(entity =>
        {
            entity
                .HasKey(x => new {x.CourseId, x.ProgramId});
                
                entity.ToTable("course_program");

            entity.HasIndex(e => e.CourseTypeId, "FK_CourseProgram_CourseType");

            entity.HasIndex(e => e.ProgramId, "FK_CourseProgram_Program");

            entity.HasIndex(e => new { e.CourseId, e.ProgramId }, "Key").IsUnique();

            entity.Property(e => e.CourseCode)
                .HasMaxLength(255)
                .HasColumnName("course_code");
            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.CourseTypeId).HasColumnName("course_type_id");
            entity.Property(e => e.ProgramId).HasColumnName("program_id");

            // entity.HasOne(d => d.Course).WithMany()
            //     .HasForeignKey(d => d.CourseId)
            //     .HasConstraintName("FK_CourseProgram_Course");
            //
            // entity.HasOne(d => d.CourseType).WithMany()
            //     .HasForeignKey(d => d.CourseTypeId)
            //     .HasConstraintName("FK_CourseProgram_CourseType");
            //
            // entity.HasOne(d => d.Program).WithMany()
            //     .HasForeignKey(d => d.ProgramId)
            //     .HasConstraintName("FK_CourseProgram_Program");
        });

        modelBuilder.Entity<CourseRelationship>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("course_relationship");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Relationship)
                .HasMaxLength(255)
                .HasColumnName("relationship");
        });

        modelBuilder.Entity<CourseType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("course_type");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .HasColumnName("type");
            entity.Property(e => e.TypeVn)
                .HasMaxLength(255)
                .HasColumnName("type_vn");
        });

        modelBuilder.Entity<Curriculum4yearsTemplate>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("curriculum_4years_template");

            entity.Property(e => e.CourseCode)
                .HasMaxLength(255)
                .HasColumnName("course_code");
            entity.Property(e => e.CourseName)
                .HasMaxLength(255)
                .HasColumnName("Course Name");
            entity.Property(e => e.Credit).HasMaxLength(39);
            entity.Property(e => e.Program).HasMaxLength(259);
            entity.Property(e => e.Semester).HasColumnName("semester");
            entity.Property(e => e.Year).HasColumnName("year");
        });

        modelBuilder.Entity<Curriculum8semestersTemplate>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("curriculum_8semesters_template");

            entity.Property(e => e.CourseCode)
                .HasMaxLength(255)
                .HasColumnName("course_code");
            entity.Property(e => e.CourseName)
                .HasMaxLength(255)
                .HasColumnName("Course Name");
            entity.Property(e => e.Credit).HasMaxLength(39);
            entity.Property(e => e.Program).HasMaxLength(259);
        });

        modelBuilder.Entity<CurriculumCs4yearItSubjectOnly>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("curriculum_cs_4year_it_subject_only");

            entity.Property(e => e.CourseCode)
                .HasMaxLength(255)
                .HasColumnName("course_code");
            entity.Property(e => e.CourseName)
                .HasMaxLength(255)
                .HasColumnName("Course Name");
            entity.Property(e => e.CreditLab).HasColumnName("credit_lab");
            entity.Property(e => e.CreditTheory).HasColumnName("credit_theory");
            entity.Property(e => e.Degree)
                .HasMaxLength(255)
                .HasColumnName("degree");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Program).HasMaxLength(255);
            entity.Property(e => e.Semester).HasColumnName("semester");
            entity.Property(e => e.Year).HasColumnName("year");
        });

        modelBuilder.Entity<CurriculumCsAe14year>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("curriculum_cs_ae1_4years");

            entity.Property(e => e.CourseCode)
                .HasMaxLength(255)
                .HasColumnName("course_code");
            entity.Property(e => e.CourseName)
                .HasMaxLength(255)
                .HasColumnName("Course Name");
            entity.Property(e => e.Semester).HasColumnName("semester");
            entity.Property(e => e.Year).HasColumnName("year");
        });

        modelBuilder.Entity<CurriculumCsAe18semester>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("curriculum_cs_ae1_8semesters");

            entity.Property(e => e.CourseCode)
                .HasMaxLength(255)
                .HasColumnName("course_code");
            entity.Property(e => e.CourseName)
                .HasMaxLength(255)
                .HasColumnName("Course Name");
        });

        modelBuilder.Entity<CurriculumDsAe14year>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("curriculum_ds_ae1_4years");

            entity.Property(e => e.CourseCode)
                .HasMaxLength(255)
                .HasColumnName("course_code");
            entity.Property(e => e.CourseName)
                .HasMaxLength(255)
                .HasColumnName("Course Name");
            entity.Property(e => e.Program).HasMaxLength(255);
            entity.Property(e => e.Semester).HasColumnName("semester");
            entity.Property(e => e.Year).HasColumnName("year");
        });

        modelBuilder.Entity<CurriculumDsAe18semester>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("curriculum_ds_ae1_8semesters");

            entity.Property(e => e.CourseCode)
                .HasMaxLength(255)
                .HasColumnName("course_code");
            entity.Property(e => e.CourseName)
                .HasMaxLength(255)
                .HasColumnName("Course Name");
        });

        modelBuilder.Entity<CurriculumItceAe14year>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("curriculum_itce_ae1_4years");

            entity.Property(e => e.CourseCode)
                .HasMaxLength(255)
                .HasColumnName("course_code");
            entity.Property(e => e.CourseName)
                .HasMaxLength(255)
                .HasColumnName("Course Name");
            entity.Property(e => e.Program).HasMaxLength(255);
            entity.Property(e => e.Semester).HasColumnName("semester");
            entity.Property(e => e.Year).HasColumnName("year");
        });

        modelBuilder.Entity<CurriculumItceAe18semester>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("curriculum_itce_ae1_8semesters");

            entity.Property(e => e.CourseCode)
                .HasMaxLength(255)
                .HasColumnName("course_code");
            entity.Property(e => e.CourseName)
                .HasMaxLength(255)
                .HasColumnName("Course Name");
        });

        modelBuilder.Entity<CurriculumItneAe14year>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("curriculum_itne_ae1_4years");

            entity.Property(e => e.CourseCode)
                .HasMaxLength(255)
                .HasColumnName("course_code");
            entity.Property(e => e.CourseName)
                .HasMaxLength(255)
                .HasColumnName("Course Name");
            entity.Property(e => e.Program).HasMaxLength(255);
            entity.Property(e => e.Semester).HasColumnName("semester");
            entity.Property(e => e.Year).HasColumnName("year");
        });

        modelBuilder.Entity<CurriculumItneAe18semester>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("curriculum_itne_ae1_8semesters");

            entity.Property(e => e.CourseCode)
                .HasMaxLength(255)
                .HasColumnName("course_code");
            entity.Property(e => e.CourseName)
                .HasMaxLength(255)
                .HasColumnName("Course Name");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("department");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<DepartmentInstructor>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("department_instructor");

            entity.HasIndex(e => e.InstructorId, "FK_DepartmentInstructor_Instructor");

            entity.HasIndex(e => new { e.DepartmentId, e.InstructorId }, "department_instructor_key").IsUnique();

            entity.Property(e => e.DepartmentId).HasColumnName("department_id");
            entity.Property(e => e.InstructorId)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("instructor_id");

            entity.HasOne(d => d.Department).WithMany()
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_DepartmentInstructor_Department");

            entity.HasOne(d => d.Instructor).WithMany()
                .HasForeignKey(d => d.InstructorId)
                .HasConstraintName("FK_department_instructor_instructor");
        });

        modelBuilder.Entity<Discipline>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("discipline");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Documentary>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documentary");

            entity.HasIndex(e => e.DocumentId, "document_id_UNIQUE").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DocumentId)
                .HasMaxLength(50)
                .HasColumnName("document_id");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Instructor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("instructor");

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("id");
            entity.Property(e => e.Degree)
                .HasMaxLength(255)
                .HasColumnName("degree");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<LearningOutcome>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("learning_outcome");

            entity.HasIndex(e => e.CourseId, "FK_LearningOutcome");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.DescriptionVn)
                .HasColumnType("text")
                .HasColumnName("description_vn");

            entity.HasOne(d => d.Course).WithMany(p => p.LearningOutcomes)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK_LearningOutcome");
        });

        modelBuilder.Entity<Major>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("major");

            entity.HasIndex(e => e.DisciplineId, "FK_major_discipline");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DisciplineId).HasColumnName("discipline_id");
            entity.Property(e => e.FullName)
                .HasMaxLength(255)
                .HasColumnName("full_name");
            entity.Property(e => e.ShortName)
                .HasMaxLength(255)
                .HasColumnName("short_name");

            entity.HasOne(d => d.Discipline).WithMany(p => p.Majors)
                .HasForeignKey(d => d.DisciplineId)
                .HasConstraintName("FK_major_discipline");
        });

        modelBuilder.Entity<Migration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("migrations");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Batch).HasColumnName("batch");
            entity.Property(e => e.Migration1)
                .HasMaxLength(255)
                .HasColumnName("migration");
        });

        modelBuilder.Entity<Pathway>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("pathway");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Pathway1)
                .HasMaxLength(255)
                .HasColumnName("pathway");
        });

        modelBuilder.Entity<Models.Program>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("program");

            entity.HasIndex(e => e.MajorId, "FK_program_major");

            entity.HasIndex(e => e.ProgramTypeId, "fk_program_program_type");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.MajorId).HasColumnName("major_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.ProgramTypeId).HasColumnName("program_type_id");
            entity.Property(e => e.ValidFrom)
                .HasMaxLength(255)
                .HasColumnName("valid_from");
            entity.Property(e => e.Version)
                .HasMaxLength(4)
                .HasColumnName("version");

            // entity.HasOne(d => d.Major).WithMany(p => p.Programs)
            //     .HasForeignKey(d => d.MajorId)
            //     .OnDelete(DeleteBehavior.Cascade)
            //     .HasConstraintName("FK_program_major");

            // entity.HasOne(d => d.ProgramType).WithMany(p => p.Programs)
            //     .HasForeignKey(d => d.ProgramTypeId)
            //     .OnDelete(DeleteBehavior.ClientSetNull)
            //     .HasConstraintName("FK_program_program_type");
        });

        modelBuilder.Entity<ProgramDocument>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("program_document");

            entity.HasIndex(e => e.ProgramId, "FK1_idx");

            entity.HasIndex(e => e.DocumentId, "FK2_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DocumentId).HasColumnName("document_id");
            entity.Property(e => e.ProgramId).HasColumnName("program_id");

            // entity.HasOne(d => d.Document).WithMany(p => p.ProgramDocuments)
            //     .HasForeignKey(d => d.DocumentId)
            //     .HasConstraintName("FK2");

            // entity.HasOne(d => d.Program).WithMany(p => p.ProgramDocuments)
            //     .HasForeignKey(d => d.ProgramId)
            //     .HasConstraintName("FK1");
        });

        modelBuilder.Entity<ProgramType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("program_type");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .HasColumnName("description");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .HasColumnName("type");
        });

        modelBuilder.Entity<Result>(entity =>
        {
            entity.HasKey(e => new { e.StudentId, e.ClassId }).HasName("PRIMARY");

            entity.ToTable("result");

            entity.Property(e => e.StudentId)
                .HasMaxLength(50)
                .HasColumnName("student_id");
            entity.Property(e => e.ClassId).HasColumnName("class_id");
            entity.Property(e => e.Abet1).HasColumnName("abet_1");
            entity.Property(e => e.Abet2).HasColumnName("abet_2");
            entity.Property(e => e.Abet3).HasColumnName("abet_3");
            entity.Property(e => e.Abet4).HasColumnName("abet_4");
            entity.Property(e => e.Abet5).HasColumnName("abet_5");
            entity.Property(e => e.Abet6).HasColumnName("abet_6");
            entity.Property(e => e.AbetScore).HasColumnName("abet_score");
            entity.Property(e => e.Avg).HasColumnName("avg");
            entity.Property(e => e.FinalScore).HasColumnName("final_score");
            entity.Property(e => e.Gpa).HasColumnName("GPA");
            entity.Property(e => e.InClassScore).HasColumnName("in_class_score");
            entity.Property(e => e.MidScore).HasColumnName("mid_score");

            entity.HasOne(d => d.Student).WithMany(p => p.Results)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Student_Result");
        });

        modelBuilder.Entity<Slo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("slo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Criteria).HasColumnName("criteria");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("student");

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .HasColumnName("id");
            entity.Property(e => e.Batch).HasColumnName("batch");
            entity.Property(e => e.Major)
                .HasMaxLength(45)
                .HasColumnName("major");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<SyllabusGenerater>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("syllabus_generater");

            entity.Property(e => e.CourseId)
                .HasMaxLength(255)
                .HasColumnName("CourseID");
            entity.Property(e => e.CourseType)
                .HasMaxLength(255)
                .HasColumnName("Course Type");
            entity.Property(e => e.Department).HasMaxLength(255);
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.English).HasMaxLength(255);
            entity.Property(e => e.IntructorName)
                .HasMaxLength(512)
                .HasColumnName("Intructor Name");
            entity.Property(e => e.TotalCredit).HasColumnName("totalCredit");
            entity.Property(e => e.Vietnamese).HasMaxLength(255);
        });

        modelBuilder.Entity<TelescopeEntriesTag>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("telescope_entries_tags");

            entity.HasIndex(e => new { e.EntryUuid, e.Tag }, "telescope_entries_tags_entry_uuid_tag_index");

            entity.HasIndex(e => e.Tag, "telescope_entries_tags_tag_index");

            entity.Property(e => e.EntryUuid).HasColumnName("entry_uuid");
            entity.Property(e => e.Tag).HasColumnName("tag");

            entity.HasOne(d => d.EntryUu).WithMany()
                .HasPrincipalKey(p => p.Uuid)
                .HasForeignKey(d => d.EntryUuid)
                .HasConstraintName("telescope_entries_tags_entry_uuid_foreign");
        });

        modelBuilder.Entity<TelescopeEntry>(entity =>
        {
            entity.HasKey(e => e.Sequence).HasName("PRIMARY");

            entity.ToTable("telescope_entries");

            entity.HasIndex(e => e.BatchId, "telescope_entries_batch_id_index");

            entity.HasIndex(e => e.CreatedAt, "telescope_entries_created_at_index");

            entity.HasIndex(e => e.FamilyHash, "telescope_entries_family_hash_index");

            entity.HasIndex(e => new { e.Type, e.ShouldDisplayOnIndex }, "telescope_entries_type_should_display_on_index_index");

            entity.HasIndex(e => e.Uuid, "telescope_entries_uuid_unique").IsUnique();

            entity.Property(e => e.Sequence).HasColumnName("sequence");
            entity.Property(e => e.BatchId).HasColumnName("batch_id");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.FamilyHash).HasColumnName("family_hash");
            entity.Property(e => e.ShouldDisplayOnIndex)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasColumnName("should_display_on_index");
            entity.Property(e => e.Type)
                .HasMaxLength(20)
                .HasColumnName("type");
            entity.Property(e => e.Uuid).HasColumnName("uuid");
        });

        modelBuilder.Entity<TelescopeMonitoring>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("telescope_monitoring");

            entity.Property(e => e.Tag)
                .HasMaxLength(255)
                .HasColumnName("tag");
        });

        modelBuilder.Entity<Topic>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("topic");

            entity.HasIndex(e => e.CourseId, "FK_Topic_Course");

            entity.HasIndex(e => e.TopicTypeId, "FK_topic_topic_type");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.LearningActivities)
                .HasMaxLength(255)
                .HasColumnName("learning_activities");
            entity.Property(e => e.Name)
                .HasMaxLength(510)
                .HasColumnName("name");
            entity.Property(e => e.TeachingActivities)
                .HasMaxLength(255)
                .HasColumnName("teaching_activities");
            entity.Property(e => e.TopicTypeId).HasColumnName("topic_type_id");

            entity.HasOne(d => d.Course).WithMany(p => p.Topics)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("fk_topic_course");
        });

        modelBuilder.Entity<TopicDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("topic_detail");

            entity.HasIndex(e => e.TopicId, "FK_topic_TopicDetail");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.TopicDetail1)
                .HasMaxLength(1000)
                .HasColumnName("topic_detail");
            entity.Property(e => e.TopicId).HasColumnName("topic_id");
            entity.Property(e => e.Week).HasColumnName("week");

            entity.HasOne(d => d.Topic).WithMany(p => p.TopicDetails)
                .HasForeignKey(d => d.TopicId)
                .HasConstraintName("FK_topic_TopicDetail");
        });

        modelBuilder.Entity<TopicType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("topic_type");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .HasColumnName("type");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.TopicType)
                .HasForeignKey<TopicType>(d => d.Id)
                .HasConstraintName("FKTopic_TopicType");
        });

        modelBuilder.Entity<TotalCreditsBySemesterC>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("total_credits_by_semester_cs");

            entity.Property(e => e.Credits).HasPrecision(33);
        });

        modelBuilder.Entity<TotalCreditsBySemesterD>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("total_credits_by_semester_ds");

            entity.Property(e => e.Credits).HasPrecision(33);
        });

        modelBuilder.Entity<TotalCreditsBySemesterItce>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("total_credits_by_semester_itce");

            entity.Property(e => e.Credits).HasPrecision(33);
        });

        modelBuilder.Entity<TotalCreditsBySemesterItne>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("total_credits_by_semester_itne");

            entity.Property(e => e.Credits).HasPrecision(33);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}