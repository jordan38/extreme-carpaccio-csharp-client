using System.Collections.Generic;
using System.IO;
using System.Text;

namespace xCarpaccio.client
{
    using Nancy;
    using System;
    using Nancy.ModelBinding;

    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Get["/"] = _ => "It works !!! You need to register your server on main server.";

            Post["/order"] = _ =>
            {
                using (var reader = new StreamReader(Request.Body, Encoding.UTF8))
                {
                    Console.WriteLine("Order received: {0}", reader.ReadToEnd());
                }

                var order = this.Bind<Order>();
                Dictionary<string,decimal> grilletaxe =new Dictionary<string, decimal>();

                grilletaxe.Add("FR",20);
                grilletaxe.Add("DE",21);
                grilletaxe.Add("IT",20);
                grilletaxe.Add("ES",19);
                grilletaxe.Add("PL", 21);
                grilletaxe.Add("RO", 20);
                grilletaxe.Add("NL", 20);
                grilletaxe.Add("BE", 24);
                grilletaxe.Add("EL", 20);
                grilletaxe.Add("CZ", 19);
                grilletaxe.Add("PT", 23);
                grilletaxe.Add("HU", 27);
                grilletaxe.Add("SE", 23);
                grilletaxe.Add("AT", 22);
                grilletaxe.Add("BG", 21);
                grilletaxe.Add("DK", 21);
                grilletaxe.Add("FI", 17);
                grilletaxe.Add("SK", 18);
                grilletaxe.Add("IE", 21);
                grilletaxe.Add("HR", 23);
                grilletaxe.Add("LT", 23);
                grilletaxe.Add("SI", 24);
                grilletaxe.Add("LV", 20);
                grilletaxe.Add("EE", 22);
                grilletaxe.Add("CY", 21);
                grilletaxe.Add("LU", 25);
                grilletaxe.Add("MT", 20);



                Taxe taxes =  new Taxe(grilletaxe);

                Bill bill = new Bill();
                bill.total = order.CalculerTaxe(taxes.TaxeParCode(order.Country));
                //TODO: do something with order and return a bill if possible
                // If you manage to get the result, return a Bill object (JSON serialization is done automagically)
                // Else return a HTTP 404 error : return Negotiate.WithStatusCode(HttpStatusCode.NotFound);
                
                return bill;
            };

            Post["/feedback"] = _ =>
            {
                var feedback = this.Bind<Feedback>();
                Console.Write("Type: {0}: ", feedback.Type);
                Console.WriteLine(feedback.Content);
                return Negotiate.WithStatusCode(HttpStatusCode.OK);
            };
        }
    }
}