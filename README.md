<div align="center">

## 

<img width="200" src="https://raw.githubusercontent.com/CosmicPredator/Uncanny-RPC/devel/Assets/main-logo-hd.png">

# UncannyRPC

#### A Discord Rich Presence Client to show-off your desktop's CPU and Memory usage. Written in Avalonia .NET

[Download The Latest Release](https://github.com/CosmicPredator/Uncanny-RPC/releases)

</div>

# 

## Features of UncannyRPC

- Always runs in background.
- Highly customizable properties.
- Configurable using TOML.
- Features a changing "Mr. Incredible becoming Uncanny" image which changes based on CPU usage.
- Simple app, yet adopted the latest fluent design principles.
- Available for Linux and MacOs (soon...)

## Documentation
- TOML Config file documentation is available [here](https://github.com/CosmicPredator/Uncanny-RPC/blob/devel/docs/Config.md).

## Information for Developers

- Framework - `.NET6`
- UI Toolkit - `AvaloniaUI`
- Build Tool - `MSBuild`
- Windows Target - `winx64`
- Language - `C#`
- Lang Version - `10`
- TOML Parser - `TommyParser`

## Build from Source



- #### Install .NET6 SDK

  - Microsoft .NET6 SDK can be installed from their [official site](https://dotnet.microsoft.com/en-us/download/dotnet/6.0).


- #### Clone the repository

    - Clone the repository by running the following command.

```
$ git clone https://github.com/CosmicPredator/Uncanny-RPC.git
```

- #### Build the app
  - Now, build the app by running,

```
$ dotnet publish -c release
```

- #### Run the app
  - Now, the built `exe` will be found in `bin/Release/net6.0/publish/`.
  - Run the app by double clicking on the `exe`.