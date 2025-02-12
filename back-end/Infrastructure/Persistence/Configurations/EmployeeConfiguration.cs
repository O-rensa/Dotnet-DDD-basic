using Domain.Employee;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            // primary key
            builder.HasKey(e => e.Id);

            // how to convert Employee.Id
            builder.Property(e => e.Id).HasConversion(
                    id => id.Value,                     // how to persist on database
                    value => new EmployeeId(value)      // how to grab from database
                );

            builder.OwnsOne(e => e.Name, nameBuilder =>
            {
                nameBuilder.Property(n => n.Firstname).IsRequired();

                nameBuilder.Property(n => n.Lastname).IsRequired();
            });

            builder.Property(e => e.Email).IsRequired();

            builder.HasIndex(e => e.Email).IsUnique();
        }
    }
}
