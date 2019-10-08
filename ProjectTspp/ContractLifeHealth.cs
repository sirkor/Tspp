using System;

namespace ProjectTspp
{
    [Serializable]
    public class ContractLifeHealth : Contract
    {
        public long HospitalCard { get; set; }

        public override void Print()
        {
            Console.WriteLine($"|Страхование жизни и здоровья. Номер больничной карты: {HospitalCard,-9}|");
            Console.WriteLine($"|{Cust.Surname,-15}|{Validity.ToShortDateString(),15}|{InsuranceAmuont,15}|{CompensationPrecentage,15}|");
            Console.WriteLine("-----------------------------------------------------------------");
        }

        public override void SetSpecialFields()
        {
            long temp;
            Console.Write("Номер больничной карты: ");
            while (!Int64.TryParse(Console.ReadLine(), out temp))
            {
                Console.Write("Данные введены неверно, повторите ввод: ");
            }
            HospitalCard = temp;
        }
    }
}
