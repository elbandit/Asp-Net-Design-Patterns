using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Infrastructure.Validation;
using NUnit.Framework;

namespace Agathas.Storefront.Infrastructure.Tests.Validation_Specs
{    
    [TestFixture]
    public class When_checking_for_a_non_null_value_and_a_null_value_is_passed
    {
        [Test]
        [ExpectedException(typeof(Exception))]
        public void Then_the_check_constraint_will_throw_an_exception()
        {
            Check.IsNotNull(null, () => { throw new Exception(); });
        }
    }
}
