using Microsoft.EntityFrameworkCore;

namespace SuperGMSTemplateModel.supergms_user_db_models
{
    public partial class supergms_userContext : DbContext
    {
        public supergms_userContext()
        {
        }

        public supergms_userContext(DbContextOptions<supergms_userContext> options)
            : base(options)
        {
        }

        public virtual DbSet<LoginLog> LoginLogs { get; set; }
        public virtual DbSet<UserLoginLog> UserLoginLogs { get; set; }
        public virtual DbSet<Userinfo> Userinfos { get; set; }
        public virtual DbSet<Userlogin> Userlogins { get; set; }

        /*  这里是自动生成的链接字符串，这里要删掉，系统走配置文件，不走这里
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("data source=192.168.0.20;port=3306;initial catalog=supergms_user;user id=supergms;password=supergms_*123456", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.3.32-mariadb"));
            }
        }
        */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8_general_ci")
                .HasCharSet("utf8");

            modelBuilder.Entity<LoginLog>(entity =>
            {
                entity.ToTable("login_log");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10)")
                    .HasColumnName("id");

                entity.Property(e => e.ClientType)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("Client_Type");

                entity.Property(e => e.ClientVersion)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("Client_Version");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.LoginDevice)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("Login_Device");

                entity.Property(e => e.LoginIp)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Login_Ip");

                entity.Property(e => e.LoginTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Login_Time");

                entity.Property(e => e.UserId).HasColumnType("int(10)");
            });

            modelBuilder.Entity<UserLoginLog>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("user_login_log");

                entity.Property(e => e.Birthday)
                    .HasColumnType("datetime")
                    .HasComment("出生日期");

                entity.Property(e => e.ClientType)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("Client_Type");

                entity.Property(e => e.ClientVersion)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("Client_Version");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasComment("Email");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10)")
                    .HasColumnName("id");

                entity.Property(e => e.LoginDevice)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("Login_Device");

                entity.Property(e => e.LoginIp)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Login_Ip");

                entity.Property(e => e.LoginTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Login_Time");

                entity.Property(e => e.RealName)
                    .HasMaxLength(40)
                    .HasComment("真实姓名");

                entity.Property(e => e.Sex)
                    .HasColumnType("int(11)")
                    .HasComment("性别 1男 2女");

                entity.Property(e => e.UserId).HasColumnType("int(10)");
            });

            modelBuilder.Entity<Userinfo>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PRIMARY");

                entity.ToTable("userinfo");

                entity.HasIndex(e => e.CreatedDate, "Idx_CreatedDate");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(10)")
                    .ValueGeneratedNever()
                    .HasComment("系统中用户唯一标识");

                entity.Property(e => e.Birthday)
                    .HasColumnType("datetime")
                    .HasComment("出生日期");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .HasComment("创建人");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasComment("创建时间");

                entity.Property(e => e.RealName)
                    .HasMaxLength(40)
                    .HasComment("真实姓名");

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .HasComment("备注");

                entity.Property(e => e.Sex)
                    .HasColumnType("int(11)")
                    .HasComment("性别 1男 2女");

                entity.Property(e => e.Status)
                    .HasColumnType("int(10)")
                    .HasComment("状态 1启用  2禁用");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .HasComment("更新人");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("datetime")
                    .HasComment("更新时间");
            });

            modelBuilder.Entity<Userlogin>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PRIMARY");

                entity.ToTable("userlogin");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(10)")
                    .ValueGeneratedNever()
                    .HasComment("关联UserInfo的UserId");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .HasComment("创建人");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasComment("创建时间");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasComment("Email");

                entity.Property(e => e.LoginPassWord)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("登陆密码");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .HasComment("更新人");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("datetime")
                    .HasComment("更新时间");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
