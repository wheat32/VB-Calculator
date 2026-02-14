# VB Calculator

A simple command-line calculator written in VB.NET, demonstrating the implementation of the Shunting Yard algorithm and postfix expression evaluation.

## Overview

This project is a demonstration of VB.NET programming, showcasing:
- The Shunting Yard algorithm for converting infix notation to postfix notation
- Stack-based postfix expression evaluation
- Basic error handling and user input validation

## Features

- Basic arithmetic operations: addition (+), subtraction (-), multiplication (*), division (/)
- Support for parentheses to control operation precedence
- Interactive command-line interface
- Error handling for invalid expressions and division by zero

## Usage

Run the program and enter mathematical expressions with space-separated operands and operators:

```
Enter expression: 2 + 2
Result: 4

Enter expression: ( 3 + 5 ) * 2
Result: 16

Enter expression: 10 / 2 - 3
Result: 2
```

Type `exit` to quit the program.

## Requirements

- .NET 10.0 or later

## Building and Running

```bash
dotnet build
dotnet run
```

## Project Structure

- `Program.vb` - Main entry point and user interface
- `ShuntingYard.vb` - Implementation of the Shunting Yard algorithm
- `PostfixEvaluator.vb` - Postfix expression evaluator

## Notes

**Important:** Expressions must be space-separated. For example:
- ✅ `2 + 2`
- ✅ `( 3 + 5 ) * 2`
- ❌ `2+2` (will not work)

