using System;
using System.Collections.Generic;

namespace KursovayaISP_336.BDModels
{
    public partial class Notification
    {
        public int Id { get; set; }
        public int Idrecruit { get; set; }
        public int IsNotification { get; set; }

        public virtual Recruit IdrecruitNavigation { get; set; } = null!;
    }
}
