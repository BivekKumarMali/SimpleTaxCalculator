using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTaxCalculator
{
    class TaxCalculator
    {
        protected int Salary;
        protected int Age;

        private sbyte [] _tax = { 5, 20, 30 };
        private sbyte[] _suncharge = { 10, 20 };
        private sbyte _heathAndEducationCess = 4;

        public TaxCalculator(int salary, int age) {
            Salary = salary;
            Age = age;
        }

        public int CalculateTax()
        {
            int taxAbleIncome = Salary -  50000;
            int fixedTaxPayable = 12500;
            int ageLowerLimit = 60;
            int ageUpperLimit = 80;
            int salaryLowerLimt = 250000;

            if (Age <= ageLowerLimit)
            {
                return GetTaxpayable(fixedTaxPayable, salaryLowerLimt, taxAbleIncome);
            }
            else if(Age > ageLowerLimit && Age <= ageUpperLimit)
            {
                fixedTaxPayable -= 2500;
                salaryLowerLimt += 50000;
                return GetTaxpayable(fixedTaxPayable, salaryLowerLimt, taxAbleIncome);
            }
            else
            {
                salaryLowerLimt *= 2;
                fixedTaxPayable = 0;
                return GetTaxpayable(fixedTaxPayable, salaryLowerLimt, taxAbleIncome);
            }
        }


        public int GetTaxpayable(int fixedTaxPayable, int salaryLowerLimt, int taxAbleIncome)
        {
            int taxPayable = 0;
            int salaryMediumLimt = 500000;
            int salaryUpperLimt = 1000000;
            int rebate = 12500;

            if (taxAbleIncome <= salaryLowerLimt)
            {
                return taxPayable;
            }
            else if (taxAbleIncome > salaryLowerLimt && taxAbleIncome <= salaryMediumLimt)
            {
                taxAbleIncome -= salaryLowerLimt;
                taxPayable = (int)(taxAbleIncome * _tax[0] / 100);
                taxPayable -= rebate;
            }
            else if (taxAbleIncome > salaryMediumLimt && taxAbleIncome <= salaryUpperLimt)
            {
                    taxAbleIncome -= salaryMediumLimt;
                
                taxPayable = (int)(fixedTaxPayable + (taxAbleIncome * _tax[1] / 100));
            }
            else
            {
                fixedTaxPayable = fixedTaxPayable + 100000;
                taxAbleIncome -= salaryUpperLimt;
                taxPayable = (int)(fixedTaxPayable + (taxAbleIncome * _tax[2] / 100));
                taxAbleIncome += salaryUpperLimt;
            }
            taxPayable += (int)(taxPayable * _heathAndEducationCess / 100);
            if (taxAbleIncome >= 5000000 && taxAbleIncome < 10000000)
            {
                taxPayable += (int)(taxPayable * _suncharge[0]);
            }
            else if(taxPayable >= 10000000)
            {
                taxPayable += (int)(taxPayable * _suncharge[1]);
            }
            return Math.Max(taxPayable, 0);
        }

    }
}
