# Documentation

### Using Libra
The first thing you should do after downloading Libra is generate an API key pair on the Gemini website. Selecting "New" under the "File->Wallet" menu in Libra will allow you to save your API key pair in an encrypted file, so that you will not need to generate API keys everytime you want to log in. Note that is possible for the encrypted file to become corrupted if Libra crashes, so you may need to generate a new keypair in the future. Due to how the API system works, backing up the file is NOT recommended.

### Internet connection
A stable internet connection is necessary to use Libra, since the program receives streaming data from the exchange. If 5 seconds pass without receiving a _heartbeat_ from the exchange, Libra will try to reconnect. Order information, market data, and stop-order service will be disrupted.

### Order Types
Limit orders- the standard Limit order provided by Gemini. The exchange will try to maximize price, and will not fill orders at a worse price than you submit.

Stop orders- Gemini does not natively support stop orders at this time, however Libra will watch every transaction that occurs on the Exchange. If an order is filled at your set stop price _P_, then Libra will immediately send a limit order to be filled. For stop-loss orders, Libra submits a limit order to fill  at _P-1_, and _P+1_ for buy orders. _As such, closing Libra will cancel all pending stop orders._

### Viewing Order Data
Libra loads all of your active orders once you load your API wallet, and is notified by the Exchange whenever there is a change to one of your orders. This is represented by the 'Order Tree', and you can select orders to view information about them, as well as cancel an individual order.

### Market Data
Libra uses the Gemini Websocket API to receive real-time market data streamed from the Exchange. Last prices are shown in the status strip, and also to the right of the Order Tree.
VWAP(24) is a calculation showing the volume-weighted average price of each currency on the exchange. This is seeded by data from the 24 hours prior to when Libra is started, and the value is recalculated everytime a trade occurs.

### Errors and Exceptions
In the event that Libra encounters an error, it will record information about the problem in a file called "libra_log.txt". You can open an issue on [GitHub](https://github.com/lazear/Libra/issues) and copy and paste this information there.