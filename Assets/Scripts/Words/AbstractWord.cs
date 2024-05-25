using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Words
{
    public abstract class AbstractWord
    {
        public string Word { get; private set; }
        public string Translation {  get; private set; }

        public AbstractWord(AbstractWordScriptableObject wordObject) 
        {
            Word = wordObject.Word;
            Translation = wordObject.Translation;
        }
    }
}
