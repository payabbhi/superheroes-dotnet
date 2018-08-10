# Superheroes - A tutorial to enable Payments acceptance via Payabbhi .Net library

Superheroes Store allows purchase of a superhero, to run errands for you, by paying a random amount between ₹1 to ₹5.

The `Payments Acceptance workflow` is implemented as described in the Payabbhi [Integration Guide](https://payabbhi.com/docs/integration) using [Payabbhi .Net Library](https://github.com/payabbhi/payabbhi-dotnet).

The Superheroes tutorial is designed to take you to full implementation in four graded steps:
- Step 1 : Basic implementation of `Payments Acceptance workflow`
- Step 2 : Add `Payment Response Handling`
- Step 3 : Add `Exception Handling`
- Step 4 : Reorganize and Refactor to bring everything together

## Getting started

* Clone the Superheroes repository
* Install [Payabbhi .Net Library](https://github.com/payabbhi/payabbhi-dotnet)
* Sign up for a Payabbhi account and download API Keys
* Set up local env for running Superheroes

### Clone the Superheroes repository

```
 $ git clone https://github.com/paypermint/superheroes-dotnet.git
```

### Install the Payabbhi .Net Client library

To run any of the steps, you will first need to install the [Payabbhi .Net Library](https://github.com/payabbhi/payabbhi-dotnet)
as per instructions provided with it for Nuget etc..

- packages.config
     ```
      <package id="Payabbhi" version="1.0.0" targetFramework="net45" />
     ```

- SuperHeroes.csproj
```
      <Reference Include="Payabbhi">
         <HintPath>packages\Payabbhi.1.0.0\lib\net45\Payabbhi.dll</HintPath>
      </Reference>
```

### Sign up for a Payabbhi account and download API Keys

Next, sign up for a [Payabbhi Account](https://payabbhi.com/docs/account) and download the [API keys](https://payabbhi.com/docs/account/#api-keys) from the [Portal](https://payabbhi.com/portal).

As you go through the tutorial, you will need to replace every instance of `<ACCESS-ID>` and `<SECRET-KEY>` in `HomeController.cs` file with your actual keys. You would typically want to use your `test mode API` keys for this tutorial.

### Running Superheroes


#### With Visual Studio

For each step of the tutorial,
1. Go to a particular step of the tutorial using the following command
```
$ cd <method>/step<step>
```
where `<method>` is either `custom` or `dropin` and `<step>` is any of `1`, `2`, `3` or `4`.

2. Open the `SuperHeroes.sln` file in Visual Studio.
3. Build and Run.


#### With command line

##### Windows

For each step of the tutorial,
1. Open Powershell.
2. Execute following commands to create a distributable `dist` folder.
```
$ ./build.ps1 -method <method> -step <step>
```
where `<method>` is either `custom` or `dropin` and `<step>` is any of `1`, `2`, `3` or `4`

3. A `dist` folder is created for distribution containing a zip file.
4. Unzip and copy the contents of `dist\SuperHeroes<method>step<step>\_PublishedWebsites\SuperHeroes` to the appropriate sub-folder of the IIS server as appropriate


##### Mac
Prerequisite - [Install Mono](http://www.mono-project.com/docs/getting-started/install/mac/)

For each step of the tutorial,

1. Execute following command to start the `xsp` webserver.
```
$ ./build.sh -method <method> -step <step>
$ cd <method>/step<step>
$ xsp4
```
where `<method>` is either `custom` or `dropin` and `<step>` is any of `1`, `2`, `3` or `4`
