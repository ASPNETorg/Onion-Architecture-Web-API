using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Models.DomainModels
{
    public class Results :BaseEntity
    {
        [Key]
        public Guid? Id { get; set; }
        public string? ResultStatus { get; set; }
        public Guid? StudentId { get; set; }
        public Student? Students { get; set; }
    }
}
