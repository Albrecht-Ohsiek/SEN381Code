namespace CallCenter.Types
{
    interface IWorkRequest
    {
        Guid requestId { get; set; }
        Guid clientId { get; set; }
        string serviceType { get; set; }
        string priority { get; set; }
        string status { get; set; }

    }
}