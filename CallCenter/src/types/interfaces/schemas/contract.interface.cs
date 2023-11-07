namespace CallCenter.Types
{
    interface IContract
    {
        Guid contractId {get; set;}
        Guid clientId {get; set;}
        ContractType contractType {get; set;}
        string contractDetails {get; set;}
        int serviceLevel {get; set;}
        ContractStatus contractStatus {get; set;}

    }
}