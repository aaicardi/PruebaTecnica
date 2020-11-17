namespace XianaCore.Application.Implements
{
    class MonthlySalaryContract: AnnualSalary
    {
        private readonly long monthtlySalary;
        public MonthlySalaryContract(long value)
        {
            this.monthtlySalary = value * 12;
        }

        public override long GetAnnualSalary()
        {
            return this.monthtlySalary;
        }
    }
}
