using ActivityConnect.Core.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ActivityConnect.DataAccess.EntityFrameworkCore.Configurations;

public class DocumentConfiguration : IEntityTypeConfiguration<Document>
{
    public void Configure(EntityTypeBuilder<Document> builder)
    {
        builder.HasKey(_document => _document.Id);

        builder.Property(_document => _document.Id)
            .HasColumnOrder(0);

        builder.Property(_document => _document.Name)
           .HasColumnOrder(1)
           .IsRequired();

        builder.Property(_document => _document.ContentType)
            .HasColumnOrder(2);

        builder.Property(_document => _document.Url)
          .HasColumnOrder(3)
          .IsRequired();
    }
}
