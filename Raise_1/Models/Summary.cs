namespace Raise_1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Summary")]
    public partial class Summary
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int summary_id { get; set; }

        [Required]
        [StringLength(50)]
        public string summary_value { get; set; }

        public int summary_year { get; set; }

        public int topic_id { get; set; }

        [Required]
        [StringLength(50)]
        public string summary_imp { get; set; }

        public virtual Topic Topic { get; set; }
    }
}
