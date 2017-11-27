Public Class deoccupation

    Private Sub deoccupation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim i As Integer
        Me.C1DateEdit1.Value = Today
        Me.C1DateEdit1.Calendar.MinDate = "1/1/2008"
        Me.C1DateEdit1.Calendar.MaxDate = "1/1/2020"

        For i = 0 To Me.C1ExpressTable1.DataTable.Rows.Count - 1
            If Me.C1ExpressTable1.DataTable.Rows.Item(i).Item(0) = Trim(Mid(Me.Label1.Text, 7)) Then
                Me.Label6.Text = Me.C1ExpressTable1.DataTable.Rows.Item(i).Item(1)
                Me.Label7.Text = Me.C1ExpressTable1.DataTable.Rows.Item(i).Item(2)
                Me.Label8.Text = Me.C1ExpressTable1.DataTable.Rows.Item(i).Item(3)
                Me.C1TextBox1.Value = Me.C1ExpressTable1.DataTable.Rows.Item(i).Item(4)
            End If
        Next

    End Sub

    Private Sub C1Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1Button1.Click

        SqlConnection1.Open()
        Try
            SqlCommand1.Parameters.Clear()
            With SqlCommand1
                .Parameters.AddWithValue("id", Trim(Mid(Label1.Text, 7)))
                .Parameters.AddWithValue("dmy_leave", Me.C1DateEdit1.Value)
            End With

            SqlCommand1.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
            Exit Sub
        Finally
            SqlConnection1.Close()
        End Try
        start.places.DataTable.DataSet.Fill()
        save_settings()
        Me.Close()
    End Sub

    Private Sub C1Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1Button2.Click
        Me.Close()
    End Sub

    Private Sub C1Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1Button3.Click
        occupation.Label1.Text = "Χώρος: " & Trim(Mid(Label1.Text, 7))
        upd = True
        occupation.Show()
        Me.Close()
        Exit Sub
    End Sub
End Class