using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Domain.Entities
{
    public abstract class Entity
    {
        public int ID { get; protected set; }
    }
}
