﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BackendApi.Models;

public partial class VitalityMasteryContext : DbContext
{
    public VitalityMasteryContext()
    {
    }

    public VitalityMasteryContext(DbContextOptions<VitalityMasteryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Achievement> Achievements { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Dialog> Dialogs { get; set; }

    public virtual DbSet<Friend> Friends { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<GroupMember> GroupMembers { get; set; }

    public virtual DbSet<MessageUser> MessageUsers { get; set; }

    public virtual DbSet<Nutrition> Nutritions { get; set; }

    public virtual DbSet<PhotoUser> PhotoUsers { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Publication> Publications { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    public virtual DbSet<Trainer> Trainers { get; set; }

    public virtual DbSet<TrainersSchedule> TrainersSchedules { get; set; }

    public virtual DbSet<Training> Training { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserNutrition> UserNutritions { get; set; }

    public virtual DbSet<UserToAchievement> UserToAchievements { get; set; }

    public virtual DbSet<UserToDialog> UserToDialogs { get; set; }

    public virtual DbSet<UserToRule> UserToRules { get; set; }

    public virtual DbSet<UserTraining> UserTrainings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Achievement>(entity =>
        {
            entity.HasKey(e => e.AchievementsId).HasName("PK__Achievem__833913348EB6F7EC");

            entity.Property(e => e.AchievementsId).HasColumnName("achievements_id");
            entity.Property(e => e.AchievementsText)
                .HasMaxLength(255)
                .HasColumnName("achievements_text");
            entity.Property(e => e.AchievementsType).HasColumnName("achievements_type");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.CommentsId).HasName("PK__Comments__E059CA99DC324E18");

            entity.HasIndex(e => e.CommentsId, "UQ__Comments__E059CA982AFBB896").IsUnique();

            entity.Property(e => e.CommentsId).HasColumnName("comments_id");
            entity.Property(e => e.CommentsDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("comments_date");
            entity.Property(e => e.CommentsText)
                .HasMaxLength(800)
                .HasColumnName("comments_text");
            entity.Property(e => e.ItemId).HasColumnName("item_id");
            entity.Property(e => e.ItemType).HasColumnName("item_type");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Comments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Comments");
        });

        modelBuilder.Entity<Dialog>(entity =>
        {
            entity.HasKey(e => e.DialogsId).HasName("PK__Dialogs__39AA56DBD0F42E0C");

            entity.Property(e => e.DialogsId).HasColumnName("dialogs_id");
            entity.Property(e => e.EndTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("end_time");
            entity.Property(e => e.TextDialogs)
                .HasMaxLength(500)
                .HasColumnName("text_dialogs");
            entity.Property(e => e.TimeCreate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("time_create");
        });

        modelBuilder.Entity<Friend>(entity =>
        {
            entity.HasKey(e => e.FriendId).HasName("PK__Friend__3FA1E155FC17435C");

            entity.ToTable("Friend");

            entity.HasIndex(e => e.FriendId, "UQ__Friend__3FA1E1544E786DC0").IsUnique();

            entity.HasIndex(e => new { e.UserId1, e.UserId2 }, "UQ__Friend__7482DAF0E16D9C14").IsUnique();

            entity.Property(e => e.FriendId).HasColumnName("friend_id");
            entity.Property(e => e.StartDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("start_date");
            entity.Property(e => e.UserId1).HasColumnName("user_id_1");
            entity.Property(e => e.UserId2).HasColumnName("user_id_2");

            entity.HasOne(d => d.UserId1Navigation).WithMany(p => p.Friends)
                .HasForeignKey(d => d.UserId1)
                .HasConstraintName("FK_Friend_1");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.GroupsId).HasName("PK__Groups__54CA4F67F69A76BB");

            entity.HasIndex(e => e.OwnerGroups, "UQ__Groups__FEBE0EE76EE8C9F0").IsUnique();

            entity.Property(e => e.GroupsId).HasColumnName("groups_id");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("create_date");
            entity.Property(e => e.GroupsName)
                .HasMaxLength(55)
                .HasColumnName("groups_name");
            entity.Property(e => e.OwnerGroups).HasColumnName("owner_groups");
            entity.Property(e => e.UpdateGroups)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("update_groups");

            entity.HasOne(d => d.OwnerGroupsNavigation).WithOne(p => p.Group)
                .HasForeignKey<Group>(d => d.OwnerGroups)
                .HasConstraintName("FK_Groups_Owner");
        });

        modelBuilder.Entity<GroupMember>(entity =>
        {
            entity.HasKey(e => e.GroupsId).HasName("PK__GroupMem__54CA4F6771C540AD");

            entity.Property(e => e.GroupsId)
                .ValueGeneratedNever()
                .HasColumnName("groups_id");
            entity.Property(e => e.JoinDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Groups).WithOne(p => p.GroupMember)
                .HasForeignKey<GroupMember>(d => d.GroupsId)
                .HasConstraintName("Fk_GroupMember_1");

            entity.HasOne(d => d.User).WithMany(p => p.GroupMembers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_GroupMember_2");
        });

        modelBuilder.Entity<MessageUser>(entity =>
        {
            entity.HasKey(e => e.MessageId).HasName("PK__MessageU__C87C037C291336D8");

            entity.Property(e => e.MessageId).HasColumnName("MessageID");
            entity.Property(e => e.DateMessage)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("date_message");
            entity.Property(e => e.DateUpMessage)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("date_up_message");
            entity.Property(e => e.MessageContent)
                .HasMaxLength(255)
                .HasColumnName("message_content");
            entity.Property(e => e.ReceiverId).HasColumnName("ReceiverID");
            entity.Property(e => e.SenderId).HasColumnName("SenderID");

            entity.HasOne(d => d.Receiver).WithMany(p => p.MessageUserReceivers)
                .HasForeignKey(d => d.ReceiverId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Message_2");

            entity.HasOne(d => d.Sender).WithMany(p => p.MessageUserSenders)
                .HasForeignKey(d => d.SenderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Message_1");
        });

        modelBuilder.Entity<Nutrition>(entity =>
        {
            entity.HasKey(e => e.NutritionId).HasName("PK__Nutritio__147CC3A2A62ED9EB");

            entity.ToTable("Nutrition");

            entity.Property(e => e.NutritionId).HasColumnName("nutrition_id");
            entity.Property(e => e.DateNutrition).HasColumnName("date_nutrition");
            entity.Property(e => e.MeanDeacription)
                .HasMaxLength(255)
                .HasColumnName("mean_deacription");
            entity.Property(e => e.MeanType)
                .HasMaxLength(255)
                .HasColumnName("mean_type");

            entity.HasOne(d => d.ProductNavigation).WithMany(p => p.Nutritions)
                .HasForeignKey(d => d.Product)
                .HasConstraintName("FK_Nutration");
        });

        modelBuilder.Entity<PhotoUser>(entity =>
        {
            entity.HasKey(e => e.PhotoId).HasName("PK__PhotoUse__21B7B582ECEDE671");

            entity.Property(e => e.PhotoId).HasColumnName("PhotoID");
            entity.Property(e => e.PhotoLink).HasMaxLength(255);
            entity.Property(e => e.UploadPhoto)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("upload_photo");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.PhotoUsers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("Fk_PhotoUser");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__B40CC6ED9C4445BF");

            entity.HasIndex(e => e.Product1, "UQ__Products__A2A64E92A9A004B0").IsUnique();

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Calories).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.CarbsPer).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.FatPer).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.NutritionalValue)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Product1)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Product");
            entity.Property(e => e.ProteinPer).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.VitaminsAndMinerals)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Publication>(entity =>
        {
            entity.HasKey(e => e.PublicationsId).HasName("PK__Publicat__CE2F37DC8509188E");

            entity.ToTable("Publication");

            entity.HasIndex(e => e.PublicationsId, "UQ__Publicat__CE2F37DD2ABCC851").IsUnique();

            entity.Property(e => e.PublicationsId).HasColumnName("publications_id");
            entity.Property(e => e.PublicationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("publication_date");
            entity.Property(e => e.PublicationText)
                .HasMaxLength(500)
                .HasColumnName("publication_text");
            entity.Property(e => e.PublicationsImage)
                .HasMaxLength(255)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("publications_image");
            entity.Property(e => e.UsersId).HasColumnName("users_id");

            entity.HasOne(d => d.Users).WithMany(p => p.Publications)
                .HasForeignKey(d => d.UsersId)
                .HasConstraintName("FK_Publication");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Roles__3213E83F24C91117");

            entity.HasIndex(e => e.Id, "UQ__Roles__3213E83EE86A8FB9").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Role1)
                .HasMaxLength(50)
                .HasColumnName("role");
        });

        modelBuilder.Entity<Schedule>(entity =>
        {
            entity.HasKey(e => e.ScheduleId).HasName("PK__Schedule__C46A8A6F001C1753");

            entity.ToTable("Schedule");

            entity.Property(e => e.ScheduleId).HasColumnName("schedule_id");
            entity.Property(e => e.DayOfWeek)
                .HasMaxLength(20)
                .HasColumnName("day_of_week");
            entity.Property(e => e.EndTime).HasColumnName("end_time");
            entity.Property(e => e.StartTime).HasColumnName("start_time");
            entity.Property(e => e.TrainerId).HasColumnName("trainer_id");
            entity.Property(e => e.TrainingId).HasColumnName("training_id");
            entity.Property(e => e.TrainingType).HasMaxLength(255);
        });

        modelBuilder.Entity<Trainer>(entity =>
        {
            entity.HasKey(e => e.TrainerId).HasName("PK__Trainer__65A4B6291F5BDAC1");

            entity.ToTable("Trainer");

            entity.HasIndex(e => new { e.TrainerId, e.UserId }, "UQ__Trainer__8E3F5558B9A95249").IsUnique();

            entity.Property(e => e.TrainerId).HasColumnName("trainer_id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("create_at");
            entity.Property(e => e.Email)
                .HasMaxLength(32)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("last_name");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(255)
                .HasColumnName("middle_name");
            entity.Property(e => e.Password)
                .HasMaxLength(32)
                .HasColumnName("password");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(32)
                .HasColumnName("phone_number");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Trainers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Trainer");
        });

        modelBuilder.Entity<TrainersSchedule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Trainers__3213E83F928DF0C8");

            entity.ToTable("TrainersSchedule");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("create_at");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.ScheduleId).HasColumnName("schedule_id");
            entity.Property(e => e.Time).HasColumnName("time");
            entity.Property(e => e.TrainerId).HasColumnName("trainer_id");
            entity.Property(e => e.TypeOfTraining)
                .HasMaxLength(50)
                .HasColumnName("type_of_training");

            entity.HasOne(d => d.Schedule).WithMany(p => p.TrainersSchedules)
                .HasForeignKey(d => d.ScheduleId)
                .HasConstraintName("FK_TrainersSchedule_2");

            entity.HasOne(d => d.Trainer).WithMany(p => p.TrainersSchedules)
                .HasForeignKey(d => d.TrainerId)
                .HasConstraintName("FK_TrainersSchedule_1");
        });

        modelBuilder.Entity<Training>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Training__3213E83F5D0AC0A2");

            entity.HasIndex(e => e.TrainingId, "UQ__Training__2F28D08ED07AEC33").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CaloriesBurned).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.DurationMinutes).HasMaxLength(255);
            entity.Property(e => e.Notes).HasMaxLength(255);
            entity.Property(e => e.TrainingDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.TrainingId).HasColumnName("training_id");
            entity.Property(e => e.TrainingType).HasMaxLength(255);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__B9BE370FE477DE7B");

            entity.HasIndex(e => e.UserId, "UQ__Users__B9BE370E5A3ABD8E").IsUnique();

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("user_id");
            entity.Property(e => e.AboutMe).HasMaxLength(255);
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("create_at");
            entity.Property(e => e.Email)
                .HasMaxLength(32)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(32)
                .HasColumnName("password");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(255)
                .HasColumnName("phone_number");
            entity.Property(e => e.RoleUser)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("role_user");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("update_at");
            entity.Property(e => e.UserImg)
                .HasMaxLength(255)
                .HasColumnName("user_img");
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .HasColumnName("user_name");
        });

        modelBuilder.Entity<UserNutrition>(entity =>
        {
            entity.HasKey(e => e.UserNutritionId).HasName("PK__UserNutr__53483C7181425DBD");

            entity.ToTable("UserNutrition");

            entity.Property(e => e.UserNutritionId).HasColumnName("user_nutrition_id");
            entity.Property(e => e.AppointmentTime).HasColumnName("appointment_time");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("create_at");
            entity.Property(e => e.DateOfAdmission).HasColumnName("date_of_admission");
            entity.Property(e => e.NutritionId).HasColumnName("nutrition_id");
            entity.Property(e => e.NutritionType)
                .HasMaxLength(255)
                .HasColumnName("nutrition_type");
            entity.Property(e => e.Report)
                .HasMaxLength(255)
                .HasColumnName("report");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Nutrition).WithMany(p => p.UserNutritions)
                .HasForeignKey(d => d.NutritionId)
                .HasConstraintName("FK_UserNutration_2");

            entity.HasOne(d => d.User).WithMany(p => p.UserNutritions)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_UserNutration_1");
        });

        modelBuilder.Entity<UserToAchievement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User_to___3213E83F7A3F286E");

            entity.ToTable("User_to_achievements");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AchievementsId).HasColumnName("achievements_id");
            entity.Property(e => e.GetDateAchievements)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("get_date_achievements");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Achievements).WithMany(p => p.UserToAchievements)
                .HasForeignKey(d => d.AchievementsId)
                .HasConstraintName("FK_UserAchievements_2");

            entity.HasOne(d => d.User).WithMany(p => p.UserToAchievements)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_UserAchievements_1");
        });

        modelBuilder.Entity<UserToDialog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User_to___3213E83FB22E8262");

            entity.ToTable("User_to_dialogs");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DialogId).HasColumnName("dialog_id");
            entity.Property(e => e.TimeCreate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("time_create");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Dialog).WithMany(p => p.UserToDialogs)
                .HasForeignKey(d => d.DialogId)
                .HasConstraintName("FK_Dialogs");

            entity.HasOne(d => d.User).WithMany(p => p.UserToDialogs)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_UserDialogs");
        });

        modelBuilder.Entity<UserToRule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User_to___3213E83F58C53065");

            entity.ToTable("User_to_rule");

            entity.HasIndex(e => e.Id, "UQ__User_to___3213E83E415D1963").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Role).WithMany(p => p.UserToRules)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_role_2");

            entity.HasOne(d => d.User).WithMany(p => p.UserToRules)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_role");
        });

        modelBuilder.Entity<UserTraining>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserTrai__3213E83F139E5454");

            entity.ToTable("UserTraining");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DayOfWeek)
                .HasMaxLength(50)
                .HasColumnName("day_of_week");
            entity.Property(e => e.Duration)
                .HasMaxLength(30)
                .HasColumnName("duration");
            entity.Property(e => e.EndAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("end_at");
            entity.Property(e => e.Notes)
                .HasMaxLength(255)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("notes");
            entity.Property(e => e.StartAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("start_at");
            entity.Property(e => e.TrainerId)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("trainer_id");
            entity.Property(e => e.TrainingId).HasColumnName("training_id");
            entity.Property(e => e.TrainingStatus)
                .HasMaxLength(20)
                .HasColumnName("training_status");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Trainer).WithMany(p => p.UserTrainings)
                .HasForeignKey(d => d.TrainerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_UserTraining_1");

            entity.HasOne(d => d.Training).WithMany(p => p.UserTrainings)
                .HasPrincipalKey(p => p.TrainingId)
                .HasForeignKey(d => d.TrainingId)
                .HasConstraintName("FK_UserTraining_3");

            entity.HasOne(d => d.User).WithMany(p => p.UserTrainings)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserTraining_2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
