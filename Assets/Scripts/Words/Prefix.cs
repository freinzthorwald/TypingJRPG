using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Words
{
    public class Prefix : AbstractWord
    {
        public float PowerModifier { get; private set; }
        public float MentalCostModifier {  get; private set; }

        public Prefix(PrefixScriptableObject prefixObject) : base(prefixObject)
        {
            this.PowerModifier = prefixObject.PowerPercent;
            this.MentalCostModifier = prefixObject.MentalCostPercent;
        }
    }
}
