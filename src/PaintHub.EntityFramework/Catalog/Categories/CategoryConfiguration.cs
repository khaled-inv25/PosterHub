using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PosterHub.Domain.Catalog.Categories;
using PosterHub.Domain.Shared.Catalog.Category;

namespace PosterHub.EntityFramework.Catalog.Categories
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasOne(c => c.Parent)
                .WithMany(c => c.Children)
                .HasForeignKey(c => c.ParentCategoryId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(CategoryConsts.MaxNameLength);

            builder.Property(c => c.Description)
                .IsRequired(false)
                .HasMaxLength(CategoryConsts.MaxDescriptionLength);

            builder.Property(c => c.PictureId)
                .HasMaxLength(CategoryConsts.MaxPictureIdLength)
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
}
