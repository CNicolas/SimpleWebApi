# SimpleWebApi
Simple ASP Web Api 2 controllers

### /api/authenticate 
The controller accepts POST method with an Email and a Password.<br>
If they are valid (compared to hardly coded credentials), it returns `Ok(true)`, otherwise `Ok(false)`.

### /api/confidentials 
The controller accepts both GET and POST, but in my opinion the GET is sufficient.<br>
It implements the **RestAuthentication**. It is not really secured, unless the **https** protocol is used.

When no Authorization header is provided in the request, the user receives a `Unauthorized` response.<br>
If the Authorization header is provided, the value is compared to hardly coded credentials.<br>
If they are valid, it returns `Ok(true)`, otherwise `Ok(false)`.
