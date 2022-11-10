namespace BudgetFazt.Util.Processes
{
    public class Budget
    {
        public int Id { get; set; }
        public string ArticleName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public string Quality { get; set; } = string.Empty;
        public double UnitPrice { get; set; }
        public double Discount { get; set; }
        public double PriceAfterDiscount { get; set; }
        public double SumTotal { get; set; }
    }
}
