using Vobiz.Core;

namespace Vobiz.Sms;

public partial class SmsClient : ISmsClient
{
    private readonly RawClient _client;

    internal SmsClient(RawClient client)
    {
        _client = client;
        Messages = new MessagesClient(_client);
        Numbers = new NumbersClient(_client);
        Coverage = new CoverageClient(_client);
        Conversations = new ConversationsClient(_client);
        OptOuts = new OptOutsClient(_client);
        Webhooks = new WebhooksClient(_client);
        Broadcasts = new BroadcastsClient(_client);
        RcsSenders = new RcsSendersClient(_client);
        Brands = new BrandsClient(_client);
        Campaigns = new CampaignsClient(_client);
    }

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
