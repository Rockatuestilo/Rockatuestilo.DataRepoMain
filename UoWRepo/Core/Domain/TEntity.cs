﻿using LinqToDB.Mapping;
using System;

namespace UoWRepo.Core.Domain
{
    [Obsolete]
    public class TEntity 
    {
        [PrimaryKey, Identity]
        [Column(Name = "Id"), NotNull]
        public int Id { get; set; }
        public DateTime UpdatedDate { get; set; }


    }
}
