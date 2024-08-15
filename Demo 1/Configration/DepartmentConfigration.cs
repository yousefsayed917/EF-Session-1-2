using Demo.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Configration
{
    internal class DepartmentConfigration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(p => p.DeptId);
            builder.Property(p => p.DeptId).UseIdentityColumn(10, 10);
            builder.Property(p => p.Name).HasColumnName("DeptName")
                   .HasColumnType("Varchar").HasMaxLength(50);

        }
    }
}
