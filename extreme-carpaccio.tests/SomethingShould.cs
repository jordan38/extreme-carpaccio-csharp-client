using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using NFluent;
using NUnit.Framework;
using xCarpaccio.client;

namespace extreme_carpaccio.tests
{
    public class SomethingShould
    {
        [Test]
        public void DoSomething()
        {
            Check.That("").IsNull();
        }

        [Test]
        public void GererGrilleDeTaxe()
        {
            Dictionary<String,decimal> grilleTaxeDecimals = new Dictionary<string, decimal>();
            grilleTaxeDecimals.Add("FR",20);

            Taxe uneTaxe = new Taxe(grilleTaxeDecimals);

            Decimal laTaxeFR = uneTaxe.TaxeParCode("FR");

            Check.That(laTaxeFR).Equals((decimal)1.20);
        }
    }

    

}
