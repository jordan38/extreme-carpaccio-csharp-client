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
        private Dictionary<String, decimal> grilleTaxeDecimals;

        [OneTimeSetUp]
        public void SetUp()
        {
            grilleTaxeDecimals = new Dictionary<string, decimal>();
            grilleTaxeDecimals.Add("FR", 20);
        }

        [Test]
        public void DoSomething()
        {
            Check.That("").IsNull();
        }

        [Test]
        public void GererGrilleDeTaxe()
        {
            Taxe uneTaxe = new Taxe(grilleTaxeDecimals);
            Decimal laTaxeFr = uneTaxe.TaxeParCode("FR");

            Check.That(laTaxeFr).Equals((decimal)1.20);
        }

        [Test]
        public void AppliquerTaxeQuantiteCommande()
        {
            Order uneCommande = new Order
            {
                Quantities = new[] {5,5},
                Prices = new decimal[] {10,11},
                Country = "FR"
            };
            Taxe uneTaxe = new Taxe(grilleTaxeDecimals);

            decimal prixTaxer = uneCommande.CalculerTaxe(uneTaxe.TaxeParCode("FR"));

            decimal test = ((5*10) + (5*11))*(decimal)1.20;

            Check.That(test).Equals(prixTaxer);

        }
    }

    

}
