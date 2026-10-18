using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz.Sms;

[JsonConverter(
    typeof(UploadRecipientsJsonDefaultCountry.UploadRecipientsJsonDefaultCountrySerializer)
)]
[Serializable]
public readonly record struct UploadRecipientsJsonDefaultCountry : IStringEnum
{
    public static readonly UploadRecipientsJsonDefaultCountry Us = new(Values.Us);

    public static readonly UploadRecipientsJsonDefaultCountry Ca = new(Values.Ca);

    public static readonly UploadRecipientsJsonDefaultCountry Gb = new(Values.Gb);

    public static readonly UploadRecipientsJsonDefaultCountry In = new(Values.In);

    public static readonly UploadRecipientsJsonDefaultCountry Au = new(Values.Au);

    public static readonly UploadRecipientsJsonDefaultCountry Nz = new(Values.Nz);

    public static readonly UploadRecipientsJsonDefaultCountry Ie = new(Values.Ie);

    public static readonly UploadRecipientsJsonDefaultCountry De = new(Values.De);

    public static readonly UploadRecipientsJsonDefaultCountry Fr = new(Values.Fr);

    public static readonly UploadRecipientsJsonDefaultCountry Es = new(Values.Es);

    public static readonly UploadRecipientsJsonDefaultCountry It = new(Values.It);

    public static readonly UploadRecipientsJsonDefaultCountry Nl = new(Values.Nl);

    public static readonly UploadRecipientsJsonDefaultCountry Be = new(Values.Be);

    public static readonly UploadRecipientsJsonDefaultCountry Ch = new(Values.Ch);

    public static readonly UploadRecipientsJsonDefaultCountry At = new(Values.At);

    public static readonly UploadRecipientsJsonDefaultCountry Se = new(Values.Se);

    public static readonly UploadRecipientsJsonDefaultCountry No = new(Values.No);

    public static readonly UploadRecipientsJsonDefaultCountry Dk = new(Values.Dk);

    public static readonly UploadRecipientsJsonDefaultCountry Fi = new(Values.Fi);

    public static readonly UploadRecipientsJsonDefaultCountry Pl = new(Values.Pl);

    public static readonly UploadRecipientsJsonDefaultCountry Pt = new(Values.Pt);

    public static readonly UploadRecipientsJsonDefaultCountry Br = new(Values.Br);

    public static readonly UploadRecipientsJsonDefaultCountry Mx = new(Values.Mx);

    public static readonly UploadRecipientsJsonDefaultCountry Ar = new(Values.Ar);

    public static readonly UploadRecipientsJsonDefaultCountry Co = new(Values.Co);

    public static readonly UploadRecipientsJsonDefaultCountry Cl = new(Values.Cl);

    public static readonly UploadRecipientsJsonDefaultCountry Sg = new(Values.Sg);

    public static readonly UploadRecipientsJsonDefaultCountry My = new(Values.My);

    public static readonly UploadRecipientsJsonDefaultCountry Id = new(Values.Id);

    public static readonly UploadRecipientsJsonDefaultCountry Ph = new(Values.Ph);

    public static readonly UploadRecipientsJsonDefaultCountry Th = new(Values.Th);

    public static readonly UploadRecipientsJsonDefaultCountry Vn = new(Values.Vn);

    public static readonly UploadRecipientsJsonDefaultCountry Jp = new(Values.Jp);

    public static readonly UploadRecipientsJsonDefaultCountry Kr = new(Values.Kr);

    public static readonly UploadRecipientsJsonDefaultCountry Cn = new(Values.Cn);

    public static readonly UploadRecipientsJsonDefaultCountry Hk = new(Values.Hk);

    public static readonly UploadRecipientsJsonDefaultCountry Ae = new(Values.Ae);

    public static readonly UploadRecipientsJsonDefaultCountry Sa = new(Values.Sa);

    public static readonly UploadRecipientsJsonDefaultCountry Qa = new(Values.Qa);

    public static readonly UploadRecipientsJsonDefaultCountry Il = new(Values.Il);

    public static readonly UploadRecipientsJsonDefaultCountry Tr = new(Values.Tr);

    public static readonly UploadRecipientsJsonDefaultCountry Za = new(Values.Za);

    public static readonly UploadRecipientsJsonDefaultCountry Ng = new(Values.Ng);

    public static readonly UploadRecipientsJsonDefaultCountry Ke = new(Values.Ke);

    public static readonly UploadRecipientsJsonDefaultCountry Eg = new(Values.Eg);

    public static readonly UploadRecipientsJsonDefaultCountry Pk = new(Values.Pk);

    public static readonly UploadRecipientsJsonDefaultCountry Bd = new(Values.Bd);

    public static readonly UploadRecipientsJsonDefaultCountry Lk = new(Values.Lk);

    public static readonly UploadRecipientsJsonDefaultCountry Np = new(Values.Np);

    public UploadRecipientsJsonDefaultCountry(string value)
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
    public static UploadRecipientsJsonDefaultCountry FromCustom(string value)
    {
        return new UploadRecipientsJsonDefaultCountry(value);
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

    public static bool operator ==(UploadRecipientsJsonDefaultCountry value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(UploadRecipientsJsonDefaultCountry value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(UploadRecipientsJsonDefaultCountry value) => value.Value;

    public static explicit operator UploadRecipientsJsonDefaultCountry(string value) => new(value);

    internal class UploadRecipientsJsonDefaultCountrySerializer
        : JsonConverter<UploadRecipientsJsonDefaultCountry>
    {
        public override UploadRecipientsJsonDefaultCountry Read(
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
            return new UploadRecipientsJsonDefaultCountry(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UploadRecipientsJsonDefaultCountry value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UploadRecipientsJsonDefaultCountry ReadAsPropertyName(
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
            return new UploadRecipientsJsonDefaultCountry(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UploadRecipientsJsonDefaultCountry value,
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
