using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Football.Models.Enums
{
    public enum CountryEnum
    {
        [Description("Россия")]
        Russia,
        [Description("США")]
        USA,
        [Description("Италия")]
        Italy
    }
}
