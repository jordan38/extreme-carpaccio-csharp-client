using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NFluent;
using NUnit.Framework;

namespace extreme_carpaccio.tests
{
    public class SomethingShould
    {
        [Test]
        public void DoSomething()
        {
            Check.That("").IsNull();
        }
    }
}
