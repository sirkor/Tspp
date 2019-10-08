namespace ProjectTspp
{
    public static class ContractFactory
    {
        public static Contract GetNewContract(ContractType contractType)
        {
            Contract item;
            switch (contractType)
            {
                case ContractType.ContractLifeHealth:
                    item = new ContractLifeHealth();
                    return item;
                case ContractType.ContractMovableProperty:
                    item = new ContractMovableProperty();
                    return item;
                case ContractType.ContactNotMovableProperty:
                    item = new ContactNotMovableProperty();
                    return item;
            }
            return null;
        }
    }
}
