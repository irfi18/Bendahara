Imports MySql.Data.MySqlClient

Public Class InputPengeluaran

    Sub ambilPengurus(ByVal usr As String)
        Dim str As String
        str = "select * from pengurus where username = '" & usr & "'"
        cmd = New MySqlCommand(str, koneksi)
        dtr = cmd.ExecuteReader
        dtr.Read()
        If dtr.HasRows Then
            tbPengurus.Text = dtr.Item("nama")
            tbIdPengurus.Text = dtr.Item("id")

        Else
        End If
        dtr.Close()
    End Sub
    Private Sub Pengeluaran_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ambilPengurus(user)
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        If (tbKeterangan.Text = "" Or tbNominal.Text = "") Then
            MsgBox("Data Belum Lengkap")
        Else
            Try
                crud("Insert into pengeluaran value ('""','" & tbNominal.Text & "','" & Format(DtTanggal.Value, "yyyy-MM-dd") & "','" & tbKeterangan.Text & "','" & tbIdPengurus.Text & "')")
                MsgBox("Berhasil disimpan")
                Me.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Me.Close()
    End Sub
End Class