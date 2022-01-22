using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napilnik
{
    public class DomainName
    {
        private string _firstLevel;
        private string _secondLevel;
        private string _thirdLevel;
        private string _pathSegment;

        public DomainName(string firstLevel, string secondLevel, string pathSegment, string thirdLevel = "")
        {
            if (string.IsNullOrWhiteSpace(secondLevel))
                throw new ArgumentNullException(secondLevel);

            if (string.IsNullOrWhiteSpace(firstLevel))
                throw new ArgumentNullException(firstLevel);

            if (string.IsNullOrWhiteSpace(thirdLevel))
                thirdLevel = "";
            else
                thirdLevel = thirdLevel + ".";

            _firstLevel = firstLevel;
            _secondLevel = secondLevel + ".";
            _thirdLevel = thirdLevel;
            _pathSegment = "/" + pathSegment;
        }

        public string GetName()
        {
            return $"{_thirdLevel}{_secondLevel}{_firstLevel}{_pathSegment}?";
        }
    }
}
