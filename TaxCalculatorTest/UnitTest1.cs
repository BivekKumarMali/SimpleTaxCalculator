using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleTaxCalculator;

namespace TaxCalculatorTest
{
    [TestClass]
    public class TaxCalculationTest
    {

        private int[] _agesTest = { 55, 60, 65, 80, 100 };
        private int[] _salaryTest = { 0, 200000, 250000, 300000, 400000, 500000, 600000, 1000000, 2000000, 6000000, 10000000 };
        private int[] _exceptedTax = {  0, 0 ,0, 0, 0, 0, 23400, 106600, 413400, 1827540, 3200340,
                                        0, 0, 0, 0, 0, 0, 23400, 106600, 413400, 1827540, 3200340,
                                        0, 0, 0, 0, 0, 0, 20800, 104000, 410800, 1824680, 3197480,
                                        0, 0, 0, 0, 0, 0, 20800, 104000, 410800, 1824680, 3197480,
                                        0, 0, 0, 0, 0, 0, 10400, 093600, 400400, 1813240, 3186040 };

        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }
        [TestMethod]
        public void TestMethod1()
        {
            int i = 0;
            foreach (int age in _agesTest)
            {
                foreach (int salary in _salaryTest)
                {
                    TaxCalculator taxCalculator = new TaxCalculator(salary, age);
                    Assert.AreEqual(_exceptedTax[i], taxCalculator.CalculateTax());
                    TestContext.WriteLine(_exceptedTax[i] + "  " + taxCalculator.CalculateTax());
                    i += 1;
                }
            }
        }
    }
}
