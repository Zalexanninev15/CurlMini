# CurlMini | [Latest release](https://github.com/Zalexanninev15/CurlMini/releases/tag/1.0)

![image](https://i.imgur.com/GaEEDbp.png)

## Description
Graphical version of the curl utility for Windows 10

## System requirements
* **OS:** Windows 10 (build 1803 or or higher)
* **Additional:** Microsoft .NET Framework 4.5

## Features

* Fast execution of curl commands/request
* The last executed command is saved in the history and automatically inserted into the text field for the command to be executed again later
* The result of the curl utility is recorded in text fields, and the results can be compared "right in front of your eyes"
* Commands are recorded in the "command history" and then they can be reused. The list is also saved in a file called "commands. log"
* The utility performs smart checks and displays progress statuses of work

## How to use it?

### GIF: 

[See here](https://github.com/Zalexanninev15/CurlMini/blob/master/CurlMini-Example.gif)

### Text:

1. Launch the utility and make sure that your version of Windows 10 is higher or equal to build 1803. **This is very important!**

2. Enter/paste the desired command in the "Command:" text field (the command must be written/inserted without "curl" at the beginning). 

**For example:**

*The original command:* 

```bash
curl -F shorten=https://www.youtube.com/ https://0x0.st
```

*The text you need:*

```bash
-F shorten=https://www.youtube.com/ https://0x0.st
```

3. Click the "Send command" button and wait for the process to finish. Text fields with results will be automatically updated at the end of the process.

## Build
Compile using Visual Studio 2015-2019, tested on Visual Studio 2019