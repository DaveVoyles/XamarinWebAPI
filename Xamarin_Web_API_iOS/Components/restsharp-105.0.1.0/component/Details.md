RestSharp makes it easy to consume the wide array of services on the web over HTTP, like: Amazon, Facebook, or even Twitter...

## Features

* Automatic XML and JSON deserialization
* Supports custom serialization and deserialization via ISerializer and IDeserializer
* Fuzzy element name matching ('product_id' in XML/JSON will match C# property named 'ProductId')
* Automatic detection of type of content returned
* GET, POST, PUT, HEAD, OPTIONS, DELETE supported
* Other non-standard HTTP methods also supported
* oAuth 1, oAuth 2, Basic, NTLM and Parameter-based Authenticators included
* Supports custom authentication schemes via IAuthenticator
* Multi-part form/file uploads
* T4 Helper to generate C# classes from an XML document

## Example

```csharp
using RestSharp;
// ...

var client = new RestClient ("http://rxnav.nlm.nih.gov/REST/RxTerms/rxcui/");

var request = new RestRequest (String.Format ("{0}/allinfo", "198440"));
client.ExecuteAsync (request, response => {
	Console.WriteLine (response.Content);
});
```