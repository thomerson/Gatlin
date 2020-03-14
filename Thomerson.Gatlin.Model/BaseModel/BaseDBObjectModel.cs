using System;
using System.Collections.Generic;
using System.Text;

namespace Thomerson.Gatlin.Model
{
    public class BaseDBObjectModel : BaseDbModel
    {
        public bool Disable { get; set; }
        public bool Deleted { get; set; }
    }
}
