#Welcome to Rabun wrapper for OANDA REST API

Hi! We offer you to use our wrapper for the oanda rest api in C#. 
We tried to implement most of the features of oanda rest api and 
provide you with a convenient C# interface.

Below you will find a detailed description of working with our wrapper.

#Support tech

This is a portable .NET library. You can use it with: Windows 8/10, Windows Phone,
WPF, ASP.NET, ASP.NET 5 DNX, Windows Forns, Mono.

#How to install library

You can build the library or download the package using nuget. You need Visual Studio
2013 or later.

##Build library from source

Get source code from github. You can use release (stable version) or master branch
with latest futures, but master sourse may not work.

Open solution at your Visual Studio and run build. All projects must build success.

##Get library from NuGet package

Open NuGet Package Manager console at your Visual Studio and run this command:

```
PM> Install-Package Rabun.Oanda.Rest.Cs
```

## Tests

You can run Integration and Unit tests. WARNING! You can use own account information:
securiry key, accountId. Don't forget change Asserts at tests for your trading.

#How to use it

To start working with services OANDA you need to create an instance of the class 
xxxEndpoints. Where xxx is the name of the operations you want to perform.

You can use Endpoints class:

```csharp
OrderEndpoints orderEndpoints = new OrderEndpoints("ec89b162d4a9922c8fa40769c2453d8b-cc1fb522857d46a08a90ef09730343a6", AccountType.practice, 4905675);
List<Order> orders = await orderEndpoints.GetOrders();
```

or use fabric:

```csharp
DefaultFactory factory = new DefaultFactory("ec89b162d4a9922c8fa40769c2453d8b-cc1fb522857d46a08a90ef09730343a6", AccountType.practice, 4905675);
RateEndpoints rateEndpoints = factory.GetEndpoint<RateEndpoints>();

List<Price> prices = await rateEndpoints.GetPrices("EUR_USD");
```

The DefaultFactory provide instances for all xxxEndpoints. Using Factory pattern is
the best way to work with this api.

#Implementation

Now implement these services:
* OrderEndpoints
* PositionEndpoints
* RateEndpoints
* TradeEndpoints
* TransactionEndpoints

More information about this services you can find at http://developer.oanda.com/rest-live/introduction/

#Examples

##Orders

####GetOrders

```csharp
List<Order> orders = await _orderEndpoints.GetOrders();
```

```csharp
List<Order> orders = await _orderEndpoints.GetOrders("EUR_USD");
```

```csharp
List<Order> orders = await _orderEndpoints.GetOrders("EUR_USD", 5);
```

```csharp
List<Order> orders = await _orderEndpoints.GetOrders("EUR_USD", 5, null, null);
```

####GetOrder
```csharp
Order order = await _orderEndpoints.GetOrder(965436841);
```

####CreateOrder

```csharp
OrderOpen order = await _orderEndpoints.CreateOrder("EUR_USD", 777, OandaTypes.Side.buy, OandaTypes.OrderType.marketIfTouched, DateTime.Now.AddDays(1), 1.1630f, null, null, null, null);
```

```csharp
OrderOpen order = await _orderEndpoints.CreateMarketOrder("EUR_USD", 999, OandaTypes.Side.buy);
```

```csharp
OrderOpen order = await _orderEndpoints.CreateMarketIfTouchedOrder("EUR_USD", 999, OandaTypes.Side.buy, DateTime.Now.AddDays(1), 1.4f);
```

####UpdateOrder
```csharp
OrderMarketIfTouched order = await _orderEndpoints.UpdateOrder(965436841, 333, 1.1f, null, null, null, null, null, null);
```

####CloseOrder
```csharp
OrderClosed order = await _orderEndpoints.CloseOrder(965875303);
```

