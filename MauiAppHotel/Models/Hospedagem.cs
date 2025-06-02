namespace MauiAppHotel.Models
{
    public class Hospedagem
    {
        public Quarto QuartoSelecionado { get; set; }
        public int QuantidadeAdulto { get; set; }
        public int QuantidadeCrianca { get; set; }
        public DateTime DiaCheckIn {  get; set; }
        public DateTime DiaCheckOut { get; set; }

        public int Estadia
        {
            get => DiaCheckOut.Subtract(DiaCheckIn).Days;
        }

        public double ValorTotal
        {
            get
            {
                double valorAdultos = QuantidadeAdulto * QuartoSelecionado.ValorDiariaAdulto;
                double valorCrianca = QuantidadeCrianca * QuartoSelecionado.ValorDiariaCrianca;
                double total = (valorAdultos +  valorCrianca) * Estadia;
                return total;
            }
        }
    }
}
