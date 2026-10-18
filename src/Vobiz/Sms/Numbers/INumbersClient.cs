using Vobiz;

namespace Vobiz.Sms;

public partial interface INumbersClient
{
    /// <summary>
    /// Returns every number on your account that is routed for SMS or MMS, sorted by `countryCode` and then `e164`. Each number carries its US registration state, the last message it sent and a `sendable` summary of where it can send right now. Check `sendable.usDomestic` before you send to US recipients from a US number. To add numbers, search with `GET /numbers/available` and buy with `POST /numbers/purchase`.
    /// </summary>
    WithRawResponseTask<SmsNumberList> ListNumbersAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the countries where you can buy messaging numbers, with the number types and capabilities in stock in each. The list is a snapshot that refreshes in the background: while `ready` is `false`, `countries` is empty and you retry shortly. India is not listed, because traffic to Indian recipients is sent from DLT-registered sender IDs. Pass a returned `country` to `GET /numbers/available` to see individual numbers.
    /// </summary>
    WithRawResponseTask<NumberCountries> ListCountriesAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Searches the inventory for numbers you can buy in one country, with their setup and monthly prices in your wallet currency. Each search returns up to 10 numbers. Pass the chosen `e164`, the `country` and any non-empty `numberKey` to `POST /numbers/purchase`. For `country=IN` the list is empty and `hint` explains that Indian traffic uses DLT-registered sender IDs. A country outside the set Vobiz sells numbers in returns `422`.
    /// </summary>
    WithRawResponseTask<AvailableNumbersResponse> SearchAvailableNumbersAsync(
        SearchAvailableNumbersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Buys a number returned by `GET /numbers/available` and routes it to your account for messaging. This call spends money: it debits the setup fee and the first month's rental from your wallet before the number is bought, and the rental renews monthly until you release the number. If the purchase cannot complete after the debit, your wallet is refunded and the error message says so. Run it only with your own credentials once you have confirmed the number and price. A `numbers.updated` WebSocket event is published when the number goes live; a US number then needs a 10DLC campaign or toll-free verification before it can send to US recipients.
    /// </summary>
    WithRawResponseTask<PurchaseNumberResponse> PurchaseNumberAsync(
        PurchaseNumberRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the numbers you have bought through Vobiz, newest first, each with its full list of wallet charges. Released numbers stay in the list with `status: released`, so this is the billing history of every number you have owned. Use `nextBillingAt` to see when each active number renews and `charges` to reconcile setup and rental debits.
    /// </summary>
    WithRawResponseTask<NumberPurchaseList> ListPurchasesAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Cancels a number you bought through Vobiz and removes it from your account. The number stops sending and receiving messages immediately, and monthly rental stops. The setup fee and the current month are not refunded, and a released number cannot be restored. The call has no request body and returns the purchase with `status: released`. Run it only with your own credentials once you are sure you no longer need the number.
    /// </summary>
    WithRawResponseTask<ReleaseNumberResponse> ReleaseNumberAsync(
        ReleaseNumberRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
