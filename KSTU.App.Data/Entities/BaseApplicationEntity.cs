using System;
using System.ComponentModel.DataAnnotations;

namespace KSTU.App.Data.Entities
{
    public class BaseApplicationEntity
    {
        [Key]
        public long Id { get; set; }
        public DateTime CreateTimeStamp { get; set; }
        public DateTime UpdateTimeStamp { get; set; }
        public long CreateUserId { get; set; }
        public long UpdateUserId { get; set; }
    }
}