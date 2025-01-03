# CurlMini

![alt](https://github.com/Zalexanninev15/CurlMini/blob/master/Logo.png?raw=true)

[![](https://img.shields.io/badge/platform-Windows-informational)](https://github.com/Zalexanninev15/CurlMini)
[![](https://img.shields.io/badge/written_on-.NET_Framework_4.5-512BD4.svg?logo=dotnet)](https://dotnet.microsoft.com/download/dotnet-framework/net45)
[![](https://img.shields.io/badge/written_on-C%23-%23239120.svg?logo=sharp&logoColor=white)](https://github.com/Zalexanninev15/CurlMini)
[![](https://img.shields.io/github/v/release/Zalexanninev15/CurlMini)](https://github.com/Zalexanninev15/CurlMini/releases/latest)
[![](https://img.shields.io/github/downloads/Zalexanninev15/CurlMini/total.svg)](https://github.com/Zalexanninev15/CurlMini/releases)
[![](https://img.shields.io/github/last-commit/Zalexanninev15/CurlMini)](https://github.com/Zalexanninev15/CurlMini/commits/master)
[![](https://img.shields.io/github/stars/Zalexanninev15/CurlMini.svg)](https://github.com/Zalexanninev15/CurlMini/stargazers)
[![](https://img.shields.io/github/forks/Zalexanninev15/CurlMini.svg)](https://github.com/Zalexanninev15/CurlMini/network/members)
[![](https://img.shields.io/github/issues/Zalexanninev15/CurlMini.svg)](https://github.com/Zalexanninev15/CurlMini/issues?q=is%3Aopen+is%3Aissue)
[![](https://img.shields.io/github/issues-closed/Zalexanninev15/CurlMini.svg)](https://github.com/Zalexanninev15/CurlMini/issues?q=is%3Aissue+is%3Aclosed)
[![](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)
[![](https://img.shields.io/badge/Donate-FFDD00.svg?logo=buymeacoffee&logoColor=black)](https://z15.neocities.org/donate)

## Screenshot

![alt](https://github.com/Zalexanninev15/CurlMini/blob/master/CurlMini-Screenshot.png?raw=true)

## Description

Graphical version of the curl utility for Windows.

## System requirements

* **OS:** Windows 7 or higher
* **Additional:** .NET Framework 4.5 or higher, curl (if this utility is not available, you will be prompted to install it in automatic mode)

## Features

* Fast execution of curl requests.
* The last executed request is saved in the history and automatically inserted into the text field for the requests to be executed again later.
* Unique feature of installing curl utility on all versions of Windows (7-10)
* The ability to expand the text field for the command so that you can check the request for indents, unnecessary spaces, or even line breaks, which of course will affect the performance of the command.
* The result of the curl utility is recorded in text fields, and the results can be compared "right in front of your eyes".
* Commands are recorded in the "requests history" and then they can be reused. The list is also saved in a file called "requests.log".
* The utility performs smart checks and displays progress statuses of work.

## How to use it?

### GIF

![See here](https://github.com/Zalexanninev15/CurlMini/blob/master/CurlMini-Example.gif?raw=true)

### Text

1. Launch the utility and make sure that your version of Windows 10 is higher or equal to build 1803 (or you have Windows > 10). If you have Windows < 10 - please, install the curl utility from application
2. Enter/paste the desired command in the "Requests:" text field (the command must be written/inserted without "curl" at the beginning).

**For example:**

*The original request:*

```batch
curl -F shorten=https://www.youtube.com/ https://0x0.st
```

*The text you need:*

```console
-F shorten=https://www.youtube.com/ https://0x0.st
```

3. Click the "Send request" button and wait for the process to finish. Text fields with results will be automatically updated at the end of the process.

## Build

Compile using [SharpDevelop](https://sourceforge.net/projects/sharpdevelop) or [Visual Studio](https://visualstudio.microsoft.com/vs)
