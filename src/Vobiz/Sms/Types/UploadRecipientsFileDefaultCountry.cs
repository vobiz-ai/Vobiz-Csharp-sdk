using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz.Sms;

[JsonConverter(
    typeof(UploadRecipientsFileDefaultCountry.UploadRecipientsFileDefaultCountrySerializer)
)]
[Serializable]
public readonly record struct UploadRecipientsFileDefaultCountry : IStringEnum
{
    public static readonly UploadRecipientsFileDefaultCountry Us = new(Values.Us);

    public static readonly UploadRecipientsFileDefaultCountry Ca = new(Values.Ca);

    public static readonly UploadRecipientsFileDefaultCountry Gb = new(Values.Gb);

    public static readonly UploadRecipientsFileDefaultCountry In = new(Values.In);

    public static readonly UploadRecipientsFileDefaultCountry Au = new(Values.Au);

    public static readonly UploadRecipientsFileDefaultCountry Nz = new(Values.Nz);

    public static readonly UploadRecipientsFileDefaultCountry Ie = new(Values.Ie);

    public static readonly UploadRecipientsFileDefaultCountry De = new(Values.De);

    public static readonly UploadRecipientsFileDefaultCountry Fr = new(Values.Fr);

    public static readonly UploadRecipientsFileDefaultCountry Es = new(Values.Es);

    public static readonly UploadRecipientsFileDefaultCountry It = new(Values.It);

    public static readonly UploadRecipientsFileDefaultCountry Nl = new(Values.Nl);

    public static readonly UploadRecipientsFileDefaultCountry Be = new(Values.Be);

    public static readonly UploadRecipientsFileDefaultCountry Ch = new(Values.Ch);

    public static readonly UploadRecipientsFileDefaultCountry At = new(Values.At);

    public static readonly UploadRecipientsFileDefaultCountry Se = new(Values.Se);

    public static readonly UploadRecipientsFileDefaultCountry No = new(Values.No);

    public static readonly UploadRecipientsFileDefaultCountry Dk = new(Values.Dk);

    public static readonly UploadRecipientsFileDefaultCountry Fi = new(Values.Fi);

    public static readonly UploadRecipientsFileDefaultCountry Pl = new(Values.Pl);

    public static readonly UploadRecipientsFileDefaultCountry Pt = new(Values.Pt);

    public static readonly UploadRecipientsFileDefaultCountry Br = new(Values.Br);

    public static readonly UploadRecipientsFileDefaultCountry Mx = new(Values.Mx);

    public static readonly UploadRecipientsFileDefaultCountry Ar = new(Values.Ar);

    public static readonly UploadRecipientsFileDefaultCountry Co = new(Values.Co);

    public static readonly UploadRecipientsFileDefaultCountry Cl = new(Values.Cl);

    public static readonly UploadRecipientsFileDefaultCountry Sg = new(Values.Sg);

    public static readonly UploadRecipientsFileDefaultCountry My = new(Values.My);

    public static readonly UploadRecipientsFileDefaultCountry Id = new(Values.Id);

    public static readonly UploadRecipientsFileDefaultCountry Ph = new(Values.Ph);

    public static readonly UploadRecipientsFileDefaultCountry Th = new(Values.Th);

    public static readonly UploadRecipientsFileDefaultCountry Vn = new(Values.Vn);

    public static readonly UploadRecipientsFileDefaultCountry Jp = new(Values.Jp);

    public static readonly UploadRecipientsFileDefaultCountry Kr = new(Values.Kr);

    public static readonly UploadRecipientsFileDefaultCountry Cn = new(Values.Cn);

    public static readonly UploadRecipientsFileDefaultCountry Hk = new(Values.Hk);

    public static readonly UploadRecipientsFileDefaultCountry Ae = new(Values.Ae);

    public static readonly UploadRecipientsFileDefaultCountry Sa = new(Values.Sa);

    public static readonly UploadRecipientsFileDefaultCountry Qa = new(Values.Qa);

    public static readonly UploadRecipientsFileDefaultCountry Il = new(Values.Il);

    public static readonly UploadRecipientsFileDefaultCountry Tr = new(Values.Tr);

    public static readonly UploadRecipientsFileDefaultCountry Za = new(Values.Za);

    public static readonly UploadRecipientsFileDefaultCountry Ng = new(Values.Ng);

    public static readonly UploadRecipientsFileDefaultCountry Ke = new(Values.Ke);

    public static readonly UploadRecipientsFileDefaultCountry Eg = new(Values.Eg);

    public static readonly UploadRecipientsFileDefaultCountry Pk = new(Values.Pk);

    public static readonly UploadRecipientsFileDefaultCountry Bd = new(Values.Bd);

    public static readonly UploadRecipientsFileDefaultCountry Lk = new(Values.Lk);

    public static readonly UploadRecipientsFileDefaultCountry Np = new(Values.Np);

    public UploadRecipientsFileDefaultCountry(string value)
    {
        Value = value;
    }

    /// <summary>
    /// The string value of the enum.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Create a string enum with the given value.
    /// </summary>
    public static UploadRecipientsFileDefaultCountry FromCustom(string value)
    {
        return new UploadRecipientsFileDefaultCountry(value);
    }

    public bool Equals(string? other)
    {
        return Value.Equals(other);
    }

    /// <summary>
    /// Returns the string value of the enum.
    /// </summary>
    public override string ToString()
    {
        return Value;
    }

    public static bool operator ==(UploadRecipientsFileDefaultCountry value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(UploadRecipientsFileDefaultCountry value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(UploadRecipientsFileDefaultCountry value) => value.Value;

    public static explicit operator UploadRecipientsFileDefaultCountry(string value) => new(value);

    internal class UploadRecipientsFileDefaultCountrySerializer
        : JsonConverter<UploadRecipientsFileDefaultCountry>
    {
        public override UploadRecipientsFileDefaultCountry Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON value could not be read as a string."
                );
            return new UploadRecipientsFileDefaultCountry(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UploadRecipientsFileDefaultCountry value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UploadRecipientsFileDefaultCountry ReadAsPropertyName(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON property name could not be read as a string."
                );
            return new UploadRecipientsFileDefaultCountry(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UploadRecipientsFileDefaultCountry value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value);
        }
    }

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Us = "US";

        public const string Ca = "CA";

        public const string Gb = "GB";

        public const string In = "IN";

        public const string Au = "AU";

        public const string Nz = "NZ";

        public const string Ie = "IE";

        public const string De = "DE";

        public const string Fr = "FR";

        public const string Es = "ES";

        public const string It = "IT";

        public const string Nl = "NL";

        public const string Be = "BE";

        public const string Ch = "CH";

        public const string At = "AT";

        public const string Se = "SE";

        public const string No = "NO";

        public const string Dk = "DK";

        public const string Fi = "FI";

        public const string Pl = "PL";

        public const string Pt = "PT";

        public const string Br = "BR";

        public const string Mx = "MX";

        public const string Ar = "AR";

        public const string Co = "CO";

        public const string Cl = "CL";

        public const string Sg = "SG";

        public const string My = "MY";

        public const string Id = "ID";

        public const string Ph = "PH";

        public const string Th = "TH";

        public const string Vn = "VN";

        public const string Jp = "JP";

        public const string Kr = "KR";

        public const string Cn = "CN";

        public const string Hk = "HK";

        public const string Ae = "AE";

        public const string Sa = "SA";

        public const string Qa = "QA";

        public const string Il = "IL";

        public const string Tr = "TR";

        public const string Za = "ZA";

        public const string Ng = "NG";

        public const string Ke = "KE";

        public const string Eg = "EG";

        public const string Pk = "PK";

        public const string Bd = "BD";

        public const string Lk = "LK";

        public const string Np = "NP";
    }
}
