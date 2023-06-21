using System;
using System.Collections.Generic;

namespace KursovayaISP_336.BDModels
{
    public partial class Recruit
    {
        public Recruit()
        {
            Notifications = new HashSet<Notification>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string SecondName { get; set; } = null!;
        public string Patronymic { get; set; } = null!;
        public int Fit { get; set; }

        public virtual FitCategory FitNavigation { get; set; } = null!;
        public virtual ICollection<Notification> Notifications { get; set; }
    }
}
