namespace MyWayApp23.Models
{
    public class HistoricoDetalhe
    {
        public DateOnly Data { get; set; }
        public string DiaSemana { get; set; } = string.Empty;
        public int TotalDia { get; set; }
        public int Dep { get; set; }
        public string DepPercentage { get; set; } = string.Empty;
        public int Arr { get; set; }
        public string ArrPercentage { get; set; } = string.Empty;
        public int JetBridge { get; set; }
        public string JetBridgePercentage { get; set; } = string.Empty;
        public int Remote { get; set; }
        public string RemotePercentage { get; set; } = string.Empty;
        public int Mais36 { get; set; }
        public string PercentageMais36 { get; set; } = string.Empty;
        public int Menos36 { get; set; }
        public string PercentageMenos36 { get; set; } = string.Empty;
        public int Wchr { get; set; }
        public int Wchs { get; set; }
        public int Wchc { get; set; }
        public int Maas { get; set; }
        public int Blnd { get; set; }
        public int Deaf { get; set; }
        public int Dpna { get; set; }
        public int Stcr { get; set; }
        public int Meda { get; set; }
        public int Wcmp { get; set; }
        public int Wcbd { get; set; }
        public int Wcbw { get; set; }
        public TimeOnly Media { get; set; }
    }

}
