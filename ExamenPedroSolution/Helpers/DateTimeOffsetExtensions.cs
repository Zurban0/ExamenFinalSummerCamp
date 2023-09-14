using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public static class DateTimeOffsetExtensions
    {

        public static int GetCurrentAge(this DateTime? dateTime)
        {
            int age = 0; // Valor predeterminado

            if (dateTime != null)
            {
                DateTime fecha = dateTime.Value;
                var currentDate = DateTime.UtcNow;
                age = currentDate.Year - fecha.Year;

                if (currentDate < fecha.AddYears(age))
                {
                    age--;
                }
            }

            return age;
        }
    }
}
