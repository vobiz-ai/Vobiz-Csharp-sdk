namespace Vobiz;

public partial interface IVobizApiClient
{
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
