using System.ComponentModel.DataAnnotations.Schema;
using DeanerySystem.DataAccess.Entities;
using DeanerySystem.DataAccess.Entities.Identity;
using DeanerySystem.DataAccess.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeanerySystem.DataAccess.Configurations
{
    class DeanaryUserConfiguration : DbEntityConfiguration<DeaneryUser>
    {
        public override void Configure(EntityTypeBuilder<DeaneryUser> entity)
        {
			entity.ToTable("DeaneryUsers");
            entity.HasKey(du => du.Id);
            entity.Property(du => du.Id).ValueGeneratedOnAdd();
        }
    }
}
