using DAL.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    /// <summary>
    /// Represents user entity in database
    /// </summary>
    public class User : BaseEntity
    {
        public string Name { get; set; }

        public DateTime Birth { get; set; }

        public Gender Gender { get; set; }

        [Column("Password")]
        public string PasswordHash { get; set; }

        public virtual Administrator Administrator { get; set; }

        public virtual Client Client { get; set; }

        public virtual Director Director { get; set; }

        public virtual InsuranceAgent InsuranceAgent { get; set; }
    }
}