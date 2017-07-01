# Libra
### The Open Source Interface for the Gemini Exchange

*Donate* 12fj5Stp31SrYjtcN9T1jnXPGKUsEF92KD

![Gemini](https://winklevosscapital.com/wp-content/uploads/2015/01/gemini-logo-2.png "Gemini Logo")

## Details:

Libra utilizes the open source C# [Gemini Library](https://github.com/lazear/Gemini) to communicate with the exchange. 

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
* Ability to place limit orders and psuedo-stop orders, track past orders
* Extensible API interface

## Setup:

1. Make an account at Gemini
2. Enable API Access, and generate a Key and Secret
3. Open Libra->File->Wallet->New. Paste your Key and Secret, and choose a password to encrypt them
4. Load your "wallet" file, and start using the client!


I claim no rights to the use of the Gemini logo, name, or any other intellectual property relating to the Gemini Trust Company, LLC. No copyright infringement has been intended. This project is completely unaffiliated with the Gemini Trust Company, LLC.