# AcmeCoporation

An auctioning system which enables user to interact and place bids.

## Technology used
* ASP.NET CORE 2.2
* Angular 11
* EF core
* Sql Server 2019 

## Getting Started

### Clone the repository

```
git clone https://github.com/ahamedraashid/AcmeCorporation.git
```

### Prerequisites

* .NET Core SDK 2.2
* Angular CLI 11.0
* Node 12
* Sql Server 2019 (SSMS)

### Installing SPA project
Open AcmeCorporation-SPA and install the npm packages described in the package.json and verify that it works:
```
npm install
```
run the application and check whether it's working.
```
ng serve
```

### Installing API project
Change the connection string to your local SQL server in appsetting.json if you want to run the application

```
 "ConnectionStrings": {
    "Default": "Server=DESKTOP-LQRJPPK\\SQLEXPRESS;Database=acme;Integrated Security=True;"
  },
```

Open AcmeCorporation.API.csproj and build the project

```
dotnet clean
dotnet build
```

If the database is not updated, update the database

```
dotnet ef database update
```

run the application
```
dotnet run
```

Modify the BaseUrl in Angular project (constants.ts) if the .net application run in any other port than localhost:5000

```
export const baseUrlApi = "http://localhost:5000/api/";
export const baseUrl = "http://localhost:5000/";
```
The system should build and work after the above steps, 

```
http://localhost:4200/home
```


## Credentials

### Admin User
* Email: johnwick@gmail.com
* password: password123

### Customer
* Email: jason@gmail.com
* password: password123

Can login to the system by clicking on login button on top right corner on nav bar.

### Features

* Product list would be listed on home (Active and Inactive products)
* User can select a product and view the details of the product.
* Registered user can place a bid for active products.
* If the auction is yet to be started. User can wait until the countdown to finish and place the bids
* When a product auction time expired, User will not be able to bid. Based on the bids, It will marked as sold or unsold.
* Admin user can create a product in the admin panel.
* Admin user can delete non-active products.
* Admin user can modify products which are in in-active status

### Future improvements

* Introducing lazy loading to load products in the home page (Instead of loading all the products in browser at once).
* Improvement to be done on on Admin features (activating and deactivating customers, adding a new Admin).
