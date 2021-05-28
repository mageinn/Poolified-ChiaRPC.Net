# ChiaRPC.Net

Wrapper library around the endpoints exposed by the RPC interfaces in the chia blockchain.
The available interface methods can be looked up [here](https://github.com/Chia-Network/chia-blockchain/wiki/RPC-Interfaces).

## How to use
### Install via nuget
`Install-Package ChiaRPC`<br>
https://www.nuget.org/packages/ChiaRPC/

### Add to service provider
- Make sure to import `ChiaRPC.Extensions`
- Add the clients you need to your `ServiceCollection` using the provided extension methods
  - `AddChiaFarmerClient`
  - `AddChiaHarvesterClient`
  - `AddChiaNodeClient`
  - `AddChiaWalletClient`

<b>Note: <br>
Instead of using the ServiceCollection you can always just create instead of the client types yourself.</b>

## Incomplete
This does not yet cover all endpoints provided by the RPC Interfaces. In case you need any endpoints that are not yet included in the library please leave an issue and I will take care of it!