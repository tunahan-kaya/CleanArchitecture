using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.EntityConfigurations;

public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.ToTable("Brands").HasKey(b=>b.Id); //hangi tabloya karşılık gelecek?
        /*
            IsRequired() : sütunun NULL değerlere izin vermemesini sağlar.
            hangi kolona karşılık gelecek:     */

        builder.Property(b=>b.Id).HasColumnName("Id").IsRequired(); 
        builder.Property(b => b.Name).HasColumnName("Name").IsRequired();
        builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");

        builder.HasIndex(indexExpression: b=>b.Name, name:"UK_Brands_Name").IsUnique();

        builder.HasMany(b => b.Models); //bire çok ilişki. bir marka bir çok modele sahip olabilir.


        builder.HasQueryFilter(b=>!b.DeletedDate.HasValue);
        /*
            global query
            silinen veri olup olmadığını kontrol ediyor. eğer DeletedDate oluşturulmamış ise veriyi alıyor.
        */
    }
}
