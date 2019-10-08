using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

namespace ProjectTspp
{
    class CustomerList
    {
        public string customerListPath = "customerList";
        private List<Customer> customers = new List<Customer>();

        private static CustomerList instance;
        private CustomerList() { }
        public static CustomerList GetInstance()
        {
            if (instance == null)
            {
                instance = new CustomerList();
                instance.ReadAndDeserialize(instance.customerListPath);
            }
            return instance;
        }

        public List<Customer> Get() => customers;

        public void View()
        {
            Console.WriteLine($"------------------------------------------------------------");
            Console.WriteLine($"|Имя            |Фамилия        |Паспорт     |Телефон      |");
            Console.WriteLine($"------------------------------------------------------------");
            foreach (var cust in customers)
            {
                cust.Print();
            }
            Console.WriteLine($"------------------------------------------------------------");
        }

        public void Add()
        {
            var item = new Customer();
            item.SetName();
            item.SetSurname();
            item.SetPasportSeriesNumber();
            foreach (var cust in customers)
            {
                if (cust.PasportSeriesNumber == item.PasportSeriesNumber)
                {
                    Console.WriteLine("Данный клиент уже есть в базе.");
                    Console.ReadKey();
                    return;
                }
            }
            item.SetPhone();
            customers.Add(item);
            Console.WriteLine($"Клиен добавлен. Всего клиентов: {customers.Count}");
        }

        public void Search()
        {
            long pasportSeriesNumber;
            Console.Write("Серия и номер паспорта: ");
            while (!Int64.TryParse(Console.ReadLine(), out pasportSeriesNumber))
            {
                Console.Write("Данные введены неверно, повторите ввод: ");
            }
            bool searchFlag = false;
            foreach (var cust in customers)
            {
                if (cust.PasportSeriesNumber == pasportSeriesNumber)
                {
                    if (!searchFlag)
                    {
                        Console.WriteLine($"------------------------------------------------------------");
                        Console.WriteLine($"|Имя            |Фамилия        |Паспорт     |Телефон      |");
                        Console.WriteLine($"------------------------------------------------------------");
                    }
                    cust.Print();
                    searchFlag = true;
                    break;
                }
            }
            if (!searchFlag)
            {
                Console.WriteLine("Такого клиента не существует.");
            }
            else
            {
                Console.WriteLine($"------------------------------------------------------------");
            }
        }

        private void ReadAndDeserialize(string path)
        {
            var serializer = new XmlSerializer(typeof(List<Customer>));
            using (var reader = new StreamReader(path))
            {
                customers = (List<Customer>)serializer.Deserialize(reader);
                return;
            }
        }

        public void SerializeAndSave(string path)
        {
            var serializer = new XmlSerializer(typeof(List<Customer>));
            using (var writer = new StreamWriter(path))
            {
                serializer.Serialize(writer, customers);
            }
        }
    }
}
