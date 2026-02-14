Public Module PostfixEvaluator
    public Function EvaluatePostfix(postfix As String) As Double
        Dim stack As New Stack(Of Double)()
        Dim tokens As String() = postfix.Split(" "c)

        For Each token As String In tokens
            If Double.TryParse(token, Nothing) Then
                stack.Push(Double.Parse(token))
            Else
                If stack.Count < 2 Then
                    Throw New Exception("Invalid expression")
                End If

                Dim b As Double = stack.Pop()
                Dim a As Double = stack.Pop()

                Select Case token
                    Case "+"
                        stack.Push(a + b)
                    Case "-"
                        stack.Push(a - b)
                    Case "*"
                        stack.Push(a * b)
                    Case "/"
                        If b = 0 Then
                            Throw New Exception("Division by zero")
                        End If
                        stack.Push(a / b)
                    Case Else
                        Throw New Exception("Unknown operator: " & token)
                End Select
            End If
        Next

        If stack.Count <> 1 Then
            Throw New Exception("Invalid expression")
        End If

        Return stack.Pop()
    End Function
End Module