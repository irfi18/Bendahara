Imports MySql.Data.MySqlClient

Public Class Pengurus
    Dim field As String = ""
    Dim hak_akses As String
    Sub getPengurus(ByVal usr As String)
        Call connection()
        Dim str As String
        str = "select * from pengurus where username = '" & usr & "'"
        cmd = New MySqlCommand(str, koneksi)
        dtr = cmd.ExecuteReader
        dtr.Read()
        If dtr.HasRows Then
            hak_akses = dtr.Item("jabatan")
        Else
        End If
        dtr.Close()
    End Sub
    Private Sub Pengurus_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tampilan(DataGridView1, "Pengurus")
        Me.ContextMenuStrip = ContextMenuStrip1
        getPengurus(user)
    End Sub
    Private Sub UbahToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UbahToolStripMenuItem.Click
        If hak_akses = "Ketua Umum" Or hak_akses = "Bendahara" Then
            Try
                With DataGridView1
                    InputPengurus.tbId.Text = .Item(0, .CurrentRow.Index).Value
                    InputPengurus.cbNim.Text = .Item(1, .CurrentRow.Index).Value
                    InputPengurus.tbNama.Text = .Item(2, .CurrentRow.Index).Value
                    InputPengurus.cbJurusan.Text = .Item(3, .CurrentRow.Index).Value
                    InputPengurus.tbUser.Text = .Item(4, .CurrentRow.Index).Value
                    InputPengurus.tbPassword.Text = .Item(5, .CurrentRow.Index).Value
                    InputPengurus.tbNohp.Text = .Item(6, .CurrentRow.Index).Value
                    InputPengurus.cbJabatan.Text = .Item(7, .CurrentRow.Index).Value
                    InputPengurus.cbNim.Enabled = False
                End With
                edit = True
                InputPengurus.Show()
            Catch ex As Exception
                MsgBox("error" & ex.Message)
            End Try
            Me.Close()
        Else
            MsgBox("Akses Ditolak")
            
        End If
    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        Dim query As String
        If hak_akses = "Ketua Umum" Or hak_akses = "Bendahara" Then
            Try
                With DataGridView1
                    query = "Delete From pengurus where id ='" & .Item(0, .CurrentRow.Index).Value & "'"
                End With
                cmd = New MySqlCommand(query, koneksi)
                cmd.ExecuteNonQuery()
                MsgBox("Berhasil dihapus")
                tampilan(DataGridView1, "pengurus")
            Catch ex As Exception
                MsgBox("error" & ex.Message)
            End Try
        Else
            MsgBox("Akses Ditolak")
        End If
    End Sub

    Private Sub cbKategori_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbKategori.SelectedIndexChanged
        field = cbKategori.SelectedItem.ToString
        If (field = "NIM") Then
            field = "nim"
        ElseIf (field = "Nama") Then
            field = "nama"
        ElseIf (field = "Jurusan") Then
            field = "jurusan"
        ElseIf (field = "Jabatan") Then
            field = "jabatan"
        End If
    End Sub

    Private Sub btnCari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCari.Click
        cari(DataGridView1, "pengurus", tbCari, field)
    End Sub

    Private Sub tbCari_TextChanged(sender As Object, e As EventArgs) Handles tbCari.TextChanged

    End Sub
End Class