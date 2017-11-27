Public Class occupation

    Private Sub occupation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim i As Integer
        If upd = False Then
            Me.C1DateEdit1.Value = Today
        Else
            For i = 0 To Me.porta.DataTable.Rows.Count - 1
                If Me.porta.DataTable.Rows.Item(i).Item(0) = Trim(Mid(Me.Label1.Text, 7)) Then
                    C1DateEdit1.Value = Me.porta.DataTable.Rows.Item(i).Item(1)
                    C1TextBox1.Text = Me.porta.DataTable.Rows.Item(i).Item(2)
                    C1TextBox2.Text = Me.porta.DataTable.Rows.Item(i).Item(3)
                    C1TextBox3.Value = Me.porta.DataTable.Rows.Item(i).Item(4)
                End If
            Next
            C1Button3.Enabled = True
            C1Button1.Enabled = False
        End If


        Me.C1DateEdit1.Calendar.MinDate = "1/1/2008"
        Me.C1DateEdit1.Calendar.MaxDate = "1/1/2020"
    End Sub

    Private Sub C1Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1Button1.Click

        If Me.C1TextBox1.Text = "" Or Me.C1TextBox2.Text = "" Then
            MessageBox.Show("Το όνομα και το επίθετο είναι υποχρεωτικά πεδία. Παρακαλώ συμπληρώστε.")
            Exit Sub
        End If

        SqlConnection1.Open()
        Try
            SqlCommand1.Parameters.Clear()
            With SqlCommand1
                .Parameters.AddWithValue("id", Trim(Mid(Label1.Text, 7)))
                .Parameters.AddWithValue("dmy_arrive", Me.C1DateEdit1.Value)
                .Parameters.AddWithValue("onoma", Me.C1TextBox1.Text)
                .Parameters.AddWithValue("epitheto", Me.C1TextBox2.Text)
                .Parameters.AddWithValue("comments", Me.C1TextBox3.Text)
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

    Private Sub C1Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1Button3.Click
        If Me.C1TextBox1.Text = "" Or Me.C1TextBox2.Text = "" Then
            MessageBox.Show("Το όνομα και το επίθετο είναι υποχρεωτικά πεδία. Παρακαλώ συμπληρώστε.")
            Exit Sub
        End If

        SqlConnection1.Open()
        Try
            SqlCommand2.Parameters.Clear()
            With SqlCommand2
                .Parameters.AddWithValue("id", Trim(Mid(Label1.Text, 7)))
                .Parameters.AddWithValue("dmy_arrive", Me.C1DateEdit1.Value)
                .Parameters.AddWithValue("onoma", Me.C1TextBox1.Text)
                .Parameters.AddWithValue("epitheto", Me.C1TextBox2.Text)
                .Parameters.AddWithValue("comments", Me.C1TextBox3.Text)
            End With
            MessageBox.Show("Επιτυχής Καταχώριση.")
            SqlCommand2.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
            Exit Sub
        Finally
            SqlConnection1.Close()
        End Try
        start.places.DataTable.DataSet.Fill()
        deoccupation.C1ExpressTable1.DataTable.DataSet.Fill()
        save_settings()
        upd = False
        Me.Close()
    End Sub

    Private Sub C1Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1Button2.Click
        upd = False
        Me.Close()
    End Sub
End Class