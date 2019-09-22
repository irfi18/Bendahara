Imports MySql.Data.MySqlClient

Public Class InputPengurus

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSimpan.Click
        If (cbNim.Text = "" Or tbPassword.Text = "" Or cbJabatan.SelectedItem = "" Or tbUser.Text = "") Then
            MsgBox("Data Belum Lengkap")
        Else
            Try
                If edit = False Then
                    crud("Insert into pengurus value ('""','" & cbNim.SelectedItem & "','" & tbNama.Text & "','" & cbJurusan.SelectedItem & "','" & tbUser.Text & "','" & tbPassword.Text & "','" & tbNohp.Text & "','" & cbJabatan.SelectedItem & "')")
                    MsgBox("Berhasil disimpan")
                Else
                    cbNim.Enabled = True
                    crud("Update pengurus set nama='" & tbNama.Text & "',jurusan='" & cbJurusan.Text & "',username ='" & tbUser.Text & "',noHp='" & tbNohp.Text & "',password='" & tbPassword.Text & "',jabatan='" & cbJabatan.Text & "' where id='" & tbId.Text & "'")
                    MsgBox("Berhasil diubah")
                End If
                Me.Close()
                cbJurusan.Enabled = True
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Sub ambilanggota()
        Try
            Dim str As String
            str = "select * from member"
            cmd = New MySqlCommand(str, koneksi)
            dtr = cmd.ExecuteReader

            If dtr.HasRows Then
                While dtr.Read
                    cbNim.Items.Add(dtr("nim"))
                End While
            End If
            dtr.Close()
        Catch ex As Exception
            MsgBox("error", ex.Message)
        End Try
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBatal.Click
        Me.Close()
    End Sub

    Private Sub cbNim_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbNim.SelectedIndexChanged
        Try
            Dim str As String
            str = "select * from member where nim = '" & cbNim.SelectedItem & "'"
            cmd = New MySqlCommand(str, koneksi)
            dtr = cmd.ExecuteReader
            dtr.Read()
            If dtr.HasRows Then
                tbNama.Text = dtr.Item("nama")
                cbJurusan.Text = dtr.Item("jurusan")
                tbNohp.Text = dtr.Item("noHp")
            End If
            dtr.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub InputPengurus_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ambilanggota()
    End Sub

    Private Sub cbJurusan_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbJurusan.SelectedIndexChanged

    End Sub
End Class