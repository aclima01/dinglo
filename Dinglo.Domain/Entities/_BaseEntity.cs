using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Dinglo.Domain.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
