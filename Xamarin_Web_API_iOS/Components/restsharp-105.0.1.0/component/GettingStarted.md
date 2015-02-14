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

## Features
```csharp
var client = new RestClient("http://example.com");
// client.Authenticator = new HttpBasicAuthenticator(username, password);

var request = new RestRequest("resource/{id}", Method.POST);
request.AddParameter("name", "value"); // adds to POST or URL querystring based on Method
request.AddUrlSegment("id", 123); // replaces matching token in request.Resource

// add parameters for all properties on an object
request.AddObject(object);

// or just whitelisted properties
request.AddObject(object, "PersonId", "Name", ...);

// easily add HTTP Headers
request.AddHeader("header", "value");

// add files to upload (works with compatible verbs)
request.AddFile(path);

// execute the request
RestResponse response = client.Execute(request);
var content = response.Content; // raw content as string

// or automatically deserialize result
// return content type is sniffed but can be explicitly set via RestClient.AddHandler();
RestResponse<Person> response2 = client.Execute<Person>(request);
var name = response2.Data.Name;

// or download and save file to disk
client.DownloadData(request).SaveAs(path);

// easy async support
client.ExecuteAsync(request, response => {
    Console.WriteLine(response.Content);
});

// async with deserialization
var asyncHandle = client.ExecuteAsync<Person>(request, response => {
    Console.WriteLine(response.Data.Name);
});

// abort the request on demand
asyncHandle.Abort();
```

## Documentation

- Wiki: [https://github.com/restsharp/RestSharp/wiki](https://github.com/restsharp/RestSharp/wiki)

## Contact / Discuss

- Please use the [Google Group](http://groups.google.com/group/RestSharp) for feature requests and troubleshooting usage.
- Twitter: [@RestSharp](http://twitter.com/restsharp)