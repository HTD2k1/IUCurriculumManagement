using System;
using System.Collections.Generic;
using CurriculumVerifier.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CurriculumVerifier.Data.Models
{
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

        public virtual DbSet<Program> Programs { get; set; }

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
            });

            modelBuilder.Entity<AsiinAssessmentTool>(entity =>
            {
                entity.HasKey(e => new { e.CloId, e.CourseId, e.AssessmentId }).HasName("PRIMARY");

                entity.HasOne(d => d.Assessment).WithMany(p => p.AsiinAssessmentTools)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_asiin_assessmentTool_assessment");

                entity.HasOne(d => d.Clo).WithMany(p => p.AsiinAssessmentTools)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_asiin_assessmentTool_clo");

                entity.HasOne(d => d.Course).WithMany(p => p.AsiinAssessmentTools)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_asiin_assessmentTool_course");
            });

            modelBuilder.Entity<AsiinClo>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");
            });

            modelBuilder.Entity<AsiinCloslo>(entity =>
            {
                entity.HasKey(e => new { e.CloId, e.SloId }).HasName("PRIMARY");

                entity.HasOne(d => d.Clo).WithMany(p => p.AsiinCloslos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_closlo_clo");

                entity.HasOne(d => d.Slo).WithMany(p => p.AsiinCloslos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_closlo_slo");
            });

            modelBuilder.Entity<Assessment>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");
            });

            modelBuilder.Entity<AssessmentTool>(entity =>
            {
                entity.HasOne(d => d.Assessment).WithMany().HasConstraintName("FK_AssessmentTool_Assessment");

                entity.HasOne(d => d.Course).WithMany().HasConstraintName("FK_AssessmentTool_Course");

                entity.HasOne(d => d.Loutcome).WithMany().HasConstraintName("FK_AssessmentTool_LOutcome");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.Property(e => e.AcademicYear).HasDefaultValueSql("'0'");
                entity.Property(e => e.CourseId).HasDefaultValueSql("'0'");
                entity.Property(e => e.GroupLab).HasDefaultValueSql("'0'");
                entity.Property(e => e.GroupTheory).HasDefaultValueSql("'0'");
                entity.Property(e => e.InstructorId).HasDefaultValueSql("'0'");
                entity.Property(e => e.NumStudents).HasDefaultValueSql("'0'");
                entity.Property(e => e.Semester).HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<ClassAssessment>(entity =>
            {
                entity.HasKey(e => new { e.AssessmentId, e.ClassId, e.LearningOutcomeId }).HasName("PRIMARY");

                entity.HasOne(d => d.Assessment).WithMany(p => p.ClassAssessments)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKcdrm0f8q2dbqmsrwi90lcjthx");

                entity.HasOne(d => d.Class).WithMany(p => p.ClassAssessments)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("classAssessmenet_ClassSession");

                entity.HasOne(d => d.LearningOutcome).WithMany(p => p.ClassAssessments)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("classAssessement_LearingOutcome");
            });

            modelBuilder.Entity<ClassAssessmentCourse>(entity =>
            {
                entity.HasKey(e => new { e.ClassId, e.AssessmentId }).HasName("PRIMARY");

                entity.HasOne(d => d.Assessment).WithMany(p => p.ClassAssessmentCourses)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("classAssessmentCourse_assessement");

                entity.HasOne(d => d.Class).WithMany(p => p.ClassAssessmentCourses)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("classAssessmentCourse_classSession");
            });

            modelBuilder.Entity<ClassSession>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.HasOne(d => d.Course).WithMany(p => p.ClassSessions).HasConstraintName("FK_classSession_course");
            });

            modelBuilder.Entity<ClassSloClo>(entity =>
            {
                entity.HasKey(e => new { e.ClassId, e.CloId, e.SloId }).HasName("PRIMARY");

                entity.HasOne(d => d.Class).WithMany(p => p.ClassSloClos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("classSLOCLO_classSession");

                entity.HasOne(d => d.Clo).WithMany(p => p.ClassSloClos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("classSLOCLO_clo");

                entity.HasOne(d => d.Slo).WithMany(p => p.ClassSloClos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("classSLOCLO_slo");
            });

            modelBuilder.Entity<CloAsiin>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");
            });

            modelBuilder.Entity<CloSlo>(entity =>
            {
                entity.HasOne(d => d.Lo).WithMany()
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_clo_slo_learning_outcome");

                entity.HasOne(d => d.Slo).WithMany().HasConstraintName("fk_clo_slo_slo");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");
            });

            modelBuilder.Entity<CourseAssessment>(entity =>
            {
                entity.HasKey(e => new { e.AssessmentId, e.CourseId }).HasName("PRIMARY");

                entity.HasOne(d => d.Course).WithMany(p => p.CourseAssessments).HasConstraintName("Fk_AssessmentCourse_Course");
            });

            modelBuilder.Entity<CourseAssessmentAsiin>(entity =>
            {
                entity.HasKey(e => new { e.AssessmentId, e.CourseId }).HasName("PRIMARY");
            });

            modelBuilder.Entity<CourseBook>(entity =>
            {
                entity.HasOne(d => d.Book).WithMany().HasConstraintName("FK_BookCourse_Book");

                entity.HasOne(d => d.Course).WithMany().HasConstraintName("FK_BookCourse_Course");
            });

            modelBuilder.Entity<CourseCourseRelationship>(entity =>
            {
                entity.HasOne(d => d.CourseId1Navigation).WithMany().HasConstraintName("FKCourse_Course1");

                entity.HasOne(d => d.CourseId2Navigation).WithMany().HasConstraintName("FKCourse_Course2");

                entity.HasOne(d => d.Relationship).WithMany().HasConstraintName("CourseCourse_CourseRelationship");
            });

            modelBuilder.Entity<CourseDepartment>(entity =>
            {
                entity.HasOne(d => d.Course).WithMany().HasConstraintName("FK_CourseDepartment_Coursre");

                entity.HasOne(d => d.Department).WithMany().HasConstraintName("FK_CourseDepartment_Department");
            });

            modelBuilder.Entity<CourseInstructor>(entity =>
            {
                entity.HasOne(d => d.Course).WithMany().HasConstraintName("FK_CourseInstructor_Course");
            });

            modelBuilder.Entity<CourseLevel>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");
            });

            modelBuilder.Entity<CoursePathway>(entity =>
            {
                entity.HasOne(d => d.Course).WithMany().HasConstraintName("FK_CoursePathway_Course");

                entity.HasOne(d => d.Pathway).WithMany().HasConstraintName("FK_CoursePathway_Pathway");

                entity.HasOne(d => d.Program).WithMany()
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CoursePathway_Program");
            });

            modelBuilder.Entity<CourseProgram>(entity =>
            {
                entity.HasOne(d => d.Course).WithMany().HasConstraintName("FK_CourseProgram_Course");

                entity.HasOne(d => d.CourseType).WithMany().HasConstraintName("FK_CourseProgram_CourseType");

                entity.HasOne(d => d.Program).WithMany().HasConstraintName("FK_CourseProgram_Program");
            });

            modelBuilder.Entity<CourseRelationship>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");
            });

            modelBuilder.Entity<CourseType>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");
            });

            modelBuilder.Entity<Curriculum4yearsTemplate>(entity =>
            {
                entity.ToView("curriculum_4years_template");
            });

            modelBuilder.Entity<Curriculum8semestersTemplate>(entity =>
            {
                entity.ToView("curriculum_8semesters_template");
            });

            modelBuilder.Entity<CurriculumCs4yearItSubjectOnly>(entity =>
            {
                entity.ToView("curriculum_cs_4year_it_subject_only");
            });

            modelBuilder.Entity<CurriculumCsAe14year>(entity =>
            {
                entity.ToView("curriculum_cs_ae1_4years");
            });

            modelBuilder.Entity<CurriculumCsAe18semester>(entity =>
            {
                entity.ToView("curriculum_cs_ae1_8semesters");
            });

            modelBuilder.Entity<CurriculumDsAe14year>(entity =>
            {
                entity.ToView("curriculum_ds_ae1_4years");
            });

            modelBuilder.Entity<CurriculumDsAe18semester>(entity =>
            {
                entity.ToView("curriculum_ds_ae1_8semesters");
            });

            modelBuilder.Entity<CurriculumItceAe14year>(entity =>
            {
                entity.ToView("curriculum_itce_ae1_4years");
            });

            modelBuilder.Entity<CurriculumItceAe18semester>(entity =>
            {
                entity.ToView("curriculum_itce_ae1_8semesters");
            });

            modelBuilder.Entity<CurriculumItneAe14year>(entity =>
            {
                entity.ToView("curriculum_itne_ae1_4years");
            });

            modelBuilder.Entity<CurriculumItneAe18semester>(entity =>
            {
                entity.ToView("curriculum_itne_ae1_8semesters");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");
            });

            modelBuilder.Entity<DepartmentInstructor>(entity =>
            {
                entity.Property(e => e.InstructorId).HasDefaultValueSql("''");

                entity.HasOne(d => d.Department).WithMany().HasConstraintName("FK_DepartmentInstructor_Department");

                entity.HasOne(d => d.Instructor).WithMany().HasConstraintName("FK_department_instructor_instructor");
            });

            modelBuilder.Entity<Discipline>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");
            });

            modelBuilder.Entity<Documentary>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");
            });

            modelBuilder.Entity<Instructor>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.Property(e => e.Id).HasDefaultValueSql("''");
            });

            modelBuilder.Entity<LearningOutcome>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.HasOne(d => d.Course).WithMany(p => p.LearningOutcomes).HasConstraintName("FK_LearningOutcome");
            });

            modelBuilder.Entity<Major>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.HasOne(d => d.Discipline).WithMany(p => p.Majors).HasConstraintName("FK_major_discipline");
            });

            modelBuilder.Entity<Migration>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");
            });

            modelBuilder.Entity<Pathway>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");
            });

            modelBuilder.Entity<Program>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.HasOne(d => d.Major).WithMany(p => p.Programs)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_program_major");

                entity.HasOne(d => d.ProgramType).WithMany(p => p.Programs)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_program_program_type");
            });

            modelBuilder.Entity<ProgramDocument>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.HasOne(d => d.Document).WithMany(p => p.ProgramDocuments).HasConstraintName("FK2");

                entity.HasOne(d => d.Program).WithMany(p => p.ProgramDocuments).HasConstraintName("FK1");
            });

            modelBuilder.Entity<ProgramType>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");
            });

            modelBuilder.Entity<Result>(entity =>
            {
                entity.HasKey(e => new { e.StudentId, e.ClassId }).HasName("PRIMARY");

                entity.HasOne(d => d.Student).WithMany(p => p.Results)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student_Result");
            });

            modelBuilder.Entity<Slo>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");
            });

            modelBuilder.Entity<SyllabusGenerater>(entity =>
            {
                entity.ToView("syllabus_generater");
            });

            modelBuilder.Entity<TelescopeEntriesTag>(entity =>
            {
                entity.HasOne(d => d.EntryUu).WithMany()
                    .HasPrincipalKey(p => p.Uuid)
                    .HasForeignKey(d => d.EntryUuid)
                    .HasConstraintName("telescope_entries_tags_entry_uuid_foreign");
            });

            modelBuilder.Entity<TelescopeEntry>(entity =>
            {
                entity.HasKey(e => e.Sequence).HasName("PRIMARY");

                entity.Property(e => e.ShouldDisplayOnIndex).HasDefaultValueSql("'1'");
            });

            modelBuilder.Entity<Topic>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.HasOne(d => d.Course).WithMany(p => p.Topics).HasConstraintName("fk_topic_course");
            });

            modelBuilder.Entity<TopicDetail>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.HasOne(d => d.Topic).WithMany(p => p.TopicDetails).HasConstraintName("FK_topic_TopicDetail");
            });

            modelBuilder.Entity<TopicType>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.HasOne(d => d.IdNavigation).WithOne(p => p.TopicType).HasConstraintName("FKTopic_TopicType");
            });

            modelBuilder.Entity<TotalCreditsBySemesterC>(entity =>
            {
                entity.ToView("total_credits_by_semester_cs");
            });

            modelBuilder.Entity<TotalCreditsBySemesterD>(entity =>
            {
                entity.ToView("total_credits_by_semester_ds");
            });

            modelBuilder.Entity<TotalCreditsBySemesterItce>(entity =>
            {
                entity.ToView("total_credits_by_semester_itce");
            });

            modelBuilder.Entity<TotalCreditsBySemesterItne>(entity =>
            {
                entity.ToView("total_credits_by_semester_itne");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}