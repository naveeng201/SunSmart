using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SunsmartAWSServerless.EntityModels
{
    public partial class SunsmartContext : DbContext
    {
        public SunsmartContext()
        {
        }

        public SunsmartContext(DbContextOptions<SunsmartContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TCatalogue> Catalogue { get; set; }
        public virtual DbSet<TCompanies> Companies { get; set; }
        public virtual DbSet<TCompanysalesagreement> Companysalesagreement { get; set; }
        public virtual DbSet<TCustomer> Customer { get; set; }
        public virtual DbSet<TMeasurements> Measurements { get; set; }
        public virtual DbSet<TProjectdocuments> Projectdocuments { get; set; }
        public virtual DbSet<TProjectphotos> Projectphotos { get; set; }
        public virtual DbSet<TProjects> Projects { get; set; }
        public virtual DbSet<TRoles> Roles { get; set; }
        public virtual DbSet<TScreens> Screens { get; set; }
        public virtual DbSet<TSubscriptionmodel> Subscriptionmodel { get; set; }
        public virtual DbSet<TTransactions> Transactions { get; set; }
        public virtual DbSet<TUseraddress> Useraddress { get; set; }
        public virtual DbSet<TUserbankdetails> Userbankdetails { get; set; }
        public virtual DbSet<TUserlocation> Userlocation { get; set; }
        public virtual DbSet<TUsers> Users { get; set; }
        public virtual DbSet<TWindowsfunctionality> Windowsfunctionality { get; set; }
        public virtual DbSet<TWindowsShape> WindowsShape { get; set; }
        public virtual DbSet<TWorkflow> Workflow { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=sunsmart;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TCatalogue>(entity =>
            {
                entity.HasKey(e => e.Itemid);

                entity.ToTable("t_catalogue");

                entity.Property(e => e.Itemid).HasColumnName("itemid");

                entity.Property(e => e.Companyid).HasColumnName("companyid");

                entity.Property(e => e.Isactive)
                    .HasColumnName("isactive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Itemdesc)
                    .HasColumnName("itemdesc")
                    .HasMaxLength(1024);

                entity.Property(e => e.Itemname)
                    .HasColumnName("itemname")
                    .HasMaxLength(50);

                entity.Property(e => e.Itempic).HasColumnName("itempic");

                entity.Property(e => e.Itemprice)
                    .HasColumnName("itemprice")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Winshapeid).HasColumnName("winshapeid");
            });

            modelBuilder.Entity<TCompanies>(entity =>
            {
                entity.HasKey(e => e.Companyid);

                entity.ToTable("t_companies");

                entity.Property(e => e.Companyid).HasColumnName("companyid");

                entity.Property(e => e.Accnumber)
                    .HasColumnName("accnumber")
                    .HasMaxLength(15);

                entity.Property(e => e.Bankname)
                    .HasColumnName("bankname")
                    .HasMaxLength(50);

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(50);

                entity.Property(e => e.Companydesc)
                    .HasColumnName("companydesc")
                    .HasMaxLength(1024);

                entity.Property(e => e.Companylogo).HasColumnName("companylogo");

                entity.Property(e => e.Companyname)
                    .HasColumnName("companyname")
                    .HasMaxLength(50);

                entity.Property(e => e.Companysuitnumber).HasColumnName("companysuitnumber");

                entity.Property(e => e.Routingnumber)
                    .HasColumnName("routingnumber")
                    .HasMaxLength(15);

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasMaxLength(50);

                entity.Property(e => e.Streetname)
                    .HasColumnName("streetname")
                    .HasMaxLength(50);

                entity.Property(e => e.Zip)
                    .HasColumnName("zip")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<TCompanysalesagreement>(entity =>
            {
                entity.HasKey(e => e.Agreementid);

                entity.ToTable("t_companysalesagreement");

                entity.Property(e => e.Agreementid).HasColumnName("agreementid");

                entity.Property(e => e.Agreement).HasColumnName("agreement");

                entity.Property(e => e.Companyint).HasColumnName("companyint");
            });

            modelBuilder.Entity<TCustomer>(entity =>
            {
                entity.HasKey(e => e.Customerid);

                entity.ToTable("t_customer");

                entity.Property(e => e.Customerid).HasColumnName("customerid");

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(50);

                entity.Property(e => e.Emailid)
                    .HasColumnName("emailid")
                    .HasMaxLength(50);

                entity.Property(e => e.Firstname)
                    .HasColumnName("firstname")
                    .HasMaxLength(50);

               // entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.Lastname)
                    .HasColumnName("lastname")
                    .HasMaxLength(50);

                entity.Property(e => e.Licensenumber)
                    .HasColumnName("licensenumber")
                    .HasMaxLength(15);

                entity.Property(e => e.Middlename)
                    .HasColumnName("middlename")
                    .HasMaxLength(50);

                entity.Property(e => e.Mobilenumber)
                    .HasColumnName("mobilenumber")
                    .HasMaxLength(15);

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasMaxLength(50);

                entity.Property(e => e.Street)
                    .HasColumnName("street")
                    .HasMaxLength(50);

                entity.Property(e => e.Suitnumber)
                    .HasColumnName("suitnumber")
                    .HasMaxLength(10);

                entity.Property(e => e.Zipcode)
                    .HasColumnName("zipcode")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<TMeasurements>(entity =>
            {
                entity.HasKey(e => e.Measurementid);

                entity.ToTable("t_measurements");

                entity.Property(e => e.Measurementid).HasColumnName("measurementid");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Height)
                    .HasColumnName("height")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Isactive)
                    .HasColumnName("isactive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Itemid).HasColumnName("itemid");

                entity.Property(e => e.Projectid).HasColumnName("projectid");

                entity.Property(e => e.Width)
                    .HasColumnName("width")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Windowpic).HasColumnName("windowpic");

                entity.Property(e => e.Winfuncid).HasColumnName("winfuncid");

                entity.Property(e => e.Winshapeid).HasColumnName("winshapeid");
            });

            modelBuilder.Entity<TProjectdocuments>(entity =>
            {
                entity.HasKey(e => e.Docid);

                entity.ToTable("t_projectdocuments");

                entity.Property(e => e.Docid).HasColumnName("docid");

                entity.Property(e => e.Docextention)
                    .HasColumnName("docextention")
                    .HasMaxLength(6);

                entity.Property(e => e.Doctype)
                    .HasColumnName("doctype")
                    .HasMaxLength(10);

                entity.Property(e => e.Document).HasColumnName("document");

                entity.Property(e => e.Projectid).HasColumnName("projectid");
            });

            modelBuilder.Entity<TProjectphotos>(entity =>
            {
                entity.HasKey(e => e.Photoid);

                entity.ToTable("t_projectphotos");

                entity.Property(e => e.Photoid).HasColumnName("photoid");

                entity.Property(e => e.Photo).HasColumnName("photo");

                entity.Property(e => e.Photodesc)
                    .HasColumnName("photodesc")
                    .HasMaxLength(1024);

                entity.Property(e => e.Projectid).HasColumnName("projectid");
            });

            modelBuilder.Entity<TProjects>(entity =>
            {
                entity.HasKey(e => e.Projectid);

                entity.ToTable("t_projects");

                entity.Property(e => e.Projectid).HasColumnName("projectid");

                entity.Property(e => e.Companyid).HasColumnName("companyid");

                entity.Property(e => e.Customerid).HasColumnName("customerid");

                entity.Property(e => e.Enddate)
                    .HasColumnName("enddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Handymanid).HasColumnName("handymanid");

                entity.Property(e => e.Isactive)
                    .HasColumnName("isactive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Laborcost)
                    .HasColumnName("laborcost")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Materialcost)
                    .HasColumnName("materialcost")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Projectdesc)
                    .HasColumnName("projectdesc")
                    .HasMaxLength(1024);

                entity.Property(e => e.Salesmanid).HasColumnName("salesmanid");

                entity.Property(e => e.Startdate)
                    .HasColumnName("startdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Workflowid).HasColumnName("workflowid");
            });

            modelBuilder.Entity<TRoles>(entity =>
            {
                entity.HasKey(e => e.Roleid);

                entity.ToTable("t_roles");

                entity.Property(e => e.Roleid).HasColumnName("roleid");

                entity.Property(e => e.Allowedscreenids)
                    .IsRequired()
                    .HasColumnName("allowedscreenids")
                    .HasMaxLength(100);

                entity.Property(e => e.Rolename)
                    .IsRequired()
                    .HasColumnName("rolename")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TScreens>(entity =>
            {
                entity.HasKey(e => e.Screenid);

                entity.ToTable("t_screens");

                entity.Property(e => e.Screenid).HasColumnName("screenid");

                entity.Property(e => e.Screenname).HasColumnName("screenname");
            });

            modelBuilder.Entity<TSubscriptionmodel>(entity =>
            {
                entity.HasKey(e => e.Subscriptionid);

                entity.ToTable("t_subscriptionmodel");

                entity.Property(e => e.Subscriptionid).HasColumnName("subscriptionid");

                entity.Property(e => e.Companyint).HasColumnName("companyint");

                entity.Property(e => e.Numberofsalespersons).HasColumnName("numberofsalespersons");

                entity.Property(e => e.Numberofyears).HasColumnName("numberofyears");

                entity.Property(e => e.Subscriptionamout)
                    .HasColumnName("subscriptionamout")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TTransactions>(entity =>
            {
                entity.HasKey(e => e.Transid);

                entity.ToTable("t_transactions");

                entity.Property(e => e.Transid).HasColumnName("transid");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Companyid).HasColumnName("companyid");

                entity.Property(e => e.Customerid).HasColumnName("customerid");

                entity.Property(e => e.Transdate)
                    .HasColumnName("transdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Transdesc)
                    .HasColumnName("transdesc")
                    .HasMaxLength(250);

                entity.Property(e => e.Userid).HasColumnName("userid");
            });

            modelBuilder.Entity<TUseraddress>(entity =>
            {
                entity.HasKey(e => e.Recordid);

                entity.ToTable("t_useraddress");

                entity.Property(e => e.Recordid).HasColumnName("recordid");

                entity.Property(e => e.Apptnumber)
                    .IsRequired()
                    .HasColumnName("apptnumber")
                    .HasMaxLength(15);

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(30);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasColumnName("state")
                    .HasMaxLength(30);

                entity.Property(e => e.Street)
                    .HasColumnName("street")
                    .HasMaxLength(50);

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.Property(e => e.Zipcode)
                    .IsRequired()
                    .HasColumnName("zipcode")
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<TUserbankdetails>(entity =>
            {
                entity.HasKey(e => e.Recordid);

                entity.ToTable("t_userbankdetails");

                entity.Property(e => e.Recordid).HasColumnName("recordid");

                entity.Property(e => e.Acctnumber)
                    .HasColumnName("acctnumber")
                    .HasMaxLength(30);

                entity.Property(e => e.Bankname)
                    .IsRequired()
                    .HasColumnName("bankname")
                    .HasMaxLength(30);

                entity.Property(e => e.Routingnumber)
                    .HasColumnName("routingnumber")
                    .HasMaxLength(30);

                entity.Property(e => e.Userid).HasColumnName("userid");
            });

            modelBuilder.Entity<TUserlocation>(entity =>
            {
                entity.HasKey(e => e.Userid);

                entity.ToTable("t_userlocation");

                entity.Property(e => e.Userid)
                    .HasColumnName("userid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Latitude)
                    .HasColumnName("latitude")
                    .HasMaxLength(50);

                entity.Property(e => e.Longitude)
                    .HasColumnName("longitude")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TUsers>(entity =>
            {
                entity.HasKey(e => e.Userid);

                entity.ToTable("t_users");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.Property(e => e.Companyid).HasColumnName("companyid");

                entity.Property(e => e.Emailid)
                    .IsRequired()
                    .HasColumnName("emailid")
                    .HasMaxLength(50);

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnName("firstname")
                    .HasMaxLength(50);

                entity.Property(e => e.Lastname)
                    .HasColumnName("lastname")
                    .HasMaxLength(50);

                entity.Property(e => e.Middlename)
                    .HasColumnName("middlename")
                    .HasMaxLength(50);

                entity.Property(e => e.Mobilenumber)
                    .IsRequired()
                    .HasColumnName("mobilenumber")
                    .HasMaxLength(15);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(100);

                entity.Property(e => e.Roleid).HasColumnName("roleid");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.TUsers)
                    .HasForeignKey(d => d.Companyid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CompanyId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.TUsers)
                    .HasForeignKey(d => d.Roleid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_RoleId");
            });

            modelBuilder.Entity<TWindowsfunctionality>(entity =>
            {
                entity.HasKey(e => e.Winfuncid);

                entity.ToTable("t_windowsfunctionality");

                entity.Property(e => e.Winfuncid).HasColumnName("winfuncid");

                entity.Property(e => e.Functionalityname)
                    .HasColumnName("functionalityname")
                    .HasMaxLength(50);

                entity.Property(e => e.Isactive)
                    .HasColumnName("isactive")
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<TWindowsShape>(entity =>
            {
                entity.HasKey(e => e.Winshapeid);

                entity.ToTable("t_windowsShape");

                entity.Property(e => e.Winshapeid).HasColumnName("winshapeid");

                entity.Property(e => e.Companyid).HasColumnName("companyid");

                entity.Property(e => e.Isactive)
                    .HasColumnName("isactive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Windowdesc)
                    .HasColumnName("windowdesc")
                    .HasMaxLength(1024);

                entity.Property(e => e.Windowpic).HasColumnName("windowpic");

                entity.Property(e => e.Windowshapename)
                    .HasColumnName("windowshapename")
                    .HasMaxLength(50);

                entity.Property(e => e.Winfuncid).HasColumnName("winfuncid");
            });

            modelBuilder.Entity<TWorkflow>(entity =>
            {
                entity.HasKey(e => e.Workflowid);

                entity.ToTable("t_workflow");

                entity.Property(e => e.Workflowid).HasColumnName("workflowid");

                entity.Property(e => e.Workflowname)
                    .HasColumnName("workflowname")
                    .HasMaxLength(50);
            });
        }
    }
}
