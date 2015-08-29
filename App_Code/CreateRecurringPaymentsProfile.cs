/*
 * Copyright 2005, 2008 PayPal, Inc. All Rights Reserved.
 *
 * CreateRecurringPaymentsProfile SOAP example; last modified 08MAY23. 
 *
 * Create a recurring payments profile.  
 */
using System;
using com.paypal.sdk.services;
using com.paypal.soap.api;
using com.paypal.sdk.profiles;
/**
 * PayPal .NET SDK sample code
 */
namespace GenerateCodeSOAP
{
	public class CreateRecurringPaymentsProfile
	{
		public CreateRecurringPaymentsProfile()
		{
		}

        public string CreateRecurringPaymentsProfileCode(string token, DateTime date, string amount, int BF, BillingPeriodType BP, CurrencyCodeType currencyCodeType)
        {
            CallerServices caller = new CallerServices();

            IAPIProfile profile = ProfileFactory.createSignatureAPIProfile();
            /*
             WARNING: Do not embed plaintext credentials in your application code.
             Doing so is insecure and against best practices.
             Your API credentials must be handled securely. Please consider
             encrypting them for use in any production environment, and ensure
             that only authorized individuals may view or modify them.
             */

            // Set up your API credentials, PayPal end point, and API version.
            profile.APIUsername = "jolene.kane_api1.sovcity.com";
            profile.APIPassword = "99K52XU4TW52NA6H";
            profile.APISignature = "AsaWhdg.F1DEJUmkrAOGADAhmx2zAhz6qMKqOp5lTasZcyA1TAVoQrzO";
            profile.Environment = "live";

            caller.APIProfile = profile;

            // Create the request object.

           
            
            CreateRecurringPaymentsProfileRequestType pp_request = new CreateRecurringPaymentsProfileRequestType();
            pp_request.Version = "51.0";

            


            // Add request-specific fields to the request.
            pp_request.CreateRecurringPaymentsProfileRequestDetails = new CreateRecurringPaymentsProfileRequestDetailsType();
            pp_request.CreateRecurringPaymentsProfileRequestDetails.Token = "";
            pp_request.CreateRecurringPaymentsProfileRequestDetails.RecurringPaymentsProfileDetails = new RecurringPaymentsProfileDetailsType();
            pp_request.CreateRecurringPaymentsProfileRequestDetails.RecurringPaymentsProfileDetails.BillingStartDate = date;
            pp_request.CreateRecurringPaymentsProfileRequestDetails.ScheduleDetails = new ScheduleDetailsType();
            pp_request.CreateRecurringPaymentsProfileRequestDetails.ScheduleDetails.PaymentPeriod = new BillingPeriodDetailsType();
            pp_request.CreateRecurringPaymentsProfileRequestDetails.ScheduleDetails.PaymentPeriod.Amount = new BasicAmountType();
            pp_request.CreateRecurringPaymentsProfileRequestDetails.ScheduleDetails.PaymentPeriod.Amount.Value = amount;
            pp_request.CreateRecurringPaymentsProfileRequestDetails.ScheduleDetails.PaymentPeriod.Amount.currencyID = currencyCodeType;//Enum for currency code is  CurrencyCodeType.USD
            pp_request.CreateRecurringPaymentsProfileRequestDetails.ScheduleDetails.PaymentPeriod.BillingFrequency = BF;
            pp_request.CreateRecurringPaymentsProfileRequestDetails.ScheduleDetails.PaymentPeriod.BillingPeriod = BP;////Enum for BillingPeriod is  BillingPeriodType.Day

            // Execute the API operation and obtain the response.
            CreateRecurringPaymentsProfileResponseType pp_response = new CreateRecurringPaymentsProfileResponseType();
            pp_response = (CreateRecurringPaymentsProfileResponseType)caller.Call("CreateRecurringPaymentsProfile", pp_request);
            return pp_response.Errors[0].LongMessage;

        }


	}
}
