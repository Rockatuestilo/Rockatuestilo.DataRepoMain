using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UoWRepo.Core.BaseDomain;
using UoWRepo.Core.EFDomain;

[Table("SubjectMedia")]
    // Inherits: Guid (PK), CreatedDate, UpdatedDate
    public class SubjectMedia : TEntityGuid
    {
        [Required]
        [Column("SubjectGuid")]
        public Guid SubjectGuid { get; set; }

        [Required]
        [Column("MediaGuid")]
        public Guid MediaGuid { get; set; }

        [Column("IsFeatured")]
        public bool IsFeatured { get; set; } = false;

        [Column("CreatedByGuid")]
        public Guid? CreatedByGuid { get; set; }

        [Column("UpdatedByGuid")]
        public Guid? UpdatedByGuid { get; set; }

        /*// --- Navigation Properties ---

        /// <summary>
        /// El subject al que está vinculado este medio.
        /// Asegúrate de que SubjectsDatamodel tenga:
        /// [InverseProperty(nameof(SubjectMedia.Subject))]
        /// public virtual ICollection&lt;SubjectMedia&gt;? SubjectMediaItems { get; set; }
        /// </summary>
        [ForeignKey(nameof(SubjectGuid))]
        [InverseProperty(nameof(SubjectsDatamodel.SubjectMediaItems))]
        public virtual SubjectsDatamodel? Subject { get; set; }

        /// <summary>
        /// El medio vinculado al subject.
        /// Asegúrate de que Media tenga:
        /// [InverseProperty(nameof(SubjectMedia.Media))]
        /// public virtual ICollection&lt;SubjectMedia&gt;? SubjectMediaItems { get; set; }
        /// </summary>
        [ForeignKey(nameof(MediaGuid))]
        [InverseProperty(nameof(Media.SubjectMediaItems))]
        public virtual Media? Media { get; set; }

        /// <summary>
        /// Opcional: Usuario que creó esta relación.
        /// Asegúrate de que Users tenga:
        /// [InverseProperty(nameof(SubjectMedia.CreatedByUser))]
        /// public virtual ICollection&lt;SubjectMedia&gt;? CreatedSubjectMedia { get; set; }
        /// </summary>
        [ForeignKey(nameof(CreatedByGuid))]
        public virtual Users? CreatedByUser { get; set; }

        /// <summary>
        /// Opcional: Usuario que actualizó esta relación por última vez.
        /// Asegúrate de que Users tenga:
        /// [InverseProperty(nameof(SubjectMedia.UpdatedByUser))]
        /// public virtual ICollection&lt;SubjectMedia&gt;? UpdatedSubjectMedia { get; set; }
        /// </summary>
        [ForeignKey(nameof(UpdatedByGuid))]
        public virtual Users? UpdatedByUser { get; set; }*/
    }