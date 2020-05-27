using System;
using System.Collections.Generic;
using System.Text;

namespace Hahn.ApplicationProcess.May2020.Core.Models
{
    public class BaseEntity : IEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
