Public Class delete_place

    Private Sub C1Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1Button1.Click

        SqlConnection1.Open()
        Try
            SqlCommand1.Parameters.Clear()
            With SqlCommand1
                .Parameters.AddWithValue("id", Me.C1TextBox1.Text)
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
End Class