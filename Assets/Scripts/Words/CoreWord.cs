using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Words
{
    public class CoreWord : AbstractWord
    {
        public float MentalCost {  get; private set; }

        public CoreWord(CoreWordScriptableObject coreWordObject) : base(coreWordObject)
        {
            this.MentalCost = coreWordObject.MentalCost;
        }
    }
}
