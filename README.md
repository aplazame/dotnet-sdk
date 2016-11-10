# Aplazame .NET SDK

[Aplazame](https://aplazame.com), a consumer credit company, offers a payment system that can be
used by online buyers to receive funding for their purchases.


## Usage


### Checkout

This SDK provides a tree of objects for guide you about to craft the checkout model.

```cs
/*
 * Merchant model
 */
Aplazame.BusinessModel.Merchant merchant = new Aplazame.BusinessModel.Merchant(
	confirmation_url: "/confirm", // url that the JS client sent to confirming the order.
	cancel_url: "/cancel",        // url that the customer is sent to if there is an error in the checkout.
	success_url: "/success"       // url that the customer is sent to after confirming their order.
);
merchant.checkout_url = "/checkout"; // url that the customer is sent to if the customer chooses to back to the e-commerce, by default is /.


/*
 * Article model
 */
Aplazame.BusinessModel.Article article = new Aplazame.BusinessModel.Article(
	id: "89793238462643383279",                               // The article ID.
	name: "Reloj en oro blanco de 18 quilates y diamantes",   // Article name.
	url: "http://shop.example.com/product.html",              // Article url.
	image_url: "http://shop.example.com/product_image.png",   // Article image url.
	quantity: 2,                                              // Article quantity.
	price: Aplazame.BusinessModel.Decimal.FromDouble(4020.00) // Article price (tax is not included). (4,020.00 €)
);
article.description = "Movimiento de cuarzo de alta precisión";          // Article description.
article.tax_rate = Aplazame.BusinessModel.Decimal.FromDouble(21.00);     // Article tax rate. (21.00%)
article.discount = Aplazame.BusinessModel.Decimal.FromDouble(5.00);      // The discount amount of the article. (5.00 €)
article.discount_rate = Aplazame.BusinessModel.Decimal.FromDouble(2.00); // The rate discount of the article. (2.00 %)

// ... rest of articles in the shopping cart.

/*
 * Articles collection
 */
Aplazame.BusinessModel.Article[] articles = new Aplazame.BusinessModel.Article[] { article };


/*
 * Order model
 */
Aplazame.BusinessModel.Order order = new Aplazame.BusinessModel.Order(
	id: "28475648233786783165",                                       // Your order ID.
	currency: "EUR",                                                  // Currency code of the order.
	tax_rate: Aplazame.BusinessModel.Decimal.FromDouble(21.00),       // Order tax rate. (21.00%)
	total_amount: Aplazame.BusinessModel.Decimal.FromDouble(4620.00), // Order total amount. (4,620.00 €)
	articles: articles                                                // Articles in cart.
);
order.discount = Aplazame.BusinessModel.Decimal.FromDouble(160.00);         // The discount amount of the order. (160.00 €)
order.discount_rate = Aplazame.BusinessModel.Decimal.FromDouble(2.00);      // The rate discount of the order. (2.00 %)
order.cart_discount = Aplazame.BusinessModel.Decimal.FromDouble(0.50);      // The discount amount of the cart. (0.50 €)
order.cart_discount_rate = Aplazame.BusinessModel.Decimal.FromDouble(3.00); // The rate discount of the cart. (3.00 %)

/*
 * Customer address model
 */
Aplazame.BusinessModel.Address customerAddress = new Aplazame.BusinessModel.Address(
	"John",                 // Address first name.
	"Coltrane",             // Address last name.
	"Plaza del Angel nº10", // Address street.
	"Madrid",               // Address city.
	"Madrid",               // Address state.
	"ES",                   // Address country code.
	"28012"                 // Address postcode.
);
customerAddress.phone = "616123456";                              // Address phone number.
customerAddress.alt_phone = "+34917909930";                       // Address alternative phone.
customerAddress.address_addition = "Cerca de la plaza Santa Ana"; // Address addition.

/*
 * Customer model
 */
Aplazame.BusinessModel.Customer customer = new Aplazame.BusinessModel.Customer(
	id: "1618",                                            // Customer ID.
	email: "dev@aplazame.com",                             // The customer email.
	type: Aplazame.BusinessModel.Customer.TYPE_EXISTING,   // Customer type. Other options are: TYPE_GUEST and TYPE_NEW.
	gender: Aplazame.BusinessModel.Customer.GENDER_UNKNOWN // Customer gender. Other options are: GENDER_MALE, GENDER_FEMALE and GENDER_NOT_APPLICABLE.
);
customer.first_name = "John";                                       // Customer first name.
customer.last_name = "Coltrane";                                    // Customer last name.
customer.birthday = DateTime.Parse("1990-08-21T13:56:45+01:00");    // Customer birthday.
customer.language = "es";                                           // Customer language preferences.
customer.date_joined = DateTime.Parse("2014-08-21T13:56:45+01:00"); // A datetime designating when the customer account was created.
customer.last_login = DateTime.Parse("2014-08-27T19:57:56+01:00");  // A datetime of the customer last login.
customer.address = customerAddress;                                 // Customer address.


/*
 * Billing address model
 */
Aplazame.BusinessModel.Address billingAddress = new Aplazame.BusinessModel.Address(
   first_name: "Bill",                // Billing first name.
   last_name: "Evans",                // Billing last name.
   street: "Calle de Las Huertas 22", // Billing street.
   city: "Madrid",                    // Billing city.
   state: "Madrid",                   // Billing state.
   country: "ES",                     // Billing country code.
   postcode: "28014"                  // Billing postcode.
);
billingAddress.phone = "+34914298407";                    // Billing phone number.
billingAddress.alt_phone = null;                          // Billing alternative phone.
billingAddress.address_addition = "Cerca de la pizzería"; // Billing address addition.


/*
 * Shipping info model
 */
Aplazame.BusinessModel.ShippingInfo shippingInfo = new Aplazame.BusinessModel.ShippingInfo(
   first_name: "Django",                                  // Shipping first name.
   last_name: "Reinhard",                                 // Shipping last name.
   street: "Plaza del Angel nº10",                        // Shipping street.
   city: "Madrid",                                        // Shipping city.
   state: "Madrid",                                       // Shipping state.
   country: "ES",                                         // Shipping country code.
   postcode: "28012",                                     // Shipping postcode.
   name: "Planet Express",                                // Shipping name.
   price: Aplazame.BusinessModel.Decimal.FromDouble(5.00) // Shipping price (tax is not included). (5.00 €)
);
shippingInfo.phone = "616123456";                                             // Shipping phone number.
shippingInfo.alt_phone = "+34917909930";                                      // Shipping alternative phone.
shippingInfo.address_addition = "Cerca de la plaza Santa Ana";                // Shipping address addition.
shippingInfo.tax_rate = Aplazame.BusinessModel.Decimal.FromDouble(21.00);     // Shipping tax rate. (21.00%)
shippingInfo.discount = Aplazame.BusinessModel.Decimal.FromDouble(1.00);      // The discount amount of the shipping. (1.00 €)
shippingInfo.discount_rate = Aplazame.BusinessModel.Decimal.FromDouble(2.00); // The rate discount of the shipping. (2.00 %)


/*
 * Checkout model
 */
Aplazame.BusinessModel.Checkout checkout = new Aplazame.BusinessModel.Checkout(
	toc: true,
	merchant: merchant,
	order: order,
	customer: customer
);
checkout.billing = billingAddress;
checkout.shipping = shippingInfo;
```

In your view you will need to put an snippet similar to this one.
```asp
<script>
  aplazame.checkout( <%= JsonConvert.SerializeObject(checkout, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }); %> );
</script>
```

### API Calls

This assist you for craft a well formatted API request and decode the response back to C# types.

```cs
string apiBaseUri = "https://api.aplazame.com";
string environment = Aplazame.Api.Client.EnvironmentSandbox; // When you are ready use Aplazame.Api.Client.EnvironmentProduction
string accessToken = "api private key";

Aplazame.Api.Client aplazameApiClient = new Aplazame.Api.Client(apiBaseUri, environment, accessToken);
dynamic result;
try
{
	result = aplazameApiClient.Get("/me");
}
catch (Aplazame.Api.ApiCommunicationException apiCommunicationException)
{
	// A network error has occurred while sending the request or receiving the response.

	// Retry
}
catch (Aplazame.Api.DeserializeException deserializationException)
{
	// Nobody knows when this happen, may an HTTP Proxy on our side or on your side started to return HTML responses with errors.

	// Retry
}
catch (Aplazame.Api.ApiServerException apiServerException)
{
	// Our server has crashed. We promise to fix it ASAP.

	Console.WriteLine("Error type " + apiServerException.ErrorType);
	Console.WriteLine("Error message " + apiServerException.Message);

	dynamic rawErrorWithErrorDetails = apiServerException.Error;

}
catch (Aplazame.Api.ApiClientException apiClientException) {
	// Your client has sent an invalid request. Please check your code.

	Console.WriteLine("Error type " + apiClientException.ErrorType);
	Console.WriteLine("Error message " + apiClientException.Message);

	dynamic rawErrorWithErrorDetails = apiClientException.Error;
}

Console.WriteLine(result);
```


## Documentation

Documentation is available at http://docs.aplazame.com.
