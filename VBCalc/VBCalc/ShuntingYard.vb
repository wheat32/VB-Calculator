Public Module ShuntingYard
    private Function IsOperator(token As Char) As Boolean
        Return token = "+" OrElse token = "-" OrElse token = "*" OrElse token = "/"
    End Function
    
    private Function GetPrecedence(op As Char) As Integer
        Select Case op
            Case "+", "-"
                Return 1
            Case "*", "/"
                Return 2
            Case Else
                Return 0
        End Select
    End Function
    
    Public Function InfixToPostfix(expression As String) As String
        Dim output As New List(Of String)()
        Dim operators As New Stack(Of String)()
        Dim tokens As String() = expression.Split(" "c)

        For Each token As String In tokens
            If Double.TryParse(token, Nothing) Then
                output.Add(token)
            ElseIf IsOperator(token) Then
                While operators.Count > 0 AndAlso IsOperator(operators.Peek()) AndAlso GetPrecedence(token) <= GetPrecedence(operators.Peek())
                    output.Add(operators.Pop())
                End While
                operators.Push(token)
            ElseIf token = "(" Then
                operators.Push(token)
            ElseIf token = ")" Then
                While operators.Count > 0 AndAlso operators.Peek() <> "("
                    output.Add(operators.Pop())
                End While
                If operators.Count = 0 OrElse operators.Peek() <> "(" Then
                    Throw New Exception("Mismatched parentheses")
                End If
                operators.Pop()
            End If
        Next

        While operators.Count > 0
            If operators.Peek() = "(" Then
                Throw New Exception("Mismatched parentheses")
            End If
            output.Add(operators.Pop())
        End While

        Return String.Join(" ", output)
    End Function
End Module