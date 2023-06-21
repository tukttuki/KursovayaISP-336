using System;
using System.Collections.Generic;

namespace KursovayaISP_336.BDModels
{
    public partial class FitCategory
    {
        public FitCategory()
        {
            Recruits = new HashSet<Recruit>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Recruit> Recruits { get; set; }
    }
}
