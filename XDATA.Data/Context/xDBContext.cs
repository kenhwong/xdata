using System;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Configuration;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.Validation;
using System.Text;

namespace XDATA.Data
{
    public class xDbContext : DbContext
    {
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Star> Stars { get; set; }
        //public virtual DbSet<Model.Perform> Performs { get; set; }
        public virtual DbSet<AvatarFile> AvatarFiles { get; set; }
        public virtual DbSet<SampleFile> SampleFile { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }

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


        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["xconn"].ConnectionString;
        }


        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var sb = new StringBuilder();
                foreach (var error in ex.EntityValidationErrors)
                {
                    foreach (var item in error.ValidationErrors)
                    {
                        sb.AppendLine(item.PropertyName + ": " + item.ErrorMessage);
                    }
                }
                Logger.Error("SaveChanges.DbEntityValidation", ex.GetAllMessages() + sb);
                throw;
            }
        }
    }    
}