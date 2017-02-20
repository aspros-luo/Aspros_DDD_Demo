using Framework.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aspros_DDD_Domain.IdentityItem
{
    public class Identity : IAggregateRoot
    {
        public long Id { get; set; }

        public string Name { get; set; }
    }
}
