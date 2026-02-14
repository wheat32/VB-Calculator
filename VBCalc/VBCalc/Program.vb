Imports System

Module Program
    Sub Main()
        Console.Title = "Calculator in VB.Net"
        
        Console.WriteLine("Type in a mathematical expression to solve. Space-separate operands and operators.")
        Console.WriteLine("Example: 2 + 2")
        Console.WriteLine("Supported operators: +, -, *, /")
        Console.WriteLine("Parentheses are supported for grouping.")
        Console.WriteLine("Type 'exit' to quit the program.")
        
        While True
            Console.Write("Enter expression: ")
            Dim input As String = Console.ReadLine()

            If input.Equals("exit", StringComparison.OrdinalIgnoreCase) Then
                Exit While
            End If

            Try
                Dim result As Double = EvaluateExpression(input)
                Console.WriteLine("Result: " & result)
            Catch ex As Exception
                Console.WriteLine("Error: " & ex.Message)
            End Try
        End While
    End Sub
    
    Private Function EvaluateExpression(expression As String) As Double
        Dim postfix As String = ShuntingYard.InfixToPostfix(expression)
        Return PostfixEvaluator.EvaluatePostfix(postfix)
    End Function
End Module
