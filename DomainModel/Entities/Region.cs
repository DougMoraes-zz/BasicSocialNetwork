using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Entities
{
    public class Region : EntityBase
    {
        public virtual Country CountryId { get; set; }
        public virtual State   StateId   { get; set; }
    }
}
