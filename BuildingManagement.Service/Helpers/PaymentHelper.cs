using BuildingManagement.Entity.Entities;
using BuildingManagement.Repository.Repository.PaymentRepository;

namespace BuildingManagement.Service.Helpers
{
    public static class PaymentHelper
    {
        public static decimal CalculateAmountToPay(decimal amount, DateTime currentDate, DateTime lastDayOfMonth)
        {
            if (currentDate <= lastDayOfMonth)
            {
                return amount;
            }
            else
            {
                // İlgili ayın sonuna kadar ödeme yapılmadı, gecikme cezası uygula (%10 fazla tahsilat yap)
                return amount * 1.1m;
            }
        }

        public static bool CheckRegularPayment(IEnumerable<Payment> pastYearPayments)
        {
            var currentDate = DateTime.Now;
            var pastYear = currentDate.AddYears(-1);

            for (int month = 1; month <= 12; month++)
            {
                var paymentsForMonth = pastYearPayments.Where(p => p.PaymentDate.Month == month);
                if (!paymentsForMonth.Any())
                {
                    return false; // Herhangi bir ay eksikse düzenli ödeme değil
                }
            }

            return true; // Geçmiş yılın tüm aylarında ödeme yapılmış
        }
    }
}
