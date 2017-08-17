# Libra
### The open source user interface for the Gemini Exchange

Donations:
* BTC 12fj5Stp31SrYjtcN9T1jnXPGKUsEF92KD
* ETH 0x2189b1E5C719093AbEFC1BE926fD92d23f4C52Fd

<img src="https://github.com/lazear/Libra/blob/master/Libra.png" width="600"/>

## Details:
Libra is a C# GUI program providing access to the Gemini Exchange API, utilizing the open source C# [Gemini Library](https://github.com/lazear/Gemini).

#### _Free!_
* Free as in beer. Free as in pizza. Free as in speech.
* Written in C#, using no external libraries (well, besides the Gemini Library, which I wrote).
* Released under the MIT License
#### _Safe!_
* API Keys are stored as AES-256 encrypted files
* Data is only transmitted to Gemini.
* Gemini only allows withdrawals to whitelisted addresses, which cannot be setup via API
* No telemetry, no automatic updates, no communicating with unknown servers.
#### _Useful!_
* Ability to place limit orders ***and*** stop orders, something not possible with just the web interface
* Extensible API interface

## Setup:

1. Make an account at Gemini
2. Enable API Access, and generate a Key and Secret
3. Open Libra->File->Wallet->New. Paste your Key and Secret, and choose a password to encrypt them
4. Load your "wallet" file, and start using the client!

## Compiling from source
Linux/Mac: Install the open source [Mono framework](http://www.mono-project.com)
1. Clone the [Gemini Library](https://github.com/lazear/Gemini) and Libra into the same parent directory
2. Windows: use Visual Studio or MSBuild to compile Gemini and then Libra
3. Linux/Mac: Use `xbuild /p:Configuration=Release` on Gemini and then Libra. Use `mono Libra.exe` to run the application

I claim no rights to the use of the Gemini logo, name, or any other intellectual property relating to the Gemini Trust Company, LLC. No copyright infringement has been intended. This project is completely unaffiliated with the Gemini Trust Company, LLC.
