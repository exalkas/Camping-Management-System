Public Class start
    'Private aa(0 To 1000, 0 To 1)
    Public Sub bbClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ii As String
        ii = CType(sender, System.Windows.Forms.Button).Name

        'MessageBox.Show(ii)
        If CType(sender, System.Windows.Forms.Button).BackColor = Color.Beige Then
            occupation.Label1.Text = "Χώρος: " & CType(sender, System.Windows.Forms.Button).Text
            occupation.C1Button3.Enabled = False
            occupation.Show()
        Else
            deoccupation.Label1.Text = "Χώρος: " & CType(sender, System.Windows.Forms.Button).Text
            deoccupation.Show()
        End If


    End Sub

    Public Sub start_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        load_plan()
    End Sub

    Private MouseIsDownOnButton1 As Boolean
    Private line As Integer
    Private MouseLocationInMouseDownEvent As Point
    Public Sub bbmousedown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim i As Integer

        If e.Button = Windows.Forms.MouseButtons.Right Then


            MouseLocationInMouseDownEvent = e.Location
            MouseIsDownOnButton1 = True

            For i = 0 To Me.places.DataTable.Rows.Count - 1
                If aa(i, 0) = CType(sender, System.Windows.Forms.Button).Name Then
                    line = aa(i, 1)
                    Exit For
                End If
            Next
        End If

    End Sub
    Public Sub bbMouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        If MouseIsDownOnButton1 And e.Button = Windows.Forms.MouseButtons.Right Then

            Select Case line
                Case 1
                    Select Case CType(sender, System.Windows.Forms.Button).Top
                        Case Is < 15
                            CType(sender, System.Windows.Forms.Button).Left += e.X - MouseLocationInMouseDownEvent.X
                            CType(sender, System.Windows.Forms.Button).Top = 15
                            bbMouseUp(CType(sender, System.Windows.Forms.Button).Name, e)
                            Exit Sub
                        Case 15 To 117
                            CType(sender, System.Windows.Forms.Button).Left += e.X - MouseLocationInMouseDownEvent.X
                            CType(sender, System.Windows.Forms.Button).Top += e.Y - MouseLocationInMouseDownEvent.Y
                        Case Is > 117
                            CType(sender, System.Windows.Forms.Button).Left += e.X - MouseLocationInMouseDownEvent.X
                            CType(sender, System.Windows.Forms.Button).Top = 117
                            bbMouseUp(CType(sender, System.Windows.Forms.Button).Name, e)
                            Exit Sub
                    End Select
                Case 2
                    Select Case CType(sender, System.Windows.Forms.Button).Top
                        Case Is < 15
                            CType(sender, System.Windows.Forms.Button).Left += e.X - MouseLocationInMouseDownEvent.X
                            CType(sender, System.Windows.Forms.Button).Top = 15
                            bbMouseUp(CType(sender, System.Windows.Forms.Button).Name, e)
                            Exit Sub
                        Case 15 To 170
                            CType(sender, System.Windows.Forms.Button).Left += e.X - MouseLocationInMouseDownEvent.X
                            CType(sender, System.Windows.Forms.Button).Top += e.Y - MouseLocationInMouseDownEvent.Y
                        Case Is > 170
                            CType(sender, System.Windows.Forms.Button).Left += e.X - MouseLocationInMouseDownEvent.X
                            CType(sender, System.Windows.Forms.Button).Top = 170
                            bbMouseUp(CType(sender, System.Windows.Forms.Button).Name, e)
                            Exit Sub
                    End Select
                Case 3
                    Select Case CType(sender, System.Windows.Forms.Button).Top
                        Case Is < 15
                            CType(sender, System.Windows.Forms.Button).Left += e.X - MouseLocationInMouseDownEvent.X
                            CType(sender, System.Windows.Forms.Button).Top = 15
                            bbMouseUp(CType(sender, System.Windows.Forms.Button).Name, e)
                            Exit Sub
                        Case 15 To 106
                            CType(sender, System.Windows.Forms.Button).Left += e.X - MouseLocationInMouseDownEvent.X
                            CType(sender, System.Windows.Forms.Button).Top += e.Y - MouseLocationInMouseDownEvent.Y
                        Case Is > 106
                            CType(sender, System.Windows.Forms.Button).Left += e.X - MouseLocationInMouseDownEvent.X
                            CType(sender, System.Windows.Forms.Button).Top = 106
                            bbMouseUp(CType(sender, System.Windows.Forms.Button).Name, e)
                            Exit Sub
                    End Select
                Case Else
                    Exit Select
            End Select

            Select Case CType(sender, System.Windows.Forms.Button).Left
                Case Is < 10
                    CType(sender, System.Windows.Forms.Button).Top += e.Y - MouseLocationInMouseDownEvent.Y
                    CType(sender, System.Windows.Forms.Button).Left = 10
                    bbMouseUp(CType(sender, System.Windows.Forms.Button).Name, e)
                    Exit Sub
                Case Is > 980
                    CType(sender, System.Windows.Forms.Button).Top += e.Y - MouseLocationInMouseDownEvent.Y
                    CType(sender, System.Windows.Forms.Button).Left = 980
                    bbMouseUp(CType(sender, System.Windows.Forms.Button).Name, e)
                    Exit Sub
            End Select

        End If

    End Sub

    Public Sub bbMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        MouseIsDownOnButton1 = False

    End Sub

    Private Sub C1Command2_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles C1Command2.Click
        sss.Show()
    End Sub

    Private Sub C1Command3_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles C1Command3.Click
        place_update.Show()
    End Sub

    Private Sub C1Command4_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles C1Command4.Click
        delete_place.Show()
    End Sub

    Private Sub C1Command5_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles C1Command5.Click

        save_settings()

        MessageBox.Show("Επιτυχής Καταχώριση.")
    End Sub
End Class
