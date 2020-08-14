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
        private int[] _ageLimit = { 60, 80 };
        private int[] _salaryLimit = { 250000, 300000, 500000, 1000000 };

        public TaxCalculator(int salary, int age) {
            Salary = salary;
            Age = age;
        }

        public int CalculateTax()
        {
            int taxAbleIncome = Salary -  50000;
            int fixedTaxPayable = 12500;

            if (Age <= _ageLimit[0])
            {
                return GetTaxpayable(fixedTaxPayable, _salaryLimit[0], taxAbleIncome);
            }
            else if(Age > _ageLimit[0] && Age <= _ageLimit[1])
            {
                fixedTaxPayable -= 2500;
                return GetTaxpayable(fixedTaxPayable, _salaryLimit[1], taxAbleIncome);
            }
            else
            {
                fixedTaxPayable = 0;
                return GetTaxpayable(fixedTaxPayable, _salaryLimit[2], taxAbleIncome);
            }
        }


        public int GetTaxpayable(int fixedTaxPayable, int salaryLowerLimt, int taxAbleIncome)
        {
            int taxPayable = 0;
            int rebate = 12500;

            if (taxAbleIncome <= salaryLowerLimt)
            {
                return taxPayable;
            }
            else if (taxAbleIncome > salaryLowerLimt && taxAbleIncome <= _salaryLimit[2])
            {
                taxAbleIncome -= salaryLowerLimt;
                taxPayable = (int)(taxAbleIncome * _tax[0] / 100);
                taxPayable -= rebate;
            }
            else if (taxAbleIncome > _salaryLimit[2] && taxAbleIncome <= _salaryLimit[3])
            {
                    taxAbleIncome -= _salaryLimit[2];
                
                taxPayable = (int)(fixedTaxPayable + (taxAbleIncome * _tax[1] / 100));
            }
            else
            {
                fixedTaxPayable = fixedTaxPayable + 100000;
                taxAbleIncome -= _salaryLimit[3];
                taxPayable = (int)(fixedTaxPayable + (taxAbleIncome * _tax[2] / 100));
                taxAbleIncome += _salaryLimit[3];
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
