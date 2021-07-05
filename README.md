# Poolified-ChiaRPC.Net

Wrapper library around the endpoints exposed by the RPC interfaces in the chia blockchain.
The available interface methods can be looked up [here](https://github.com/Chia-Network/chia-blockchain/wiki/RPC-Interfaces).

## Differences to version on Nuget
The only difference is that this fork contains some endpoints only found in the <a href="https://github.com/mageinn/Poolified-ChiaRPC.Net">poolfied-chia-blockchain</a> fork.


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
- If required change the default settings with the parameters in those methods or use `ConfigureChiaRPC` to change the certificate path

<b>Note: <br>
Instead of using the ServiceCollection you can always just create the clients yourself with `new`.</b>


## Warning
- Treat user input into this library with caution as especially the wallet endpoints can be used to spend the coins stored in the wallet!
- This does not yet cover all endpoints provided by the RPC Interfaces. In case you need any endpoints that are not yet included in the library please leave an issue and I will take care of it!
