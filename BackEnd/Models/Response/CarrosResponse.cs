namespace BackEnd.Models.Response
{
    public class CarrosResponse
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int? AnoFabricacao { get; set; }
        public int? AnoModelo { get; set; }
        public string Cor { get; set; }
        public int? QtdTotal {get; set;}
        public int? QtdDisponivel {get; set;}
    }
}