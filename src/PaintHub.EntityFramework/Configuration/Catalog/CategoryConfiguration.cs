using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PosterHub.Domain.Catalog.Categories;
using PosterHub.Domain.Shared.Catalog.Category;

namespace PosterHub.EntityFramework.Configuration.Catalog
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasOne(c => c.Parent)
                .WithMany(c => c.Children)
                .HasForeignKey(c => c.ParentCategoryId)
                .OnDelete(DeleteBehavior.NoAction);
           
            builder.HasOne(c => c.MediaFile)
                .WithMany()
                .HasForeignKey(c => c.MediaFiledId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(CategoryConsts.MaxNameLength);

            builder.Property(c => c.FullName)
                .IsRequired(false)
                .HasMaxLength(CategoryConsts.MaxFullNameLength);

            builder.Property(c => c.Description)
                .IsRequired(false);

            builder.Property(c => c.BadegStyle)
                .IsRequired();

            builder.Property(c => c.BadgeText)
                .IsRequired(false)
                .HasMaxLength(CategoryConsts.MaxBadgeTextLength);

            builder.Property(c => c.MetaTitle)
                .IsRequired(false)
                .HasMaxLength(CategoryConsts.MaxMetaTitleLength);
            
            builder.Property(c => c.MetaDescription)
                .IsRequired(false)
                .HasMaxLength(CategoryConsts.MaxDescriptionLength);

            builder.Property(c => c.ShowOnMenu)
                .IsRequired();
            
            builder.Property(c => c.ShowOnHomePage)
                .IsRequired();
            
            builder.Property(c => c.SubjectToAcl)
                .IsRequired();
            
            builder.Property(c => c.Published)
                .IsRequired();
        }
    }

    /*
    internal class CategorySeed : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(Seed());
        }

        public Category[] Seed()
        {
            Category[] categories =
            [
                new Category()
                {
                    Id = 1,
                    TreePath ="/1/",
                    Name = "Electronic",
                    FullName = "Electronic",
                    Description = "Description",
                    //BadgeText = null,
                    BadegStyle = BadgeStyle.None,
                    //MetaTitle = null,
                    //MetaDescription = null,
                    //MediaFiledId = null,
                    ShowOnMenu = true,
                    ShowOnHomePage = true,
                    SubjectToAcl = false,
                    Published = true
                },
            ];
            return categories;
        }
    }
    */
}
