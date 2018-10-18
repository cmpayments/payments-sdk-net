﻿using CM.Payments.Client.Enums;
using CM.Payments.Client.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

//<auto-generated>
//	IMPORTANT NOTE:
//	This code is generated by MessageUnitTestGenerator in this project.
//	Date and time: 06-04-2018 14:52:27
//
//	Changes to this file may cause incorrect behavior and will be lost on the next code generation.
//</auto-generated>
namespace CM.Payments.Client.Test
{
    [TestClass, ExcludeFromCodeCoverage]
	public partial class AfterPayPaymentResponseTests : BaseJsonConvertTests
	{
		public TestContext TestContext { get; set; }

		[TestMethod]
		public void AfterPayPaymentResponse()
		{
			var obj = new AfterPayPaymentResponse
			{
				Amount = 52,
				ChargeId = "Lorum_24",
				CreatedAt = DateTime.Now,
				Currency = "Lorum_521",
				Details = new AfterPayDetailsResponse
				{
					AuthenticationUrl = "Lorum_851",
					BankAccountNumber = "Lorum_539",
					BillToAddress = new AfterPayDetailsRequest.OrderAddress
					{
						City = "Lorum_45",
						HouseNumber = 49,
						HouseNumberAddition = "Lorum_582",
						IsoCountryCode = "Lorum_375",
						PostalCode = "Lorum_620",
						Reference = new AfterPayDetailsRequest.OrderAddress.ReferencePerson
						{
							DateOfBirth = DateTime.Now,
							EmailAddress = "Lorum_414",
							Gender = "Lorum_870",
							Initials = "Lorum_33",
							IsoLanguage = "Lorum_240",
							LastName = "Lorum_171",
							PhoneNumber1 = "Lorum_457",
							PhoneNumber2 = "Lorum_148"
						},
						Region = "Lorum_323",
						StreetName = "Lorum_399"
					},
					CallbackUrl = "Lorum_970",
					CancelledUrl = "Lorum_817",
					ExpiredUrl = "Lorum_35",
					FailedUrl = "Lorum_298",
					InvoiceNumber = "Lorum_490",
					IpAddress = "Lorum_764",
					Orderline = new List<AfterPayDetailsRequest.OrderLine>
					{
						new AfterPayDetailsRequest.OrderLine
						{
							ArticleDescription = "Lorum_328",
							ArticleId = "Lorum_235",
							NetUnitPrice = 22,
							Quantity = 50,
							UnitPrice = 36,
							VatCategory = AfterPayVatCategory.Low
						},
						new AfterPayDetailsRequest.OrderLine
						{
							ArticleDescription = "Lorum_856",
							ArticleId = "Lorum_704",
							NetUnitPrice = 12,
							Quantity = 39,
							UnitPrice = 24,
							VatCategory = AfterPayVatCategory.None
						}
					},
					OrderNumber = "Lorum_253",
					Password = "Lorum_718",
					PortfolioId = 19,
					PurchaseId = "Lorum_281",
					Result = new AfterPayDetailsResponse.ResultResponse
					{
						Checksum = "Lorum_656",
						OrderReference = "Lorum_301",
						ResultId = 21,
						StatusCode = "Lorum_217",
						TimestampIn = "Lorum_354",
						TimestampOut = "Lorum_704",
						TotalInvoicedAmount = 58,
						TotalReservedAmount = 71,
						TransactionId = "Lorum_612"
					},
					ShipToAddress = new AfterPayDetailsRequest.OrderAddress
					{
						City = "Lorum_308",
						HouseNumber = 77,
						HouseNumberAddition = "Lorum_316",
						IsoCountryCode = "Lorum_9",
						PostalCode = "Lorum_705",
						Reference = new AfterPayDetailsRequest.OrderAddress.ReferencePerson
						{
							DateOfBirth = DateTime.Now,
							EmailAddress = "Lorum_444",
							Gender = "Lorum_726",
							Initials = "Lorum_30",
							IsoLanguage = "Lorum_86",
							LastName = "Lorum_211",
							PhoneNumber1 = "Lorum_810",
							PhoneNumber2 = "Lorum_273"
						},
						Region = "Lorum_80",
						StreetName = "Lorum_18"
					},
					SuccessUrl = "Lorum_226",
					TotalOrderAmount = 56
				},
				DueDate = DateTime.Now,
				ExpiresAt = DateTime.Now,
				PaymentId = "Lorum_165",
				Recurring = false,
				RecurringId = "Lorum_855",
				ShortPaymentId = "Lorum_936",
				Status = "Lorum_527",
				Test = false,
				UpdatedAt = DateTime.Now
			};
			var deserialized = ConversionTest(obj);
			Assert.IsNotNull(deserialized);
			Assert.AreEqual(obj.ChargeId, deserialized.ChargeId);
			// Check only date and time up to seconds.. Json.NET does not save milliseconds.
			Assert.AreEqual(
				new DateTime(obj.CreatedAt.Year, obj.CreatedAt.Month, obj.CreatedAt.Day, obj.CreatedAt.Hour, obj.CreatedAt.Minute, obj.CreatedAt.Second),
				new DateTime(deserialized.CreatedAt.Year, deserialized.CreatedAt.Month, deserialized.CreatedAt.Day, deserialized.CreatedAt.Hour, deserialized.CreatedAt.Minute, deserialized.CreatedAt.Second));
			Assert.AreEqual(obj.Currency, deserialized.Currency);
			Assert.AreEqual(obj.Details.AuthenticationUrl, deserialized.Details.AuthenticationUrl);
			Assert.AreEqual(obj.Details.BankAccountNumber, deserialized.Details.BankAccountNumber);
			Assert.AreEqual(obj.Details.BillToAddress.City, deserialized.Details.BillToAddress.City);
			Assert.AreEqual(obj.Details.BillToAddress.HouseNumber, deserialized.Details.BillToAddress.HouseNumber);
			Assert.AreEqual(obj.Details.BillToAddress.HouseNumberAddition, deserialized.Details.BillToAddress.HouseNumberAddition);
			Assert.AreEqual(obj.Details.BillToAddress.IsoCountryCode, deserialized.Details.BillToAddress.IsoCountryCode);
			Assert.AreEqual(obj.Details.BillToAddress.PostalCode, deserialized.Details.BillToAddress.PostalCode);
			// Check only date and time up to seconds.. Json.NET does not save milliseconds.
			Assert.AreEqual(
				new DateTime(obj.Details.BillToAddress.Reference.DateOfBirth.Year, obj.Details.BillToAddress.Reference.DateOfBirth.Month, obj.Details.BillToAddress.Reference.DateOfBirth.Day, obj.Details.BillToAddress.Reference.DateOfBirth.Hour, obj.Details.BillToAddress.Reference.DateOfBirth.Minute, obj.Details.BillToAddress.Reference.DateOfBirth.Second),
				new DateTime(deserialized.Details.BillToAddress.Reference.DateOfBirth.Year, deserialized.Details.BillToAddress.Reference.DateOfBirth.Month, deserialized.Details.BillToAddress.Reference.DateOfBirth.Day, deserialized.Details.BillToAddress.Reference.DateOfBirth.Hour, deserialized.Details.BillToAddress.Reference.DateOfBirth.Minute, deserialized.Details.BillToAddress.Reference.DateOfBirth.Second));
			Assert.AreEqual(obj.Details.BillToAddress.Reference.EmailAddress, deserialized.Details.BillToAddress.Reference.EmailAddress);
			Assert.AreEqual(obj.Details.BillToAddress.Reference.Gender, deserialized.Details.BillToAddress.Reference.Gender);
			Assert.AreEqual(obj.Details.BillToAddress.Reference.Initials, deserialized.Details.BillToAddress.Reference.Initials);
			Assert.AreEqual(obj.Details.BillToAddress.Reference.IsoLanguage, deserialized.Details.BillToAddress.Reference.IsoLanguage);
			Assert.AreEqual(obj.Details.BillToAddress.Reference.LastName, deserialized.Details.BillToAddress.Reference.LastName);
			Assert.AreEqual(obj.Details.BillToAddress.Reference.PhoneNumber1, deserialized.Details.BillToAddress.Reference.PhoneNumber1);
			Assert.AreEqual(obj.Details.BillToAddress.Reference.PhoneNumber2, deserialized.Details.BillToAddress.Reference.PhoneNumber2);
			Assert.AreEqual(obj.Details.BillToAddress.Region, deserialized.Details.BillToAddress.Region);
			Assert.AreEqual(obj.Details.BillToAddress.StreetName, deserialized.Details.BillToAddress.StreetName);
			Assert.AreEqual(obj.Details.CallbackUrl, deserialized.Details.CallbackUrl);
			Assert.AreEqual(obj.Details.CancelledUrl, deserialized.Details.CancelledUrl);
			Assert.AreEqual(obj.Details.ExpiredUrl, deserialized.Details.ExpiredUrl);
			Assert.AreEqual(obj.Details.FailedUrl, deserialized.Details.FailedUrl);
			Assert.AreEqual(obj.Details.InvoiceNumber, deserialized.Details.InvoiceNumber);
			Assert.AreEqual(obj.Details.IpAddress, deserialized.Details.IpAddress);
			Assert.AreEqual(obj.Details.Orderline?.Count(), deserialized.Details.Orderline?.Count());
			for(var orderlineIndex = 0; orderlineIndex < obj.Details.Orderline.Count(); orderlineIndex++)
			{
				var expectedOrderLineInOrderline = obj.Details.Orderline.ElementAt(orderlineIndex) as AfterPayDetailsRequest.OrderLine;
				var actualOrderLineInOrderline = deserialized.Details.Orderline.ElementAt(orderlineIndex) as AfterPayDetailsRequest.OrderLine;
					Assert.AreEqual(expectedOrderLineInOrderline.ArticleDescription, actualOrderLineInOrderline.ArticleDescription);
					Assert.AreEqual(expectedOrderLineInOrderline.ArticleId, actualOrderLineInOrderline.ArticleId);
					Assert.AreEqual(expectedOrderLineInOrderline.NetUnitPrice, actualOrderLineInOrderline.NetUnitPrice);
					Assert.AreEqual(expectedOrderLineInOrderline.Quantity, actualOrderLineInOrderline.Quantity);
					Assert.AreEqual(expectedOrderLineInOrderline.UnitPrice, actualOrderLineInOrderline.UnitPrice);
					Assert.AreEqual(expectedOrderLineInOrderline.VatCategory, actualOrderLineInOrderline.VatCategory);
			}
			Assert.AreEqual(obj.Details.OrderNumber, deserialized.Details.OrderNumber);
			Assert.AreEqual(obj.Details.Password, deserialized.Details.Password);
			Assert.AreEqual(obj.Details.PortfolioId, deserialized.Details.PortfolioId);
			Assert.AreEqual(obj.Details.PurchaseId, deserialized.Details.PurchaseId);
			Assert.AreEqual(obj.Details.Result.Checksum, deserialized.Details.Result.Checksum);
			Assert.AreEqual(obj.Details.Result.OrderReference, deserialized.Details.Result.OrderReference);
			Assert.AreEqual(obj.Details.Result.ResultId, deserialized.Details.Result.ResultId);
			Assert.AreEqual(obj.Details.Result.StatusCode, deserialized.Details.Result.StatusCode);
			Assert.AreEqual(obj.Details.Result.TimestampIn, deserialized.Details.Result.TimestampIn);
			Assert.AreEqual(obj.Details.Result.TimestampOut, deserialized.Details.Result.TimestampOut);
			Assert.AreEqual(obj.Details.Result.TotalInvoicedAmount, deserialized.Details.Result.TotalInvoicedAmount);
			Assert.AreEqual(obj.Details.Result.TotalReservedAmount, deserialized.Details.Result.TotalReservedAmount);
			Assert.AreEqual(obj.Details.Result.TransactionId, deserialized.Details.Result.TransactionId);
			Assert.AreEqual(obj.Details.ShipToAddress.City, deserialized.Details.ShipToAddress.City);
			Assert.AreEqual(obj.Details.ShipToAddress.HouseNumber, deserialized.Details.ShipToAddress.HouseNumber);
			Assert.AreEqual(obj.Details.ShipToAddress.HouseNumberAddition, deserialized.Details.ShipToAddress.HouseNumberAddition);
			Assert.AreEqual(obj.Details.ShipToAddress.IsoCountryCode, deserialized.Details.ShipToAddress.IsoCountryCode);
			Assert.AreEqual(obj.Details.ShipToAddress.PostalCode, deserialized.Details.ShipToAddress.PostalCode);
			// Check only date and time up to seconds.. Json.NET does not save milliseconds.
			Assert.AreEqual(
				new DateTime(obj.Details.ShipToAddress.Reference.DateOfBirth.Year, obj.Details.ShipToAddress.Reference.DateOfBirth.Month, obj.Details.ShipToAddress.Reference.DateOfBirth.Day, obj.Details.ShipToAddress.Reference.DateOfBirth.Hour, obj.Details.ShipToAddress.Reference.DateOfBirth.Minute, obj.Details.ShipToAddress.Reference.DateOfBirth.Second),
				new DateTime(deserialized.Details.ShipToAddress.Reference.DateOfBirth.Year, deserialized.Details.ShipToAddress.Reference.DateOfBirth.Month, deserialized.Details.ShipToAddress.Reference.DateOfBirth.Day, deserialized.Details.ShipToAddress.Reference.DateOfBirth.Hour, deserialized.Details.ShipToAddress.Reference.DateOfBirth.Minute, deserialized.Details.ShipToAddress.Reference.DateOfBirth.Second));
			Assert.AreEqual(obj.Details.ShipToAddress.Reference.EmailAddress, deserialized.Details.ShipToAddress.Reference.EmailAddress);
			Assert.AreEqual(obj.Details.ShipToAddress.Reference.Gender, deserialized.Details.ShipToAddress.Reference.Gender);
			Assert.AreEqual(obj.Details.ShipToAddress.Reference.Initials, deserialized.Details.ShipToAddress.Reference.Initials);
			Assert.AreEqual(obj.Details.ShipToAddress.Reference.IsoLanguage, deserialized.Details.ShipToAddress.Reference.IsoLanguage);
			Assert.AreEqual(obj.Details.ShipToAddress.Reference.LastName, deserialized.Details.ShipToAddress.Reference.LastName);
			Assert.AreEqual(obj.Details.ShipToAddress.Reference.PhoneNumber1, deserialized.Details.ShipToAddress.Reference.PhoneNumber1);
			Assert.AreEqual(obj.Details.ShipToAddress.Reference.PhoneNumber2, deserialized.Details.ShipToAddress.Reference.PhoneNumber2);
			Assert.AreEqual(obj.Details.ShipToAddress.Region, deserialized.Details.ShipToAddress.Region);
			Assert.AreEqual(obj.Details.ShipToAddress.StreetName, deserialized.Details.ShipToAddress.StreetName);
			Assert.AreEqual(obj.Details.SuccessUrl, deserialized.Details.SuccessUrl);
			Assert.AreEqual(obj.Details.TotalOrderAmount, deserialized.Details.TotalOrderAmount);

		    if (obj.DueDate.HasValue && deserialized.DueDate.HasValue)
		    {
		        // Check only date and time up to seconds.. Json.NET does not save milliseconds.
		        Assert.AreEqual(
		            new DateTime(obj.DueDate.Value.Year, obj.DueDate.Value.Month, obj.DueDate.Value.Day, obj.DueDate.Value.Hour, obj.DueDate.Value.Minute, obj.DueDate.Value.Second),
		            new DateTime(deserialized.DueDate.Value.Year, deserialized.DueDate.Value.Month, deserialized.DueDate.Value.Day, deserialized.DueDate.Value.Hour, deserialized.DueDate.Value.Minute, deserialized.DueDate.Value.Second));
		    }

		    if (obj.ExpiresAt.HasValue && deserialized.ExpiresAt.HasValue)
		    {
		        // Check only date and time up to seconds.. Json.NET does not save milliseconds.
		        Assert.AreEqual(
		            new DateTime(obj.ExpiresAt.Value.Year, obj.ExpiresAt.Value.Month, obj.ExpiresAt.Value.Day, obj.ExpiresAt.Value.Hour, obj.ExpiresAt.Value.Minute, obj.ExpiresAt.Value.Second),
		            new DateTime(deserialized.ExpiresAt.Value.Year, deserialized.ExpiresAt.Value.Month, deserialized.ExpiresAt.Value.Day, deserialized.ExpiresAt.Value.Hour, deserialized.ExpiresAt.Value.Minute, deserialized.ExpiresAt.Value.Second));
		    }

		    Assert.AreEqual(obj.PaymentId, deserialized.PaymentId);
		    Assert.AreEqual(obj.Recurring, deserialized.Recurring);
		    Assert.AreEqual(obj.RecurringId, deserialized.RecurringId);
		    Assert.AreEqual(obj.ShortPaymentId, deserialized.ShortPaymentId);
		    Assert.AreEqual(obj.Status, deserialized.Status);
		    Assert.AreEqual(obj.Test, deserialized.Test);

		    if (obj.UpdatedAt.HasValue && deserialized.UpdatedAt.HasValue)
		    {
		        // Check only date and time up to seconds.. Json.NET does not save milliseconds.
		        Assert.AreEqual(
		            new DateTime(obj.UpdatedAt.Value.Year, obj.UpdatedAt.Value.Month, obj.UpdatedAt.Value.Day, obj.UpdatedAt.Value.Hour, obj.UpdatedAt.Value.Minute, obj.UpdatedAt.Value.Second),
		            new DateTime(deserialized.UpdatedAt.Value.Year, deserialized.UpdatedAt.Value.Month, deserialized.UpdatedAt.Value.Day, deserialized.UpdatedAt.Value.Hour, deserialized.UpdatedAt.Value.Minute, deserialized.UpdatedAt.Value.Second));
		    }
		}
	}
}
