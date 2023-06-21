using System;
using System.Collections.Generic;

namespace KursovayaISP_336.BDModels
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string SecondName { get; set; } = null!;
        public string Patronymic { get; set; } = null!;
    }
}
