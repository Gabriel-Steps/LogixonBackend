namespace LogixonBackend.Application.ViewModels.StockAlertViewModels
{
    public class StockAlertViewModelDTO
    {
        public string AlertType { get; set; } = string.Empty;
        public DateTime AlertDate { get; set; }
        public int ProductId { get; set; }
    }
}
