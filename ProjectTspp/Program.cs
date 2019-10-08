using System;

namespace ProjectTspp
{
    class Program
    {
        static void Main(string[] args)
        {
            var customerList = CustomerList.GetInstance();
            var contractList = ContractList.GetInstance();
            InsuranceSpecialist spec = new InsuranceSpecialist();
            while (true)
            {
                Console.Clear();
                switch (Menu.Menu.PrintMenu(Menu.MenuItems.accessOption, "Для выбора пунта меню нажмите Enter"))
                {
                    case 1: // зайти как специалист
                        {
                            bool exit = false;
                            while (!exit)
                                {
                                    Console.Clear();
                                    switch (Menu.Menu.PrintMenu(Menu.MenuItems.specialistOption, "Для выбора пунта меню нажмите Enter"))
                                    {
                                        case 1:
                                            {
                                                Console.Clear();
                                                spec.AddCustomer();
                                                Menu.Menu.WaitKey();
                                                break;
                                            }
                                        case 2:
                                            {
                                                Console.Clear();
                                                spec.ViewCustomerList();
                                                Menu.Menu.WaitKey();
                                                break;
                                            }
                                        case 3:
                                            {
                                                Console.Clear();
                                                spec.SearchCustomer();
                                                Menu.Menu.WaitKey();
                                                break;
                                            }
                                        case 4:
                                            {
                                                Console.Clear();
                                                switch (Menu.Menu.PrintMenu(Menu.MenuItems.contractOption, "Для выбора пунта меню нажмите Enter"))
                                                {
                                                    case 1:
                                                        {
                                                            Console.Clear();
                                                            spec.AddConract(ContractType.ContractLifeHealth);
                                                            break;
                                                        }
                                                    case 2:
                                                        {
                                                            Console.Clear();
                                                            spec.AddConract(ContractType.ContractMovableProperty);
                                                            break;
                                                        }
                                                    case 3:
                                                        {
                                                            Console.Clear();
                                                            spec.AddConract(ContractType.ContactNotMovableProperty);
                                                            break;
                                                        }
                                                    case 0: break;
                                                    default: break;
                                                }
                                                Menu.Menu.WaitKey();
                                                break;
                                            }
                                        case 5:
                                            {
                                                Console.Clear();
                                                spec.ViewContractList();
                                                Menu.Menu.WaitKey();
                                                break;
                                            }
                                        case 6:
                                            {
                                                Console.Clear();
                                                spec.SearchContract();
                                                Menu.Menu.WaitKey();
                                                break;
                                            }
                                        case 0:
                                            {
                                                exit = true;
                                                break;
                                            }
                                        default: break;
                                    }
                                }
                            break;
                        }
                    case 2: // зайти как клиент
                        {
                            Console.Clear();

                            long tempPasport;
                            Console.Write("Серия и номер паспорта: ");
                            while (!Int64.TryParse(Console.ReadLine(), out tempPasport))
                            {
                                Console.Write("Данные введены неверно, повторите ввод: ");
                            }
                            Customer currentCustomer = null;
                            foreach (var cust in customerList.Get())
                            {
                                if (cust.PasportSeriesNumber == tempPasport)
                                {
                                    currentCustomer = cust;
                                }
                            }
                            if (currentCustomer == null)
                            {
                                Console.WriteLine("Вас нет в базе. Вход невозможен.");
                                Menu.Menu.WaitKey();
                                break;
                            }
                            bool exit = false;
                            while (!exit)
                                {
                                    Console.Clear();
                                    switch(Menu.Menu.PrintMenu(Menu.MenuItems.clientOption, "Для выбора пунта меню нажмите Enter"))
                                    {
                                        case 1: // просмотр договоров
                                            {
                                                Console.Clear();
                                                currentCustomer.ViewContract();
                                                Menu.Menu.WaitKey();
                                                break;
                                            }
                                        case 2: // продление договора
                                            {
                                                Console.Clear();
                                                currentCustomer.RenewContract();
                                                Menu.Menu.WaitKey();
                                                break;
                                            }
                                        case 3: // активация договора
                                            {
                                                Console.Clear();
                                                currentCustomer.ActivateContract();
                                                Menu.Menu.WaitKey();
                                                break;
                                            }
                                        case 0:
                                            {
                                                exit = true;
                                                break;
                                            }
                                        default: break;
                                    }
                                }
                            break;
                        }
                    case 0: // выйти
                        {
                            Console.Clear();
                            switch (Menu.Menu.PrintMenu(Menu.MenuItems.selectOption, "Вы действительно хотите выйти?"))
                            {
                                case 1:
                                {
                                    customerList.SerializeAndSave(customerList.customerListPath);
                                    contractList.SerializeAndSave(contractList.contractListPath);
                                    return;
                                }
                                case 2:
                                {
                                    break;
                                }
                                default: break;
                            }
                            break;
                        }
                        default: break;
                }
            }
        }
    }
}
