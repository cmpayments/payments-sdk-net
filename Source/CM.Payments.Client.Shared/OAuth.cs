using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using JetBrains.Annotations;

namespace CM.Payments.Client
{
    /// <summary>
    ///     Contains the authentication tokens to connect.
    /// </summary>
    public sealed class OAuth
    {
        private static readonly char[] HexUpperChars = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
        private const string OAuthConsumerKeyKey = "oauth_consumer_key";
        private const string OAuthNonceKey = "oauth_nonce";
        private const string OAuthParameterPrefix = "oauth_";
        private const string OAuthSignatureKey = "oauth_signature";
        private const string OAuthSignatureMethodKey = "oauth_signature_method";
        private const string OAuthSignatureType = "HMAC-SHA256";
        private const string OAuthTimestampKey = "oauth_timestamp";
        private const string OAuthVersion = "1.0";
        private const string OAuthVersionKey = "oauth_version";
        private static readonly ReadOnlyCollection<string> AcceptedMethods = new ReadOnlyCollection<string>(new[] {"POST", "GET", "PUT"});
        private readonly string _oAuthConsumerKey;
        private readonly string _oAuthConsumerSecret;

        /// <summary>
        ///     Initializes a new instance of the <see cref="OAuth" /> class.
        /// </summary>
        /// <param name="consumerKey">The consumer key.</param>
        /// <param name="consumerSecret">The consumer secret.</param>
        public OAuth(string consumerKey, string consumerSecret)
        {
            _oAuthConsumerKey = consumerKey;
            _oAuthConsumerSecret = consumerSecret;
        }

        /// <summary>
        ///     Generates a signature for authentication purpose.
        /// </summary>
        /// <param name="method">THe HTTP method.</param>
        /// <param name="url">The full URL.</param>
        /// <param name="data">Data to send, if HTTP method is POST.</param>
        /// <param name="timeStamp">A timestamp</param>
        /// <param name="nonce">A unique sequence of alphanumeric characters.</param>
        /// <returns></returns>
        public string GenerateSignature(string method, string url, string data, string timeStamp, string nonce)
        {
            return ComputeHash(
                $"{UrlEncode(_oAuthConsumerKey)}&{UrlEncode(_oAuthConsumerSecret)}",
                GenerateSignatureBase(method, url, data, timeStamp, nonce));
        }

        internal string GenerateHeader([NotNull] string method, string url, string data = "")
        {
            var auth = new StringBuilder();
            var nonce = GenerateNonce();
            var timeStamp = GenerateTimeStamp();
            var signature = GenerateSignature(method.ToUpper(), url, data, timeStamp, nonce);

            auth.Append($"{UrlEncode(OAuthConsumerKeyKey)}=\"{UrlEncode(_oAuthConsumerKey)}\", ");
            auth.Append($"{UrlEncode(OAuthNonceKey)}=\"{UrlEncode(nonce)}\", ");
            auth.Append($"{UrlEncode(OAuthSignatureKey)}=\"{UrlEncode(signature)}\", ");
            auth.Append($"{UrlEncode(OAuthSignatureMethodKey)}=\"{UrlEncode(OAuthSignatureType)}\", ");
            auth.Append($"{UrlEncode(OAuthTimestampKey)}=\"{UrlEncode(timeStamp)}\", ");
            auth.Append($"{UrlEncode(OAuthVersionKey)}=\"{UrlEncode(OAuthVersion)}\"");
            return auth.ToString();
        }

        private static string ComputeHash([NotNull] string key, [NotNull] string data)
        {
            var hmac = new HMACSHA256 {Key = Encoding.ASCII.GetBytes(key)};

            var hashString = new StringBuilder();
            foreach (var t in hmac.ComputeHash(Encoding.UTF8.GetBytes(data)))
            {
                hashString.Append(t.ToString("x2"));
            }

            return Convert.ToBase64String(Encoding.UTF8.GetBytes(hashString.ToString()));
        }

        private static string GenerateNonce()
        {
            var chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            var data = new byte[32];

            using (var crypto = RandomNumberGenerator.Create())
            {
                crypto.GetBytes(data);
            }

            var result = new StringBuilder(32);
            foreach (var b in data)
            {
                result.Append(chars[b % chars.Length]);
            }

            return result.ToString();
        }

        private string GenerateSignatureBase(
            [NotNull] string method,
            [NotNull] string url,
            string data,
            [NotNull] string timeStamp,
            [NotNull] string nonce)
        {
            if (!AcceptedMethods.Contains(method))
            {
                throw new ArgumentException($"{method} is not an accepted method.");
            }

            var parameters = new List<Parameter>();
            if (method == HttpMethod.Post.Method || method == HttpMethod.Put.Method)
            {
                parameters.Add(new Parameter("", data));
            }
            parameters.AddRange(GetParameters(GetQueryFromUrl(url)));
            parameters.Add(new Parameter(UrlEncode(OAuthVersionKey), UrlEncode(OAuthVersion)));
            parameters.Add(new Parameter(UrlEncode(OAuthNonceKey), UrlEncode(nonce)));
            parameters.Add(new Parameter(UrlEncode(OAuthTimestampKey), UrlEncode(timeStamp)));
            parameters.Add(new Parameter(UrlEncode(OAuthSignatureMethodKey), UrlEncode(OAuthSignatureType)));
            parameters.Add(new Parameter(UrlEncode(OAuthConsumerKeyKey), UrlEncode(_oAuthConsumerKey)));

            parameters = parameters.OrderBy(v => v.Name).ToList();

            var normalizedRequestParameters = NormalizeRequestParameters(parameters);

            var signatureBase = new StringBuilder();
            signatureBase.Append($"{method}&");
            signatureBase.Append($"{UrlEncode(url)}&");
            signatureBase.Append($"{UrlEncode(normalizedRequestParameters)}");

            return signatureBase.ToString();
        }

        private static string GenerateTimeStamp()
        {
            // Default implementation of UNIX time of the current UTC time
            return $"{(long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds}";
        }

        private static List<Parameter> GetParameters(string parameters)
        {
            if (parameters.StartsWith("?"))
            {
                parameters = parameters.Remove(0, 1);
            }

            var result = new List<Parameter>();

            if (string.IsNullOrEmpty(parameters))
            {
                return result;
            }
            var p = parameters.Split('&');
            foreach (var s in p)
            {
                if (string.IsNullOrEmpty(s) || s.StartsWith(OAuthParameterPrefix))
                {
                    continue;
                }
                if (s.IndexOf('=') > -1)
                {
                    var temp = s.Split('=');
                    result.Add(new Parameter(UrlEncode(temp[0]), UrlEncode(temp[1])));
                }
                else
                {
                    result.Add(new Parameter(UrlEncode(s), UrlEncode(string.Empty)));
                }
            }

            return result;
        }

        private static string GetQueryFromUrl([NotNull] string url)
        {
            return url.Contains("?") ? url.Split('?')[1] : "";
        }

        private static string NormalizeRequestParameters([NotNull] IList<Parameter> parameters)
        {
            var sb = new StringBuilder();
            for (var i = 0; i < parameters.Count; i++)
            {
                var p = parameters[i];
                sb.Append(!string.IsNullOrEmpty(p.Name) ? $"{p.Name}={p.Value}" : p.Value);

                if (i < parameters.Count - 1)
                {
                    sb.Append("&");
                }
            }
            return sb.ToString();
        }

        private static void EscapeAsciiChar(char ch, char[] to, ref int pos)
        {
            to[pos++] = '%';
            to[pos++] = HexUpperChars[(ch & 0xf0) >> 4];
            to[pos++] = HexUpperChars[ch & 0xf];
        }

        // Transforms a character into its hexadecimal representation
        // This is a reimplementation of Uri.HexEscape since it is NOT available in DotNet Core
        private static string HexEscape(char character)
        {
            if (character > '\xff')
            {
                throw new ArgumentOutOfRangeException("character");
            }
            char[] chars = new char[3];
            int pos = 0;
            EscapeAsciiChar(character, chars, ref pos);
            return new string(chars);
        }

        private static string UrlEncode([NotNull] string value)
        {
            // Start with RFC 2396 escaping by calling Uri.EscapeDataString to do the work.
            // This MAY sometimes exhibit RFC 3986 behavior (according to the documentation).
            // If it does, the escaping we do that follows it will be a no-op since the
            // characters we search for to replace can't possibly exist in the string.
            var s = Regex.Replace(Uri.EscapeDataString(value), @"%[a-f0-9]{2}", match => match.Value.ToUpperInvariant()).Replace("+", "%20");

            // Upgrade the escaping to RFC 3986, if necessary, and return the value
            return Regex.Replace(s, @"[\!*\'\(\)]", match => HexEscape(Convert.ToChar(match.Value[0].ToString())));
        }

        private sealed class Parameter
        {
            public string Name { get; }
            public string Value { get; }

            public Parameter(string name, string value)
            {
                Name = name;
                Value = value;
            }
        }
    }
}