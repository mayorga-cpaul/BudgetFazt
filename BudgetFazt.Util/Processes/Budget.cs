namespace BudgetFazt.Util.Processes
{
    public class Budget
    {
        public int CódigoDeProducto { get; set; }
        public string NombreDeArticulo { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Cantidad { get; set; }
        public string Calidad { get; set; } = string.Empty;
        public double PrecioUnitario { get; set; }
        public double Descuento { get; set; }
        public double PrecioDespuésDeDescuento { get; set; }
        public double SumTotal { get; set; }
    }
}
