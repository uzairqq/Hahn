using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Hahn.ApplicatonProcess.May2020.Domain
{
    public class BaseEntity
    {
        public int Id { get; set; }

        [DefaultValue(10023)]
        public int CreatedById { get; set; }


        public DateTime CreatedOn { get; set; }

        [DefaultValue(10023)]
        public int LastUpdatedById { get; set; }
        [DefaultValue(10024)]
        public DateTime LastUpdatedOn { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }
}
