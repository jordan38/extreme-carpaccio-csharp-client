using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xCarpaccio.client
{
    public class Taxe
    {
        private Dictionary<string, decimal> _grilleTaxe;

        public Taxe(Dictionary<String, decimal> grilleTaxe)
        {
            _grilleTaxe = grilleTaxe;
        }

        public decimal TaxeParCode(string code)
        {
            return (decimal)(_grilleTaxe[code] / 100) + 1;

        }
    }
}
