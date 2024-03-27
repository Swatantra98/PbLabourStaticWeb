using Microsoft.EntityFrameworkCore;

namespace PbLabourStatic.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DocumentType>().HasData(
                new DocumentType
                {
                    DocumentTypeId = 1,
                    DocumentTypeName = "Act",
                    Active = true,
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now,
                },
                new DocumentType
                {
                    DocumentTypeId = 2,
                    DocumentTypeName = "Rule",
                    Active = true,
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now,
                },
                new DocumentType
                {
                    DocumentTypeId = 3,
                    DocumentTypeName = "News",
                    Active = true,
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now,
                }
            );
        }
    }
}
