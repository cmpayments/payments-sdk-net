using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CM.Payments.Client.Model;
using CM.Payments.Client.Validators;
using FluentValidation;
using JetBrains.Annotations;

namespace CM.Payments.Client
{
    /// <summary>
    ///     Client for CM Payments API.
    /// </summary>
    [PublicAPI]
    public sealed class PaymentClient : RestBaseClient
    {
        private readonly ChargeValidator _chargeValidator;
        private readonly QrValidator _qrValidator;

        /// <summary>
        ///     Initialization for the client.
        /// </summary>
        /// <param name="consumerKey">The consumer key.</param>
        /// <param name="consumerSecret">The consumer secret.</param>
        /// <param name="baseUri">Optional client base uri. If no uri is provided, the default uri will be used.</param>
        public PaymentClient(string consumerKey, string consumerSecret, Uri baseUri = null) : base(consumerKey, consumerSecret, baseUri)
        {
            this._chargeValidator = new ChargeValidator();
            this._qrValidator = new QrValidator();
        }

        /// <summary>
        ///     Get a charge.
        /// </summary>
        /// <param name="id">The id of the charge.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A charge object.</returns>
        public async Task<ChargeResponse> GetChargeAsync([NotNull] string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException();
            }

            var query = $"charges/v1/{id}";
            return await this.GetAsync<ChargeResponse>(query, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        ///     Gets the issuers.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>List of issuers</returns>
        public async Task<List<Issuer>> GetIssuersAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            const string query = "issuers/v1/ideal";
            var result = await this.GetAsync<Dictionary<string, string>>(query, cancellationToken).ConfigureAwait(false);
            return result.Select(p => new Issuer {Name = p.Key, ID = p.Value}).ToList();
        }

        /// <summary>
        ///     Get a payment.
        /// </summary>
        /// <param name="id">The id of the payment.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A payment object.</returns>
        public async Task<PaymentResponse> GetPaymentAsync([NotNull] string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException();
            }

            var query = $"payments/v1/{id}";
            return await this.GetAsync<PaymentResponse>(query, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        ///     Gets the QR code.
        /// </summary>
        /// <param name="id">The id of the QR.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The QR object.</returns>
        public async Task<QrResponse> GetQrAsync([NotNull] string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException();
            }

            var query = $"qr/v1/{id}";
            return await this.GetAsync<QrResponse>(query, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        ///     Gets the status of the QR code.
        /// </summary>
        /// <param name="id">The id of the QR code.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The status of the QR code.</returns>
        public async Task<QrResponse> GetQrStatusAsync([NotNull] string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException();
            }

            var query = $"qr/v1/status/{id}";
            return await this.GetAsync<QrResponse>(query, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        ///     Gets the refund.
        /// </summary>
        /// <param name="id">The id of the refund.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<RefundResponse> GetRefundAsync([NotNull] string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException();
            }

            var query = $"refunds/v1/{id}";
            return await this.GetAsync<RefundResponse>(query, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        ///     Method to pay with iDeal, PayPal, AfterPay, Creditcard, Sofort or Bancontact.
        /// </summary>
        /// <param name="charge">The charge object to send.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A charge response object.</returns>
        public async Task<ChargeResponse> PayAsync(ChargeRequest charge, CancellationToken cancellationToken = default(CancellationToken))
        {
            this._chargeValidator.ValidateAndThrow(charge);
            var query = "charges/v1";
            return await this.PostAsync<ChargeResponse>(query, charge, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        ///     Creates a single QR code for iDeal.
        /// </summary>
        /// <param name="qr">A QR object.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A QR response object.</returns>
        public async Task<QrResponse> QrAsync(QrRequest qr, CancellationToken cancellationToken = default(CancellationToken))
        {
            this._qrValidator.ValidateAndThrow(qr);
            var query = "qr/v1";
            return await this.PostAsync<QrResponse>(query, qr, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        ///     Refund a payment (AfterPay and iDeal only).
        /// </summary>
        /// <param name="refund">A refund object.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A refund response object.</returns>
        public async Task<RefundResponse> RefundAsync([NotNull] RefundRequest refund, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (refund == null)
            {
                throw new ArgumentNullException(nameof(refund));
            }

            const string query = "refunds/v1";
            return await this.PostAsync<RefundResponse>(query, refund, cancellationToken).ConfigureAwait(false);
        }
    }
}