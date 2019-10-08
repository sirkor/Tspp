using System;
using System.Xml.Serialization;

namespace ProjectTspp
{
    [XmlInclude(typeof(ContractLifeHealth))]
    [XmlInclude(typeof(ContractMovableProperty))]
    [XmlInclude(typeof(ContactNotMovableProperty))]
    public abstract class Contract
    {
        public Customer Cust { get; set; }
        public DateTime Validity { get; set; }
        public long InsuranceAmuont { get; set; }
        public int CompensationPrecentage { get; set; }

        public abstract void Print();
        public abstract void SetSpecialFields();

        public void SetCust()
        {
            long tempLong;
            Console.Write("Серия и номер паспорта клиента: ");
            while (!Int64.TryParse(Console.ReadLine(), out tempLong))
            {
                Console.Write("Данные введены неверно, повторите ввод: ");
            }
            var custList = CustomerList.GetInstance();
            foreach (var cust in custList.Get())
            {
                if (cust.PasportSeriesNumber == tempLong)
                {
                    Cust = cust;
                }
            }
            if (Cust == null)
            {
                Console.WriteLine("Данного клиента нет в базе. Заключение констракта не может быть выполнено.");
                Console.ReadKey();
                return;
            }
        }

        public void SetValidity()
        {
            Validity = DateTime.Now.AddYears(1);
        }

        public void SetInsuranceAmuont()
        {
            long tempLong;
            Console.Write("Страховая сумма: ");
            while (!Int64.TryParse(Console.ReadLine(), out tempLong))
            {
                Console.Write("Данные введены неверно, повторите ввод: ");
            }
            InsuranceAmuont = tempLong;
        }

        public void SetCompensationPrecentage()
        {
            int temp;
            Console.Write("Процент выплаты: ");
            while (!Int32.TryParse(Console.ReadLine(), out temp) || (temp < 1 || temp > 100))
            {
                Console.Write("Данные введены неверно, повторите ввод: ");
            }
            CompensationPrecentage = temp;
        }

        public void Activate()
        {
            throw new NotImplementedException();
        }

        public void RenewContract()
        {
            throw new NotImplementedException();
        }
    }
}
