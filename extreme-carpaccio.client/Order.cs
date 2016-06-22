namespace xCarpaccio.client
{
    public class Order
    {
        public decimal[] Prices { get; set; }
        public int[] Quantities { get; set; }
        public string Country { get; set; }
        public string Reduction { get; set; }


        public decimal CalculerTaxe(decimal taxeParCode)
        {
            decimal resultFinal = 0;
            int index = 0;

            foreach (var produit in Quantities)
            {
                decimal prix = Prices[index];
                decimal result = (prix*produit)*taxeParCode;
                resultFinal = +result;
                index = +1;
            }
            return resultFinal;
        }
    }
}