using BusinessLogicWPF.Model;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogicWPF.Collections
{
    public static class TteCollection
    {
        public static Dictionary<string, string> Choices;

        public static Dictionary<string, string> GetChoices(List<Tte> ttes)
        {
            Choices = ttes.ToDictionary(t => t.TT_ID, t => string.Format(t.F_NAME + " " + t.L_NAME));

            return Choices;
        }
    }
}
