namespace MyWayApp23.Models.Tables;

public class TotalByMonthModel
{
    public DateTime Mes { get; set; }
    public decimal Total { get; set; }
    public decimal DepNotif { get; set; }
    public decimal DepNotNotif { get; set; }
    public decimal ArrNotif { get; set; }
    public decimal ArrNotNotif { get; set; }
    public decimal ArrNotNotif90 { get; set; }
}
