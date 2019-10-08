using System;

namespace ProjectTspp
{
    [Serializable]
    public class ContractMovableProperty : Contract
    {
        public int RiskOfLose { get; set; }

        public override void Print()
        {
            Console.WriteLine($"|Страхование движимого имущества. Риск потери: {RiskOfLose,-17}|");
            Console.WriteLine($"|{Cust.Surname,-15}|{Validity.ToShortDateString(),15}|{InsuranceAmuont,15}|{CompensationPrecentage,15}|");
            Console.WriteLine("-----------------------------------------------------------------");
        }

        public override void SetSpecialFields()
        {
            int temp;
            Console.Write("Риск потери: ");
            while (!Int32.TryParse(Console.ReadLine(), out temp) || (temp < 1 || temp > 100))
            {
                Console.Write("Данные введены неверно, повторите ввод: ");
            }
            RiskOfLose = temp;
        }
    }
}
