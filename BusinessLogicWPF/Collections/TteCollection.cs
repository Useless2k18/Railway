using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogicWPF.Collections
{
    public static class TteCollection
    {
        public static Dictionary<string, string> Choices;
        
        public static Dictionary<string, string> GetChoices()
        {
            Choices = new Dictionary<string, string>
            {
                {"1", "Anil Kumar"},
                {"2", "Bijay Mahato"},
                {"3", "Suresh Singh"},
                {"4", "Niranjan Patra"}
            };

            return Choices;
        }
    }
}
