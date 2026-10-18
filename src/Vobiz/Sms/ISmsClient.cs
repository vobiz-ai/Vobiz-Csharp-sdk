namespace Vobiz.Sms;

public partial interface ISmsClient
{
    public IMessagesClient Messages { get; }
    public INumbersClient Numbers { get; }
    public ICoverageClient Coverage { get; }
    public IConversationsClient Conversations { get; }
    public IOptOutsClient OptOuts { get; }
    public IWebhooksClient Webhooks { get; }
    public IBroadcastsClient Broadcasts { get; }
    public IRcsSendersClient RcsSenders { get; }
    public IBrandsClient Brands { get; }
    public ICampaignsClient Campaigns { get; }
}
