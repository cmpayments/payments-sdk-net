using JetBrains.Annotations;

namespace CM.Payments.Client.Model
{
    [PublicAPI]
    public interface IAuthenticatedResponse
    {
        string AuthenticationUrl { get; set; }
    }
}
