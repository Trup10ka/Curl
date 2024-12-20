# Curl CLI Application

A simple CLI application that mimics a basic version of the `curl` command. It supports several commands like `curl`, `help`, and `exit`, and provides functionality to interact with URLs and perform simple HTTP GET operation.

## Features

- **Curl Command**: Makes HTTP requests to a specified URL and allows custom arguments for options like limiting output length and writing the result to a file.
- **Help Command**: Provides descriptions for available commands.
- **Exit Command**: Terminates the CLI application.
- **Configurable**: The application reads configuration settings from a JSON file for flexibility.

## Requirements

- .NET 6.0 or higher
- JSON configuration file (`config.json`)

## Setup and Installation

1. Clone the repository to your local machine.
   
   ```bash
   git clone https://github.com/Trup10ka/Curl.git
   cd curl-cli
   ```

2. Build the application using the .NET CLI.

   ```bash
   dotnet build
   ```

3. Run the application.

   ```bash
   dotnet run
   ```

   When you run the application, the command-line interface (CLI) will start, and you can enter commands interactively.

## Usage

### Commands

The CLI supports the following commands:

### 1. `curl <url> [options]`

Makes an HTTP request to the specified URL with optional arguments.

#### Options:
- `-L <length>`: Limits the output to the first `<length>` characters.
- `-O <filename>`: Writes the output to the specified `<filename>`.

#### Example:
```bash
> curl https://example.com -L 100 -O output.txt
```
This command will fetch the content from `https://example.com`, limit the output to the first 100 characters, and write the result to `output.txt`.

### 2. `help [command]`

Displays help information about the available commands. If no command is specified, general help is shown.

#### Example:
```bash
> help
```
This will display general help about the CLI.

For a specific command, use the command name after `help`.

```bash
> help curl
```
This will display help information specifically for the `curl` command.

### 3. `exit`

Terminates the CLI application.

#### Example:
```bash
> exit
```
This command will close the application.

## Configuration

The application loads configuration settings from a JSON file (`config.json`). The configuration file contains general help text and command-specific help text.

Here’s an example of the `config.json` structure:

```json
{
  "SimpleHelpText": "This is the general help text for the CLI.",
  "CurlHelpText": "Usage of the curl command: curl <url> [options]."
}
```

If the `config.json` file does not exist, a template will be created automatically.

## Error Handling

The CLI handles various errors gracefully:

- Invalid command or argument: A helpful error message will be displayed.
- Missing configuration file: A template will be generated automatically.

## How It Works

### Command Execution

When a command is entered, the following steps are performed:

1. The input is parsed into a command type (e.g., `curl`, `help`, `exit`).
2. If the command is valid, it is executed.
3. If additional arguments are provided, they are processed accordingly.
4. The result of the command execution is displayed in the console.

### Curl Command

The `CurlCommand` class is responsible for handling HTTP requests. It allows users to provide optional arguments for limiting content length or writing to a file.

- **HTTP Request**: The `GetContentAsync` method performs the HTTP request to fetch content.
- **Output Handling**: If a file output is specified, the content is written to the file.

### Help Command

The `HelpCommand` class provides information on available commands. It can either show general help or provide details for a specific command.

### Config Loading

Configuration settings are loaded from a `config.json` file. If the file doesn't exist, it will be created with a template.

---

For more information, check the project documentation or contribute to the repository.


## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
