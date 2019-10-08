using System;

namespace ProjectTspp
{
    class InsuranceSpecialist
    {
        public string Name { get; set; }
        public string Sutname { get; set; }
        public int PasportSeriesNumber { get; set; }

        CustomerList customerList;
        ContractList contractList;

        public InsuranceSpecialist()
        {
            customerList = CustomerList.GetInstance();
            contractList = ContractList.GetInstance();
        }

        public void ViewContractList() => contractList.View();

        public void ViewCustomerList() => customerList.View();

        public void AddConract(ContractType contractType) => contractList.Add(contractType);

        public void AddCustomer() => customerList.Add();

        public void SearchContract() => contractList.Search();

        public void SearchCustomer() => customerList.Search();
    }
}
