using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Infrastructure.Validation;
using NUnit.Framework;

namespace Agathas.Storefront.Infrastructure.Tests.Validation_Specs
{
    [TestFixture]
    public class When_asserting_on_a_passing_check_constraint
    {

        [Test]
        public void Then_an_exception_will_not_be_thrown()
        {
            Check.That(true, () => { throw new Exception(); });            
        }
    }
}
