﻿using System;
using System.Collections.Generic;

namespace KursovayaISP_336.BDModels
{
    public partial class User
    {
        public int Id { get; set; }
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
