using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    /// <summary>
    /// Represents background info of a client as entity in database
    /// </summary>
    public class BackgroundInfo : BaseEntity
    {
        public int ClientId { get; set; }

        [ForeignKey(nameof(ClientId))]
        public virtual Client Client { get; set; }
        
        public string Text { get; set; }

        public DateTime Date { get; set; }
    }
}