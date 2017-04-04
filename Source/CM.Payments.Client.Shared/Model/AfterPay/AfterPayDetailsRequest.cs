using System;
using System.Collections.Generic;
using CM.Payments.Client.Enums;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    /// <summary>
    /// Specific details for a AfterPay payment.
    /// </summary>
    [PublicAPI]
    public class AfterPayDetailsRequest : DetailsRequest
    {
        /// <summary>
        ///     International Bank Account Number, must be compliant with ISO. ISO 13616:2007.
        /// </summary>
        [JsonProperty("bank_account_number")]
        public string BankAccountNumber { get; set; }

        /// <summary>
        ///     The billing address
        /// </summary>
        [JsonProperty("bill_to_address")]
        public OrderAddress BillToAddress { get; set; }

        /// <summary>
        ///     Invoice number of the order.
        /// </summary>
        [JsonProperty("invoice_number")]
        public string InvoiceNumber { get; set; }

        /// <summary>
        ///     IP Address of the buyer.
        /// </summary>
        [JsonProperty("ip_address")]
        public string IpAddress { get; set; }

        /// <summary>
        ///     List of an order line.
        /// </summary>
        [JsonProperty("order_line")]
        public IEnumerable<OrderLine> Orderline { get; set; }

        /// <summary>
        ///     Unique number for the order.
        /// </summary>
        [JsonProperty("order_number")]
        public string OrderNumber { get; set; }

        /// <summary>
        ///     Password for the portfolio.
        /// </summary>
        [JsonProperty("password")]
        public string Password { get; set; }

        /// <summary>
        ///     Unique identifier for the portfolio.
        /// </summary>
        [JsonProperty("portfolio_id")]
        public int PortfolioId { get; set; }

        /// <summary>
        ///     The shipping address.
        /// </summary>
        [JsonProperty("ship_to_address")]
        public OrderAddress ShipToAddress { get; set; }

        /// <summary>
        ///     Total amount of the order.
        /// </summary>
        [JsonProperty("total_order_amount")]
        public int TotalOrderAmount { get; set; }

        /// <summary>
        /// Information about one line in an order.
        /// </summary>
        public class OrderLine
        {
            /// <summary>
            ///     Description of the article.
            /// </summary>
            [JsonProperty("article_description")]
            public string ArticleDescription { get; set; }

            /// <summary>
            ///     Unique identifier of the article
            /// </summary>
            [JsonProperty("article_id")]
            public string ArticleId { get; set; }

            /// <summary>
            ///     The final price after deducting all discounts and taxes.
            /// </summary>
            [JsonProperty("net_unit_price")]
            public int NetUnitPrice { get; set; }

            /// <summary>
            ///     Quantity of the article
            /// </summary>
            [JsonProperty("quantity")]
            public int Quantity { get; set; }

            /// <summary>
            ///     Unit price of the article
            /// </summary>
            [JsonProperty("unit_price")]
            public int UnitPrice { get; set; }

            /// <summary>
            ///     VAT category.
            /// </summary>
            [JsonProperty("vat_category")]
            public AfterPayVatCategory VatCategory { get; set; }
        }

        /// <summary>
        /// Delivery address for the order.
        /// </summary>
        public class OrderAddress
        {
            /// <summary>
            ///     The customers city.
            /// </summary>
            [JsonProperty("city")]
            public string City { get; set; }

            /// <summary>
            ///     House number of the customer.
            /// </summary>
            [JsonProperty("house_number")]
            public int HouseNumber { get; set; }

            /// <summary>
            ///     Optional addition to the customers house number.
            /// </summary>
            [JsonProperty("house_number_addition", NullValueHandling = NullValueHandling.Ignore)]
            public string HouseNumberAddition { get; set; }

            /// <summary>
            ///     Country of the billing address ISO 3166-1.
            /// </summary>
            [JsonProperty("iso_country_code")]
            public string IsoCountryCode { get; set; }

            /// <summary>
            ///     Zip code of the address.
            /// </summary>
            [JsonProperty("postal_code")]
            public string PostalCode { get; set; }

            /// <summary>
            ///     Additional information about the customer.
            /// </summary>
            [JsonProperty("reference_person")]
            public ReferencePerson Reference { get; set; }

            /// <summary>
            ///     Region of the address. (Optional)
            /// </summary>
            [JsonProperty("region", NullValueHandling = NullValueHandling.Ignore)]
            public string Region { get; set; }

            /// <summary>
            ///     Street name of the customer.
            /// </summary>
            [JsonProperty("street_name")]
            public string StreetName { get; set; }

            /// <summary>
            /// Details about the customer.
            /// </summary>
            public class ReferencePerson
            {
                /// <summary>
                ///     Date of birth of the customer.
                /// </summary>
                [JsonProperty("date_of_birth")]
                public DateTime DateOfBirth { get; set; }

                /// <summary>
                ///     Email address of the customer.
                /// </summary>
                [JsonProperty("email_address")]
                public string EmailAddress { get; set; }

                /// <summary>
                ///     Gender of the customer. Values: (M, F).
                /// </summary>
                [JsonProperty("gender")]
                public string Gender { get; set; }

                /// <summary>
                ///     Initials of the customer.
                /// </summary>
                [JsonProperty("initials")]
                public string Initials { get; set; }

                /// <summary>
                ///     Language of the customer ISO 3166-1.
                /// </summary>
                [JsonProperty("iso_language")]
                public string IsoLanguage { get; set; }

                /// <summary>
                ///     The last name of the customer
                /// </summary>
                [JsonProperty("last_name")]
                public string LastName { get; set; }

                /// <summary>
                ///     Phone number of the customer.
                /// </summary>
                [JsonProperty("phone_number_1")]
                public string PhoneNumber1 { get; set; }

                /// <summary>
                ///     Secondary phone number of the customer.
                /// </summary>
                [JsonProperty("phone_number_2")]
                public string PhoneNumber2 { get; set; }
            }
        }
    }
}