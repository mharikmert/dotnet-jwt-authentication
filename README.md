## What is JSON Web Token?
JSON Web Token (JWT) is an open standard (RFC 7519) that defines a compact and self-contained way for securely transmitting information between parties as a JSON object. This information can be verified and trusted because it is digitally signed. JWTs can be signed using a secret (with the HMAC algorithm) or a public/private key pair using RSA or ECDSA.

Although JWTs can be encrypted to also provide secrecy between parties, we will focus on signed tokens. Signed tokens can verify the integrity of the claims contained within it, while encrypted tokens hide those claims from other parties. When tokens are signed using public/private key pairs, the signature also certifies that only the party holding the private key is the one that signed it.

## Structure of JWT 
![legacy-app-auth-5](https://user-images.githubusercontent.com/42295478/127875741-f7aa64fd-d44f-4272-9eed-ea28d2aff759.png)

## Installation and Run 
```
~$ git clone https://github.com/mharikmert/dotnet-jwt-authentication
```
In the main directory; 
```
dotnet-jwt-authentication~$ dotnet run
```
Checkout swagger UI -> https://localhost:5001/swagger/index.html

![swagger ui](https://user-images.githubusercontent.com/42295478/127877592-6b0ad0ff-92be-4a6a-a519-9259398405e7.png)

### In memory users
![in mem users](https://user-images.githubusercontent.com/42295478/127879997-ad2cdd1f-fa62-4622-b439-d254f5c7ae0c.png)

## Authentication 
User credentials are sent to ```api/auth``` endpoint in the request body. If the credentials are matched, user is authenticated and a Json Web Token is produced for the user.
User password assigned as null, and the token returns to the client in the response body. 

### Auth request with correct user credentials 
![auth request](https://user-images.githubusercontent.com/42295478/127878877-1319811f-266a-4c2d-9d16-dc23e56996ec.png)

### Auth response and Produced Web Token
![auth response ](https://user-images.githubusercontent.com/42295478/127878965-f5d73236-7878-4c18-87a4-b358da6e4b90.png)

### Auth request with incorrect user credentials
![wrong request](https://user-images.githubusercontent.com/42295478/127880572-c1c7bada-181b-402e-8755-0f88ec1c724a.png)

### Auth response as bad request
![bad reqeust](https://user-images.githubusercontent.com/42295478/127880636-c2d435a1-56d1-4b1c-9fde-728d56e3b24e.png)


## Resources 
You can checkout the official documentation of JWT for more information -> https://jwt.io/introduction
