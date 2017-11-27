Public Class place_update

    Private Sub C1Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1Button1.Click
        Dim i As Integer

        For i = 0 To Me.places.DataTable.Rows.Count - 1

            If Me.C1TextBox3.Text = Me.places.DataTable.Rows.Item(i).Item(0) Then
                Me.C1TextBox1.Value = Me.places.DataTable.Rows.Item(i).Item(0)
                Me.C1TextBox2.Text = Me.places.DataTable.Rows.Item(i).Item(1)
                Me.C1NumericEdit1.Value = Me.places.DataTable.Rows.Item(i).Item(3)
                Me.C1NumericEdit2.Value = Me.places.DataTable.Rows.Item(i).Item(4)
                Me.C1NumericEdit3.Value = Me.places.DataTable.Rows.Item(i).Item(5)
                Exit For
            Else
                Me.C1TextBox1.Value = 0
                Me.C1TextBox2.Text = ""
                Me.C1NumericEdit1.Value = 0
                Me.C1NumericEdit2.Value = 0
                Me.C1NumericEdit3.Value = 0
            End If

        Next
    End Sub

    Private Sub C1Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1Button3.Click
        Select Case Me.C1NumericEdit1.Value
            Case 1
                If Me.C1NumericEdit3.Value < 15 Or Me.C1NumericEdit3.Value > 117 Then
                    MessageBox.Show("Η σειρά 1 μπορεί να έχει Υ από 15 εώς 117. Παρακαλώ διορθώστε")
                    Exit Sub
                End If
            Case 2
                If Me.C1NumericEdit3.Value < 15 Or Me.C1NumericEdit3.Value > 170 Then
                    MessageBox.Show("Η σειρά 2 μπορεί να έχει Υ από 15 εώς 170. Παρακαλώ διορθώστε")
                    Exit Sub
                End If
            Case 3
                If Me.C1NumericEdit3.Value < 15 Or Me.C1NumericEdit3.Value > 106 Then
                    MessageBox.Show("Η σειρά 3 μπορεί να έχει Υ από 15 εώς 106. Παρακαλώ διορθώστε")
                    Exit Sub
                End If
            Case Else
                MessageBox.Show("Η σειρά μπορεί να είναι 1,2 ή 3. Παρακαλώ διορθώστε")
                Exit Sub
        End Select

        If Me.C1NumericEdit2.Value < 10 Or Me.C1NumericEdit2.Value > 980 Or Me.C1NumericEdit2.Value < 10 Or Me.C1NumericEdit2.Value > 980 Or Me.C1NumericEdit2.Value < 10 Or Me.C1NumericEdit2.Value > 980 Then
            MessageBox.Show("Οι σειρές μπορούν να έχουν X από 10 εώς 980. Παρακαλώ διορθώστε")
            Exit Sub
        End If

        test_place(Me.C1NumericEdit2.Value, Me.C1NumericEdit3.Value, Me.C1NumericEdit1.Value)
    End Sub

    Private Sub C1Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1Button4.Click
        If Me.C1TextBox1.Text = "" Or Me.C1TextBox2.Text = "" Then
            MessageBox.Show("Ο κωδικός χώρου και η Περιγραφή είναι υποχρεωτικά πεδία. Παρακαλώ συμπληρώστε.")
            Exit Sub
        End If

        If Me.C1NumericEdit1.Value = 0 Or Me.C1NumericEdit1.Value > 3 Then
            MessageBox.Show("Η σειρά μπορεί να είναι 1,2 ή 3. Παρακαλώ διορθώστε")
            Exit Sub
        End If

        Select Case Me.C1NumericEdit1.Value
            Case 1
                If Me.C1NumericEdit3.Value < 15 Or Me.C1NumericEdit3.Value > 117 Then
                    MessageBox.Show("Η σειρά 1 μπορεί να έχει Υ από 15 εώς 117. Παρακαλώ διορθώστε")
                    Exit Sub
                End If
            Case 2
                If Me.C1NumericEdit3.Value < 15 Or Me.C1NumericEdit3.Value > 170 Then
                    MessageBox.Show("Η σειρά 2 μπορεί να έχει Υ από 15 εώς 170. Παρακαλώ διορθώστε")
                    Exit Sub
                End If
            Case 3
                If Me.C1NumericEdit3.Value < 15 Or Me.C1NumericEdit3.Value > 106 Then
                    MessageBox.Show("Η σειρά 3 μπορεί να έχει Υ από 15 εώς 106. Παρακαλώ διορθώστε")
                    Exit Sub
                End If
            Case Else
                MessageBox.Show("Η σειρά μπορεί να είναι 1,2 ή 3. Παρακαλώ διορθώστε")
                Exit Sub
        End Select

        If Me.C1NumericEdit2.Value < 10 Or Me.C1NumericEdit2.Value > 980 Or Me.C1NumericEdit2.Value < 10 Or Me.C1NumericEdit2.Value > 980 Or Me.C1NumericEdit2.Value < 10 Or Me.C1NumericEdit2.Value > 980 Then
            MessageBox.Show("Οι σειρές μπορούν να έχουν X από 10 εώς 980. Παρακαλώ διορθώστε")
            Exit Sub
        End If

        SqlConnection1.Open()
        Try
            SqlCommand1.Parameters.Clear()
            With SqlCommand1
                .Parameters.AddWithValue("id", Me.C1TextBox1.Text)
                .Parameters.AddWithValue("descr", C1TextBox2.Text)
                .Parameters.AddWithValue("line", Me.C1NumericEdit1.Value)
                .Parameters.AddWithValue("x", Me.C1NumericEdit2.Value)
                .Parameters.AddWithValue("y", Me.C1NumericEdit3.Value)
            End With

            SqlCommand1.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
            Exit Sub
        Finally
            SqlConnection1.Close()
        End Try

        MessageBox.Show("Επιτυχής Καταχώριση.")
        start.places.DataTable.DataSet.Fill()
        load_plan()
        start.GroupBox1.Controls.RemoveByKey("test")
        start.GroupBox2.Controls.RemoveByKey("test")
        start.GroupBox3.Controls.RemoveByKey("test")
        Me.Close()
    End Sub

    Private Sub C1Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1Button2.Click
        start.GroupBox1.Controls.RemoveByKey("test")
        start.GroupBox2.Controls.RemoveByKey("test")
        start.GroupBox3.Controls.RemoveByKey("test")
        Me.Close()
    End Sub
End Class