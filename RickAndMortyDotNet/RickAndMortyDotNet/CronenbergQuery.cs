using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interdimensional
{
    public static class CronenbergQuery
    {
        public static Protagonist GetCharacterAsync(int id)
        {
            return Character.GetCharacterAsync(id).GetAwaiter().GetResult();
        }
    }
}
