using Assets.Scripts.Words.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Words
{
    public class DomainWord : AbstractWord
    {
        public DomainsEnum Domain { get; private set; }

        public DomainWord(DomainScriptableObject domainObject) : base(domainObject)
        {
            this.Domain = domainObject.Domain;
        }
    }
}
