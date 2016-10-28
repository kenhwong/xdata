namespace XDATA.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Reflection;
    using System.Data.Entity.ModelConfiguration;

    public class xDbContext : DbContext
    {
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Star> Stars { get; set; }
        //public virtual DbSet<Model.Perform> Performs { get; set; }
        public virtual DbSet<AvatarFile> AvatarFiles { get; set; }
        public virtual DbSet<SampleFile> SampleFile { get; set; }

        static xDbContext()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<xDbContext>());
        }

        public xDbContext() : base("name = xconn")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Configurations.Add(new Model.MappingMovie());
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => !String.IsNullOrEmpty(type.Namespace))
                .Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }

            base.OnModelCreating(modelBuilder);
        }


        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }    
}