# 1.31.0

You project should still work, you might need to add Cloudinary.Core.Html if certain methods are missing.

* Reduce dependencies on Cloudinary.Core main project
  * Extract Html components and put it into Cloudinary.Core.Html.
  * Deprecate usage of internal StringDicionary and use `IDictionary<string, string>` instead

# 1.30.0

* Async first
* Replaced WebClient with HttpClient
* Moved Synchronous code to Cloudinary.Core.Sync (Extension methods on Cloudinary)

# 1.30.0-camma

* properly implemented Async for: UploadAsync & DeleteResourcesAsync

# 1.30.0-beta

* Code cleanup
* Better handling of async tasks 

# 1.30.0-alpha 

* Initial buildable solution: 
  * Contains custom simple rectangle struct. 
  * Throws whenever HttpContext.Current is used 
  * Removed Aspx references