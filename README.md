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
dynamic merchant = new {};
merchant.confirmation_url = "/confirm"; // url that the JS client sent to confirming the order.
merchant.cancel_url = "/cancel";        // url that the customer is sent to if there is an error in the checkout.
merchant.success_url = "/success";      // url that the customer is sent to after confirming their order.
merchant.checkout_url = "/checkout";    // url that the customer is sent to if the customer chooses to back to the e-commerce, by default is /.


/*
 * Article model
 */
dynamic article = new {};
article.id = "89793238462643383279";                                      // The article ID.
article.name = "Reloj en oro blanco de 18 quilates y diamantes";          // Article name.
article.url = "http://shop.example.com/product.html";                     // Article url.
article.image_url = "http://shop.example.com/product_image.png";          // Article image url.
article.quantity = 2;                                                     // Article quantity.
article.price = Aplazame.Serializer.DecimalType.FromDouble(4020.00);      // Article price (tax is not included). (4,020.00 €)
article.description = "Movimiento de cuarzo de alta precisión";           // Article description.
article.tax_rate = Aplazame.Serializer.DecimalType.FromDouble(21.00);     // Article tax rate. (21.00%)
article.discount = Aplazame.Serializer.DecimalType.FromDouble(5.00);      // The discount amount of the article. (5.00 €)
article.discount_rate = Aplazame.Serializer.DecimalType.FromDouble(2.00); // The rate discount of the article. (2.00 %)

// ... rest of articles in the shopping cart.

/*
 * Articles collection
 */
dynamic[] articles = new dynamic[] { article, ... };


/*
 * Order model
 */
dynamic order = new {};
order.id = "28475648233786783165";                                           // Your order ID.
order.currency = "EUR";                                                      // Currency code of the order.
order.tax_rate = Aplazame.Serializer.DecimalType.FromDouble(21.00);          // Order tax rate. (21.00%)
order.total_amount = Aplazame.Serializer.DecimalType.FromDouble(4620.00);    // Order total amount. (4,620.00 €)
order.articles = articles;                                                   // Articles in cart.
order.discount = Aplazame.Serializer.DecimalType.FromDouble(160.00);         // The discount amount of the order. (160.00 €)
order.discount_rate = Aplazame.Serializer.DecimalType.FromDouble(2.00);      // The rate discount of the order. (2.00 %)
order.cart_discount = Aplazame.Serializer.DecimalType.FromDouble(0.50);      // The discount amount of the cart. (0.50 €)
order.cart_discount_rate = Aplazame.Serializer.DecimalType.FromDouble(3.00); // The rate discount of the cart. (3.00 %)

/*
 * Customer address model
 */
dynamic customerAddress = new {};
customerAddress.first_name = "John";                              // Address first name.
customerAddress.last_name = "Coltrane";                           // Address last name.
customerAddress.street = "Plaza del Angel nº10";                  // Address street.
customerAddress.city = "Madrid";                                  // Address city.
customerAddress.state = "Madrid";                                 // Address state.
customerAddress.country = "ES";                                   // Address country code.
customerAddress.postcode = "28012";                               // Address postcode.
customerAddress.phone = "616123456";                              // Address phone number.
customerAddress.alt_phone = "+34917909930";                       // Address alternative phone.
customerAddress.address_addition = "Cerca de la plaza Santa Ana"; // Address addition.

/*
 * Customer model
 */
dynamic customer = new {};
customer.id = "1618";                                                                                  // Customer ID.
customer.email = "dev@aplazame.com";                                                                   // The customer email.
customer.type = 'e';                                                                                   // Customer type, the choices are g:guest, n:new, e:existing.
customer.gender = 0;                                                                                   // Customer gender, the choices are 0: not known, 1: male, 2:female, 3: not applicable.
customer.first_name = "John";                                                                          // Customer first name.
customer.last_name = "Coltrane";                                                                       // Customer last name.
customer.birthday = Aplazame.Serializer.DateType.FromDateTime(new DateTime("1990-08-21 13:56:45"));    // Customer birthday.
customer.language = "es";                                                                              // Customer language preferences.
customer.date_joined = Aplazame.Serializer.DateType.FromDateTime(new DateTime("2014-08-21 13:56:45")); // A datetime designating when the customer account was created.
customer.last_login = Aplazame.Serializer.DateType.FromDateTime(new DateTime("2014-08-27 19:57:56"));  // A datetime of the customer last login.
customer.address = customerAddress;                                                                    // Customer address.


/*
 * Billing address model
 */
dynamic billingAddress = new {};
billingAddress.first_name = "Bill";                        // Billing first name.
billingAddress.last_name = "Evans";                        // Billing last name.
billingAddress.street = "Calle de Las Huertas 22";         // Billing street.
billingAddress.city = "Madrid";                            // Billing city.
billingAddress.state = "Madrid";                           // Billing state.
billingAddress.country = "ES";                             // Billing country code.
billingAddress.postcode = "28014";                         // Billing postcode.
billingAddress.phone = "+34914298407";                     // Billing phone number.
billingAddress.alt_phone = null;                           // Billing alternative phone.
billingAddress.address_addition =  "Cerca de la pizzería"; // Billing address addition.


/*
 * Shipping info model
 */
dynamic shippingInfo = new {};
shippingInfo.first_name = "Django";                                            // Shipping first name.
shippingInfo.last_name = "Reinhard";                                           // Shipping last name.
shippingInfo.street = "Plaza del Angel nº10";                                  // Shipping street.
shippingInfo.city = "Madrid";                                                  // Shipping city.
shippingInfo.state = "Madrid";                                                 // Shipping state.
shippingInfo.country = "ES";                                                   // Shipping country code.
shippingInfo.postcode = "28012";                                               // Shipping postcode.
shippingInfo.name = "Planet Express";                                          // Shipping name.
shippingInfo.price = Aplazame.Serializer.DecimalType.FromDouble(5.00);         // Shipping price (tax is not included). (5.00 €)
shippingInfo.phone = "616123456";                                              // Shipping phone number.
shippingInfo.alt_phone = "+34917909930";                                       // Shipping alternative phone.
shippingInfo.address_addition = "Cerca de la plaza Santa Ana";                 // Shipping address addition.
shippingInfo.tax_rate = Aplazame.Serializer.DecimalType.FromDouble(21.00);     // Shipping tax rate. (21.00%)
shippingInfo.discount = Aplazame.Serializer.DecimalType.FromDouble(1.00);      // The discount amount of the shipping. (1.00 €)
shippingInfo.discount_rate = Aplazame.Serializer.DecimalType.FromDouble(2.00); // The rate discount of the shipping. (2.00 %)


/*
 * Checkout model
 */
dynamic checkout = new {};
checkout.toc = true;
checkout.merchant = merchant;
checkout.order = order;
checkout.customer = customer;
checkout.billing = billingAddress;
checkout.shipping = shippingInfo;
```

In your view you will need to put an snippet similar to this one.
```asp
<script>
  aplazame.checkout( <%= Aplazame.Serializer.JsonSerializer.AsJsonString(checkout); %> );
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

	Console.WriteLine("HTTP Status code " + apiServerException.HttpStatusCode);
	Console.WriteLine("Error type " + apiServerException.ErrorType);
	Console.WriteLine("Error message " + apiServerException.Message);

	dynamic rawErrorWithErrorDetails = apiServerException.Error;

}
catch (Aplazame.Api.ApiClientException apiClientException) {
	// Your client has sent an invalid request. Please check your code.

	Console.WriteLine("HTTP Status code " + apiClientException.HttpStatusCode);
	Console.WriteLine("Error type " + apiClientException.ErrorType);
	Console.WriteLine("Error message " + apiClientException.Message);

	dynamic rawErrorWithErrorDetails = apiClientException.Error;
}

Console.WriteLine(result);
```


## Documentation

Documentation is available at http://docs.aplazame.com.
