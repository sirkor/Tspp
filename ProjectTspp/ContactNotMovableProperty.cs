using System;

namespace ProjectTspp
{
    [Serializable]
    public class ContactNotMovableProperty : Contract
    {
        public string Location { get; set; }

        public override void Print()
        {
            Console.WriteLine($"|Страхование недвижимого имущества. Локация: {Location,-19}|");
            Console.WriteLine($"|{Cust.Surname,-15}|{Validity.ToShortDateString(),15}|{InsuranceAmuont,15}|{CompensationPrecentage,15}|");
            Console.WriteLine("-----------------------------------------------------------------");
        }
        public override void SetSpecialFields()
        {
            string temp;
            Console.Write("Локация: "); temp = Console.ReadLine();
            while (temp.Length > 15)
            {
                Console.Write("Данные введены неверно, повторите ввод: ");
                temp = Console.ReadLine();
            }
            Location = temp;
        }
    }
}
