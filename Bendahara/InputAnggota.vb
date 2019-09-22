Public Class InputAnggot

    Private Sub btnSimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSimpan.Click
        If (tbNim.Text = "" Or tbNama.Text = "" Or tbNohp.Text = "") Then
            MsgBox("Data Belum Lengkap")
        End If
        Try
            If edit = False Then
                crud("Insert into member value ('""','" & tbNim.Text & "','" & tbNama.Text & "','" & cbJurusan.SelectedItem & "','" & tbNohp.Text & "')")
                MsgBox("Berhasil disimpan")
            Else
                crud("Update member set nama='" & tbNama.Text & "',jurusan='" & cbJurusan.Text & "',noHp='" & tbNohp.Text & "' where id='" & tbId.Text & "'")
                MsgBox("Berhasil diubah")
            End If

        Catch ex As Exception
            MsgBox("error", ex.Message)
        End Try
        Anggota.Show()
        Me.Close()
    End Sub

    Private Sub btnBatal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBatal.Click
        Me.Close()
    End Sub

    Private Sub InputAnggot_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class