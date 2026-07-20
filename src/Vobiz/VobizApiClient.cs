using Vobiz.Core;

namespace Vobiz;

public partial class VobizApiClient : IVobizApiClient
{
    private readonly RawClient _client;

    public VobizApiClient(
        string authId,
        string authToken,
        string? username = null,
        string? password = null,
        ClientOptions? clientOptions = null
    )
    {
        clientOptions ??= new ClientOptions();
        var platformHeaders = new Headers(
            new Dictionary<string, string>()
            {
                { "X-Fern-Language", "C#" },
                { "X-Fern-SDK-Name", "Vobiz" },
                { "X-Fern-SDK-Version", Version.Current },
            }
        );
        foreach (var header in platformHeaders)
        {
            if (!clientOptions.Headers.ContainsKey(header.Key))
            {
                clientOptions.Headers[header.Key] = header.Value;
            }
        }
        var clientOptionsWithAuth = clientOptions.Clone();
        var authHeaders = new Headers(
            new Dictionary<string, string>()
            {
                { "X-Auth-ID", authId },
                { "X-Auth-Token", authToken },
            }
        );
        foreach (var header in authHeaders)
        {
            clientOptionsWithAuth.Headers[header.Key] = header.Value;
        }
        clientOptionsWithAuth.Headers["Authorization"] =
            $"Basic {Convert.ToBase64String(global::System.Text.Encoding.UTF8.GetBytes($"{username}:{password}"))}";
        _client = new RawClient(clientOptionsWithAuth);
        Account = new AccountClient(_client);
        Balance = new BalanceClient(_client);
        LiveCalls = new LiveCallsClient(_client);
        Calls = new CallsClient(_client);
        Cdr = new CdrClient(_client);
        SubAccounts = new SubAccountsClient(_client);
        SubAccountKyc = new SubAccountKycClient(_client);
        SubAccountKycTestMode = new SubAccountKycTestModeClient(_client);
        PhoneNumbers = new PhoneNumbersClient(_client);
        Trunks = new TrunksClient(_client);
        Conference = new ConferenceClient(_client);
        RecordCalls = new RecordCallsClient(_client);
        PlayAudio = new PlayAudioClient(_client);
        SpeakText = new SpeakTextClient(_client);
        Dtmf = new DtmfClient(_client);
        AudioStreams = new AudioStreamsClient(_client);
        Conferences = new ConferencesClient(_client);
        ConferenceMembers = new ConferenceMembersClient(_client);
        ConferenceRecording = new ConferenceRecordingClient(_client);
        Recordings = new RecordingsClient(_client);
        Credentials = new CredentialsClient(_client);
        IpAccessControlList = new IpAccessControlListClient(_client);
        OriginationUri = new OriginationUriClient(_client);
        Applications = new ApplicationsClient(_client);
        Endpoints = new EndpointsClient(_client);
        PartnerApi = new PartnerApiClient(_client);
    }

    public IAccountClient Account { get; }

    public IBalanceClient Balance { get; }

    public ILiveCallsClient LiveCalls { get; }

    public ICallsClient Calls { get; }

    public ICdrClient Cdr { get; }

    public ISubAccountsClient SubAccounts { get; }

    public ISubAccountKycClient SubAccountKyc { get; }

    public ISubAccountKycTestModeClient SubAccountKycTestMode { get; }

    public IPhoneNumbersClient PhoneNumbers { get; }

    public ITrunksClient Trunks { get; }

    public IConferenceClient Conference { get; }

    public IRecordCallsClient RecordCalls { get; }

    public IPlayAudioClient PlayAudio { get; }

    public ISpeakTextClient SpeakText { get; }

    public IDtmfClient Dtmf { get; }

    public IAudioStreamsClient AudioStreams { get; }

    public IConferencesClient Conferences { get; }

    public IConferenceMembersClient ConferenceMembers { get; }

    public IConferenceRecordingClient ConferenceRecording { get; }

    public IRecordingsClient Recordings { get; }

    public ICredentialsClient Credentials { get; }

    public IIpAccessControlListClient IpAccessControlList { get; }

    public IOriginationUriClient OriginationUri { get; }

    public IApplicationsClient Applications { get; }

    public IEndpointsClient Endpoints { get; }

    public IPartnerApiClient PartnerApi { get; }
}
